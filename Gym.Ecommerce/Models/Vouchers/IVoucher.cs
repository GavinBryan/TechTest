using System;
using Gym.Ecommerce.Models.Vouchers.Apply;

namespace Gym.Ecommerce.Models.Vouchers
{
    public interface IVoucher
    {
        VoucherType VoucherType { get; }
        string Code { get; }
        string Name { get; }
        Decimal Value { get; }
        VoucherApplyStrategy ApplyStrategy { get; }
        bool CanBeAppliedToCart(ShoppingCart shoppingCart);
    }
}