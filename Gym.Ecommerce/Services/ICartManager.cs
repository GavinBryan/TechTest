using System.Collections.Generic;
using Gym.Ecommerce.Models;
using Gym.Ecommerce.Models.Vouchers;

namespace Gym.Ecommerce.Services
{
    public interface ICartManager
    {
        ShoppingCart Cart { get; }
        void AddItems(List<ShoppingCartItem> cartItems);
        void AddItem(ShoppingCartItem cartItem);
        void ApplyVoucher(IVoucher voucher);
    }
}