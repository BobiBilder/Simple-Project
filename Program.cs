using System;

namespace Tirgul
{
    class Program
    {
        //helpers
        public static Rational Maker()
        {
            Console.Write("Enter a numerator: ");
            int numerator = int.Parse(Console.ReadLine());
            Console.Write("Enter a denominator: ");
            int denominator = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return new Rational(numerator, denominator);
        } //Making Rationals, makes the code shorter
        public static bool IsPrime(int x)
        {
            bool prime = true;
            if (x == 1 || x == 2 || x == 3)
            {
                return true;
            }
            for (int i = 2; i < Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                {
                    prime = false;
                }
            }
            return prime;
        } //Chcking if a number is a prime number

        //Questions
        public static void Q2()
        {
            Rational rat1 = Maker();
            Rational rat2 = Maker();
            Console.WriteLine(rat1.ToString() + " + " + rat2.ToString() + " = " + rat1.Addition(rat2));
            Console.WriteLine(" | " + rat1.ToString() + " - " + rat2.ToString() + " | " + " = " + rat1.Difference(rat2));
            Console.WriteLine(rat1.ToString() + " * " + rat2.ToString() + " = " + rat1.Multiply(rat2));
            Console.WriteLine(rat1.ToString() + " / " + rat2.ToString() + " = " + rat1.Divide(rat2));
            Console.WriteLine(rat1.ToString() + " => " + rat1.Decimal());
            Console.WriteLine(rat2.ToString() + " => " + rat2.Decimal());
        }
        public static void Q3()
        {
            Console.Write("Enter the amount of rationals:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Rational sum = Maker();
            for (int i = 1; i < n; i++)
            {
                Rational rat = Maker();
                sum = sum.Addition(rat);
            }
            Console.WriteLine(sum.ToString());
        }
        public static void Q4()
        {
            Console.Write("Enter the amount of rationals:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Rational min = Maker();
            Rational max = min;
            for (int i = 1; i < n; i++)
            {
                Rational rati = Maker();
                if (rati.Decimal() > max.Decimal())
                {
                    max = rati;
                }
                if (rati.Decimal() < min.Decimal())
                {
                    min = rati;
                }
            }
            Console.WriteLine("The Biggest Rational: " + max.ToString());
            Console.WriteLine("The smalles Rational: " + min.ToString());
        }
        public static void Q5()
        {
            int ans = 0;
            Rational rat = Maker();
            while (rat.GetDenominator() != 0)
            {
                Rational rati = Maker();
                if (rati.Decimal() < rat.Decimal())
                {
                    ans++;
                }
                rat.SetDenominator(rati.GetDenominator());
                rat.SetNumerator(rati.GetNumerator());
            }
            Console.WriteLine(ans);
        }
        public static void Q6()
        {
            Console.Write("Enter the amount of rationals:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            string ans = "";
            for (int i = 0; i < n; i++)
            {
                Rational rat = Maker();
                rat.Assembler();
                if (IsPrime(rat.GetNumerator()) || IsPrime(rat.GetDenominator()))
                {
                    if (i < n - 1)
                    {
                        ans = ans + rat.ToString() + ", ";
                    }
                    else
                    {
                        ans = ans + rat.ToString() + ".";
                    }
                }
            }
            Console.WriteLine(ans);
        }

        public static void QAll()
        {
            Console.WriteLine("Q2");
            Q2();
            Console.WriteLine("\r\n" + "Q3");
            Q3();
            Console.WriteLine("\r\n" + "Q4");
            Q4();
            Console.WriteLine("\r\n" + "Q5");
            Q5();
            Console.WriteLine("\r\n" + "Q6");
            Q6();
        } //all the questions together, makes the code shorter
        static void Main(string[] args)
        {
            QAll();
            Console.ReadKey();
        }
    }
}
