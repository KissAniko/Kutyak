using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sorok = File.ReadAllLines("Datas\\Kutyak.csv");
            foreach ( var sor in sorok)
            {
                Console.WriteLine(sor);
            }
        }
    }
}
