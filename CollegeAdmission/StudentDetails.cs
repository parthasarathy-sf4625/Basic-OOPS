using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
namespace CollegeAdmission;
/// <summary>
/// This Enum is used to Store the Gender values it only has 2 values either Male or Female
/// </summary>
enum Gender
{
    Male,
    Female,
    Transgender
}
/// <summary>
/// This class is used to store the Details of a particular student refer the class<see cref="StudentDetails"/> 
/// </summary> <summary>
/// 
/// </summary>
class StudentDetails
{
    //Fields

    /// <summary>
    /// Static field s_studentCount used to autoincrement of the instance to count the students and used to creation of student ID
    /// </summary>
    private static long s_studentCount=3001;
    /// <summary>
    /// Private Field to store the student ID which can't be altered
    /// </summary>
    private string _studentId="";

    //Properties

    //Auto Property
    //ReadOnly

    //StudentID - Property used to hold the student ID of the instance of <see cref = "StudentDetails"> 

    public string StudentId{get {return _studentId;}}
    /// <summary>
    /// Name Property used to hold a Student's ID of instance of <see cref="StudentDetails"/> 
    /// </summary>
    public string StudentName{get;set;}
    /// <summary>
    /// Father Name Property which is used to hold the Father's name of the instance of <see cref="StudentDetails"/> 
    /// </summary>
    /// <value></value>
    public string FatherName{get;set;}
     /// <summary>
    /// Father Name Property which is used to hold the Date of Birth name of the instance of <see cref="StudentDetails"/> 
    /// </summary>
    /// <value></value>
    public DateTime Dob{get;set;}
     /// <summary>
    /// Father Name Property which is used to hold the Gender name of the instance of <see cref="StudentDetails"/> 
    /// </summary>
    /// <value></value>
    public Gender Gender{get;set;}
    public double Physics{get;set;}
    public double Chemistry{get;set;}
    public double Maths{get;set;}
    

    //Constructors

/// <summary>
/// Constructor Student Details used to intialise default values
/// </summary>
    public StudentDetails()
    {
        StudentName = "Enter your name";
        FatherName = "Enter your father's name";
    }
/// <summary>
/// Constructor Student Details used to initialize parameter values to its property
/// </summary>
/// <param name="name">name parameter used to assign its value to associated property/param>
/// <param name="fatherName">fatherName used to assign values to associated property</param>
/// <param name="dob">Dob used to assign values to associated property</param>
/// <param name="gender">genderr used to assign values to associated property</param>
/// <param name="physics">physics used to assign values to associated property</param>
/// <param name="chemistry">chemistry used to assign values to associated property</param>
/// <param name="maths">fatherName used to assign values to associated property</param>
    public StudentDetails(string name,string fatherName,DateTime dob,Gender gender,double physics,double chemistry,double maths)
    {
        _studentId="SF"+Convert.ToString(s_studentCount++);
        StudentName = name;
        FatherName = fatherName;
        Dob = dob;
        Gender = gender;
        Physics = physics;
        Chemistry = chemistry;
        Maths = maths;
    }
    //Methods
    /// <summary>
    /// Method CheckEligblity used to check wheather the instance of<see cref="StudentDetails"/> 
    /// </summary>
    /// <returns>true if eligible false if not</returns>
    public bool CheckEligiblity()
    {
        double average = (Maths+Physics+Chemistry)/3;
        if(average>=75.0)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Show the exisiting value of the insnatce of the class <see cref="StudentDetails"/> 
    /// </summary>

    public void ShowDetails()
    {
        Console.WriteLine("_________________________________________________");
        Console.WriteLine($"ID             : {StudentId}");
        Console.WriteLine();
        Console.WriteLine($"Name           : {StudentName}");
        Console.WriteLine();
        Console.WriteLine($"Father Name    : {FatherName}");
        Console.WriteLine();
        Console.WriteLine($"Date of Birth  : {Dob.ToString("dd/MM/yyyy")}");
        Console.WriteLine();
        Console.WriteLine($"Gender         : {Gender}");
        Console.WriteLine();
        Console.WriteLine($"Physics Mark   : {Physics}");
        Console.WriteLine();
        Console.WriteLine($"Chemistry Mark : {Chemistry}");
        Console.WriteLine();
        Console.WriteLine($"Maths Mark     : {Maths}");
        Console.WriteLine();
        Console.WriteLine("_________________________________________________");
    }
}