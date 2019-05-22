using System;
using System.Collections.Generic;
using Gym.Ecommerce.Models;
using Gym.Ecommerce.Models.Exceptions;
using Gym.Ecommerce.Models.Vouchers;
using Gym.Ecommerce.Models.Vouchers.Apply;

namespace Gym.Ecommerce.Services
{
    public class CartManager : ICartManager
    {
        public CartManager()
        {
            Cart = new ShoppingCart(); 
        }
        
        public ShoppingCart Cart { get; private set; }
        public string Status { get; private set; } = string.Empty;

        public void AddItems(List<ShoppingCartItem> cartItems)
        {
            cartItems.ForEach(AddItem);
        }
        
        public void AddItem(ShoppingCartItem cartItem)
        {
            Cart.CartItems.Add(cartItem);
        }

        public void ApplyVoucher(IVoucher voucher)
        {
            try
            {
                if (!voucher.CanBeAppliedToCart(Cart))
                {
                    return;
                }

                var appliedVoucher = new VoucherAppliedDecorator(voucher);
                appliedVoucher.Apply(Cart);

                Cart.Vouchers.Add(appliedVoucher);
            }
            catch (OfferVoucherBasketTotalTooLowException exception)
            {
                Cart.Message =
                    $"You have not reached the spend threshold for voucher {voucher.Code}. Spend another £{exception.AmountToSpendStill} to receive £{voucher.Value} discount from your basket total.";
            }
            catch (VoucherDoesNotContainProductCategoryException exception)
            {
                Cart.Message = $"There are no products in your basket applicable to Voucher {voucher.Code} .";
            }
            catch (GiftVoucherBasketTotalTooLowException exception)
            {
                Cart.Message = $"There are no items in your basket applicable to Voucher {voucher.Code} .";
            }
            catch (Exception exception)
            {
            }
        }
    }
}
