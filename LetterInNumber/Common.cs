using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetterInNumber
{
    public static class Common
    {
        public static List<string> ListCombin(this List<string> current, string newOne)
        {

            List<string> result = new List<string>();

            if (current.Count == 0)
            {
                foreach (char letter in newOne.ToCharArray())
                {
                    result.Add(letter.ToString());
                }
            }


            foreach (string item in current)
            {
                foreach (char letter in newOne.ToCharArray())
                {
                    string newItem = new string(item.Append(letter).ToArray());
                    result.Add(newItem);
                }
            }
            return result;
        }

        public static List<string> GetCombinations(List<NumberLetter> numberLetters)
        {
            List<string> currentStrs = new List<string>();

            foreach (char item in numberLetters[0].Letters.ToCharArray())
            {
                currentStrs.Add(item.ToString());
            }

            int index = 0;
            while (index < numberLetters.Count - 1)
            {
                currentStrs = currentStrs.ListCombin(numberLetters[index + 1].Letters);
                index++;
            }

            return currentStrs;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="filterDuplicate">filter the input number any duplicated</param>
        /// <returns></returns>
        public static (List<NumberLetter>, string) GetCombinations(string numbers, bool filterDuplicate)
        {

            List<string> realInputNumber = new List<string>();

            List<string> inputNumbers = numbers.Split(",").ToList();

            foreach (var num in inputNumbers)
            {
                if (num.Length == 1)
                    realInputNumber.Add(num);
                else
                    num.ToCharArray().ToList().ForEach(x => realInputNumber.Add(x.ToString()));

            }

            List<NumberLetter> numberLetters = new List<NumberLetter>();

            List<NumberLetter> initData = Common.GetInitNumberLetters();

            if (filterDuplicate)
            {
                numberLetters = initData.Where(x => realInputNumber.Contains(x.Number)).ToList();
            }
            else
            {
                foreach (var inputNumber in realInputNumber)
                {
                    NumberLetter item = initData.FirstOrDefault(x => x.Number == inputNumber);
                    numberLetters.Add(item);
                }
            }


            List<string> currentStrs = new List<string>();

            foreach (char item in numberLetters[0].Letters.ToCharArray())
            {
                currentStrs.Add(item.ToString());
            }

            int index = 0;
            while (index < numberLetters.Count - 1)
            {
                currentStrs = currentStrs.ListCombin(numberLetters[index + 1].Letters);
                index++;
            }

            string result = string.Join(",", currentStrs);

            return (numberLetters, result);

        }



        public static List<NumberLetter> GetInitNumberLetters()
        {
            List<NumberLetter> reslut = new List<NumberLetter>();

            List<NumberLetter> singelNumberLetters = new List<NumberLetter>()
            {
                new NumberLetter(){ Number="0",Letters="0" },
                new NumberLetter(){ Number="1",Letters="1" },
                new NumberLetter(){ Number="2",Letters="ABC" },
                new NumberLetter(){ Number="3",Letters="DEF" },
                new NumberLetter(){ Number="4",Letters="GHI" },
                new NumberLetter(){ Number="5",Letters="JKL" },
                new NumberLetter(){ Number="6",Letters="MNO" },
                new NumberLetter(){ Number="7",Letters="PQLS" },
                new NumberLetter(){ Number="8",Letters="TUV" },
                new NumberLetter(){ Number="9",Letters="WXYZ" },

            };

            reslut.AddRange(singelNumberLetters);

            //for (int i = 10; i < 100; i++)
            //{
            //    NumberLetter numberLetter = new NumberLetter();
            //    numberLetter.Number = i.ToString();
            //    foreach (char singleNumber in numberLetter.Number.ToCharArray())
            //    {
            //        string number = singleNumber.ToString();
            //        string letters = singelNumberLetters.FirstOrDefault(x => x.Number == number).Letters;
            //        numberLetter.Letters += letters;
            //    }

            //    reslut.Add(numberLetter);
            //}

            return reslut;

        }


    }
}
