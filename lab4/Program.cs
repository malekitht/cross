using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        public static void Main(string[] args)
        {
            string command = "";
            string lab_variant = "";
            string path="";
            string outputpath="";
            while (true)
            {
                command = Console.ReadLine();
                //Console.WriteLine(command);
                if (command == "version")
                {
                    Console.WriteLine("==========================================================\n");
                    Console.WriteLine("Shkoloviy Oleg IPZ-42. Variant 23. Version 1.0 of all labs\n");
                    Console.WriteLine("==========================================================\n");
                }
                if (command.Contains("run"))
                {
                    //Console.WriteLine("which lab  to run? lab1, lab2, lab3");

                    //lab_variant = Console.ReadLine();

                    string a = "run lab2 -i C/DD/aa/ss/dasd.txt";

                    if (command.Contains("-i") && !(command.Contains("--input")))
                    {
                        int len = command.Length;

                        path = command.Substring(12);
                        Console.WriteLine(path);

                    }
                    if (command.Contains("--input"))
                    {
                        int len = command.Length;

                        path = command.Substring(17);
                        Console.WriteLine(path);
                    }
                    if (command.Contains("-o") && !(command.Contains("--output")))
                    {
                        int len = command.Length;

                        outputpath = command.Substring(command.IndexOf("-o") + 3);
                        Console.WriteLine(outputpath);

                    }
                    if (command.Contains("--output"))
                    {
                        int len = command.Length;

                        outputpath = command.Substring(command.IndexOf("--output")+9);
                        Console.WriteLine(outputpath);
                    }
                }

                if (command.Contains("-p"))
                {
                    outputpath = command.Substring(command.IndexOf("-p") + 3)+@"/OUTPUT.TXT";
                    path = command.Substring(command.IndexOf("-p") + 3) + @"/INPUT.TXT";
                }
                if (command.Contains("--path"))
                {
                    outputpath = command.Substring(command.IndexOf("-p") + 7) + @"/OUTPUT.TXT";
                    path = command.Substring(command.IndexOf("-p") + 7) + @"/INPUT.TXT";
                }

                bool swich = false;

                if (command.Contains("lab1"))
                {
                    if (path.Length > 1 & outputpath.Length > 1)
                    {
                        lab1(outputpath, path);
                        swich = true;
                    }
                    if (path.Length > 1 & !(swich))
                    {
                        lab1("OUTPUT.TXT", path);
                    }
                    if (outputpath.Length > 1 & !(swich))
                    {
                        lab1(outputpath, "INPUT.TXT");
                    }

                    else if (path.Length<1 & outputpath.Length<1) lab1("OUTPUT.TXT", "INPUT.TXT");
                }
                if (command.Contains("lab2"))
                {
                    if (path.Length > 1 & outputpath.Length > 1)
                    {
                        lab2(outputpath, path);
                        swich = true;
                    }
                    if (path.Length > 1 & !(swich))
                    {
                        lab2("OUTPUT.TXT", path);
                    }
                    if (outputpath.Length > 1 & !(swich))
                    {
                        lab2(outputpath, "INPUT.TXT");
                    }

                    else if (path.Length < 1 & outputpath.Length < 1) lab2("OUTPUT.TXT", "INPUT.TXT");
                }
                if (command.Contains("lab3"))
                {
                    //call lab3 
                }
                else Console.WriteLine("wrong command line!\n");
                
            }
        }


        public static void lab1([Optional, DefaultParameterValue("OUTPUT.TXT")] string outputpath, [Optional, DefaultParameterValue("INPUT.TXT")] string inputpath)
        {
            int x = 0;
            int k = 0;
            try
            {
                x = ReadNumbers(inputpath)[0];
                k = ReadNumbers(inputpath)[1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("FILE IS INCORRECT OR NOT EXISTING! FOLLOW EXAMPLE BELOW!: \n55 10");
                Console.WriteLine(ex.Message);
            }
            Double a = x / 5;
            Double result = (Factorial(a + k) / (Factorial(a) * Factorial(k)));
            File.WriteAllTextAsync(outputpath, Convert.ToString(result));

        }

        public static void lab2([Optional, DefaultParameterValue("OUTPUT.TXT")] string outputpath, [Optional, DefaultParameterValue("INPUT.TXT")] string inputpath)
        {
            List<int[]> listOfArrays =
               File.ReadLines(inputpath)
               .Select(line => line.Split(' ').Select(s => int.Parse(s)).ToArray())
               .ToList();
            int[] coins = listOfArrays[1];
            int[] values = listOfArrays[3];
            int i = 0;
            string res = "";
            foreach (int value in values)
            {
                bool a = false;
                if (values.Length > 1)
                {
                    if (!(coins.Contains(value)))
                    {
                        if (dp_possible(values[i], coins))
                        {
                            a = true;
                        }
                    }
                    else if (coins.Contains(value)) a = true;

                    i++;
                    if (a) res = res + "1 "; else res = res + "0 ";
                }
                else if (!coins.Contains(values[0])) res = "0";
                else Console.WriteLine("File have incorrect format");
            }
            File.WriteAllText(outputpath, res);
            Console.WriteLine("done, check file");
        }

        public static List<int> ReadNumbers(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                List<int> a = new List<int>();
                string numbers = sr.ReadToEnd();
                foreach (var number in numbers.Split())
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

        private static bool dp_possible(int S, int[] coins)
        {
            var A = new List<bool>() { true };
            A.AddRange(Enumerable.Repeat(false, S));

            foreach (var c in coins)
            {
                foreach (var i in Enumerable.Range(0, S + 1 - c))
                {
                    if (A[i])
                    {
                        A[i + c] = true;
                    }
                }
            }
            return A[S];
        }

    }
}