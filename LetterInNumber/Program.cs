using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LetterInNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("please input the number array splited by ',',for example:'0,1,2,4,5'.");

            Console.WriteLine("----------------------------------");

            string numbers = string.Empty;

            List<string> inputNumbers = new List<string>();

            string regPattern = @"^\d{1,2}$";

            while (true)
            {
                numbers = Console.ReadLine();

                inputNumbers = numbers.Split(",").ToList();

                if (inputNumbers.Any(x => !Regex.IsMatch(x, regPattern)))
                {
                    Console.WriteLine("please input the numbers between [0-99] again:");
                }
                else break;
            }


            //process the number large than 10, e.g  23 will be 2 and 3
            List<string> realNumbers = new List<string>();

            foreach (var num in inputNumbers)
            {
                if (num.Length == 1)
                    realNumbers.Add(num);
                else
                    num.ToCharArray().ToList().ForEach(x => realNumbers.Add(x.ToString()));

            }

            var distinctNumbers = realNumbers.Distinct();

            bool filterDuplicate = false;

            if (distinctNumbers.Count() < realNumbers.Count)
            {
                Console.WriteLine("do you want to filter the  duplicated numbers:[Y/N]");

                filterDuplicate = Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase);
            }

            var result = Common.GetCombinations(numbers, filterDuplicate);

            Console.WriteLine("----------------------------------");

            Console.WriteLine("the number mappings you input ars:");


            foreach (var item in result.Item1)
            {
                Console.WriteLine($"{item.Number}:{item.Letters}");
            }

            Console.WriteLine("----------------------------------");


            Console.WriteLine("the result of the combinations are:");

            Console.WriteLine(result.Item2);

            Console.ReadKey();

        }
    }


}
