using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        private static bool dp_possible(int S, int [] coins)
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
    
        public static void Main(string[] args)
        {
            List<int[]> listOfArrays =
                File.ReadLines("INPUT.TXT")
                .Select(line => line.Split(' ').Select(s => int.Parse(s)).ToArray())
                .ToList();
            int[] coins = listOfArrays[1];
            int[] values = listOfArrays[3];
            int i = 0;
            string res = "";
            foreach(int value in values)
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
            File.WriteAllText("OUTPUT.TXT", res);
            Console.WriteLine("done, check file");
        }
    }

}