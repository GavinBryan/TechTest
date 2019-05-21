using FluentAssertions;
using Gym.Ecommerce.Models;
using Gym.Ecommerce.Models.Products;
using Gym.Ecommerce.Models.Vouchers;
using Gym.Ecommerce.Services;
using NUnit.Framework;

namespace Gym.Tests
{
    [TestFixture]
    public class BasketScenarioTests
    {
        [Test(Description="Basket 1")]
        public void Basket1Scenario()
        {
            // Arrange
            var cartManager = new CartManager();
            var cartItem1 = new ShoppingCartItem(new Product(ProductCategory.Hat, "Hat"), 1, 10.50M);
            var cartItem2 = new ShoppingCartItem(new Product(ProductCategory.Jumper, "Jumper"), 1, 54.65M);
            var voucherFactory = new VoucherFactory();
            var giftVoucher5PoundsOff = voucherFactory.Create(VoucherFactoryType.GiftVoucher5PoundsOff, "XXX-XXX", "£5.00 Gift Voucher");
            
            // Act
            cartManager.AddItem(cartItem1);
            cartManager.AddItem(cartItem2);
            cartManager.ApplyVoucher(giftVoucher5PoundsOff);
            
            // Assert
            cartManager.Cart.CartItems.Should().HaveCount(2);
            cartManager.Cart.CartItems.Should().Contain(cartItem1);
            cartManager.Cart.CartItems.Should().Contain(cartItem2);
            cartManager.Cart.CartNonDiscountedPrice.Should().Be(65.15M);
            cartManager.Cart.CartDiscountValue.Should().Be(5.00M);
            cartManager.Cart.CartDiscountedPrice.Should().Be(60.15M);
            cartManager.Cart.ContainsOfferVoucher().Should().BeFalse();
            cartManager.Cart.ContainsGiftVoucher().Should().BeTrue();
            cartManager.Cart.ContainsGiftVoucherProducts().Should().BeFalse();
        }

        [Test(Description="Basket 2")]
        public void Basket2Scenario()
        {
            // Arrange
            var cartManager = new CartManager();
            var cartItem1 = new ShoppingCartItem(new Product(ProductCategory.Hat, "Hat"), 1, 25.00M);
            var cartItem2 = new ShoppingCartItem(new Product(ProductCategory.Jumper, "Jumper"), 1, 26.00M);
            var voucherFactory = new VoucherFactory();
            var offerVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly = voucherFactory.Create(VoucherFactoryType.OfferVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly, "YYY-YYY", "£5.00 off Head Gear in baskets over £50.00 Offer Voucher");
            
            // Act
            cartManager.AddItem(cartItem1);
            cartManager.AddItem(cartItem2);
            cartManager.ApplyVoucher(offerVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly);
            
            // Assert
            cartManager.Cart.CartItems.Should().HaveCount(2);
            cartManager.Cart.CartItems.Should().Contain(cartItem1);
            cartManager.Cart.CartItems.Should().Contain(cartItem2);
            cartManager.Cart.CartNonDiscountedPrice.Should().Be(51.00M);
            cartManager.Cart.CartDiscountValue.Should().Be(0.00M);
            cartManager.Cart.CartDiscountedPrice.Should().Be(51.00M);
            cartManager.Cart.ContainsOfferVoucher().Should().BeFalse();
            cartManager.Cart.ContainsGiftVoucher().Should().BeFalse();
            cartManager.Cart.ContainsGiftVoucherProducts().Should().BeFalse();
            cartManager.Cart.Message.Should().Be("There are no products in your basket applicable to Voucher YYY-YYY .");
        }
        
        [Test(Description="Basket 3")]
        public void Basket3Scenario()
        {
            // Arrange
            var cartManager = new CartManager();
            var cartItem1 = new ShoppingCartItem(new Product(ProductCategory.Hat, "Hat"), 1, 25.00M);
            var cartItem2 = new ShoppingCartItem(new Product(ProductCategory.Jumper, "Jumper"), 1, 26.00M);
            var cartItem3 = new ShoppingCartItem(new Product(ProductCategory.HeadGear, "Head Light"), 1, 3.50M);
            var voucherFactory = new VoucherFactory();
            var offerVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly = voucherFactory.Create(VoucherFactoryType.OfferVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly, "YYY-YYY", "£5.00 off Head Gear in baskets over £50.00 Offer Voucher");
            
            // Act
            cartManager.AddItem(cartItem1);
            cartManager.AddItem(cartItem2);
            cartManager.AddItem(cartItem3);
            cartManager.ApplyVoucher(offerVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly);
            
            // Assert
            cartManager.Cart.CartItems.Should().HaveCount(3);
            cartManager.Cart.CartItems.Should().Contain(cartItem1);
            cartManager.Cart.CartItems.Should().Contain(cartItem2);
            cartManager.Cart.CartItems.Should().Contain(cartItem3);
            cartManager.Cart.CartNonDiscountedPrice.Should().Be(54.50M);
            cartManager.Cart.CartDiscountValue.Should().Be(5.00M);
            cartManager.Cart.CartDiscountedPrice.Should().Be(49.50M);
            cartManager.Cart.ContainsOfferVoucher().Should().BeTrue();
            cartManager.Cart.ContainsGiftVoucher().Should().BeFalse();
            cartManager.Cart.ContainsGiftVoucherProducts().Should().BeFalse();
        }   
        
