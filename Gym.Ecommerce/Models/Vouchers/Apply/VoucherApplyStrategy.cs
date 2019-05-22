namespace Gym.Ecommerce.Models.Vouchers.Apply
{
    public abstract class VoucherApplyStrategy
    {
        public abstract void Apply(ShoppingCart cart, VoucherAppliedDecorator voucher);
    }
}
