using System;

namespace PowerShellFractions
{
    public class Fraction
    {
        private int _numerator;
        private int _denominator;

        public int Numerator
        {
            get => _numerator;
            set
            {
                _numerator = value;
                FixNegatives();
                Simplify();
            }
        }
        public int Denominator
        {
            get => _denominator;
            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator can't be zero!");
                }
                _denominator = value;
                FixNegatives();
                Simplify();
            }
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0) throw new ArgumentException("Denominator can't be zero!", nameof(denominator));

            _numerator = numerator;
            _denominator = denominator;
            FixNegatives();
            Simplify();
        }

        public void Simplify()
        {
            int d = GCD(Numerator, Denominator);
            _numerator /= d;
            _denominator /= d;
        }

        public void FixNegatives()
        {
            if (Denominator < 0)
            {
                _numerator *= -1;
                _denominator *= -1;
            }
        }

        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.Numerator, a.Denominator);

        public static Fraction operator +(Fraction a, Fraction b)
            => new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);

        public static Fraction operator -(Fraction a, Fraction b)
            => a + (-b);

        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static int GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            return GCD(b, a % b);
        }
    }
}
