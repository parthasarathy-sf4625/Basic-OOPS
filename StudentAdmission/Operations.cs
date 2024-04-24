using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StuentAdmission
{
     //Static class
     public static class Operations
     {

          //Local/Global Object craetion
          static StudentDetails currentLoggedInStudent;
          //Static List Creation
          public static List<StudentDetails> studentList = new List<StudentDetails>();
          public static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
          public static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();

          //Main Menu
          public static void MainMenu()
          {
               Console.WriteLine("_________________________________Welcome to Syncfuison College___________________________________");

               string mainChoise = "yes";
               //Need to iterate untill the option is exit
               do
               {
                    //Need to Show the main menu option
                    Console.WriteLine("Main Menu");
                    Console.WriteLine("1.Registration");
                    Console.WriteLine("2.Login");
                    Console.WriteLine("3.Department Wise Seat availablity");
                    Console.WriteLine("4.Exit");
                    //Need to gte an input from thee user       
                    Console.Write("Select an option (1,2,3,4) : ");
                    int mainOption = int.Parse(Console.ReadLine());

                    //Need to create mainmenu structure
                    switch (mainOption)
                    {
                         case 1:
                              {
                                   Console.WriteLine("***********************Student Registration**********************");
                                   StudentRegistration();
                                   break;
                              }
                         case 2:
                              {
                                   Console.WriteLine("*****************************Login*************************");
                                   StudentLogin();
                                   break;
                              }
                         case 3:
                              {
                                   Console.WriteLine("************************Department Wise Seat Availablity**********************");
                                   DepartmentwiseSeatAvailablity();
                                   break;
                              }
                         case 4:
                              {
                                   Console.WriteLine("Application Exited Successfully");
                                   mainChoise = "no";
                                   break;
                              }
                    }
               } while (mainChoise == "yes");
          }//Main Menu Ends

          //Student Registration
          public static void StudentRegistration()
          {
               //Need to get required details
               Console.Write("Enter your name : ");
               string studentName = Console.ReadLine();
               Console.Write("Enter your Father's name : ");
               string fatherName = Console.ReadLine();
               Console.Write("Enter your Date of Birth in dd/MM/yyyy: ");
               DateTime dateOfBirth = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
               Console.Write("Enter Your Gender : ");
               Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
               Console.Write("Enter your marks in Physics   : ");
               double physics = double.Parse(Console.ReadLine());
               Console.Write("Enter your marks in Chemistry : ");
               double chemistry = double.Parse(Console.ReadLine());
               Console.Write("Enter your marks in Maths     : ");
               double maths = double.Parse(Console.ReadLine());

               //Need to create an object
               StudentDetails student = new StudentDetails(studentName, fatherName, dateOfBirth, gender, physics, chemistry, maths);

               //Need to add in the list
               studentList.Add(student);
               //Need to display confirmation message an ID.
               Console.WriteLine($"Registration Sucessfull . Student ID : {student.StudentID}");
          }//Student Registration Ends

          //Student Login
          public static void StudentLogin()
          {
               //Need to get ID input
               Console.Write("Enter your Student ID  :  ");
               string loginID = Console.ReadLine().ToUpper();
               //Validate by its presence in the list
               bool flag = true;
               foreach (StudentDetails student in studentList)
               {
                    if (loginID.Equals(student.StudentID))
                    {
                         flag = false;
                         //Assigning current user to Global variable
                         currentLoggedInStudent = student;
                         Console.WriteLine("Logged in Successfully");
                         SubMenu();
                         break;
                    }
               }
               if (flag)
               {
                    Console.WriteLine("Invalid ID");
               }

               //if - not invalid
          }//Student Login Ends
          static void SubMenu()
          {
               string subChoise = "yes";
               do
               {
                    Console.WriteLine("_______________________________SubMenu_________________________________");
                    //Need to show submenu options
                    Console.WriteLine("Select an Option\n 1.Check Eligiblity\n 2.Show Details\n 3.Take Admission\n 4.Cancel Admission\n 5.ShowAdmissionDetails\n 6.Exit");
                    //Getting user options
                    Console.Write("Enter your Option : ");
                    int subOption = int.Parse(Console.ReadLine());
                    //Need to create Submenu structure
                    switch (subOption)
                    {
                         case 1:
                              {
                                   Console.WriteLine("__________________________Check Eligiblity_____________________");
                                   CheckEligiblity();
                                   break;
                              }
                         case 2:
                              {
                                   Console.WriteLine("__________________________Show Details_____________________");
                                   ShowDetails();
                                   break;
                              }
                         case 3:
                              {
                                   Console.WriteLine("__________________________Take Admission_____________________");
                                   TakeAdmission();
                                   break;
                              }
                         case 4:
                              {
                                   Console.WriteLine("__________________________Cancel Admission_____________________");
                                   CancelAdmission();
                                   break;
                              }
                         case 5:
                              {
                                   Console.WriteLine("__________________________Admission Status_____________________");
                                   ShowAdmissionDetails();
                                   break;
                              }
                         case 6:
                              {
                                   Console.WriteLine("Logged out.....Taking back to main menu");
                                   subChoise = "no";
                                   break;
                              }
                    }
                    //Iterate till option is exit.               
               } while (subChoise.Equals("yes"));
          }

          //Check - Eligiblity
          public static void CheckEligiblity()
          {
               Console.Write("Enter the cutoff : ");
               double cutoff = double.Parse(Console.ReadLine());
               if (currentLoggedInStudent.CheckEligibility(cutoff))
               {
                    Console.WriteLine("Student is eligible");
               }
               else
               {
                    Console.WriteLine("Student is not eligible");
               }
          }//Check-Eligbliy ends

          //Show Details
          public static void ShowDetails()
          {
               //Need to show the current student details
               Console.WriteLine($"Student ID          :   {currentLoggedInStudent.StudentID}");
               Console.WriteLine($"Student Name        :   {currentLoggedInStudent.StudentName}");
               Console.WriteLine($"Father Name         :   {currentLoggedInStudent.FatherName}");
               Console.WriteLine($"Date of birth       :   {currentLoggedInStudent.DateOfBirth.ToString("dd/MM/yyyy")}");
               Console.WriteLine($"Gender              :   {currentLoggedInStudent.Gender}");
               Console.WriteLine($"PhysicsMark         :   {currentLoggedInStudent.Physics}");
               Console.WriteLine($"Chemistry Mark      :   {currentLoggedInStudent.Chemistry}");
               Console.WriteLine($"Maths Mark          :   {currentLoggedInStudent.Maths}");
          }//Show Details ends

          //Take- Admission
          public static void TakeAdmission()
          {

               //Need to show Available department Details
               DepartmentwiseSeatAvailablity();
               //Ask department Id from user
               Console.Write("Select an department ID :  ");
               string departmentID = Console.ReadLine().ToUpper();
               //Check the Id is Present or not
               bool flag = true;
               foreach (DepartmentDetails department in departmentList)
               {
                    if (department.DepartmentID.Equals(departmentID))
                    {
                         flag = false;
                         Console.Write("Enter the cutoff value   :  ");
                         double cutoff = double.Parse(Console.ReadLine());
                         //Check student Eligible or not
                         if (currentLoggedInStudent.CheckEligibility(cutoff))
                         {
                              //Check the seat available or not
                              if (department.NumberOfSeats > 0)
                              {
                                   //Check student already taken any admission
                                   int count = 0;
                                   foreach (AdmissionDetails admission in admissionList)
                                   {
                                        if (currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus == AdmissionStatus.Admitted)
                                        {
                                             count++;
                                        }
                                   }
                                   if (count == 0)
                                   {
                                        //create admission object
                                        AdmissionDetails admission = new AdmissionDetails(currentLoggedInStudent.StudentID, department.DepartmentID, DateTime.Now, AdmissionStatus.Admitted);
                                        //Reduce seat count
                                        department.NumberOfSeats--;
                                        //Add to the Admission List
                                        admissionList.Add(admission);
                                        //Display Admission Succesfull message and display Admission ID 
                                        Console.WriteLine($"You have taken admission Successfully .  Admission ID - {admission.AdmissionID}");
                                   }
                                   else
                                   {
                                        Console.WriteLine("You already took admission");
                                        ShowAdmissionDetails();
                                   }

                              }
                              else
                              {
                                   Console.WriteLine("Seats are not available");
                              }

                         }
                         else
                         {
                              Console.WriteLine("You are not eligible");
                              break;
                         }
                         break;
                    }
               }
               if (flag)
               {
                    Console.WriteLine("Invalid ID or ID not present");
               }


          }//TAke Admission Ends

          //Cancel-Admission
          public static void CancelAdmission()
          {
               //Checking if the Student is taken admission
               bool flag = true;
               foreach (AdmissionDetails admission in admissionList)
               {
                    if (admission.StudentID.Equals(currentLoggedInStudent.StudentID) && admission.AdmissionStatus == AdmissionStatus.Admitted)
                    {
                         flag = false;
                         //Cancel the found admission
                         admission.AdmissionStatus = AdmissionStatus.Cancelled;
                         //return the seat to department
                         foreach (DepartmentDetails department in departmentList)
                         {
                              if (department.DepartmentID.Equals(admission.DepartmentID))
                              {
                                   department.NumberOfSeats++;
                                   break;
                              }
                         }
                         break;
                    }
               }

               if (flag)
               {
                    Console.WriteLine("You haven't taken any Admission");
               }
          }//Cancel Admission ends

          //Admission details
          public static void ShowAdmissionDetails()
          {
               //Need to show current logged in student admission detail
               foreach (AdmissionDetails admission in admissionList)
               {
                    if (currentLoggedInStudent.StudentID.Equals(admission.StudentID))
                    {
                         Console.WriteLine("AdmissionID      |    StudentID      |   DepartmentID   |   AdmissionStatus ");
                         Console.WriteLine($"{admission.AdmissionID}            |    {admission.StudentID}     |   {admission.DepartmentID}     |    {admission.AdmissionStatus}   ");
                         Console.WriteLine();
                    }

               }
          }//Admission Detail Ends

          //Department wise seat availablity
          public static void DepartmentwiseSeatAvailablity()
          {
               Console.WriteLine(" ______________________________________");
               Console.WriteLine("|DepartmentID|DepartName |NumberOfSeats|");
               Console.WriteLine("|____________|___________|_____________|");
               //Need to display the all Department wise seat availablity
               foreach (DepartmentDetails department in departmentList)
               {
                    Console.WriteLine($"|{department.DepartmentID,-12}|{department.DepartName,-11}|{department.NumberOfSeats,-13}|");
                    Console.WriteLine("|____________|___________|_____________|");
               }
          }//Department Wise Seat Availablity

          //Adding Default Data
          public static void AddDefaultData()
          {
               StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
               StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
               studentList.AddRange(new List<StudentDetails> { student1, student2 });

               DepartmentDetails department1 = new DepartmentDetails("EEE", 29);
               DepartmentDetails department2 = new DepartmentDetails("CSE", 29);
               DepartmentDetails department3 = new DepartmentDetails("MECH", 30);
               DepartmentDetails department4 = new DepartmentDetails("ECE", 30);
               departmentList.AddRange(new List<DepartmentDetails> { department1, department2, department3, department4 });

               AdmissionDetails admission1 = new AdmissionDetails(student1.StudentID, department1.DepartmentID, new DateTime(2022, 05, 11), AdmissionStatus.Admitted);
               AdmissionDetails admission2 = new AdmissionDetails(student2.StudentID, department2.DepartmentID, new DateTime(2022, 05, 11), AdmissionStatus.Admitted);
               admissionList.AddRange(new List<AdmissionDetails> { admission1, admission2 });

               //Printing Default Data 
               //Student List
               Console.WriteLine("----------------------------Student Details ---------------------------------");
               foreach (StudentDetails student in studentList)
               {
                    Console.WriteLine($"|{student.StudentID}     |    {student.StudentName}   |     {student.FatherName}     |    {student.DateOfBirth}    |    {student.Gender}    |    {student.Physics}   |    {student.Chemistry}      |    {student.Maths}     ");
                    Console.WriteLine();
               }

               Console.WriteLine("----------------------------Department Details ---------------------------------");
               //Department List
               foreach (DepartmentDetails department in departmentList)
               {
                    Console.WriteLine($"{department.DepartmentID}     |    {department.DepartName}      |     {department.NumberOfSeats}   ");
                    Console.WriteLine();
               }
               Console.WriteLine("----------------------------Admission Details ---------------------------------");

               //Admission List
               foreach (AdmissionDetails admission in admissionList)
               {
                    Console.WriteLine($"{admission.AdmissionID}       |    {admission.StudentID}         |        {admission.DepartmentID}       |    {admission.AdmissionStatus}   ");
                    Console.WriteLine();
               }
          }


     }
}