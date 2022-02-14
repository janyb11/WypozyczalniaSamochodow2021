using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BWypozyczalniaBack;

namespace AWypozyczalniaFront
{
    public static class Ekran
    {
        public static void PokazOpcje()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1 => Lista klientów i samochodów");
            Console.WriteLine("2 => Wypożyczenie samochodu");
            Console.WriteLine("3 => Zakończ Program");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Wybierz 1,2 lub 3:");
            Console.ReadLine();
        }
    }
}
   

 
