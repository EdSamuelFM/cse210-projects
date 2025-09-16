using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int inputNumber = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (inputNumber != 0)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            inputNumber = int.Parse(input);

            if (inputNumber != 0)
            {
                numbers.Add(inputNumber);
            }
        }

        int sum = numbers.Sum();

        double average = 0;
        if (numbers.Count > 0)
        {
            average = numbers.Average();
        }
        
        int maxNumber = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");

        int smallestPositive = -1;
        List<int> positiveNumbers = numbers.Where(n => n > 0).ToList();
        if (positiveNumbers.Count > 0)
        {
            smallestPositive = positiveNumbers.Min();
        }

        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        numbers.Sort();

        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
