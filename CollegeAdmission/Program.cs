using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Transactions;
namespace CollegeAdmission;

class Program 
{
        static List<StudentDetails> studentDetailsList =  new List<StudentDetails>();
        static List<DepartmentDetails> departmentDetailsList = new List<DepartmentDetails >();

        static List<AdmissionDetails> admissionDetailsList = new List<AdmissionDetails>();
        
        
    public static void Main(string[] args)
    {
        DefaultDetails();
        
        int choise = 0;
        do
        {
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("1. Student Registration");
            Console.WriteLine();
            Console.WriteLine("2. Student Login");
            Console.WriteLine();
            Console.WriteLine("3. Department wise seat availablity");
            Console.WriteLine();
            Console.WriteLine("4. Exit");
            Console.WriteLine("_________________________________________________");
            choise =  int.Parse(Console.ReadLine());


            if(choise == 1)
            {
                userRegistration();
            } 

            else if(choise == 2)
            {
                userLogin();
            }
            else if(choise == 3)
            {
                DisplayDepartmentDetails();
            }          
        } while (choise!=4);
    }



    static void userRegistration()
    {
                Console.Write("Enter your Name  : ");
                string studentName = Console.ReadLine();

                Console.Write("Enter your Father's Name : " );
                string fatherName = Console.ReadLine();

                Console.Write("Enter your Gender : ");
                Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);

                Console.Write("Enter your Date of Birth : ");
                DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

                Console.Write("Enter your Physics mark : ");
                double physics = double.Parse(Console.ReadLine());

                Console.Write("Enter your Chemistry mark : ");
                double chemistry = double.Parse(Console.ReadLine());

                Console.Write("Enter your Maths Mark : ");
                double maths  = double.Parse(Console.ReadLine());

                StudentDetails Student = new StudentDetails(studentName,fatherName,dob,gender,physics,chemistry,maths);

                Console.WriteLine($"Student Registration Sucessfull and your id is {Student.StudentId}");

