using System;
namespace Debugging
{
    //Enum
    public enum AdmissionStatusEnum{Select,Admitted,Cancelled}
    public class AdmissionDetails
    {
        //Field
        //Static Field for Auto Generation of ID.
        public static int s_admissionID = 3000;

        //Properties
        public string AdmissionID { get; }
        public string StudentID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatusEnum AdmissionStatus { get; set; }

        //Constructor
        public AdmissionDetails(string studentID,string departmentID,DateTime admissionDate,AdmissionStatusEnum admissionStatus)
        {
            s_admissionID++;
            AdmissionID = "AID" + s_admissionID;
            StudentID = studentID;
            DepartmentID = departmentID;
            AdmissionDate = admissionDate;
            AdmissionStatus = admissionStatus;
        }
    }
}