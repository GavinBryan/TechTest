namespace Gym.Ecommerce.Models.Vouchers.Apply
{
    public class VoucherAppliedDecorator : VoucherDecorator
    {
        public VoucherAppliedDecorator(IVoucher voucher) : base(voucher)
        {
        }

        public decimal AppliedValue { get; set; }

        public void Apply(ShoppingCart cart)
        {
            ApplyStrategy.Apply(cart, this);
        }
    }
}
