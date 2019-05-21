using System;

namespace Gym.Ecommerce.Models.Exceptions
{
    public class OfferVoucherBasketTotalTooLowException : Exception
    {
        public decimal CartNonDiscountedPriceExcludingGiftVouchers { get; }
        public decimal MinimumSpend { get; }
        public decimal AmountToSpendStill => MinimumSpend - CartNonDiscountedPriceExcludingGiftVouchers;

        public OfferVoucherBasketTotalTooLowException(Decimal cartNonDiscountedPriceExcludingGiftVouchers, decimal minimumSpend) : base()
        {
            CartNonDiscountedPriceExcludingGiftVouchers = cartNonDiscountedPriceExcludingGiftVouchers;
            MinimumSpend = minimumSpend;
        }
    }
}