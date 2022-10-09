using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Program
    {

        static void Main(string[] args)
        {
            int x = 0;
            int k = 0;
            try
            {
                x = ReadNumbers()[0];
                k = ReadNumbers()[1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("FILE IS INCORRECT OR NOT EXISTING! FOLLOW EXAMPLE BELOW!: \n55 10");
                Console.WriteLine(ex.Message);
            }
            Double a = x/5;
            Double result = (Factorial(a + k) / (Factorial(a) * Factorial(k)));
            File.WriteAllTextAsync("OUTPUT.TXT", Convert.ToString(result));
        }

        public static List <int> ReadNumbers()
        {
            using (StreamReader sr = new StreamReader("INPUT.TXT"))
            {
                List<int> a = new List<int>();
                string numbers = sr.ReadToEnd();
                foreach(var number in numbers.Split())
                {
                    a.Add(Convert.ToInt32(number));
                }
                if (a.Count() > 2)
                {
                    Exception ex = new Exception("FILE HAVE INCORRECT FORMAT");
                    throw ex;
                }
                return a;
            }
        }

        public static double Factorial(double a)
        {
            if (a % 1 == 0)
            {
                if (a == 0) return 1;
                if (a > 0)
                {
                    int b = 1;
                    for (int i = 1; i <= a; i++)
                    {
                        b *= i;
                    }
                    return b;
                }
            }
            return double.NaN;
        }
    }
}