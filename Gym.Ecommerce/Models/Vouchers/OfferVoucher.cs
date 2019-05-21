using Gym.Ecommerce.Specifications;

namespace Gym.Ecommerce.Models.Vouchers
{
    public class OfferVoucher : Voucher
    {
        public OfferVoucher(string code, string name, decimal value, VoucherSpecification voucherSpecification) 
            : base(code, name, value, voucherSpecification)
        {
        }
    }
}