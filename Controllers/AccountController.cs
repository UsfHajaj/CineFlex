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
        public async Task<IActionResult> Login([Bind(Prefix = "Login")] AuthViewModel authVM)
        {
            if (!ModelState.IsValid)
                return View("Auth", authVM);

            var loginVM = authVM.Login;
            var user = await _userManager.FindByEmailAsync(loginVM.EmailAdress);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Movie");
                }
                TempData["Error"] = "Wrong Credentials, Please tryy again!";
                return View("Auth", authVM);
            }

            TempData["Error"] = "Wrong credentials. Please try again!";
            return View("Auth", authVM);
        }





        //public IActionResult Login()
        //{
        //    var respone = new LoginVM();
        //    return View(respone);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginVM loginVM)
        //{
        //    if (!ModelState.IsValid)
        //        return View(loginVM);

        //    var user = await _userManager.FindByEmailAsync(loginVM.EmailAdress);

        //    if (user != null)
        //    {
        //        var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);

        //        if (passwordCheck)
        //        {
        //            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Index", "Movies");
        //            }
        //        }
        //        TempData["Error"] = "Wrong Credentials, Please tryy again!";

        //        return View(loginVM);
        //    }

        //    TempData["Error"] = "Wrong Credentials, Please tryy again!";

        //    return View(loginVM);
        //}












        [HttpPost]
        public async Task<IActionResult> Register(AuthViewModel authVM)
        {
            if (!ModelState.IsValid)
                return View("Auth", authVM);

            var registerVM = authVM.Register;

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAdress);
            if (user != null)
            {
                TempData["Error"] = "This email is already used.";
                return View("Auth", authVM);
            }

            var newUser = new ApplicationUser
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAdress,
                UserName = registerVM.EmailAdress
            };

            var result = await _userManager.CreateAsync(newUser, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return View("Auth", authVM);
            }

            //await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            return RedirectToAction("Index", "Movie"); // أو عرض رسالة تسجيل مكتمل
        }


        //public IActionResult Register()
        //{
        //    var respone = new RegisterVM();
        //    return View(respone);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterVM registerVM)
        //{
        //    if (!ModelState.IsValid)
        //        return View(registerVM);

        //    var user = await _userManager.FindByEmailAsync(registerVM.EmailAdress);

        //    if (user != null)
        //    {
        //        ModelState.AddModelError("", "This Email is already used");

        //        return View(registerVM);
        //    }

        //    var newUser = new ApplicationUser()
        //    {
        //        FullName = registerVM.FullName,
        //        Email = registerVM.EmailAdress,
        //        UserName = registerVM.EmailAdress,
        //    };

        //    var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

        //    if (!newUserResponse.Succeeded)
        //    {
        //        foreach (var error in newUserResponse.Errors)
        //            ModelState.AddModelError("", error.Description);

        //            return View(registerVM);

        //    }

        //    return RedirectToAction("Index", "movie");



        //}
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movies");
        }












        //[HttpPost]
        //public async Task<IActionResult> Auth(AuthViewModel authVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (authVM.Login != null && !string.IsNullOrEmpty(authVM.Login.EmailAdress))
        //        {
        //            // تسجيل الدخول
        //            var user = await _userManager.FindByEmailAsync(authVM.Login.EmailAdress);
        //            if (user != null)
        //            {
        //                var result = await _signInManager.PasswordSignInAsync(user, authVM.Login.Password, false, false);
        //                if (result.Succeeded)
        //                {
        //                    return RedirectToAction("Index", "Movie");
        //                }
        //                ModelState.AddModelError("", "Invalid login attempt.");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "Email not found.");
        //            }
        //        }

        //        if (authVM.Register != null && !string.IsNullOrEmpty(authVM.Register.EmailAdress))
        //        {
        //            // تسجيل جديد
        //            var user = await _userManager.FindByEmailAsync(authVM.Register.EmailAdress);
        //            if (user != null)
        //            {
        //                ModelState.AddModelError("", "This Email is already used.");
        //            }
        //            else
        //            {
        //                var newUser = new ApplicationUser()
        //                {
        //                    FullName = authVM.Register.FullName,
        //                    Email = authVM.Register.EmailAdress,
        //                    UserName = authVM.Register.EmailAdress,
        //                };

        //                var result = await _userManager.CreateAsync(newUser, authVM.Register.Password);
        //                if (result.Succeeded)
        //                {
        //                    return RedirectToAction("Index", "Movie");
        //                }
        //                else
        //                {
        //                    foreach (var error in result.Errors)
        //                    {
        //                        ModelState.AddModelError("", error.Description);
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    return View(authVM);
        //}












    }
}
