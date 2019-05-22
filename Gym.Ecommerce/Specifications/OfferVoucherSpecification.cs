using System;
using System.Linq;
using Gym.Ecommerce.Models;
using Gym.Ecommerce.Models.Exceptions;
using Gym.Ecommerce.Models.Products;

namespace Gym.Ecommerce.Specifications
{
    public class OfferVoucherSpecification : VoucherSpecification
    {
        private readonly decimal _minimumSpend;

        public OfferVoucherSpecification(decimal minimumSpend, ProductCategory? productCategory = null)
        {
            _minimumSpend = minimumSpend;
            ProductCategory = productCategory;
        }

        public ProductCategory? ProductCategory { get; }

        protected override Func<ShoppingCart, bool> Predicate()
        {
            return shoppingCart =>
            {
                // Ensure non-voucher items total matches minimum spend set in voucher.
                var cartNonDiscountedPriceExcludingGiftVouchers = shoppingCart.CartNonDiscountedPriceExcludingGiftVouchers();
                if (cartNonDiscountedPriceExcludingGiftVouchers < _minimumSpend)
                {
                    throw new OfferVoucherBasketTotalTooLowException(shoppingCart.CartNonDiscountedPriceExcludingGiftVouchers(), _minimumSpend);
                }

                // Can't apply offer voucher if one is already applied to this cart.
                if (shoppingCart.ContainsOfferVoucher())
                {
                    return false;
                }
                
                // Can only apply vouchers to certain product categories if the voucher has those defined.
                if (!(ProductCategory != null && shoppingCart.CartItems.Any(x => x.Product.ProductCategory == ProductCategory) || ProductCategory == null))
                {
                    throw new VoucherDoesNotContainProductCategoryException();
                }

                return true;
            };
        }
    }
}
