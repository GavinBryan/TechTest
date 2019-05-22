using Gym.Ecommerce.Helpers;
using Gym.Ecommerce.Models.Vouchers.Apply;

namespace Gym.Ecommerce.Models.Vouchers
{
    public class VoucherDecorator : IVoucher
    {
        public VoucherDecorator(IVoucher voucher)
        {
            Voucher = voucher;
        }

        protected IVoucher Voucher { get; }
        public VoucherType VoucherType => Voucher.VoucherType;
        public string Code => Voucher.Code;
        public string Name => Voucher.Name;
        public decimal Value => Voucher.Value;
        public VoucherApplyStrategy ApplyStrategy => Voucher.ApplyStrategy;

        public bool CanBeAppliedToCart(ShoppingCart shoppingCart)
        {
            Guard.AgainstNull(shoppingCart, nameof(shoppingCart));

            return Voucher.CanBeAppliedToCart(shoppingCart);
        }
    }
}
