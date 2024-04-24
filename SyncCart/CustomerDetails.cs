using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public class CustomerDetails
    {
        //Fields
        private static int s_customerID = 1000;//Auto Increment ID

        //Properties

        public string CustomerID {get;}
        public string CustomerName{get;set;}
        public string City{get;set;}
        public string MobileNumber{get;set;}
        public double WalletBalance{get;set;}
        public string EmailID{get;set;}

        public CustomerDetails(string customerName,string city,string mobileNumber,double walletBalance,string emailID)
        {
            CustomerID = "CID"+(++s_customerID);
            CustomerName =customerName;
            City = city;
            MobileNumber = mobileNumber;
            WalletBalance = walletBalance;
            EmailID = emailID;
        }
        public void WalletRecharge(double deposit)
        {
            WalletBalance+=deposit;
        }
        public void DeductBalance(double deduction)
        {
            WalletBalance-=deduction;
        }
    }

}