using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionDemo
{
    class Fraction
    {
        


        public int wholeNumber { get; set; }
        public int numerator { get; set; }
        private int denominator;
        public int Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                if (value == 0)
                {
                    value = 1;
                }
                denominator = value;
            }
        }

        public Fraction(int wholeNumber, int numerator, int denominator)
        {
            this.wholeNumber = wholeNumber;
            this.numerator = numerator;
            Denominator = denominator;
            Reduce(numerator, denominator);
        }

        public Fraction(int numerator, int denominator)
        {
            wholeNumber = 0;
            this.numerator = numerator;
            Denominator = denominator;
            //Reduce(numerator, Denominator);
        }

        public Fraction()
        {
            wholeNumber = 0;
            numerator = 0;
            denominator = 1;
        }

        public void Reduce(int numerator, int denominator)
        {
            int gcd = getGCD(numerator, denominator);
            this.numerator /= gcd;
            this.denominator /= gcd;
        }


        private static int getGCD(int a, int b)
        {
            //Drop negative signs
            a = Math.Abs(a);
            b = Math.Abs(b);

            //Return the greatest common denominator between two integers
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            if (a == 0)
                return b;
            else
                return a;
        }



        private static int getLCD(int a, int b)
        {
            //Return the Least Common Denominator between two integers
            return (a * b) / getGCD(a, b);
        }


        public static Fraction operator +(Fraction one, Fraction two)
        {
            int newOneNumerator = (one.denominator * one.wholeNumber) + one.numerator;
            int newTwoNumerator = (two.denominator * two.wholeNumber) + two.numerator;

            int LCD = getLCD(one.denominator, two.denominator);

            newOneNumerator *= LCD / one.denominator;
            newTwoNumerator *= LCD / two.denominator;

            int newNumerator = newOneNumerator + newTwoNumerator;
            int newDenominator = LCD;

            int newWholeNumber = newNumerator / newDenominator;
            newNumerator %= newDenominator;

            return new Fraction(newWholeNumber, newNumerator, newDenominator);
        }

        public static Fraction operator *(Fraction one, Fraction two)
        {
            int newOneNumerator = (one.denominator * one.wholeNumber) + one.numerator;
            int newTwoNumerator = (two.denominator * two.wholeNumber) + two.numerator;

            int newNumerator = newOneNumerator * newTwoNumerator;
            int newDenominator = one.denominator * two.denominator;

            int newWholeNumber = newNumerator / newDenominator;
            newNumerator %= newDenominator;

            return new Fraction(newWholeNumber, newNumerator, newDenominator);
        }

        public override string ToString()
        {
            if (wholeNumber == 0 && numerator == 0)
                return ($"0");
            else if (wholeNumber == 0)
                return ($"{numerator} / {denominator}");
            else if (numerator == 0)
                return ($"{wholeNumber}");
            else
                return ($"{wholeNumber} {numerator} / {denominator}");
        }
    }
}
