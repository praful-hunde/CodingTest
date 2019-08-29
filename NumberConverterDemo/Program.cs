using System;
using System.Collections.Generic;
using NumberConverter;

namespace NumberConverterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int testNum = 30;///999_999_999;
            List<string> NumberInWords = new List<string>(testNum);

            for (int i = 999; i <= 1000; i++)
            {
                var str = $"{i} in words is {i.ToWords()}";
                Console.WriteLine(str);
                NumberInWords.Add(str);
            }
           

            
            Console.ReadLine();
        }
    }
}
