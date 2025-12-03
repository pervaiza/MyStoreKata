using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Domain
{
    public class DefaultPricing
    {
        public static IEnumerable<PricingRule> GetDefaultPricingRules()
        {
            return new List<PricingRule>
            {
                new PricingRule
                {
                    Sku = "A",
                    UnitPrice = 50,
                    SpecialOffer = new SpecialOffer { Quantity = 3, Price = 130 }
                },
                new PricingRule
                {
                    Sku = "B",
                    UnitPrice = 30,
                    SpecialOffer = new SpecialOffer { Quantity = 2, Price = 45 }
                },
                new PricingRule
                {
                    Sku = "C",
                    UnitPrice = 20
                },
                new PricingRule
                {
                    Sku = "D",
                    UnitPrice = 15
                }
            };
        }
    }
}
