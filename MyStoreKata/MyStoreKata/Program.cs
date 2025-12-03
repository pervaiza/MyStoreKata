
using MyStore.Domain;
using MyStoreKata.Services;


var checkout = new Checkout(DefaultPricing.GetDefaultPricingRules());

var myBasket = new[] { "A", "A", "A", "B", "B", "C" };

foreach (var item in myBasket)
{
    checkout.Scan(item);
}

var totalPrice = checkout.GetTotalPrice();

Console.WriteLine("Items in your basket: " + string.Join(", ", myBasket));
Console.WriteLine($"Mr. Bob, the total amount due: {totalPrice}");