                studentDetailsList.Add(Student);
    }
    static void userLogin()
    {
        string option = "";
        int admissionIndex = -1;
        int studentIndex = -1;
        Console.Write("Enter Your StudentId : ");
        string id = Console.ReadLine();
        for(int i=0 ; i<studentDetailsList.Count;i++)
        {
            if(id == studentDetailsList[i].StudentId)
            {
                studentIndex=i;
            }
        }
        if(studentIndex>=0)
        {
            do
            {
                    Console.WriteLine("_________________________________________________");
                    Console.WriteLine("1. Check Eligibility");
                    Console.WriteLine("2. Show Details");
                    Console.WriteLine("3. Take Admission");
                    Console.WriteLine("4. CancelAdmiison");
                    Console.WriteLine("5. Show Admission Details");
                    Console.WriteLine("6. Exit");

                    int loginChoise = int.Parse(Console.ReadLine());      
                   
                    
                    bool isEligible = true;
                    
                    

                    //Check eligiblity
                    if(loginChoise == 1)
                    {
                        isEligible = studentDetailsList[studentIndex].CheckEligiblity();
                        if(isEligible)
                        {
                            Console.WriteLine("Student is eligible");
                        }
                        else
                        {
                            Console.WriteLine("Student is not eligible");
                        }
                    }

                    //Show Details

                    else if(loginChoise==2)
                    {
                        studentDetailsList[studentIndex].ShowDetails();
                    }

                    //Take admission
                    else if( loginChoise == 3)
                    {
                        DisplayDepartmentDetails();
                        admissionIndex=-1;
                        for(int i = 0;i<admissionDetailsList.Count;i++)
                        {
                            if(admissionDetailsList[i].StudentId == id && admissionDetailsList[i].AdmissionStatus == AdmissionStatus.Booked)
                            {
                                admissionIndex = i;
                                break;
                            }
                        }
                        if(admissionIndex==-1)
                        {
                            takeAdmission(isEligible,studentIndex,id);
                        }
                        else
                        {
                            Console.WriteLine("Sorry you already took your Admission and your details are below");
                            admissionDetailsList[admissionIndex].showAdmissionDetails();
                        }
                    }
                    
                    //Cancel Admission
                    else if(loginChoise == 4)
                    {    
                        for(int i = 0;i<admissionDetailsList.Count;i++)
                        {
                            if(admissionDetailsList[i].StudentId == id)
                            {
                                admissionIndex = i;
                                break;
                            }
                        }
                        cancelAdmission(id,admissionIndex);
                    }       

                    //Show Admission Details    
                    else if(loginChoise == 5)
                    {
                        for(int i = 0;i<admissionDetailsList.Count;i++)
                        {
                            if(admissionDetailsList[i].StudentId == id)
                            {
                                admissionIndex = i;
                                break;
                            }
                        }
                         if(admissionIndex>=0)
                         {
                            admissionDetailsList[admissionIndex].showAdmissionDetails();
                         }
                         else
                         {
                            Console.WriteLine("You haven't taken any admission");
                         }
                    }
                    else if(loginChoise == 6 )
                    {
                        break;
                    }
                    Console.Write("Do you want to continue?yes/no   :   ");
                    option =  Console.ReadLine();
                    option = option.ToLower();
                }while(option == "yes");
        }
        else
        {
            Console.WriteLine("Sorry Invalid ID");
        }           
    }
    static void takeAdmission(bool isEligible,int index,string id)
    {
        Console.Write("Pick the Department ID : ");
        int deptIndex = -1;
        string departmentId = Console.ReadLine();
        bool validDepartment= false;                        
        for(int i = 0;i<departmentDetailsList.Count;i++)
        {
            if(departmentId==departmentDetailsList[i].DepartmentID)
            {
                validDepartment = true;
                break;
            }
        }
        if(validDepartment)
        {
            isEligible = studentDetailsList[index].CheckEligiblity();
            bool admissionStatus = true;
            if(isEligible)
            {

                for(int i = 0;i<departmentDetailsList.Count;i++)
                {
                    if(departmentDetailsList[i].DepartmentID == departmentId)
                    {
                        deptIndex = i ;
                    }
                }
                if(admissionStatus && departmentDetailsList[deptIndex].NumberOfSeats>0)
                {
                    AdmissionDetails admission = new AdmissionDetails(studentDetailsList[index].StudentId,departmentDetailsList[deptIndex].DepartmentID,DateTime.Today,AdmissionStatus.Booked);
                    departmentDetailsList[deptIndex].NumberOfSeats--;
                    admissionDetailsList.Add(admission);
                    Console.WriteLine($"Admission took Sucessfully. Your Admission ID is {admission.AdmissionId}");
                }
            }
        }
    }
    static void cancelAdmission(string id,int admissionIndex)
    {     

        if(admissionIndex>=0)
        {
            admissionDetailsList[admissionIndex].AdmissionStatus = AdmissionStatus.Cancelled;
            for(int i = 0 ;i<departmentDetailsList.Count;i++)
            {
                if(departmentDetailsList[i].DepartmentID == admissionDetailsList[admissionIndex].DepartmentId)
                {
                    Console.WriteLine("Admission is Cancelled");
                    departmentDetailsList[i].NumberOfSeats++;
                }
            }
        }
        else
        {
            Console.WriteLine("You haven't taken any admission");
        }
    }
    static void DisplayDepartmentDetails()
    {
        Console.WriteLine("Department Id            Department Name             NumberOfSeat");
        for(int i =0 ; i<departmentDetailsList.Count;i++)
        {
            Console.WriteLine($"{departmentDetailsList[i].DepartmentID}                      {departmentDetailsList[i].DepartmentName}                         {departmentDetailsList[i].NumberOfSeats}");
        }
    }    
    static void DefaultDetails()
    {
        StudentDetails defaultStudent =new StudentDetails("Ravichandran E","Ettaparajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
        studentDetailsList.Add(defaultStudent);
        StudentDetails defaultStudent1 =new StudentDetails("Baskaran S","Sethurajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
        studentDetailsList.Add(defaultStudent1);

        DepartmentDetails defaultDepartment = new DepartmentDetails("EEE",29);
        departmentDetailsList.Add(defaultDepartment);
        DepartmentDetails defaultDepartment1 = new DepartmentDetails("CSE",29);
        departmentDetailsList.Add(defaultDepartment1);
        DepartmentDetails defaultDepartment2 = new DepartmentDetails("MECH",30);
        departmentDetailsList.Add(defaultDepartment2);
        DepartmentDetails defaultDepartment3 = new DepartmentDetails("ECE",30);
        departmentDetailsList.Add(defaultDepartment3);

        AdmissionDetails defaultAdmission  = new AdmissionDetails("SF3001","DID101",new DateTime(2022,05,11),AdmissionStatus.Booked);
        admissionDetailsList.Add(defaultAdmission);
        AdmissionDetails defaultAdmission1 = new AdmissionDetails("SF3002","DID102",new DateTime(2022,05,11),AdmissionStatus.Booked);
        admissionDetailsList.Add(defaultAdmission1);
    }
}
