using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BWypozyczalniaBack;
using AWypozyczalniaFront;

namespace AWypozyczalniaFront
{
    public static class Ekran
    {
        public static void PokazOpcje()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1 => Lista klientów i samochodów ");
            Console.WriteLine("2 => Wypożyczenie samochodu");
            Console.WriteLine("3 => Zakończ Program");
            Console.WriteLine("Wybierz 1,2 lub 3:");
            WybierzOpcje();            
        }
        public static void WybierzOpcje()
        {

            string klawisz = Console.ReadLine();

            if (klawisz == "1")
                Opcje.Jeden();
            else if (klawisz == "2")
                Console.WriteLine("haha");
            else if (klawisz == "3")
                Opcje.Trzy();
            else
                Console.WriteLine("Zły klawisz");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            PokazOpcje();
            WybierzOpcje();
           

        }
        public static void PokazKlientow()
        {
            Console.WriteLine("Lista klientów:");
            Console.WriteLine();
            Console.WriteLine(("").PadRight(24, '-'));
            Console.WriteLine();
            Console.WriteLine("|{0,-5}|{1,-25}|{2,-20}","Id","Imię i nazwisko","Data wydania prawa jazdy");
            WypozyczalniaClients clients = new WypozyczalniaClients();
            foreach (var client in clients.Clients)
            {
                Console.WriteLine(string.Format("|{0,-5}|{1,-25}|{2,-20}",$"{client.ClientId} ", $"{client.FullName} ", $"{client.PrawoJazdy.ToString("MM/dd/yyyy")}"));
            }
            Console.WriteLine();
            Console.WriteLine("Lista samochodów:");
            Console.WriteLine();
            Console.WriteLine(("").PadRight(24, '-'));
            Console.WriteLine();
            Console.WriteLine(string.Format("|{0,-5}|{1,-25}|{2,-20}|{3,-20}|{4,-20}", "Id", "Model", "Segment", "Rodzaj Paliwa", "Cena za dobę"));
            WypozyczalniaCars cars = new WypozyczalniaCars();
            foreach (var Car in cars.Cars)
            {
                Console.WriteLine(string.Format("|{0,-5}|{1,-25}|{2,-20}|{3,-20}|{4,-20}",$"{Car.CarId}", $"{Car.Marka}" ,$"{Car.Segment}" ,$"{Car.Paliwo}" ,$"{Car.Cena} PLN"));
            }
        }
    }
}
   

 
