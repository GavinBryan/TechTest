using System;
using Gym.Ecommerce.Models;

namespace Gym.Ecommerce.Specifications
{
    public abstract class VoucherSpecification
    {
        protected abstract Func<ShoppingCart, bool> Predicate();
        
        public bool VoucherCanBeApplied(ShoppingCart shoppingCart)
        {
            Func<ShoppingCart, bool> predicate = Predicate();
            return predicate(shoppingCart);
        }
    }
}
