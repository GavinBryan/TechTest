using Gym.Ecommerce.Specifications;

namespace Gym.Ecommerce.Models.Vouchers
{
    public class GiftVoucher : Voucher
    {
        public GiftVoucher(string code, string name, decimal value, VoucherSpecification voucherSpecification)
            : base(code, name, value, voucherSpecification)
        {
        }
    }
}