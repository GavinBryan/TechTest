using Gym.Ecommerce.Models.Products;

namespace Gym.Ecommerce.Models.Vouchers.Apply
{
    public class OfferVoucherApplyToProductCategoryStratergy : VoucherApplyStrategy
    {
        private readonly ProductCategory _productCategory;

        public OfferVoucherApplyToProductCategoryStratergy(ProductCategory productCategory)
        {
            _productCategory = productCategory;
        }

        public override void Apply(ShoppingCart cart, VoucherAppliedDecorator voucher)
        {
            var cartProductCategoryValue = cart.CartProductCategoryTotal(_productCategory);
            voucher.AppliedValue = (cartProductCategoryValue >= voucher.Value)
                                ? voucher.Value
                                : cartProductCategoryValue;
        }
    }
}
