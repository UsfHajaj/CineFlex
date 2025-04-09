using ETickets.Data.Cart;

namespace ETickets.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
        public double ShoppingCartAmount { get;set; }
    }
}
