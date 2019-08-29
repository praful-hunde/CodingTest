using System;

namespace NumberConverter
{
    public static class IntegerExtension
    {
        static readonly int maxNumber = 999_999_999;
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
                switch (number)
                {
                    case 0:
                        numInWords = "Zero";
                        break;
                    case 1:
                        numInWords = "One";
                        break;
                    case 2:
                        numInWords = "Two";
                        break;
                    case 3:
                        numInWords = "Three";
                        break;
                    case 4:
                        numInWords = "Four";
                        break;
                    case 5:
                        numInWords = "Five";
                        break;
                    case 6:
                        numInWords = "Six";
                        break;
                    case 7:
                        numInWords = "Seven";
                        break;
                    case 8:
                        numInWords = "Eight";
                        break;
                    case 9:
                        numInWords = "Nine";
                        break;
                    default:
                        break;
                }
            }

            if (number > 9 && number < 20)
            {
                switch (number)
                {
                    case 10:
                        numInWords = "Ten";
                        break;
                    case 11:
                        numInWords = "Eleven";
                        break;
                    case 12:
                        numInWords = "Twelve";
                        break;
                    case 13:
                        numInWords = "Thirteen";
                        break;
                    case 14:
                        numInWords = "Fourteen";
                        break;
                    case 15:
                        numInWords = "Fifteen";
                        break;
                    case 16:
                        numInWords = "Sixteen";
                        break;
                    case 17:
                        numInWords = "Seventeen";
                        break;
                    case 18:
                        numInWords = "Eighteen";
                        break;
                    case 19:
                        numInWords = "Nineteen";
                        break;
                }
            }


            ///10 Ten                2     1
            ///100 Hundred           3     2
            ///1000 - Thousand       4     3
            ///1000000 - Million     7     6
            int remainder;
            numInWords += " " + number.ToWords(1000000, out remainder);

            if(remainder != 0)
            numInWords += " " + number.ToWords(1000, out remainder);

            if (remainder != 0)
                numInWords += " " + number.ToWords(100,out remainder);

            if (remainder != 0)
            numInWords += " " + number.ToWords(10,out remainder);

            return numInWords;
        }

        private static string ToWords(this int number,int divisor , out int remainder)
        {
            string numInWords = String.Empty;
            int quotient = Math.DivRem(number, divisor, out remainder);

            if (quotient > 0)
            {
                numInWords = quotient.ToWords() + GetName(divisor,number,remainder);
            }

            return numInWords;
        }

        private static string GetName(int divisor,int number,int remainder)
        {
            string name = String.Empty;

            switch (divisor)
            {
                case 1000000:
                    name = "Million";
                    break;
                case 1000:
                    name = "Thousand";
                    break;
                case 100:
                    name = "Hundred";
                    break;
                case 10:
                    GetNameForTens(number - remainder);
                    break;
                default:
                    break;
            }

            return name;
        }


        private static string GetNameForTens(int number)
        {
            string numInWords = String.Empty;
            
            switch (number)
            {
                case 20:
                    numInWords = "Twenty";
                    break;
                case 30:
                    numInWords = "Thirty";
                    break;
                case 40:
                    numInWords = "Fourty";
                    break;
                case 50:
                    numInWords = "Fifty";
                    break;
                case 60:
                    numInWords = "Sixty";
                    break;
                case 70:
                    numInWords = "Seventy";
                    break;
                case 80:
                    numInWords = "Eighty";
                    break;
                case 90:
                    numInWords = "Ninety";
                    break;

            }

            return numInWords;
        }
    }
}
