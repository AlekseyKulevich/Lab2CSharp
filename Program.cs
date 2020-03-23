using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace lab2_lesha
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                int choose;
                Console.WriteLine("1 - Date\n2 - UpperCaseSymbols\n3 - Monthes\n");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                    if (choose < 1 || choose > 3)
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect input");
                   
                    continue;
                }

                switch (choose)
                {
                    case 1:
                        DateTask();
                        break;
                    case 2:
                        UpperCaseSymbols();
                        break;
                    case 3:
                        Monthes();
                        break;
                }
                Console.ReadLine();
            }

        }

        public static void DateTask()
        {
            OutPut("G");
            OutPut("F");
        }
        public static void OutPut(string c)
        {
            int[] Numbers = new int[10];
            DateTime Time = DateTime.Now;
            Console.WriteLine(Time.ToString(c));
            string TimeTwo = Time.ToString();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < TimeTwo.Length; j++)
                {
                    int digit = (int)(TimeTwo[j]);
                    if (digit == i + 48)
                    {
                        Numbers[i]++;
                    }

                }
                Console.WriteLine($"\nКоличество {i}: {Numbers[i]}");
            }
         
        }

        public static void UpperCaseSymbols()
        {
            Console.Write("Input string: ");
            string str = Console.ReadLine();
            foreach (char c in str)
            {
                if (Char.IsUpper(c) && !(c >= 'A' && c <= 'Z'))
                {
                    Console.Write(c);
                }
            }
        }

        public static void Monthes()
        {
            Console.WriteLine("Input culture(example ru, en, fr, de): ");
            string cultureSymbol = Console.ReadLine();
            try
            {
                CultureInfo culture = new CultureInfo(cultureSymbol);
                if (!CultureInfo.GetCultures(CultureTypes.AllCultures).Contains(culture))
                    throw new Exception();
                foreach (var month in culture.DateTimeFormat.MonthNames)
                {
                    Console.WriteLine(month);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect culture");
            }
        }
    }
}