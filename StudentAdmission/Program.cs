using System;
using System.IO;
using StuentAdmission;
namespace StudentAdmission;
public class Program
{
    public static void Main(string[] args)
    {
        FileHandling.create();

        //Calling Add Default Data

        StreamReader sr  = new StreamReader("StudentAdmission/StudentDetails.csv");
        if(sr.ReadLine == null)
        {
            Operations.AddDefaultData();
        }
        
        //Reading from csv
        else
        {
            FileHandling.ReadFromCSV();
        }
        sr.Close();

        //Calling Main Menu
        Operations.MainMenu();

        //Writing to csv

        FileHandling.WriteToCSV(); 
    }
}