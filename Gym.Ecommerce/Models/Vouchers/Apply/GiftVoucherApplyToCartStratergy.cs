namespace Gym.Ecommerce.Models.Vouchers.Apply
{
    public class GiftVoucherApplyToCartStratergy : VoucherApplyStrategy
    {
        public override void Apply(ShoppingCart cart, VoucherAppliedDecorator voucher)
        {
            voucher.AppliedValue = (cart.CartNonDiscountedPriceExcludingGiftVouchers() >= voucher.Value)
                            ? voucher.Value
                            : cart.CartNonDiscountedPriceExcludingGiftVouchers();
        }
    }
}
