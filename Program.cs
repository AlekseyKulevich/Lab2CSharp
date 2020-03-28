using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Lab2
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
            DateTime date = new DateTime();
            date = DateTime.Now;
            var dateFormats = date.GetDateTimeFormats();
            foreach (var dateFormat in dateFormats)
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();
                foreach (char c in dateFormat)
                {
                    if (Char.IsDigit(c))
                    {
                        if (dict.ContainsKey(c))
                            dict[c]++;
                        else
                            dict[c] = 1;
                    }
                }
                Console.WriteLine(dateFormat);
                foreach (var digit in dict)
                {
                    Console.WriteLine(digit.Key + " " + digit.Value);
                }
                Console.WriteLine("\n\n");
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
