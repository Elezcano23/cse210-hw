using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue().ToString(CultureInfo.InvariantCulture));

        Fraction fraction2 = new Fraction(6);
        fraction2.SetTop(5);
        fraction2.SetBottom(1);
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue().ToString(CultureInfo.InvariantCulture));

        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue().ToString(CultureInfo.InvariantCulture));

        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue().ToString(CultureInfo.InvariantCulture));
    }
}
