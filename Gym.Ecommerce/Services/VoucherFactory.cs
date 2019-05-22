using System.Collections.Generic;
using Gym.Ecommerce.Helpers;
using Gym.Ecommerce.Models.Products;
using Gym.Ecommerce.Models.Vouchers;
using Gym.Ecommerce.Specifications;
using Gym.Ecommerce.Models.Vouchers.Apply;

namespace Gym.Ecommerce.Services
{
    public class VoucherFactory : IVoucherFactory
    {
        private Dictionary<VoucherFactoryType, IVoucher> _vouchers;
        private string _voucherCode;
        private string _voucherName;
        
        public IVoucher Create(VoucherFactoryType voucherFactoryType, string voucherCode, string voucherName)
        {
            _voucherCode = voucherCode;
            _voucherName = voucherName;
            
            _vouchers = new Dictionary<VoucherFactoryType, IVoucher>
            {
                { VoucherFactoryType.GiftVoucher5PoundsOff, GiftVoucher5PoundsOff },
                { VoucherFactoryType.OfferVoucher5PoundsOffBasketsOver50Pounds, OfferVoucher5PoundsOffBasketsOver50Pounds },
                { VoucherFactoryType.OfferVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly, OfferVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly },
            };

            Guard.AgainstInValidFactoryVoucherType(_vouchers, voucherFactoryType);

            return _vouchers[voucherFactoryType];
        }

        private IVoucher GiftVoucher5PoundsOff 
            => new GiftVoucher(_voucherCode, _voucherName, 5.00M, new GiftVoucherSpecification(), new GiftVoucherApplyToCartStratergy());

        private IVoucher OfferVoucher5PoundsOffBasketsOver50Pounds 
            => new OfferVoucher(_voucherCode, _voucherName, 5.00M, new OfferVoucherSpecification(minimumSpend: 50.01M), new OfferVoucherApplyToCartStratergy());
        
        private IVoucher OfferVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly 
            => new OfferVoucher(_voucherCode, _voucherName, 5.00M, new OfferVoucherSpecification(minimumSpend: 50.01M, productCategory: ProductCategory.HeadGear), new OfferVoucherApplyToProductCategoryStratergy(ProductCategory.HeadGear));
    }

    public interface IVoucherFactory
    {
        IVoucher Create(VoucherFactoryType voucherFactoryType, string code, string description);
    }
}
