using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WypozyczalniaBack;
using WypozyczalniaFront;

namespace WypozyczalniaFront
{
    public static class Ekran
    {
        public static void PokazOpcje()
        {
            Console.WriteLine("Wybierz opcję: \n" +
                "\n" +
                "1 => Lista klientów i samochodów\n" +
                "\n" +
                "2 => Wypożyczenie samochodu\n" +
                "\n" +
                "3 => Menu główne\n" +
                "\n" +
                "4 => Zakończ program\n" +
                "\n" +
                "Wybierz 1,2,3 lub 4:");
            WybierzOpcje();            
        }  
        public static void WybierzOpcje()
        {

            string klawisz = Console.ReadLine();
            while (true)
            {
                int value;
                if (int.TryParse(klawisz,out value))
                {
                    switch (value)
                    {
                        case 1:
                            Opcje.Jeden();
                            break;
                        case 2:
                            Opcje.Dwa();
                            break;
                        case 3:
                            Opcje.Trzy();
                            break;
                        case 4:
                            Opcje.Cztery();
                            break;
                        default:
                            Console.WriteLine("Zły klawisz");
                            System.Threading.Thread.Sleep(500);
                            Console.Clear();
                            PokazOpcje();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy input.");
                    System.Threading.Thread.Sleep(500);
                    Console.Clear();
                    PokazOpcje();
                }
            }
        }
        public static void PokazKlientow()
        {
            Console.WriteLine("Lista klientów: \n" +
                "\n" +
                ("").PadRight(24, '-') +
                "");
            Console.WriteLine(string.Format("|{0,-5}|{1,-25}|{2,-20}","Id","Imię i nazwisko","Data wydania prawa jazdy"));
            WypozyczalniaClients clients = new WypozyczalniaClients();
            foreach (var client in clients.Clients)
            {
                Console.WriteLine(string.Format("|{0,-5}|{1,-25}|{2,-20}",$"{client.ClientId} ", $"{client.FullName} ", $"{client.PrawoJazdy.ToShortDateString()}"));
            }
            Console.WriteLine("\n" +
                "Lista samochodów: \n" +
                "\n" +
                ("").PadRight(24, '-') +
                "");
            Console.WriteLine(string.Format("|{0,-5}|{1,-25}|{2,-20}|{3,-20}|{4,-20}", "Id", "Model", "Segment", "Rodzaj Paliwa", "Cena za dobę"));
            WypozyczalniaCars cars = new WypozyczalniaCars();
            foreach (var Car in cars.Cars)
            {
                Console.WriteLine(string.Format("|{0,-5}|{1,-25}|{2,-20}|{3,-20}|{4,-20}",$"{Car.CarId}", $"{Car.Marka}" ,$"{Car.Segment}" ,$"{Car.Paliwo}" ,$"{Car.Cena} PLN"));
            }
        }
    }
}
   

 
