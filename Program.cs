using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction[] fractions = new Fraction[4];

            for (int x = 0; x < fractions.Length; x++)
            {
                Console.WriteLine();
                Console.Write("Whole Number: ");
                int wholeNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Numerator: ");
                int numerator = Convert.ToInt32(Console.ReadLine());
                Console.Write("Denominator: ");
                int denominator = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                fractions[x] = new Fraction(wholeNumber, numerator, denominator);
                
            }

            for (int x = 0; x < fractions.Length; x++)
            {
                Fraction fraction1 = fractions[x];
                for (int i = 0; i < fractions.Length; i++)
                {
                    Console.WriteLine();
                    Fraction fraction2 = fractions[i];
                    Fraction fraction3 = fraction1 + fraction2;
                    Fraction fraction4 = fraction1 * fraction2;

                    Console.WriteLine(fraction1.ToString() + " + " + fraction2.ToString());
                    Console.WriteLine(fraction3.ToString());
                    Console.WriteLine(fraction1.ToString() + " * " + fraction2.ToString());
                    Console.WriteLine(fraction4.ToString());

                }
            }
        }
    }
}
