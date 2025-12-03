using System;
using System.Collections.Generic;
using System.Text;

namespace MyStoreKata.Services
{
    public interface ICheckout
    {
        void Scan(string item);

        int GetTotalPrice();
    }

    public class Checkout : ICheckout
    {
        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
            throw new NotImplementedException();
        }
    }

}
