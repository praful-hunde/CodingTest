using System;
using System.Collections.Generic;
using System.Text;
using NumberConverter;

namespace NumberConverterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stringBuffer = new StringBuilder(2*1024*1024);

            int[] sampleNumbers = new int[] {1,5,10,20,90,99,21,1000,9000,9876,10000,19811,1000000, 25000001,999_999_999 };

            foreach (var number in sampleNumbers)
            {
                stringBuffer.AppendLine($"{number} -> \"{number.ToWords().Trim()}\"");
            }

            Console.WriteLine(stringBuffer.ToString());
            Console.ReadLine();
        }
    }
}
