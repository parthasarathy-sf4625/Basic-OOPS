using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuentAdmission
{
    public enum AdmissionStatus
    {
        Select,
        Admitted,
        Cancelled
    }
    public class AdmissionDetails
    {
        /*a.AdmissionID – (Auto Increment ID - AID1001)
        b.	StudentID
        c.	DepartmentID
        d.	AdmissionDate 
        e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)
        */
        //Fields

        private static long s_admissionID = 1000;

        //Property
        public string AdmissionID { get; }//Read-Only Property
        public string StudentID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatus AdmissionStatus { get; set; }


        //Constructor

        public AdmissionDetails(string studentID, string departmentID, DateTime admissionDate, AdmissionStatus admissionStatus)
        {
            //Auto-increment ID
            AdmissionID = "AID" + (++s_admissionID);
            StudentID = studentID;
            DepartmentID = departmentID;
            AdmissionDate = admissionDate;
            AdmissionStatus = admissionStatus;
        }

        public AdmissionDetails(string admission)
        {
            string[] admissionDetails = admission.Split(",");
            ++s_admissionID;
            AdmissionID =  admissionDetails[0];
            StudentID = admissionDetails[1];
            DepartmentID = admissionDetails[2];
            AdmissionDate = DateTime.ParseExact(admissionDetails[3],"dd/MM/yyyy",null);
            AdmissionStatus = Enum.Parse<AdmissionStatus>(admissionDetails[4],true);            
        }
    }
}