using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Ecommerce.Models.Products;
using Gym.Ecommerce.Models.Vouchers;
using Gym.Ecommerce.Models.Vouchers.Apply;

namespace Gym.Ecommerce.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Created = DateTime.UtcNow;
            CartId = Guid.NewGuid();
            CartItems = new List<ShoppingCartItem>();
            Vouchers = new List<VoucherAppliedDecorator>();
        }

        public Guid CartId { get; private set; }
        public DateTime Created { get; private set; }
        public List<ShoppingCartItem> CartItems { get; private set; }
        public decimal CartNonDiscountedPrice => CartItems.Sum(x => x.UnitPrice * x.Qty);
        public decimal CartDiscountValue => Vouchers.Sum(x => x.AppliedValue);
        public decimal CartDiscountedPrice => CartNonDiscountedPrice - CartDiscountValue;
        public List<VoucherAppliedDecorator> Vouchers { get; private set; }
        public string Message { get; set; }

        public string Display
        {
            get
            {
                var cartItemDetails = String.Join("\n", CartItems.Select(x => $"{x.Qty} {x.Product.Description} @ £{x.UnitPrice}"));
                var voucherDetails = String.Join("\n", Vouchers.Select(v => $"1 x {v.Name} {v.Code} applied"));
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(cartItemDetails);
                sb.AppendLine("--------------");
                sb.AppendLine(voucherDetails);
                sb.AppendLine("--------------");
                sb.AppendLine($"Total: £{CartDiscountedPrice}");
                if (!string.IsNullOrEmpty(Message))
                {
                    sb.AppendLine($"Message: {Message}");
                }

                return sb.ToString();
            }
        }

        public bool ContainsOfferVoucher()
            => Vouchers.Any(x => x.VoucherType == VoucherType.Offer);

        public bool ContainsGiftVoucher()
            => Vouchers.Any(x => x.VoucherType == VoucherType.Gift);

        public bool ContainsGiftVoucherProducts()
            => CartItems.Any(x => x.Product.ProductCategory == ProductCategory.GiftVoucher);

        public decimal CartNonDiscountedPriceExcludingGiftVouchers() =>
            CartItems.Where(y => y.Product.ProductCategory != ProductCategory.GiftVoucher)
                .Sum(x => x.UnitPrice * x.Qty);

        public decimal CartProductCategoryTotal(ProductCategory productCategory) =>
            CartItems.Where(y => y.Product.ProductCategory == productCategory)
                .Sum(x => x.UnitPrice * x.Qty);
    }
}