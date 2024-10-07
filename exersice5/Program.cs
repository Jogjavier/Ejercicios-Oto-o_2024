// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class Program
{
    static void Main()
    {
        int baseNumber = 2;
        int exponent = 3;
        int result = Power(baseNumber, exponent);
        Console.WriteLine($"{baseNumber} elevado a {exponent} es {result}");
    }

    static int Power(int baseNumber, int exponent)
    {
        int result = 1;
        for (int i = 0; i < exponent; i++)
        {
            result *= baseNumber;
        }
        return result;
    }
}