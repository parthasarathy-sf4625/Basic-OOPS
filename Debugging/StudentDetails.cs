using System;
namespace Debugging
{
    //Enum
    public enum GenderEnum{Select,Male,Female,Transgender}
    public class StudentDetails
    {
        //Field
        //Static Field for Auto Generation of ID.
        private static int s_studentID = 3000;

        //Properties
        public string StudentID { get; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; } 
        public GenderEnum Gender { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }

        //Constructor
        public StudentDetails(string studentName,string fatherName,DateTime dob,GenderEnum gender,int physics,int chemistry,int maths)
        {
            
             StudentID = "SF" + (++s_studentID);
             StudentName = studentName;
             FatherName = fatherName;
             DOB = dob;
             Gender = gender;
             Physics = physics;
             Chemistry = chemistry;
             Maths = maths;
        }

        //Method
        public bool CheckEligibility(double cutOff)
        {
            double average = (double)(Physics + Chemistry + Maths)/3;
            if(average >= cutOff)
            {
                return true;
            }
            return false;
        }
    }
}