using System;
using System.Data;
namespace CollegeAdmission;

class DepartmentDetails
{
    //Field
    private static long _departmentCount=101;

    private string _departmentId="";

    private string _departmentName="";


    //properties

    public string DepartmentID
    {
        get
        {
            return _departmentId;
        }
    }
    public string DepartmentName
    {
        get
        {
            return _departmentName;
        }
    }
    public long NumberOfSeats{get;set;}

    // Constructors

    public DepartmentDetails(string departmentName, long numberOfSeats)
    {
        _departmentId = "DID"+Convert.ToString(_departmentCount++);
        _departmentName = departmentName;
        NumberOfSeats = numberOfSeats;
    }

}