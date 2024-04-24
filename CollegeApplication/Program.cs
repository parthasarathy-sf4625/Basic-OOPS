using System;
using System.Collections.Generic;
namespace CollegeApplication;

class Program 
{
    public static void Main(string[] args)
    {
        List<StudentDetails> studentList = new List<StudentDetails>(); 
        

        string option ="";

        do
        {
            StudentDetails student = new StudentDetails();
            Console.WriteLine("Enter your name");
            student.StudentName = Console.ReadLine();
            
            Console.WriteLine("Enter your Father name");
            student.FatherName = Console.ReadLine();

            Console.WriteLine("Enter your gender");
            student.Gender = Console.ReadLine();

            Console.WriteLine("Enter your Date of birth");
            student.Dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

            Console.WriteLine("Enter your mobile number");
            student.MobileNumber = Console.ReadLine();
            
            Console.WriteLine("Enter your Maths mark ");
            student.MathsMark=int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your Physics mark");
            student.PhysicsMark = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your Chemistry mark");
            student.ChemistryMark = int.Parse(Console.ReadLine());
            

            studentList.Add(student);

            Console.WriteLine("Do you want to Continue???");
            option = Console.ReadLine();
        } while (option == "yes");
        

        foreach(StudentDetails student in studentList)
        {
            Console.WriteLine();
        }

        
    }
}