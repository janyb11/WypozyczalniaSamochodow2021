using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AWypozyczalniaFront;
using BWypozyczalniaBack;

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

        public static void Dwa()
        {
            KalkulatorScreen.WypozyczalniaKalkulator();
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