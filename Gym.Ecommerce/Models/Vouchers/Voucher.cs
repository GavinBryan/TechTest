using Gym.Ecommerce.Specifications;

namespace Gym.Ecommerce.Models.Vouchers
{
    public class Voucher : IVoucher
    {
        private readonly VoucherSpecification _voucherSpecification;

        public Voucher(string code, string name, decimal value, VoucherSpecification voucherSpecification)
        {
            Code = code;
            Name = name;
            Value = value;
            _voucherSpecification = voucherSpecification;
        }

        public string Code { get; }
        public string Name { get; }
        public decimal Value { get; private set; }
        public bool CanBeAppliedToCart(ShoppingCart shoppingCart) => _voucherSpecification.VoucherCanBeApplied(shoppingCart);
    }
}
