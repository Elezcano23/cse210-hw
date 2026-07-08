using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        int sum = 0;
        int largestNumber = numbers[0];
        int smallestPositiveNumber = int.MaxValue;

        foreach (int currentNumber in numbers)
        {
            sum += currentNumber;

            if (currentNumber > largestNumber)
            {
                largestNumber = currentNumber;
            }

            if (currentNumber > 0 && currentNumber < smallestPositiveNumber)
            {
                smallestPositiveNumber = currentNumber;
            }
        }

        double average = ((double)sum) / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average.ToString(CultureInfo.InvariantCulture)}");
        Console.WriteLine($"The largest number is: {largestNumber}");

        if (smallestPositiveNumber != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositiveNumber}");
        }

        numbers.Sort();

        Console.WriteLine("The sorted list is:");

        foreach (int currentNumber in numbers)
        {
            Console.WriteLine(currentNumber);
        }
    }
}
