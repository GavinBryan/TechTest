using Gym.Ecommerce.Services;
using NUnit.Framework;
using FluentAssertions;
using Gym.Ecommerce.Models.Exceptions;
using System;
using Gym.Ecommerce.Models.Vouchers;

namespace Gym.Tests
{
    [TestFixture()]
    public class VoucherFactoryTests
    {
        [TestCase]
        public void GiftVoucher5PoundsOffIsCreated()
        {
            // Arrange
            var factory = new VoucherFactory();

            // Act
            var voucherCreated = factory.Create(VoucherFactoryType.GiftVoucher5PoundsOff, string.Empty, String.Empty);

            // Assert
            voucherCreated.Should().BeOfType<GiftVoucher>();
            ((GiftVoucher) voucherCreated).Value.Should().Be(5.00M);
        }
        
        [TestCase]
        public void OfferVoucher5PoundsOffBasketsOver50PoundsIsCreated()
        {
            // Arrange
            var factory = new VoucherFactory();

            // Act
            var voucherCreated = factory.Create(VoucherFactoryType.OfferVoucher5PoundsOffBasketsOver50Pounds,string.Empty, String.Empty);

            // Assert
            voucherCreated.Should().BeOfType<OfferVoucher>();
            ((OfferVoucher) voucherCreated).Value.Should().Be(5.00M);
        }

        [TestCase]
        public void OfferVoucher5PoundsOffBasketsOver50PoundsHeadGearOnlyIsCreated()
        {
            // Arrange
            var factory = new VoucherFactory();

            // Act
            var voucherCreated = factory.Create(VoucherFactoryType.OfferVoucher5PoundsOffBasketsOver50PoundsHeadGearOnly,string.Empty, String.Empty);

            // Assert
            voucherCreated.Should().BeOfType<OfferVoucher>();
            ((OfferVoucher) voucherCreated).Value.Should().Be(5.00M);
        }
        
        [TestCase]
        public void NonImplementedVoucherFactoryTypeRaisesException()
        {
            // Arrange
            var factory = new VoucherFactory();
            Action action = () => factory.Create(VoucherFactoryType.GiftVoucher10PoundsOff,string.Empty, String.Empty);

            // Assert
            Assert.Throws<InvalidVoucherFactoryTypeException>(action.Invoke);
        }
    }
}
