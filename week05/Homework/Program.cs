using System;

class Program
{
    static void Main(string[] args)
    {
        // Test base Assignment class
        Assignment assignment1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine();

        // Test MathAssignment class
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
        Console.WriteLine();

        // Test WritingAssignment class
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
        Console.WriteLine();

        // Additional test cases
        Console.WriteLine("Additional Tests:");
        Console.WriteLine("=================");
        
        // Another math assignment
        MathAssignment math2 = new MathAssignment("John Smith", "Algebra", "5.2", "1-15, 20-25");
        Console.WriteLine(math2.GetSummary());
        Console.WriteLine(math2.GetHomeworkList());
        Console.WriteLine();

        // Another writing assignment
        WritingAssignment writing2 = new WritingAssignment("Sarah Johnson", "American Literature", "The Great Gatsby Analysis");
        Console.WriteLine(writing2.GetSummary());
        Console.WriteLine(writing2.GetWritingInformation());
    }
}