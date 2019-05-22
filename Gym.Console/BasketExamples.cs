using Gym.Ecommerce.Models;
using Gym.Ecommerce.Models.Products;
using Gym.Ecommerce.Models.Vouchers;
using Gym.Ecommerce.Services;

namespace Gym.Console
{
    public class BasketExamples
    {
        public CartManager Basket1()
        {
            var cartManager = new CartManager();
            var cartItem1 = new ShoppingCartItem(new Product(ProductCategory.Hat, "Hat"), 1, 10.50M);
            var cartItem2 = new ShoppingCartItem(new Product(ProductCategory.Jumper, "Jumper"), 1, 54.65M);
            var voucherFactory = new VoucherFactory();
            var giftVoucher5PoundsOff = voucherFactory.Create(VoucherFactoryType.GiftVoucher5PoundsOff, "XXX-XXX", "£5.00 Gift Voucher");

            cartManager.AddItem(cartItem1);
            cartManager.AddItem(cartItem2);
            cartManager.ApplyVoucher(giftVoucher5PoundsOff);

            return cartManager;
        }

        public CartManager Basket2()
        {
            var cartManager = new CartManager();
            var cartItem1 = new ShoppingCartItem(new Product(ProductCategory.Hat, "Hat"), 1, 25.00M);
            var cartItem2 = new ShoppingCartItem(new Product(ProductCategory.Jumper, "Jumper"), 1, 26.00M);
            var voucherFactory = new VoucherFactory();
            var offerVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly = voucherFactory.Create(VoucherFactoryType.OfferVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly, "YYY-YYY", "£5.00 off Head Gear in baskets over £50.00 Offer Voucher");
            
            cartManager.AddItem(cartItem1);
            cartManager.AddItem(cartItem2);
            cartManager.ApplyVoucher(offerVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly);

            return cartManager;
        }

        public CartManager Basket3()
        {
            var cartManager = new CartManager();
            var cartItem1 = new ShoppingCartItem(new Product(ProductCategory.Hat, "Hat"), 1, 25.00M);
            var cartItem2 = new ShoppingCartItem(new Product(ProductCategory.Jumper, "Jumper"), 1, 26.00M);
            var cartItem3 = new ShoppingCartItem(new Product(ProductCategory.HeadGear, "Head Light"), 1, 3.50M);
            var voucherFactory = new VoucherFactory();
            var offerVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly = voucherFactory.Create(VoucherFactoryType.OfferVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly, "YYY-YYY", "£5.00 off Head Gear in baskets over £50.00 Offer Voucher");
            
            cartManager.AddItem(cartItem1);
            cartManager.AddItem(cartItem2);
            cartManager.AddItem(cartItem3);
            cartManager.ApplyVoucher(offerVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly);

            return cartManager;
        }
        
        public CartManager Basket4()
        {
            var cartManager = new CartManager();
            var cartItem1 = new ShoppingCartItem(new Product(ProductCategory.Hat, "Hat"), 1, 25.00M);
            var cartItem2 = new ShoppingCartItem(new Product(ProductCategory.Jumper, "Jumper"), 1, 26.00M);
            var voucherFactory = new VoucherFactory();
            var giftVoucher5PoundsOff = voucherFactory.Create(VoucherFactoryType.GiftVoucher5PoundsOff, "XXX-XXX", "£5.00 Gift Voucher");
            var offerVoucher5PoundsOffBasketsOver50Pounds = voucherFactory.Create(VoucherFactoryType.OfferVoucher5PoundsOffBasketsOver50Pounds, "YYY-YYY", "£5.00 off baskets over £50.00 Offer Voucher");

            cartManager.AddItem(cartItem1);
            cartManager.AddItem(cartItem2);
            cartManager.ApplyVoucher(giftVoucher5PoundsOff);
            cartManager.ApplyVoucher(offerVoucher5PoundsOffBasketsOver50Pounds);

            return cartManager;
        }
        
        public CartManager Basket5()
        {
            var cartManager = new CartManager();
            var cartItem1 = new ShoppingCartItem(new Product(ProductCategory.Hat, "Hat"), 1, 25.00M);
            var cartItem2 = new ShoppingCartItem(new Product(ProductCategory.GiftVoucher, "£30 Gift Voucher"), 1, 30.00M);
            var voucherFactory = new VoucherFactory();
            var offerVoucher5PoundsOffBasketsOver50Pounds = voucherFactory.Create(VoucherFactoryType.OfferVoucher5PoundsOffBasketsOver50Pounds, "YYY-YYY", "£5 Off Baskets Over £50.00 Voucher");

            cartManager.AddItem(cartItem1);
            cartManager.AddItem(cartItem2);
            cartManager.ApplyVoucher(offerVoucher5PoundsOffBasketsOver50Pounds);

            return cartManager;
        }
    }
}