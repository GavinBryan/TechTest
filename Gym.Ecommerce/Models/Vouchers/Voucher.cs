using Gym.Ecommerce.Models.Vouchers.Apply;
using Gym.Ecommerce.Specifications;

namespace Gym.Ecommerce.Models.Vouchers
{
    public class Voucher : IVoucher
    {
        public Voucher(VoucherType voucherType,
                       string code, 
                       string name, 
                       decimal value, 
                       VoucherSpecification voucherSpecification,
                       VoucherApplyStrategy applyStrategy)
        {
            VoucherType = voucherType;
            Code = code;
            Name = name;
            Value = value;
            VoucherSpecification = voucherSpecification;
            ApplyStrategy = applyStrategy;
        }

        public VoucherType VoucherType { get; }
        public string Code { get; }
        public string Name { get; }
        public decimal Value { get; private set; }
        public VoucherSpecification VoucherSpecification { get; }
        public VoucherApplyStrategy ApplyStrategy { get; }
        public bool CanBeAppliedToCart(ShoppingCart shoppingCart) => VoucherSpecification.VoucherCanBeApplied(shoppingCart);
    }
}
