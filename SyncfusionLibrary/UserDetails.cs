using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public enum Gender{Select,Male,Female}
public enum Department {Select,ECE,EEE,CSE}

namespace SyncfusionLibrary
{
    public class UserDetails
    {
        /*a.	UserID (Auto Increment – SF3000)
b.	UserName
c.	Gender
d.	Department – (Enum – ECE, EEE, CSE)
e.	MobileNumber
f.	MailID
*/
        //Fields

        private static int s_userID = 3000;//Autoincrement ID

        //Properties
        public string UserID{get;}//Auto property
        public string UserName{get;set;}
        public Gender Gender{get;set;}
        public Department Department{get;set;}
        public string MobileNumber{get;set;}
        public string MailID{get;set;}
        public double WalletBalance{get;set;}

        //Constructors
        public UserDetails(string userName,Gender gender, Department department,string mobileNumber,string mailID,double walletBalance)
        {
            UserID = "SF"+(++s_userID);
            UserName = userName;
            Gender = gender;
            Department = department;
            MobileNumber = mobileNumber;
            MailID = mailID;
            WalletBalance = walletBalance;
        }

        //Method to Recharge the Wallet
        public void WalletRecharge(double amount)
        {
            WalletBalance+=amount;
        }

        //Method to Deduct the balance if any Borrows were made
        public void DeductBalance(double amount)
        {
            WalletBalance-=amount;
        }
    }
}