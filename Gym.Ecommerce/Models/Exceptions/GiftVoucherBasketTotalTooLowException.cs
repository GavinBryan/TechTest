using System;

namespace Gym.Ecommerce.Models.Exceptions
{
    public class GiftVoucherBasketTotalTooLowException : Exception
    {
        public decimal CartNonDiscountedPriceExcludingGiftVouchers { get; }

        public GiftVoucherBasketTotalTooLowException(Decimal cartNonDiscountedPriceExcludingGiftVouchers) : base()
        {
            CartNonDiscountedPriceExcludingGiftVouchers = cartNonDiscountedPriceExcludingGiftVouchers;
        }
    }
}