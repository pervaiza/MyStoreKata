using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Domain
{
    public class PricingRule
    {
        public string Sku { get; set; }

        public int UnitPrice { get; set; }

        public SpecialOffer SpecialOffer { get; set; }
    }
}
