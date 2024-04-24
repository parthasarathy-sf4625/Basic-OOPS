using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using StuentAdmission;

namespace StudentAdmission
{
    public static class FileHandling
    {

        //Creation of csv files
        public static void create()
        {

            //Directory creation
            if (!Directory.Exists("StudentAdmission"))
            {
                Console.WriteLine("Creating Folder");
                Directory.CreateDirectory("StudentAdmission");
            }

            //Files creation
            if (!File.Exists("StudentAdmission/StudentDetails.csv") && !File.Exists("StudentAdmission/AdmissionDetails.csv") && !File.Exists("StudentAdmission/DepartmentDetails.csv"))
            {
                Console.WriteLine("Creating Files");
                File.Create("StudentAdmission/StudentDetails.csv").Close();
                File.Create("StudentAdmission/AdmissionDetails.csv").Close();
                File.Create("StudentAdmission/DepartmentDetails.csv").Close();
            }
        }


        //File Write

        public static void WriteToCSV()
        {
            //Students Details

            string[] students = new string[Operations.studentList.Count];
            for (int i = 0; i < Operations.studentList.Count; i++)
            {
                students[i] = Operations.studentList[i].StudentID + "," + Operations.studentList[i].StudentName + "," + Operations.studentList[i].FatherName + "," + Operations.studentList[i].DateOfBirth.ToString("dd/MM/yyyy") + "," + Operations.studentList[i].Gender + "," + Operations.studentList[i].Physics + "," + Operations.studentList[i].Chemistry + "," + Operations.studentList[i].Maths;
            }

            File.WriteAllLines("StudentAdmission/StudentDetails.csv", students);


            //Department Details

            string[] departments = new string[Operations.departmentList.Count];
            for (int i = 0; i < Operations.departmentList.Count; i++)
            {
                departments[i] = Operations.departmentList[i].DepartmentID + "," + Operations.departmentList[i].DepartName + "," + Operations.departmentList[i].NumberOfSeats;
            }
            File.WriteAllLines("StudentAdmission/DepartmentDetails.csv", departments);


            //Admission Details

            string[] admissions = new string[Operations.admissionList.Count];
            for (int i = 0; i < Operations.admissionList.Count; i++)
            {
                admissions[i] = Operations.admissionList[i].AdmissionID + "," + Operations.admissionList[i].StudentID + "," + Operations.admissionList[i].DepartmentID + "," + Operations.admissionList[i].AdmissionDate.ToString("dd/MM/yyyy") + "," + Operations.admissionList[i].AdmissionStatus;
            }
            File.WriteAllLines("StudentAdmission/AdmissionDetails.csv", admissions);

        }
        

        //Read file
        public static void ReadFromCSV()
        {
            string[] students = File.ReadAllLines("StudentAdmission/StudentDetails.csv");

            foreach(string student in students)
            {
                StudentDetails studentDetail = new StudentDetails(student);
                Operations.studentList.Add(studentDetail);

            }

            string[] departments = File.ReadAllLines("StudentAdmission/DepartmentDetails.csv");

            foreach(string department in departments)
            {
                DepartmentDetails departmentDetail = new DepartmentDetails(department);
                Operations.departmentList.Add(departmentDetail);

            }

            string[] admissions = File.ReadAllLines("StudentAdmission/AdmissionDetails.csv");

            foreach(string admission in admissions)
            {
                AdmissionDetails admissionDetail = new AdmissionDetails(admission);
                Operations.admissionList.Add(admissionDetail);
            }
        }
    }
}