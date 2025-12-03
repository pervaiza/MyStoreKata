using System;
using System.Collections.Generic;
using System.Text;
using MyStore.Domain;
namespace MyStoreKata.Services
{
    public interface ICheckout
    {
        void Scan(string item);

        int GetTotalPrice();
    }

    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, PricingRule> _pricingRules;
        private readonly Dictionary<string, int> _scannedItems;

        public Checkout(IEnumerable<PricingRule> pricingRules)
        {
            if (pricingRules == null)
                throw new ArgumentNullException(nameof(pricingRules));

            _pricingRules = pricingRules.ToDictionary(rule => rule.Sku, rule => rule);

            _scannedItems = new Dictionary<string, int>();
        }

        public void Scan(string item)
        {
            if (string.IsNullOrWhiteSpace(item))
                throw new ArgumentException("Item cannot be null or empty", nameof(item));

            if (!_pricingRules.ContainsKey(item))
                throw new ArgumentException($"Unknown item: {item}", nameof(item));

            if (_scannedItems.ContainsKey(item))
                _scannedItems[item]++;
            else
                _scannedItems[item] = 1;
        }

        public int GetTotalPrice()
        {
            int total = 0;

            foreach (var scannedItem in _scannedItems)
            {
                string sku = scannedItem.Key;
                int quantity = scannedItem.Value;

                var pricingRule = _pricingRules[sku];

                total += CalculatePrice(pricingRule, quantity);
            }

            return total;
        }

        private int CalculatePrice(PricingRule pricingRule, int quantity)
        {
            if (pricingRule.SpecialOffer == null)
            {
                return pricingRule.UnitPrice * quantity;
            }

            int specialOfferQuantity = pricingRule.SpecialOffer.Quantity;
            int specialOfferPrice = pricingRule.SpecialOffer.Price;

            int numberOfSpecialOffers = quantity / specialOfferQuantity;
            int remainingItems = quantity % specialOfferQuantity;

            int specialOfferTotal = numberOfSpecialOffers * specialOfferPrice;
            int regularPriceTotal = remainingItems * pricingRule.UnitPrice;

            return specialOfferTotal + regularPriceTotal;
        }
    }

}
