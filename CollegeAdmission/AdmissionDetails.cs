using System;
namespace CollegeAdmission;

enum AdmissionStatus
{
    Select,
    Booked,
    Cancelled
}
/// <summary>
/// This class in used to store Admission Details
/// </summary> <summary>
/// 
/// </summary>
class AdmissionDetails
{
    //Field
    /// <summary>
    /// Static field s_admissionCount is an Auto Increment ID which is used track the admission count and to create the admission ID
    /// </summary>
    private static long s_admissionCount = 1001;
    /// <summary>
    /// Private field _admission ID is used to store the admission ID of the student
    /// </summary>
    private string _admissionId = "";
    
    //Properties

    public string StudentId{get;set;}
    public string AdmissionId
    {
        get
        {
            return _admissionId;
        }
    }

    public string DepartmentId{get;set;}
    public string AdmissionDate{get;set;}
    public AdmissionStatus AdmissionStatus{get;set;}    


    public  AdmissionDetails(string studentId,string departmentId,DateTime admissionDate,AdmissionStatus admissionStatus)
    {
        _admissionId= "AID"+Convert.ToString(s_admissionCount++);
        StudentId = studentId;
        DepartmentId = departmentId;
        AdmissionDate = admissionDate.ToString("dd/MM/yyyy");
        AdmissionStatus =admissionStatus;       
    }

    public void showAdmissionDetails()
    {
        Console.WriteLine("____________________________________________________________________________________");
        Console.WriteLine(); 
        Console.WriteLine("AdmissionID	    StudentID	    DepartmentID	AdmissionDate	AdmissionStatus");
        Console.WriteLine();
        Console.WriteLine($"{AdmissionId}           {StudentId}             {DepartmentId}              {AdmissionDate}             {AdmissionStatus}");
        Console.WriteLine("____________________________________________________________________________________");
    }
    
}