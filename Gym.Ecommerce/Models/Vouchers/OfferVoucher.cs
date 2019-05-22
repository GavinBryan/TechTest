using Gym.Ecommerce.Specifications;
using Gym.Ecommerce.Models.Vouchers.Apply;

namespace Gym.Ecommerce.Models.Vouchers
{
    public class OfferVoucher : Voucher
    {
        public OfferVoucher(string code, 
                            string name, 
                            decimal value, 
                            VoucherSpecification voucherSpecification, 
                            VoucherApplyStrategy voucherApplyStrategy) 
            : base(VoucherType.Offer, code, name, value, voucherSpecification, voucherApplyStrategy)
        {
        }
    }
}