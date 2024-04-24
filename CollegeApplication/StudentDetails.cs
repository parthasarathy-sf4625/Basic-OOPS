using System;
using Microsoft.Win32.SafeHandles;
namespace CollegeApplication;

public class StudentDetails
{

    //fields
    private string _studentName;

    //property
    public string StudentName{get;set;}
    public string FatherName{get;set;}
    public string Gender{get;set;}
    public DateTime Dob {get;set;}
    public string MobileNumber {get;set;}
    public int MathsMark {get;set;}
    public int PhysicsMark{get;set;}
    public int ChemistryMark{get;set;}

    //Events
    //Indexer
    //Constructors

    //Default Constructor;
    public StudentDetails()
    {
        StudentName = "Enter Your Name";
        FatherName = "Enter Your Fathername";
        Gender = "Enter your Gender";
    }

    //Parametrised Constructor
    public StudentDetails(string studentName,string fatherName,string gender,DateTime dob,string mobileNumber,int mathsMark,int physicsMark,int chemistryMark)
    {
        StudentName=studentName;
        FatherName = fatherName;
        Gender = gender;
        Dob = dob;
        MobileNumber = mobileNumber;
        MathsMark= mathsMark;
        PhysicsMark = physicsMark;
        ChemistryMark = chemistryMark;
    }
}