        [Test(Description="Basket 4")]
        public void Basket4Scenario()
        {
            // Arrange
            var cartManager = new CartManager();
            var cartItem1 = new ShoppingCartItem(new Product(ProductCategory.Hat, "Hat"), 1, 25.00M);
            var cartItem2 = new ShoppingCartItem(new Product(ProductCategory.Jumper, "Jumper"), 1, 26.00M);
            var voucherFactory = new VoucherFactory();
            var giftVoucher5PoundsOff = voucherFactory.Create(VoucherFactoryType.GiftVoucher5PoundsOff, "XXX-XXX", "£5.00 Gift Voucher");
            var offerVoucher5PoundsOffBasketsOver50Pounds = voucherFactory.Create(VoucherFactoryType.OfferVoucher5PoundsOffBasketsOver50Pounds, "YYY-YYY", "£5.00 off baskets over £50.00 Offer Voucher");

            // Act
            cartManager.AddItem(cartItem1);
            cartManager.AddItem(cartItem2);
            cartManager.ApplyVoucher(giftVoucher5PoundsOff);
            cartManager.ApplyVoucher(offerVoucher5PoundsOffBasketsOver50Pounds);
            
            // Assert
            cartManager.Cart.CartItems.Should().HaveCount(2);
            cartManager.Cart.CartItems.Should().Contain(cartItem1);
            cartManager.Cart.CartItems.Should().Contain(cartItem2);
            cartManager.Cart.CartNonDiscountedPrice.Should().Be(51.00M);
            cartManager.Cart.CartDiscountValue.Should().Be(10.00M);
            cartManager.Cart.CartDiscountedPrice.Should().Be(41.00M);
            cartManager.Cart.ContainsOfferVoucher().Should().BeTrue();
            cartManager.Cart.ContainsGiftVoucher().Should().BeTrue();
            cartManager.Cart.ContainsGiftVoucherProducts().Should().BeFalse();
        }    
        
        [Test(Description="Basket 5")]
        public void Basket5Scenario()
        {
            // Arrange
            var cartManager = new CartManager();
            var cartItem1 = new ShoppingCartItem(new Product(ProductCategory.Hat, "Hat"), 1, 25.00M);
            var cartItem2 = new ShoppingCartItem(new Product(ProductCategory.GiftVoucher, "£30 Gift Voucher"), 1, 30.00M);
            var voucherFactory = new VoucherFactory();
            var offerVoucher5PoundsOffBasketsOver50Pounds = voucherFactory.Create(VoucherFactoryType.OfferVoucher5PoundsOffBasketsOver50Pounds, "YYY-YYY", "£5 Off Baskets Over £50.00 Voucher");

            // Act
            cartManager.AddItem(cartItem1);
            cartManager.AddItem(cartItem2);
            cartManager.ApplyVoucher(offerVoucher5PoundsOffBasketsOver50Pounds);
            
            // Assert
            cartManager.Cart.CartItems.Should().HaveCount(2);
            cartManager.Cart.CartItems.Should().Contain(cartItem1);
            cartManager.Cart.CartItems.Should().Contain(cartItem2);
            cartManager.Cart.CartNonDiscountedPrice.Should().Be(55.00M);
            cartManager.Cart.CartDiscountValue.Should().Be(0.00M);
            cartManager.Cart.CartDiscountedPrice.Should().Be(55.00M);
            cartManager.Cart.ContainsOfferVoucher().Should().BeFalse();
            cartManager.Cart.ContainsGiftVoucher().Should().BeFalse();
            cartManager.Cart.ContainsGiftVoucherProducts().Should().BeTrue();
            cartManager.Cart.Message.Should().Be("You have not reached the spend threshold for voucher YYY-YYY. Spend another £25.01 to receive £5.00 discount from your basket total.");
        }         
    }
}