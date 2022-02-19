using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tirgul
{
    class Rational
    {
        //feild
        int numerator;
        int denominator;
        int integer;

        //builder
        public Rational(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            Divider();
            Simplifier();
        }

        //functions
        /**adds a rational with another rational
         * a -> rational to add with
         */
        public Rational Addition(Rational a)
        {
            Helper1(a);
            int newDenominator = a.denominator * this.denominator;
            int newNumerator = a.numerator * this.denominator + a.denominator * this.numerator;
            Rational ans = new Rational(newNumerator, newDenominator);
            Helper2(a, ans);
            return ans;
        }
        /**subtracts a rational with another rational
         * a -> rational to sabtracts with
         */
        public Rational Difference(Rational a)
        {
            Helper1(a);
            int newDenominator = a.denominator * this.denominator;
            int newNumerator =Math.Max(a.numerator * this.denominator, a.denominator * this.numerator) - Math.Min(a.denominator * this.numerator, a.numerator * this.denominator) ;
            Rational ans = new Rational(newNumerator, newDenominator);
            Helper2(a, ans);
            return ans;
        }
        /**multiplies a rational with another rational
         * a -> rational to multiply with
         */
        public Rational Multiply(Rational a)
        {
            Helper1(a);
            int newDenominator = a.denominator * this.denominator;
            int newNumerator = a.numerator * this.numerator;
            Rational ans = new Rational(newNumerator, newDenominator);
            Helper2(a, ans);
            return ans;
        }

        /**divides a rational with another rational
         * a -> rational to divide with
         */
        public Rational Divide(Rational a)
        {
            Helper1(a);
            int newNumerator = this.numerator * a.denominator;
            int newDenominator = this.denominator * a.numerator;
            Rational ans = new Rational(newNumerator, newDenominator);
            Helper2(a, ans);
            return ans;
        }


        public double Decimal()
        {
            return (double)integer + ((double)numerator / (double)denominator);
        }

        //tostring
        override
        public string ToString()
        {
            if(numerator != 0){
                if (this.integer > 0)
                {
                    string ans = this.integer + " " + this.numerator + ":" + this.denominator;
                    return ans;
                }
                else
                {
                    string ans = this.numerator + ":" + this.denominator;
                    return ans;
                }
            }
            else
            {
                if (this.integer > 0)
                {
                    string ans = integer.ToString() + ".0";
                    return ans;
                }
                else
                {
                    return "0";
                }
            }
        }




        //helpers
        private void Simplifier()
        {
            int gcd = 1;
            for (int i = 2; i <= Math.Min(numerator,denominator); i++)
            {
                if(numerator % i == 0 && denominator % i == 0 && i > gcd)
                {
                    gcd = i;
                }
            }
            numerator = numerator / gcd;
            denominator = denominator / gcd;
        }  //simplifing the rational
        public void Assembler()
        {
            numerator = numerator + (integer * denominator);
            integer = 0;
        }    //assembling the integers into the rational
        private void Divider()
        {
            Assembler();
            if (denominator != 0)
            {
                if (numerator / denominator >= 1)
                {
                    integer = numerator / denominator;
                    numerator = numerator - (integer * denominator);
                }
            }
        }     //dividing the integer from the rational
        private void Helper1(Rational a)
        {
            Assembler();
            a.Assembler();
        }  //helping to assemble, makes the code shorter
        private void Helper2(Rational a, Rational ans)
        {
            ans.Divider();
            ans.Simplifier();
            Divider();
            a.Divider();
            Simplifier();
            a.Simplifier();
        } //helping to divide and simplify, makes the code shorter


        //getters
        public int GetDenominator()
        {
            return this.denominator;
        }
        public int GetNumerator()
        {
            return this.numerator;
        }

        //setters
        public void SetDenominator(int denominator)
        {
            this.denominator = denominator;
        }
        public void SetNumerator(int numerator)
        {
            this.numerator = numerator;
        }
    }
}
