using ETickets.Data;
using ETickets.Data.Static;
using ETickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ETickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(ApplicationDbContext context,UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users); 
        }

        public IActionResult Auth()
        {
            var response = new AuthViewModel();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                var model = new AuthViewModel
                {
                    Login = loginVM,
                    Register = new RegisterVM(),

                };
                return View("Auth", model);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAdress);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);

                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movie");
                    }
                }
                ModelState.AddModelError("", "Wrong Credentials, Please try again!");
            }
            else
            {
                ModelState.AddModelError("", "Wrong Credentials, Please try again!");
            }

            var failModel = new AuthViewModel
            {
                Login = loginVM,
                Register = new RegisterVM(),
                
            };

            return View("Auth", failModel);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                var model = new AuthViewModel
                {
                    Login = new LoginVM(),
                    Register = registerVM,

                };
                return View("Auth", model);
            }

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAdress);

            if (user != null)
            {
                ModelState.AddModelError("", "This email is already used");

                var model = new AuthViewModel
                {
                    Login = new LoginVM(),
                    Register = registerVM,

                };
                return View("Auth", model);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAdress,
                UserName = registerVM.EmailAdress,
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (!newUserResponse.Succeeded)
            {
                foreach (var error in newUserResponse.Errors)
                    ModelState.AddModelError("", error.Description);

                var model = new AuthViewModel
                {
                    Login = new LoginVM(),
                    Register = registerVM,
                    
                };
                return View("Auth", model);
            }

            await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            await _signInManager.SignInAsync(newUser, isPersistent: registerVM.RememberMe);
            return RedirectToAction("Index", "Movie");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Auth", "Account");
        }
    }
}
