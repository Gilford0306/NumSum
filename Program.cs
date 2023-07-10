using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace NumSum
{
    internal class Program
    {

        static List<string> strings = new List<string>();
        static int sum = 0;

        private static void ReadNum(object param)
        {
            string str = (string)param;
            strings.AddRange(File.ReadAllLines(str));

        }
        private static void SumNum()
        {
            Thread.Sleep(1);
            foreach (string s in strings)
                sum += int.Parse(s);

            Console.WriteLine(sum);
        }
        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ParameterizedThreadStart(ReadNum));
            th1.Start("C:/Users/Pavel/Desktop/sum.txt");
            Thread th2 = new Thread(SumNum);
            th2.Start();
        }
    }
}
