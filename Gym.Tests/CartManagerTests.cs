using FluentAssertions;
using Gym.Ecommerce.Models;
using Gym.Ecommerce.Models.Products;
using Gym.Ecommerce.Models.Vouchers;
using Gym.Ecommerce.Services;
using NUnit.Framework;

namespace Gym.Tests
{
    [TestFixture]
    public class CartManagerTests
    {
        [TestCase]
        public void InitialisedCartShouldContainerNoVouchers()
        {
            // Arrange
            var cartManager = new CartManager();
            
            // Assert
            cartManager.Cart.Vouchers.Should().HaveCount(0);
        }
        
        [TestCase]
        public void InitialisedCartShouldContainerNoItems()
        {
            // Arrange
            var cartManager = new CartManager();
            
            // Assert
            cartManager.Cart.CartItems.Should().HaveCount(0);
        }

        [TestCase]
        public void AddNonGiftVoucherItemsToCartWithNoAppliedVouchers()
        {
            // Arrange
            var cartManager = new CartManager();
            var qty1 = 2;
            var price1 = 10.25M;
            var qty2 = 1;
            var price2 = 5.50M;
            var cartItem1 = new ShoppingCartItem(new Product(ProductCategory.Hat, "Hat"), qty1, price1);
            var cartItem2 = new ShoppingCartItem(new Product(ProductCategory.Jumper, "Jumper"), qty2, price2);
            
            // Act
            cartManager.AddItem(cartItem1);
            cartManager.AddItem(cartItem2);
            
            // Assert
            cartManager.Cart.CartItems.Should().HaveCount(2);
            cartManager.Cart.CartItems.Should().Contain(cartItem1);
            cartManager.Cart.CartItems.Should().Contain(cartItem2);
            cartManager.Cart.CartNonDiscountedPrice.Should().Be(( qty1 * price1) + (qty2 * price2));
            cartManager.Cart.CartDiscountValue.Should().Be(0.00M);
            cartManager.Cart.CartDiscountedPrice.Should().Be(( qty1 * price1) + (qty2 * price2));
            cartManager.Cart.ContainsOfferVoucher().Should().BeFalse();
            cartManager.Cart.ContainsGiftVoucher().Should().BeFalse();
            cartManager.Cart.ContainsGiftVoucherProducts().Should().BeFalse();
        }
    }
}