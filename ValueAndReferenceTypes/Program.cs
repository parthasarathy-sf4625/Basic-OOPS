using System;
namespace ValueAndReferenceTypes;

class Program 
{
    public static void Main(string[] args)
    {
        int number1 = 10;
        
        Console.WriteLine(number1);

        int number2 = number1 ;
        Console.WriteLine(number2);

        number1 = 20;
        Console.WriteLine(number1);

        Student sample = new Student();

        sample.StudentName="Parthaa";

        Console.WriteLine(sample.Name);

        Student sample1 = new Student();

        sample1=sample;

        Console.WriteLine(sample1.Name);

        sample.Name="ParthaSarathy";
        Console.WriteLine(sample.Name);
        Console.WriteLine(sample1.Name);

    }
}