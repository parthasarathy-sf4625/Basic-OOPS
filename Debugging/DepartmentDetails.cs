using System;
namespace Debugging
{
    public class DepartmentDetails
    {
        //Field
        //Static Field for Auto Generation of ID.
        private static int s_departmentID = 100;

        //Properties
        public  string DepartmentID { get; }
        public  string DepartmentName { get; set; }
        public  int NumberOfSeats { get; set; }

        //Constructor
        public DepartmentDetails(string departmentName,int numberOfSeats)
        {
            s_departmentID++;
            DepartmentID = "DID" + s_departmentID;
            DepartmentName = departmentName;
            NumberOfSeats = numberOfSeats;
        }
    }
}