using System;
using Gym.Ecommerce.Models.Products;

namespace Gym.Ecommerce.Models
{
    public class Product
    {
        public Product(ProductCategory productCategory, string description)
        {
            Id = Guid.NewGuid();
            ProductCategory = productCategory;
            Description = description;
        }

        public Guid Id { get; }
        public ProductCategory ProductCategory { get; }
        public string Description { get; }
    }
}
