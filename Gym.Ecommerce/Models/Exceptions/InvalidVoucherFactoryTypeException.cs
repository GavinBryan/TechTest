using System;

namespace Gym.Ecommerce.Models.Exceptions
{
    public class InvalidVoucherFactoryTypeException : Exception
    {
        public InvalidVoucherFactoryTypeException()
        {
        }

        public InvalidVoucherFactoryTypeException(string message) : base(message)
        {
        }
    }
}
