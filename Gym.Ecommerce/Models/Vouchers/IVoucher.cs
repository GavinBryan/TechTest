using System;

namespace Gym.Ecommerce.Models.Vouchers
{
    public interface IVoucher
    {
        string Code { get; }
        string Name { get; }
        Decimal Value { get; }
        bool CanBeAppliedToCart(ShoppingCart shoppingCart);
    }
}