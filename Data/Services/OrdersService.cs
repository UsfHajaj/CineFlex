using ETickets.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Data.Services
{
    public class OrdersService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrdersService(ApplicationDbContext context) 
        {
            this._context = context;
        }
        public async Task<List<Order>> GetOrdersByUserIDAndRoleAsync(string userID, string userRole)
        {
            var orders = await _context.Orders
                .Include(m => m.OrderItems)
                .ThenInclude(m => m.Movie)
                .Include(m => m.User)
                .ToListAsync();
            if(userRole!= "Admin")
            {
                orders=orders.Where(m=>m.UserID==userID).ToList();
            }
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userID, string userEmailAdress)
        {
            var order = new Order()
            {
                UserID=userID,
                Email=userEmailAdress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            foreach(var i in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount=i.Amount,
                    MovieID=i.ID,
                    OrderID=order.ID,
                    Price=i.Movie.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();

        }
    }
}
