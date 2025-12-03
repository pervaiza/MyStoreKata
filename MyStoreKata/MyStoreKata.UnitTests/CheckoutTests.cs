using MyStoreKata.Services;

namespace MyStoreKata.UnitTests
{
    public class CheckoutTests
    {
        [Fact]
        public void ThrowsNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => new Checkout().Scan("A"));
        }
    }
}
