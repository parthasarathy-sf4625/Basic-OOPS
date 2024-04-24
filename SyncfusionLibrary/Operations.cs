using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{
    public static class Operations
    {
        //Creation of Global login user
        static UserDetails currentLoggedInUser;

        //Creation of lists
        static List<UserDetails> userList = new List<UserDetails>();
        static List<BookDetails> bookList = new List<BookDetails>();
        static List<BorrowDetails> borrowList = new List<BorrowDetails>();

        //MainMenu
        public static void MainMenu()
        {
            string mainChoise = "yes";

            do
            {
                //Displaying the MainMenu
                Console.WriteLine("1.User Registration");
                Console.WriteLine("2.User Login");
                Console.WriteLine("3.Exit");
                Console.Write("Select an Option : ");
                //Asking the user to select the option
                int mainOption = int.Parse(Console.ReadLine());
                //Pass the control using switch
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("**********************User Registration********************");
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("***********************User Login***************************");
                            UserLogin();
                            break;
                        }
                    case 3:
                        {
                            mainChoise = "no";
                            break;
                        }
                }
            } while (mainChoise.Equals("yes"));

        }//Main menu ends
        //User registraion
        public static void UserRegistration()
        {
            //Asking the user to fill the details
            Console.Write("Enter your user Name : ");
            string userName = Console.ReadLine();

            Console.Write("Enter your Gender(Male,Female) : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

            Console.Write("Enter your Department(ECE,EEE,CSE) : ");
            Department department = Enum.Parse<Department>(Console.ReadLine(), true);

            Console.Write("Enter your MobileNumber : ");
            string mobileNumber = Console.ReadLine();

            Console.Write("Enter your Mail ID : ");
            string mailID = Console.ReadLine();

            Console.Write("Enter the Wallent Amount that you want to Add During Registration : ");
            double walletBalance = double.Parse(Console.ReadLine());

            //Passing the values by creating a object and passing it through constructor
            UserDetails user = new UserDetails(userName, gender, department, mobileNumber, mailID, walletBalance);
            //Display user ID
            userList.Add(user);
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine($"User Registration Sucessfull . Your User ID is {user.UserID}");
            Console.WriteLine("--------------------------------------------------------------");
        }//User Registration Ends
        public static void UserLogin()
        {
            //Ask the user to enter the user ID
            Console.Write("Enter Your User ID : ");
            string loginID = Console.ReadLine().ToUpper();
            bool validLoginID = true;
            //Check wheather the user id is valid by traversing the userList
            foreach (UserDetails user in userList)
            {
                if (user.UserID.Equals(loginID))
                {
                    currentLoggedInUser = user;
                    validLoginID = false;
                    Console.WriteLine("-------------------");
                    Console.WriteLine("Login Sucessfull");
                    Console.WriteLine("-------------------");
                    SubMenu();
                    break;
                }
            }
            if (validLoginID)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine();
                Console.WriteLine("Invalid Login ID, Please try again");
                Console.WriteLine();
                Console.WriteLine("Moving to Main Menu..........");
                Console.WriteLine();
                Console.WriteLine("-----------------------------------");
            }

        }//UserLogin Ends
        //Submenu
        public static void SubMenu()
        {
            string subChoise = "yes";
            do
            {
                //Showing submenu
                Console.WriteLine("1.Borrowbook.");
                Console.WriteLine("2.ShowBorrowedhistory.");
                Console.WriteLine("3.ReturnBooks");
                Console.WriteLine("4.WalletRecharge ");
                Console.WriteLine("5.Exit");

                //Asking the user to select an option
                Console.WriteLine("Select an Option (1,2,3,4,5) : ");
                int subOption = int.Parse(Console.ReadLine());
                //Building Submenu structure
                switch (subOption)
                {
                    case 1:
                        {
                            BorrowBooks();
                            break;
                        }
                    case 2:
                        {
                            ShowBorrowedhistory();
                            break;
                        }
                    case 3:
                        {
                            ReturnBooks();
                            break;
                        }
                    case 4:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("********************Exit**********************");
                            subChoise = "no";
                            break;
                        }

                }
            } while (subChoise == "yes");


        }
        //Borrow books
        public static void BorrowBooks()
        {
            //Display the books
            DisplayBooks();
            //Asking the user to enter an ID
            Console.Write("Enter the Book ID to borrow : ");
            string borrowBookID = Console.ReadLine().ToUpper();
            //Check if the books is valid
            bool validBook = true;
            foreach (BookDetails book in bookList)
            {
                if (book.BookID.Equals(borrowBookID))
                {
                    validBook = false;
                    Console.Write("Enter the Count of book : ");
                    int borrowCount = int.Parse(Console.ReadLine());

                    if (book.BookCount >= borrowCount)
                    {
                        int userBorrowedCount = 0;
                        foreach (BorrowDetails borrow in borrowList)
                        {
                            if (borrow.UserID.Equals(currentLoggedInUser.UserID) && borrow.Status == Status.Returned)
                            {
                                userBorrowedCount++;
                            }
                        }
                        if (userBorrowedCount >= 3)
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("You have borrowed 3 books already");
                            Console.WriteLine("--------------------------------------");
                        }
                        else
                        {
                            if (borrowCount + userBorrowedCount > 3)
                            {
                                Console.WriteLine("-------------------------------------------------------------");
                                Console.WriteLine($"You can have maximum of 3 borrowed books.\n Your already borrowed books count is {userBorrowedCount} \nand requested count is {borrowCount}, which exceeds 3 ");
                                Console.WriteLine("--------------------------------------------------------------");
                            }
                            else
                            {
                                BorrowDetails borrow = new BorrowDetails(book.BookID, currentLoggedInUser.UserID, DateTime.Now, borrowCount, Status.Borrowed, 0);
                                borrowList.Add(borrow);
                                Console.WriteLine("------------------------------");
                                Console.WriteLine("Book Borrowed Successfully");
                                Console.WriteLine("------------------------------");
                                book.BookCount--;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("--------------------------------------------------------------");
                        Console.WriteLine("Books are not available for the selected Count");
                        Console.WriteLine("--------------------------------------------------------------");
                        DateTime AvailableDate = DateTime.Now;
                        DateTime minDate = DateTime.Now;
                        foreach (BorrowDetails borrow in borrowList)
                        {
                            if (borrow.BookID.Equals(borrowBookID))
                            {

                                if (borrow.BorrowedDate < minDate)
                                {
                                    minDate = borrow.BorrowedDate;
                                }

                            }
                        }
                        AvailableDate = minDate.AddDays(15);
                        Console.WriteLine("---------------------------------------------------------------------");
                        Console.WriteLine($"The Book will be Available on {AvailableDate.ToString("dd/MM/yyyy")}");
                        Console.WriteLine("---------------------------------------------------------------------");
                    }
                }
            }
            if (validBook)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Invalid Book ID, Please enter valid ID");
                Console.WriteLine("-----------------------------------------");
            }
        }//Borrow book ends
        //Show Borrowed History 
        public static void ShowBorrowedhistory()
        {
            //Traverses the borrowlist 
            int count = 0;
            foreach (BorrowDetails borrow in borrowList)
            {

                if (borrow.UserID.Equals(currentLoggedInUser.UserID))
                {
                    count++;

                    if (count == 1)
                    {
                        Console.WriteLine("|----------------------------------------------------------------------------------------------|");
                        Console.WriteLine($"|{"BorrowID",-10}|{"BookID",-10}|{"UserID",-10}|{"BorrowedDate",-15}|{"BorrowBookCount",-18}|{"Status",-10}|{"PaidFineAmount",-15}|");
                        Console.WriteLine("|----------------------------------------------------------------------------------------------|");
                    }
                    Console.WriteLine($"|{borrow.BorrowID,-10}|{borrow.BookID,-10}|{borrow.UserID,-10}|{borrow.BorrowedDate.ToString("dd/MM/yyyy"),-15}|{borrow.BorrowBookCount,-18}|{borrow.Status,-10}|{borrow.PaidFineAmount,-15}|");
                    Console.WriteLine("|----------------------------------------------------------------------------------------------|");
                }
            }
            if (count == 0)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("You have no borrows to show");
                Console.WriteLine("---------------------------------");
            }
            //Check if the user id is found 
            //Display all the data which has the current user ID            
        }//Show Borrowed History ends
        //Return Books
        public static void ReturnBooks()
        {
            //Travese through the borrowd list 
            int count = 0;
            foreach (BorrowDetails borrow in borrowList)
            {
                //check if the status is borrowed if its has current user userID
                if (borrow.UserID.Equals(currentLoggedInUser.UserID) && borrow.Status == Status.Borrowed)
                {
                    count++;
                    DateTime returnDate = borrow.BorrowedDate.AddDays(+15);

                    if (count == 1)
                    {
                        Console.WriteLine("|----------------------------------------------------------------------------------------------|");
                        Console.WriteLine($"|{"BorrowID",-10}|{"BookID",-10}|{"UserID",-10}|{"BorrowedDate",-15}|{"BorrowBookCount",-18}|{"Status",-10}|{"Return Date",-15}|");
                        Console.WriteLine("|----------------------------------------------------------------------------------------------|");
                    }
                    //display the details along with the return date i.e+15 from borrowed
                    Console.WriteLine($"|{borrow.BorrowID,-10}|{borrow.BookID,-10}|{borrow.UserID,-10}|{borrow.BorrowedDate.ToString("dd/MM/yyyy"),-15}|{borrow.BorrowBookCount,-18}|{borrow.Status,-10}|{returnDate.ToString("dd/MM/yyyy"),-15}|");
                    Console.WriteLine("|----------------------------------------------------------------------------------------------|");
                }
            }
            if (count == 0)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("You have no books to return");
                Console.WriteLine("---------------------------------");
            }
            else
            {
                //Display them Ask the user to select an id to return
                Console.Write("Enter the borrowID : ");
                string borrowID = Console.ReadLine().ToUpper();
                //check if the id is valid
                bool validReturn = true;
                foreach (BorrowDetails borrow in borrowList)
                {
                    //check if the status is borrowed if its has current user userID
                    if (borrow.BorrowID.Equals(borrowID) && borrow.Status == Status.Borrowed && currentLoggedInUser.UserID.Equals(borrow.UserID))
                    {
                        validReturn = false;
                        count++;
                        DateTime returnDate = borrow.BorrowedDate.AddDays(+15);
                        DateTime currentDate = DateTime.Now;
                        //if the return date < current date

                        if (returnDate > currentDate)
                        {
                            TimeSpan span = returnDate - currentDate;
                            int delayedDays = span.Days;
                            int fineAmount = delayedDays * 1;
                            //display fine amount
                            Console.WriteLine($"Return Date Elapsed .Your Fine Amount is :Rs {fineAmount} ");
                            //if the user has sufficiant balance deduct from balance and display "returned Sucessfully" 
                            if (fineAmount < currentLoggedInUser.WalletBalance)
                            {
                                Console.WriteLine("Fine Amount Paid Successfully from your Wallet");
                                currentLoggedInUser.DeductBalance(fineAmount);
                                Console.WriteLine($"Your current Balance after deduction of fine amount is Rs {currentLoggedInUser.WalletBalance}");
                                break;
                            }
                            //else display"Recharge and proceed"
                            else
                            {
                                Console.WriteLine("-------------------------------------------------------------------------");
                                Console.WriteLine();
                                Console.WriteLine("Insufficiant Balance in the Wallet , Please Recharge your wallet to proceed");
                                Console.WriteLine();
                                Console.WriteLine("---------------------------------------------------------------------------");
                                break;
                            }
                        }

                        else
                        {
                            Console.WriteLine("Book Returned Successfully");
                            borrow.Status = Status.Returned;
                            foreach (BookDetails book in bookList)
                            {
                                if (book.BookID.Equals(borrow.BookID))
                                {
                                    book.BookCount++;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (validReturn)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Please Enter a valid Borrow ID");
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------");
                }
            }
            //change the status to returned
            //add the book count+1;
        }//Return Books ends
        //WalletRecharge
        public static void WalletRecharge()
        {
            Console.WriteLine("******************Wallet Recharge******************");
            Console.Write("Enter the amount that you want to recharge : ");
            //Gets the amount user wants to add
            double amount = double.Parse(Console.ReadLine());
            //Calling the method in CustumerDetails class
            currentLoggedInUser.WalletRecharge(amount);
            Console.WriteLine($"Amount Added : {amount}");
            //Displaying Balance after Recharge
            Console.WriteLine($"Total Wallet Balance : {currentLoggedInUser.WalletBalance}");
        }//Wallet Recharge Ends
        //Displaying the list of books available
        public static void DisplayBooks()
        {
            int count = 0;
            foreach (BookDetails book in bookList)
            {
                count++;
                if (count == 1)
                {
                    Console.WriteLine("|--------------------------------------------|");
                    Console.WriteLine($"|{"BookID",-10}|{"BookName",-10}|{"AuthorName",-10}|{"BookCount",-10}|");
                    Console.WriteLine("|--------------------------------------------|");
                }
                Console.WriteLine($"|{book.BookID,-10}|{book.BookName,-10}|{book.AuthorName,-10}|{book.BookCount,-10}|");
                Console.WriteLine("|--------------------------------------------|");
            }
        }
        //Adding Default Values to the List;
        public static void AddDefaultValues()
        {
            //Default Data of UserDetail Class
            UserDetails user1 = new UserDetails("Ravichandran", Gender.Male, Department.EEE, "9938388333", "ravi@gmail.com", 100);
            UserDetails user2 = new UserDetails("Priyadharshini", Gender.Female, Department.CSE, "9944444455", "priya@gmail.com", 150);

            //Adding this to the List
            userList.AddRange(new List<UserDetails> { user1, user2 });

            //Default Data of Book Details
            BookDetails book1 = new BookDetails("C#", "Author1", 3);
            BookDetails book2 = new BookDetails("HTML", "Author2", 5);
            BookDetails book3 = new BookDetails("CSS", "Author1", 3);
            BookDetails book4 = new BookDetails("JS", "Author1", 3);
            BookDetails book5 = new BookDetails("TS", "Author2", 2);

            //Adding the data to the list
            bookList.AddRange(new List<BookDetails> { book1, book2, book3, book4 });

            //Default Data of BorrowDetails
            BorrowDetails borrow1 = new BorrowDetails("BID1001", "SF3001", new DateTime(2023, 09, 10), 2, Status.Borrowed, 0);
            BorrowDetails borrow2 = new BorrowDetails("BID1003", "SF3001", new DateTime(2023, 09, 12), 1, Status.Borrowed, 0);
            BorrowDetails borrow3 = new BorrowDetails("BID1004", "SF3001", new DateTime(2023, 09, 14), 1, Status.Returned, 16);
            BorrowDetails borrow4 = new BorrowDetails("BID1002", "SF3002", new DateTime(2023, 09, 11), 2, Status.Borrowed, 0);
            BorrowDetails borrow5 = new BorrowDetails("BID1005", "SF3002", new DateTime(2023, 09, 09), 1, Status.Returned, 20);

            //Adding the Data to the List
            borrowList.AddRange(new List<BorrowDetails> { borrow1, borrow2, borrow3, borrow4, borrow5 });
        }//Add default values end
    }
}