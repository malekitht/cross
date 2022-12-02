using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {

        static void Main(string[] args)
        {
            List<int> result = new List<int>();
            List<List<int>> data = new List<List<int>>();
            int q = -1;
            int w = 999;
            int e = 999;
            using (StreamReader sr = new StreamReader("INPUT.TXT"))
            {
                while (!sr.EndOfStream)
                {
                    if (q == w)
                    {
                        result.Add(DoStuff(data, w, e));
                        data.Clear();
                        q = -1;
                    }
                    List<int> kek = new List<int>();
                    string line = sr.ReadLine();
                    if (line.Length < 2)
                    {
                        //Console.WriteLine("ERROR WITH FILE FORMAT!");
                        break;
                    }
                    foreach (string number in line.Split())
                    {
                        int x = Convert.ToInt32(number);
                        kek.Add(x);
                    }
                    data.Add(new List<int>{ kek[0], kek[1] });
                    if (q == -1)
                    {
                        w=kek.Last();
                        e = kek.FirstOrDefault();
                    }
                    q++;
                    kek.Clear();
                }
            }

            TextWriter tw = new StreamWriter("OUTPUT.TXT");

            foreach (int s in result)
                tw.WriteLine(Convert.ToString( s));

            tw.Close();

        }
        public static int DoStuff(List<List<int>> list, int length, int nEEEE)
        {
            int nV, nE;
            nV = nEEEE;
            nE = length;
            const int INF = 1000000000;
            int[,] d = new int[nV, nV];
            for (int i = 0; i < nV; i++)
            {
                for (int j = 0; j < nE; j++)
                {
                    d[i, j] = INF;
                }
            }
            for (int i = 0; i < nV; i++)
            {
                d[i, i] = 0;
            }
            for (int i = 0; i <= nE; i++)
            {
                for (int j =0; j < list[i].Count(); j++)
                {
                    int v1, v2;
                    //Console.WriteLine("Enter v1");
                    v1 = list[i][0];
                    //Console.WriteLine("Enter v2");
                    v2 = list[i][1];
                    v1--;
                    v2--;
                    d[v1, v2] = 0;
                    d[v2, v1] = Math.Min(d[v2, v1], 1);
                }

            }
            for (int k = 0; k < nV; k++)
            {
                for (int i = 0; i < nV; i++)
                {
                    for (int j = 0; j < nV; j++)
                    {
                        d[i, j] = Math.Min(d[i, j], d[i, k] + d[k, j]);
                    }
                }
            }
            int max = 0;
            for (int i = 0; i < nV; i++)
            {
                for (int j = 0; j < nV; j++)
                {
                    max = Math.Max(max, d[i, j]);
                }
            }
            Console.WriteLine(max);
            return max;
           
        }
    }

}