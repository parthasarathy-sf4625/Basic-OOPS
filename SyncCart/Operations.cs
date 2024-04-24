using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SyncCart
{
    public static class Operations
    {
        //Global Object Creation
        static CustomerDetails currentLoggedInCustomer;
        //Static List Creation
        static List<CustomerDetails> CustomerList = new List<CustomerDetails>();
        static List<ProductDetails> ProductList = new List<ProductDetails>();
        static List<OrderDetails> OrderList = new List<OrderDetails>();

        //Main Menu
        public static void MainMenu()
        {
            //Displaying the Main Menu
            string mainChoise = "yes";
            do
            {
                //Showing Main Menu
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Customer Registration");
                Console.WriteLine("2.Login");
                Console.WriteLine("3.Exit");
                //Getting the input from the user
                Console.Write("Select an Option (1,2,3)  :  ");
                int mainOption = int.Parse(Console.ReadLine());

                //Building Main menu structure
                switch (mainOption)
                {
                    case 1:
                        {
                            CustomerRegistration();
                            break;
                        }
                    case 2:
                        {
                            CustomerLogin();
                            break;
                        }
                    case 3:
                        {
                            mainChoise = "no";
                            break;
                        }
                }

            } while (mainChoise.Equals("yes"));


        }//Main Menu End

        //Customer Registration
        public static void CustomerRegistration()
        {
            //Need to get the required Details
            Console.Write("Enter your Name : ");
            string customerName = Console.ReadLine();

            Console.Write("Enter your city : ");
            string city = Console.ReadLine();

            Console.Write("Enter Your Mobile  Number : ");
            string mobileNumber = Console.ReadLine();

            Console.Write("Enter your Mail ID  : ");
            string mailID = Console.ReadLine();

            Console.Write("Enter the Deposit Wallet Balance : ");
            double walletBalance = double.Parse(Console.ReadLine());

            //Passing the values to the Constructor
            CustomerDetails customer = new CustomerDetails(customerName, city, mobileNumber, walletBalance, mailID);

            //Adding the Object to the List
            CustomerList.Add(customer);

            //Displaying the Customer ID
            Console.WriteLine($"Your Registration is Sucessfull. Cusutumer ID {customer.CustomerID}");
        }//Customer Registration Ends
        //Customer Login
        public static void CustomerLogin()
        {
            //Getting the customer ID as inupt
            Console.Write("Enter the Customer ID : ");
            string loginID = Console.ReadLine().ToUpper();
            //Checking if the user is registered by traversing the CustomerList
            bool flag = true;
            foreach (CustomerDetails customer in CustomerList)
            {
                if (customer.CustomerID.Equals(loginID))
                {
                    flag = false;
                    currentLoggedInCustomer = customer;
                    //Calling Submenu
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid Customer ID");
            }
            //Calls the Submenu if customerID is present
            //if - Invalid Display as Invalid id  
        }//Customer Login Ends
        //Sub Menu of Login
        public static void SubMenu()
        {
            string subChoise = "yes";
            do
            {
                Console.WriteLine("Sub Menu");
                Console.WriteLine("a.Purchase");
                Console.WriteLine("b.Order History");
                Console.WriteLine("c.Cancel Order");
                Console.WriteLine("d.Wallet Balance");
                Console.WriteLine("e.WalletRecharge");
                Console.WriteLine("f.Exit");
                //Getting the choise from the user
                Console.Write("Select an option : ");
                char subOption = char.Parse(Console.ReadLine());
                //Building the Submenu structure
                switch (subOption)
                {
                    case 'a':
                        {
                            Console.WriteLine("Purchase");
                            Purchase();
                            break;
                        }
                    case 'b':
                        {
                            Console.WriteLine("Order History");
                            OrderHistory();
                            break;
                        }
                    case 'c':
                        {
                            Console.WriteLine("Cancel Order");
                            CancelOrder();
                            break;
                        }
                    case 'd':
                        {
                            Console.WriteLine("Wallet Balance");
                            WalletBalance();
                            break;
                        }
                    case 'e':
                        {
                            Console.WriteLine("Wallet Recharge");
                            WalletRecharge();
                            break;
                        };
                    case 'f':
                        {
                            Console.WriteLine("Logging out...Taking back to Main Menu");
                            subChoise = "no";
                            break;
                        }
                }
            } while (subChoise == "yes");
            //Showing the submenu

        }//SubMenu Ends
        //Purchace
        public static void Purchase()
        {
            //Displaying Products
            Console.WriteLine("______________________________________________________________________________________________________________________________");
            Console.WriteLine($"|{"ProductID",-10}|{"Product Name",-25}|{"Available Stock Quantity",-25}|{"Price Per Quantity",-20}|{"Shipping Duration",-19}|");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
            foreach(ProductDetails product in ProductList)
            {
                Console.WriteLine($"|{product.ProductID,-10}|{product.ProductName,-25}|{product.Stock,-25}|{product.Price,-20}|{product.ShippingDuration,-19}|");
            }
            //Asking the Custumer to select a product by entering the product ID
            Console.Write("Enter the ID of the Product that you want to purchase : ");
            string purchaseID = Console.ReadLine().ToUpper();
            //If the product id is valid 
            bool validProduct = true;
            foreach(ProductDetails product in ProductList)
            {
                if(product.ProductID.Equals(purchaseID))
                {
                    Console.Write("Enter the Quantity that you want to Purchase : ");
                    //ask for the count
                    int purchaseCount = int.Parse(Console.ReadLine());
                    validProduct = false;
                    //if count exxeds available show as "Required Count not available" and show the current availablity
                    if(product.Stock>=purchaseCount)
                    {
                        //if count available calculate the total amount
                        double totalAmount = (purchaseCount*product.Price)+50;
                        //Check the user's Wallet Amount
                         //If the balance is sufficiant deduct the balance and deduct the count from stock availablity of the product
            
                        if(totalAmount<=currentLoggedInCustomer.WalletBalance)
                        {
                            currentLoggedInCustomer.DeductBalance(totalAmount);
                            product.Stock--;
                            //Create order with available details 
                            OrderDetails order = new OrderDetails(currentLoggedInCustomer.CustomerID,product.ProductID,totalAmount,DateTime.Now,purchaseCount,OrderStatus.Ordered);
                            //Add the order to the list
                            OrderList.Add(order);
                            //Display the Order ID
                            Console.WriteLine($"Your Order has been sucessfully completed an your order ID is {order.OrderID}");  
                            //Show the Delivery Date by calculating the orderdate +shippping duration
                            Console.WriteLine($"Your Delivery Date will be {DateTime.Now.AddDays(product.ShippingDuration).ToString("dd/MM/yyyy")}");  
                            break;       

                        }
                        //If its is insufficiant display as "Insufficiant balance.Recharge the Wallet and do purchase again"
                        else
                        {
                            Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do purchase again");
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine($"Required count not available. Current availability is {product.Stock}");
                        break;
                    }
                }   
            }
            if(validProduct)
            {
                Console.WriteLine("Please Enter a valid Product ");
            }
            
            
            
        }//Purchase Ends
        //Order History
        public static void OrderHistory()
        {
            //Show all the information about the purchases the current logged in user made
            int count = 0;
            bool flag =  true;
            foreach(OrderDetails order in OrderList)
            {
                if(order.CustomerID.Equals(currentLoggedInCustomer.CustomerID))
                {
                    flag = false;
                    count++;
                    //Display the header only for the first time when the order is found 
                    if(count==1)
                    {
                        Console.WriteLine($"|{"Order ID",-13}|{"Custumer ID",-13}|{"Product ID",-13}|{"Total Price",-13}|{"Purchase Date",-13}|{"Quantity Purchased",-20}|{"Order Status",-13}|");
                    }
                    // print the details
                    Console.WriteLine($"|{order.OrderID,-13}|{order.CustomerID,-13}|{order.ProductID,-13}|{order.TotalPrice,-13}|{order.PurchaseDate.ToString("dd/MM/yyyy"),-13}|{order.Quantity,-20}|{order.OrderStatus,-13}|");

                    
                }
            }
            if(flag)
            {
                Console.WriteLine("You haven't made any purchases");
            }
        }//Order History Ends
        //Cancel Order
        public static void CancelOrder()
        {
            //Show the orders which are currently active i.e not Cancelled
            int count = 0;
            bool flag =  true;
            foreach(OrderDetails order in OrderList)
            {
                if(order.CustomerID.Equals(currentLoggedInCustomer.CustomerID) && order.OrderStatus==OrderStatus.Ordered)
                {
                    flag = false;
                    count++;
                    //Display the header only for the first time when the order is found 
                    if(count==1)
                    {
                        Console.WriteLine($"|{"Order ID",-13}|{"Custumer ID",-13}|{"Product ID",-13}|{"Total Price",-13}|{"Purchase Date",-13}|{"Quantity Purchased",-20}|{"Order Status",-13}|");
                    }
                    // print the details
                    Console.WriteLine($"|{order.OrderID,-13}|{order.CustomerID,-13}|{order.ProductID,-13}|{order.TotalPrice,-13}|{order.PurchaseDate.ToString("dd/MM/yyyy"),-13}|{order.Quantity,-20}|{order.OrderStatus,-13}|");                    
                }
            }
            //Print if no purchaces were made oin the past
            if(flag)
            {
                Console.WriteLine("You haven't made any orders");
            }
            //else get the input of order id 
            else
            {
                Console.Write("Enter the order id of the Order that you want to cancel : ");
                string cancelOrder = Console.ReadLine().ToUpper();
                bool validCancel =true;//to check if the orderid is valid

                //Traverse through the orderlist to find the order
                foreach(OrderDetails order in OrderList)
                {
                    if(order.OrderID.Equals(cancelOrder) && order.CustomerID.Equals(currentLoggedInCustomer.CustomerID))
                    {
                        validCancel = false;
                        order.OrderStatus=OrderStatus.Cancelled;
                        Console.WriteLine("Your order has been cancelled");
                        //Traverse through the product list to add a stock
                        foreach(ProductDetails product in ProductList)
                        {
                            if(product.ProductID.Equals(order.ProductID))
                            {
                                currentLoggedInCustomer.WalletBalance+=order.TotalPrice-50;
                                product.Stock++;
                                break;
                            }
                        }
                        break;
                    }
                }
                if(validCancel)
                {
                    Console.WriteLine("Enter a valid OrderID");
                }
            }  
        }//Cancel Order Ends
        //Wallet Balance
        public static void WalletBalance()
        {
            Console.WriteLine($"Your Wallet Balance is {currentLoggedInCustomer.WalletBalance}");
        }//Wallet Balance Ends
        //Wallet Recharge 
        public static void WalletRecharge()
        {
            //Asks 
            Console.Write("Enter the amount you want to recharge  : ");
            double deposit = double.Parse(Console.ReadLine());
            currentLoggedInCustomer.WalletRecharge(deposit);
            Console.WriteLine($"Your current balance is {currentLoggedInCustomer.WalletBalance}");
        }  //Wallet Recharge Ends     
        //Adding Default Details
        public static void AddDefaultValues()
        {
            //Default customer Details
            CustomerDetails customer1 = new CustomerDetails("Ravi", "Chennai", "9885858588", 50000, "ravi@mail.com");
            CustomerDetails customer2 = new CustomerDetails("Baskaran", "Chennai", "9888475757", 60000, "baskaran@mail.com");

            //Adding Default Details to the Customer List
            CustomerList.AddRange(new List<CustomerDetails> { customer1, customer2 });

            //Default Product Details
            ProductDetails product1 = new ProductDetails("Mobile (Samsung)", 10, 10000, 3);
            ProductDetails product2 = new ProductDetails("Tablet (Lenovo)", 5, 15000, 2);
            ProductDetails product3 = new ProductDetails("Camara (Sony)", 3, 20000, 4);
            ProductDetails product4 = new ProductDetails("iPhone", 5, 50000, 6);
            ProductDetails product5 = new ProductDetails("Laptop (Lenovo I3)", 3, 40000, 3);
            ProductDetails product6 = new ProductDetails("HeadPhone (Boat)", 5, 1000, 2);
            ProductDetails product7 = new ProductDetails("Speakers (Boat)", 4, 500, 2);

            //Adding Default Details to Product List
            ProductList.AddRange(new List<ProductDetails> { product1, product2, product3, product4, product5, product6, product7 });

            //Default Order Details
            OrderDetails order1 = new OrderDetails("CID1001", "PID101", 20000, DateTime.Now, 2, OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("CID1002", "PID103", 40000, DateTime.Now, 2, OrderStatus.Ordered);

            //Adding Default Details to Order List
            OrderList.AddRange(new List<OrderDetails> { order1, order2 });
        }//Adding Default Details End
    }
}