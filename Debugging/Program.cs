using System;
using System.Collections.Generic;

namespace Debugging
{
    class Program
    {
        //Global List Declaration
        static List<StudentDetails> studentList = new List<StudentDetails>();
        static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();
        
        //Global Student Object
        static StudentDetails currentLoggedInStudent;

        //Line variable
        static string line = "--------------------------------------------------------------------------";

        //Main Method
        public static void Main(string[] args)
        {
            //Calling AddDefaultData Method
            AddDefaultData();
            //calling Mainmenu Method
            MainMenu();

        }//Main Method Ends

        //Main Menu
        static void MainMenu()
        {
            string mainChoice = "yes";
            do
            {
                System.Console.WriteLine(line);
                System.Console.WriteLine("Welcome to Syncfusion College of Engineering and Technology");
                System.Console.WriteLine(line);
                System.Console.WriteLine("Choose an option from the Mainmenu\n1. Student registration\n2. Student Login\n3. Department wise seat availability\n4. Exit");
                System.Console.WriteLine(line);
                //Getting input option from user
                System.Console.Write("Enter your Option: ");
                int mainOption;
                bool tempMainOption = int.TryParse(Console.ReadLine(),out mainOption);
                while(!tempMainOption)
                {
                    System.Console.WriteLine("Invalid Input. Enter a correct option");
                    tempMainOption = int.TryParse(Console.ReadLine(),out mainOption);
                }
                //Creating mainmenu structure
                switch(mainOption)
                {
                    case 1:
                    {
                        StudentRegistration();
                        break;
                    }
                    case 2:
                    {
                        StudentLogin();
                        break;
                    }
                    case 3:
                    {
                        DepartmentWiseSeatAvailability();
                        break;
                    }
                    case 4:
                    {
                        //Exit method
                        mainChoice = "no";
                        System.Console.WriteLine("Application Exited Successfully.");
                        break;
                    }
                }
            }while(mainChoice=="yes"); //Maintaing the mainmenu looping until user chose to exit
            
        }//MainMenu Method ends

        //Student Registration
        static void StudentRegistration()
        {
            System.Console.WriteLine(line);
            System.Console.WriteLine("Student Registration Form");
            System.Console.WriteLine(line);
            //Getting necessary details.
            System.Console.Write("Enter Your Name: ");
            //Student Name
            string studentName = Console.ReadLine();
            System.Console.Write("Enter Your Father's Name: ");
            //Father Name
            string fatherName = Console.ReadLine();
            System.Console.Write("Enter Your Date Of Birth as Specified - dd/MM/yyyy: ");
            //Date Of Birth
            DateTime dob = new DateTime();
            bool tempDob = DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out dob);
            while(!tempDob)
            {
                System.Console.Write("Invalid Date......yEnter Your Date Of Birth as Specified - dd/MM/yyyy: ");

                tempDob = DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out dob);
            }
            //
            //
            //
            //
            //
            //
            System.Console.Write("Enter Your Gender: ");
            //Gender
            GenderEnum gender;
            bool tempGender = Enum.TryParse(Console.ReadLine(),true,out gender);
            while(!tempGender)
            {
                System.Console.WriteLine("Invalid Input. Enter a valid Gender");
                tempGender = Enum.TryParse(Console.ReadLine(),true,out gender);
            }
            System.Console.Write("Enter Your Physics Mark: ");
            //Physics Mark
            int physics;
            bool tempPhysics = int.TryParse(Console.ReadLine(), out  physics);
            while(!tempPhysics)
            {
                System.Console.WriteLine("Invalid Input. Enter a Valid Mark.");
                tempPhysics = int.TryParse(Console.ReadLine(), out physics);
            }
            System.Console.Write("Enter Your Chemistry Mark: ");
            //Chemistry Mark
            int chemistry;
            bool tempChemistry = int.TryParse(Console.ReadLine(), out chemistry);
            while(!tempChemistry)
            {
                System.Console.WriteLine("Invalid Input. Enter a Valid Mark.");
                tempChemistry = int.TryParse(Console.ReadLine(), out chemistry);
            }
            System.Console.Write("Enter Your Maths Mark: ");
            //Maths Mark
            int maths;
            bool tempMaths = int.TryParse(Console.ReadLine(), out maths);
            while(!tempMaths)
            {
                System.Console.WriteLine("Invalid Input. Enter a Valid Mark.");
                tempMaths = int.TryParse(Console.ReadLine(), out maths);
            }

