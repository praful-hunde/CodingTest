using System;

namespace NumberConverter
{
    public static class IntegerExtension
    {
        static readonly int maxNumber = 999_999_999;

        static readonly string[] name_0_to_9 = new string[] { " Zero", " One", " Two", " Three", " Four", " Five", " Six", " Seven", " Eight", " Nine" };
        static readonly string[] name_10_To_90 = new string[] { " Zero", " Ten", " Twenty", " Thirty", " Fourty", " Fifty", " Sixty", " Seventy", " Eighty", " Ninty" };
        static readonly string[] name_10_To_19 = new string[] { " Ten", " Eleven", " Tweleve", " Thirteen", " Fourteen", " Fifteen", " Sixteen", " Sevnteen", " Eighteen", " Ninteen" };

        public static string ToWords(this int number)
        {
            string numInWords = String.Empty;

            if (number > maxNumber)
            {
                throw new NotSupportedException($"Number greater than {maxNumber} is not supported.");
            }

            if (number < 0)
            {
                numInWords = "Minus ";
                number = Math.Abs(number);
            }

            if (number < 10)
            {
                numInWords += name_0_to_9[number];
                return numInWords;
            }

            if (number >= 10 && number < 20)
            {
                numInWords += name_10_To_19[number - 10];
                return numInWords;
            }

            int remainder, quotent;
            numInWords += number.ToWords(1000000, out remainder,out quotent);

            if (remainder != 0)
                numInWords += number.ToWords(1000, out remainder, out quotent);

            if (remainder != 0)
                numInWords += number.ToWords(100, out remainder, out quotent);

            if (remainder != 0)
            {
                if (number > 9 && number < 20) // 10 to 19
                {
                }
                else
                    numInWords += number.ToWords(10, out remainder, out quotent);
            }

            if (remainder != 0)
            {
                numInWords += number.ToWords();
            }

            return numInWords;
        }

        /// <summary>
        /// Private extension method
        /// </summary>
        /// <param name="number"></param>
        /// <param name="divisor"></param>
        /// <param name="remainder"></param>
        /// <param name="quotient"></param>
        /// <returns></returns>
        private static string ToWords(ref this int number, int divisor, out int remainder,out int quotient)
        {
            string numInWords = String.Empty;
            quotient = Math.DivRem(number, divisor, out remainder);

            if (quotient > 0)
            {
                if (divisor == 10)
                    numInWords = GetName(divisor, quotient * 10, remainder);
                else
                    numInWords = quotient.ToWords() + GetName(divisor, number, remainder);

                number = remainder;
            }

            return numInWords;
        }

        private static string GetName(int divisor, int number, int remainder)
        {
            string name = String.Empty;

            switch (divisor)
            {
                case 1000000:
                    name = " Million";
                    break;
                case 1000:
                    name = " Thousand";
                    break;
                case 100:
                    name = " Hundred";
                    break;
                case 10:
                    name = name_10_To_90[number / 10];
                    break;
                default:
                    break;
            }

            return name;
        }
    }
}
