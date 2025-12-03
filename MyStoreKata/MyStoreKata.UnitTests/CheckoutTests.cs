using MyStore.Domain;
using MyStoreKata.Services;

namespace MyStoreKata.UnitTests
{
    public class CheckoutTests
    {
        [Fact]
        public void Constructor_WithNullPricingRules_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Checkout(null));
        }

        [Fact]
        public void GetTotalPrice_NoItemsScanned_ReturnsZero()
        {
            var checkout = new Checkout(DefaultPricing.GetDefaultPricingRules());
           
            var totalPrice = checkout.GetTotalPrice();
            
            Assert.Equal(0, totalPrice);
        }

        [Fact]
        public void Scan_WithUnknownItem_ThrowsArgumentException()
        {
            var checkout = new Checkout(DefaultPricing.GetDefaultPricingRules());
            
            Assert.Throws<ArgumentException>(() => checkout.Scan("X"));
        }

        [Fact]
        public void Scan_WithNullOrEmptyItem_ThrowsArgumentException()
        {
            var checkout = new Checkout(DefaultPricing.GetDefaultPricingRules());
            
            Assert.Throws<ArgumentException>(() => checkout.Scan(null));
            Assert.Throws<ArgumentException>(() => checkout.Scan(string.Empty));
        }
    }
}
