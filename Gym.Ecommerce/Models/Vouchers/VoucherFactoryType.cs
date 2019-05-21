namespace Gym.Ecommerce.Models.Vouchers
{
    // Wouldn't normally hard code behaviour logic into enum name but just for clarity.
    public enum VoucherFactoryType
    {
        OfferVoucher5PoundsOffBasketsOver50Pounds,
        OfferVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly,
        GiftVoucher5PoundsOff,
        //Not implemented in VoucherFactory.Create() but using as a test to test guard clause works.
        GiftVoucher10PoundsOff
    }
}
