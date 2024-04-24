using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

namespace StuentAdmission
{
    public enum Gender { Select, Male, Female }
    public class StudentDetails
    {
        /*
        a.	StudentID – (AutoGeneration ID – SF3000)
        b.	StudentName
        c.	FatherName
        d.	DOB
        e.	Gender – Enum (Male, Female, Transgender)
        f.	Physics
        g.	Chemistry
        h.	Maths
        */
        //Fields
        //Static field
        private static long s_studentID = 3000;


        //Properties

        public string StudentID { get; }//Read-only Property
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public double Physics { get; set; }
        public double Chemistry { get; set; }
        public double Maths { get; set; }

        //Constructors

        public StudentDetails(string studentName, string fatherName, DateTime dateOfBirth, Gender gender, double physics, double chemistry, double maths)
        {
            //Auto-Incremnetation
            StudentID = "SF" + (++s_studentID);
            StudentName = studentName;
            FatherName = fatherName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
        }
        public StudentDetails(string student)
        {
             
            
            string[] studentDetail =  student.Split(",");
            s_studentID++;//Auto-Incremnetation
            StudentID = studentDetail[0];
            StudentName = studentDetail[1];
            FatherName = studentDetail[2];
            DateOfBirth = DateTime.ParseExact(studentDetail[3],"dd/MM/yyyy",null);
            Gender = Enum.Parse<Gender>(studentDetail[4],true);
            Physics = double.Parse(studentDetail[5]);
            Chemistry = double.Parse(studentDetail[6]);
            Maths = double.Parse(studentDetail[7]);
        }

        //Methods

        public double Average()
        {
            double total = Physics + Maths + Chemistry;
            double average = (total) / 3;
            return average;
        }

        public bool CheckEligibility(double cutoff)
        {
            if (Average() >= cutoff)
            {
                return true;
            }
            return false;
        }
    }
}