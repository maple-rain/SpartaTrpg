using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teast
{
    internal class FileName
    {
        static void PrintLine()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("=");
            }
            Console.WriteLine();
        }

        static void Start(string[] args)
        {
            PrintLine();
        }
    }
}
