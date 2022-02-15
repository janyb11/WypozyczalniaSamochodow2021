using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AWypozyczalniaFront;

namespace AWypozyczalniaFront
{
    internal class Opcje
    {
        public static void Jeden()
        {
            Console.Clear();
            Ekran.PokazKlientow();
            Console.WriteLine();
            Console.WriteLine(("").PadRight(24, '-'));
            Console.WriteLine();
            Ekran.PokazOpcje();
        }

        public static void Trzy()
        {
            Environment.Exit(0);
        }
    }
}