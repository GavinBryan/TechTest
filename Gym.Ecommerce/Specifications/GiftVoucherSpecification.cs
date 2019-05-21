using System;
using Gym.Ecommerce.Models;
using Gym.Ecommerce.Models.Exceptions;

namespace Gym.Ecommerce.Specifications
{
    public class GiftVoucherSpecification : VoucherSpecification
    {
        protected override Func<ShoppingCart, bool> Predicate()
        {
            return shoppingCart =>
            {
                // Ensure non-voucher items total > 0.
                var cartNonDiscountedPriceExcludingGiftVouchers =
                    shoppingCart.CartNonDiscountedPriceExcludingGiftVouchers();
                if (cartNonDiscountedPriceExcludingGiftVouchers <= 0)
                {
                    throw new GiftVoucherBasketTotalTooLowException(shoppingCart.CartNonDiscountedPriceExcludingGiftVouchers());
                }

                return true;
            };
        }
    }
}