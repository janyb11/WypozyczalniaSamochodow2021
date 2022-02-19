using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WypozyczalniaFront;
using WypozyczalniaBack;

namespace WypozyczalniaFront
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
        public static void Dwa()
        {
            Kalkulator.WypozyczalniaKalkulator();
        }
        public static void Trzy()
        {
            Console.Clear();
            Ekran.PokazOpcje();
        }
        public static void Cztery()
        {
            Environment.Exit(0);
        }
    }
}