using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public class ProductDetails
    {
        //Fields
        private static int s_productID = 100;//Auto-Increment

        //Properties
        public string ProductID{get;}//Read-only property
        public string ProductName{get;set;}
        public double Price{get;set;}
        public int Stock {get;set;}
        public int ShippingDuration{get;set;}

        //Constructor
        public ProductDetails(string productName,int stock,double price,int shippingDuration)
        {
            ProductID = "PID"+(++s_productID);
            ProductName = productName;
            Price = price;
            Stock =stock;
            ShippingDuration =shippingDuration;
        }
    }
}