            //Creating Student Detail Object
            StudentDetails student = new StudentDetails(studentName,fatherName,dob,gender,physics,chemistry,maths);
            //Adding the object to the student detail list.
            
            studentList.Add(student);
            //Displaying Message with Student ID.
            System.Console.WriteLine(line);
            System.Console.WriteLine($"Student Registered Successfully and StudentID is {student.StudentID}.");
            System.Console.WriteLine(line);

        }//StudentRegistration Method ends

        //Student Login
        static void StudentLogin()
        {
            System.Console.WriteLine(line);
            System.Console.WriteLine("Student's Login Portal");
            System.Console.WriteLine(line);
            //Asking the student ID as input
            System.Console.WriteLine("Enter Your Student ID to Login");
            string studentID = Console.ReadLine().ToUpper();
            if(studentID != null) //checking whether the input is null or not
            {
                bool flag = true;
                foreach(StudentDetails student in studentList)
                {
                    if(student.StudentID == studentID)
                    {
                        flag = false;
                        //Assigning the found local object to the global student object
                        currentLoggedInStudent = student;
                        //calling Submenu
                        SubMenu();
                        break;
                    }
                }
                if(flag)
                {
                    System.Console.WriteLine("Student ID is not Found");
                }
            }
            else
            {
                System.Console.WriteLine("Student ID cannot be Null. Enter a valid Student ID.");
            }
        }//StudentLogin Method Ends

        //Sub Menu
        static void SubMenu()
        {
            string subChoice = "yes";
            do
            {
                System.Console.WriteLine(line);
                System.Console.WriteLine($"Welcome {currentLoggedInStudent.StudentName} to Student's Portal");
                System.Console.WriteLine(line);
                System.Console.WriteLine("Choose an Option from Sub Menu\n1. Check Eligibility\n2. Show Details\n3. Take Admission\n4. Cancel Admission\n5. Show Admission Details\n6. Exit");
                System.Console.WriteLine(line);
                //Getting input option from user
                System.Console.Write("Enter your Option: ");
                int subOption = int.Parse(Console.ReadLine());
                //
                //
                // 
                //    
                //
                //
                //
                //Creating submenu structure
                switch(subOption)
                { 
                    case 1:
                    {
                        CheckEligibility();
                        break;
                    }
                    case 2:
                    {
                        ShowDetails();
                        break;
                    }
                    case 3:
                    {
                        TakeAdmission();
                        break;
                    }
                    case 4:
                    {
                        CancelAdmission();
                        break;
                    }
                    case 5:
                    {
                        ShowAdmissionDetails();
                        break;
                    }
                    case 6:
                    {
                        subChoice = "no";
                        System.Console.WriteLine("SubMenu Exited. Switching Back To MainMenu");
                        break;
                    }
                }
            }while(subChoice == "yes"); //Maintaing the submenu looping until user chose to exit
        }//SubMenu Method Ends

        //Check Eligibility Method
        static void CheckEligibility()
        {
            //Consider the Sycfusion College average cutoff is 75.0 and above.
            bool eligibility = currentLoggedInStudent.CheckEligibility(75.0);
            //If Average value is greater than cutoff
            if(eligibility)
            {
                System.Console.WriteLine(line);
                System.Console.WriteLine("Student is Eligible");
                System.Console.WriteLine(line);
            } // or
            else
            {
                System.Console.WriteLine(line);
                System.Console.WriteLine("Student is not Eligibile");
                System.Console.WriteLine(line);
            }
        }//Check Eligibility Method Ends

        //Show Details Method
        static void ShowDetails()
        {
            //Shows the current Logged in Student's details.
            System.Console.WriteLine(line);
            System.Console.WriteLine($"Student ID: {currentLoggedInStudent.StudentID}");
            System.Console.WriteLine($"Student Name: {currentLoggedInStudent.StudentName}");
            System.Console.WriteLine($"Father's Name: {currentLoggedInStudent.FatherName}");
            System.Console.WriteLine($"DOB: {currentLoggedInStudent.DOB.ToString("dd/MM/yyyy")}");
            System.Console.WriteLine($"Gender: {currentLoggedInStudent.Gender}");
            System.Console.WriteLine($"Physics: {currentLoggedInStudent.Physics}");
            System.Console.WriteLine($"Chemistry: {currentLoggedInStudent.Chemistry}");
            System.Console.WriteLine($"Maths: {currentLoggedInStudent.Maths}");
            System.Console.WriteLine(line);
        }//Show Details Ends

        //Take Admission Method
        static void TakeAdmission()
        {
            //Showing the list of available seats in the departments from the department list
            System.Console.WriteLine(line);
            DepartmentWiseSeatAvailability();
            System.Console.WriteLine(line);
            System.Console.WriteLine("Enter the Department ID to select the Department");
            //Getting the Department ID as input
            string departmentID = Console.ReadLine().ToUpper();
            if(departmentID != null) //checking whether the input is null or not
            {
                bool flag = true;
                foreach(DepartmentDetails department in departmentList)
                {
                    //Validating the Department ID is present in the Department List or Not
                    if(department.DepartmentID == departmentID)
                    {
                        flag = false;
                        //Checking eligibility
                        bool eligibilty = currentLoggedInStudent.CheckEligibility(75.0);
                        if(eligibilty) //If Eligible
                        {
                            if(department.NumberOfSeats > 0) //Checking seat availabilty
                            {
                                int count = 0;
                                foreach(AdmissionDetails admission in admissionList)
                                {
                                    //Checking already taken any admission
                                    if(admission.StudentID == currentLoggedInStudent.StudentID && admission.AdmissionStatus == AdmissionStatusEnum.Admitted)
                                    {
                                        count++;
                                        break;
                                    }
                                }
                                if(count == 0) //If no admission is taken previously
                                {
                                    //Reducing available seat count
                                    department.NumberOfSeats-=1;

                                    //Creating Admission Details object
                                    AdmissionDetails newAdmission = new AdmissionDetails(currentLoggedInStudent.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatusEnum.Admitted);
                                    //Adding the object to the global admission list.
                                    admissionList.Add(newAdmission);

                                    //Displaying admission message with Admission ID.
                                    System.Console.WriteLine(line);
                                    System.Console.WriteLine($"Admission took successfully. Your admission ID: {newAdmission.AdmissionID}.");
                                    System.Console.WriteLine(line);
                                }
                                else //If taken any admission
                                {
                                    System.Console.WriteLine(line);
                                    System.Console.WriteLine("Since you have already taken admission. You cannot take admission again.");
                                    System.Console.WriteLine(line);
                                }
                            }
                            else //If no seats are available
                            {
                                System.Console.WriteLine(line);
                                System.Console.WriteLine("Selected Department seats are already booked, can't make the admission.");
                                System.Console.WriteLine(line);
                            }
                        }
                        else //If Not Eligibile
                        {
                            System.Console.WriteLine(line);
                            System.Console.WriteLine("Due to low Cutoff mark, you are not eligibile to take admission.");
                            System.Console.WriteLine(line);
                        }
                        break;
                    }
                }
                if(flag)
                {
                    System.Console.WriteLine(line);
                    System.Console.WriteLine("Department ID is not found.");
                    System.Console.WriteLine(line);
                }
            }
            else
            {
                System.Console.WriteLine(line);
                System.Console.WriteLine("Department ID cannot be Null. Enter a valid Department ID.");
                System.Console.WriteLine(line);
            }
        }//Take Admission Ends

        //Cancel Admission Method
        static void CancelAdmission()
        {
            bool flag = true;
            System.Console.WriteLine(line);
            System.Console.WriteLine("AdmissionID StudentID DepartmentID AdmissionDate AdmissionStatus");
            System.Console.WriteLine(line);
            foreach(AdmissionDetails admission in admissionList)
            {
                //Checking if the student has admission already
                if(admission.StudentID == currentLoggedInStudent.StudentID && admission.AdmissionStatus == AdmissionStatusEnum.Admitted)
                {
                    flag = false;
                    //Displaying the admission entry
                    System.Console.WriteLine($"{admission.AdmissionID} {admission.StudentID} {admission.DepartmentID} {admission.AdmissionDate.ToString("dd/MM/yyyy")} {admission.AdmissionStatus}");
                    System.Console.WriteLine(line);
                    //Cancelling the Admission
                    admission.AdmissionStatus = AdmissionStatusEnum.Cancelled;
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(department.DepartmentID == admission.DepartmentID)
                        {
                            //Returning the seat count to the department
                            department.NumberOfSeats++;
                            break;
                        }
                    }
                    //Displaying Cancel Message
                    System.Console.WriteLine(line);
                    System.Console.WriteLine($"{admission.AdmissionID} - Admission Cancelled Successfully.");
                    System.Console.WriteLine(line);
                    break;
                }
            }
            if(flag) //if no details found
            {
                System.Console.WriteLine(line);
                System.Console.WriteLine("No Admission Details to Cancel.");
                System.Console.WriteLine(line);
            }
        }//Cancel Admission Ends

        //Show Admission Details
        static void ShowAdmissionDetails()
        {
            bool flag = true;
            System.Console.WriteLine(line);
            System.Console.WriteLine("AdmissionID StudentID DepartmentID AdmissionDate AdmissionStatus");
            System.Console.WriteLine(line);
            foreach(AdmissionDetails admission in admissionList)
            {
                //Checking if the student's admission details
                if(admission.StudentID == currentLoggedInStudent.StudentID)
                {
                    flag = false;
                    //Displaying the admission entry
                    System.Console.WriteLine($"{admission.AdmissionID} {admission.StudentID} {admission.DepartmentID} {admission.AdmissionDate.ToString("dd/MM/yyyy")} {admission.AdmissionStatus}");
                    System.Console.WriteLine(line);
                }
            }
            if(flag) //if no details found
            {
                System.Console.WriteLine(line);
                System.Console.WriteLine("No Admission Details to show.");
                System.Console.WriteLine(line);
            }
        }//Show Admission Details Method Ends

        //Departmentwise Seat Availability Method
        static void DepartmentWiseSeatAvailability()
        {
            //Displaying the department details travesing through the department list
            System.Console.WriteLine(line);
            System.Console.WriteLine("DepartmentID DepartmentName NumberOfSeats");
            System.Console.WriteLine(line);
            foreach(DepartmentDetails department in departmentList)
            {
                System.Console.WriteLine($"{department.DepartmentID} {department.DepartmentName} {department.NumberOfSeats}");
                System.Console.WriteLine(line);
            }
        }//Departmentwise Seat Availability Method Ends

        //Adding Default Data
        static void AddDefaultData()
        {
            //Adding Student Details
            StudentDetails student1 = new StudentDetails("Ravichandran","Ettapparajan",new DateTime(1999,11,11),GenderEnum.Male,95,95,95);
            studentList.Add(student1);
            StudentDetails student2 = new StudentDetails("Baskaran","Sethurajan",new DateTime(1999,11,11),GenderEnum.Male,95,95,95);
            studentList.Add(student2);

            //Adding Department Details
            DepartmentDetails department1 = new DepartmentDetails("EEE",29);
            departmentList.Add(department1);
            DepartmentDetails department2 = new DepartmentDetails("CSE",29);
            departmentList.Add(department2);
            DepartmentDetails department3 = new DepartmentDetails("MECH",30);
            departmentList.Add(department3);
            DepartmentDetails department4 = new DepartmentDetails("ECE",30);
            departmentList.Add(department4);

            //Adding Admission Details
            AdmissionDetails admission1 = new AdmissionDetails(studentList[0].StudentID,departmentList[0].DepartmentID,new DateTime(2023,05,11),AdmissionStatusEnum.Admitted);
            admissionList.Add(admission1);
            AdmissionDetails admission2 = new AdmissionDetails(studentList[1].StudentID,departmentList[1].DepartmentID,new DateTime(2023,05,12),AdmissionStatusEnum.Admitted);
            admissionList.Add(admission2);
        }//AddDefaultData Ends
    }
}
