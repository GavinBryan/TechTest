using Gym.Ecommerce.Models.Vouchers.Apply;
using Gym.Ecommerce.Specifications;

namespace Gym.Ecommerce.Models.Vouchers
{
    public class GiftVoucher : Voucher
    {
        public GiftVoucher(string code,
                            string name,
                            decimal value,
                            VoucherSpecification voucherSpecification,
                            VoucherApplyStrategy voucherApplyStrategy)
            : base(VoucherType.Gift, code, name, value, voucherSpecification, voucherApplyStrategy)
        {
        }
    }
}