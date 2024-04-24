using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public enum OrderStatus{Default,Ordered,Cancelled}
namespace SyncCart
{
    public class OrderDetails
    {
        //Field
        private static long s_orderID = 1000;//Auto Increment ID
        
        //Properties
        public string OrderID {get;}//Read-only property
        public string CustomerID{get;set;}
        public string ProductID{get;set;}
        public double TotalPrice{get;set;}
        public DateTime PurchaseDate{get;set;}
        public int Quantity {get;set;}
        public OrderStatus OrderStatus {get;set;}
        
        public OrderDetails(string customerID,string productId,double totalPrice,DateTime purchaseDate,int quantity,OrderStatus orderStatus)
        {
            OrderID = "OID"+(++s_orderID);
            CustomerID = customerID;
            ProductID = productId;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            Quantity = quantity;
            OrderStatus = orderStatus;
        }
    }
}