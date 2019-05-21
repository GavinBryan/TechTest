using System;
using System.Collections.Generic;
using Gym.Ecommerce.Models;
using Gym.Ecommerce.Models.Exceptions;
using Gym.Ecommerce.Models.Vouchers;

namespace Gym.Ecommerce.Helpers
{
    public static class Guard
    {
        public static void AgainstNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void AgainstInValidFactoryVoucherType(Dictionary<VoucherFactoryType, IVoucher> vouchers, VoucherFactoryType voucherFactoryType)
        {
            Guard.AgainstNull(vouchers, nameof(vouchers));

            if (!vouchers.ContainsKey(voucherFactoryType))
            {
                throw new InvalidVoucherFactoryTypeException();
            }
        }
    }
}
