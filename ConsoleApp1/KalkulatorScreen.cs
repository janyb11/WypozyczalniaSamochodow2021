using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BWypozyczalniaBack;

namespace BWypozyczalniaBack
{
    public class KalkulatorScreen
    {
        public static void WypozyczalniaKalkulator()
        {
            Console.Clear();
            Console.WriteLine("Proszę podać Id klienta, który wypożycza samochód:");
            Client WybranyKlient = null;
            WypozyczalniaClients clients = new ();
            WypozyczalniaCars cars = new();
            while (true)
            {
                string input = Console.ReadLine();
                int value;
                if (int.TryParse(input, out value))
                {
                    WybranyKlient = clients.getClientById(value);
                    if (WybranyKlient != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Klient o takim Id nie istnieje.");
                        System.Threading.Thread.Sleep(500);
                        Console.Clear();
                        Console.WriteLine("Proszę podać Id klienta, który wypożycza samochód:");
                    }
                }
                else
                {
                    Console.WriteLine("Niepoprawny input.");
                    System.Threading.Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Proszę podać Id klienta, który wypożycza samochód:");
                }
            }
            Console.Clear();
            Console.WriteLine("1. Mini");
            Console.WriteLine("2. Kompakt");
            var someDate = DateTime.Now;
            var someDate1 = WybranyKlient.PrawoJazdy.Date;
            int difference = someDate.Year - someDate1.Year;
            if (difference >= 4)
            {
                Console.WriteLine("3. Premium");
            }

            Console.WriteLine("Podaj segment samochodu: ");
            string Segment = null;
            bool dobryInput = false;
            while (!dobryInput)
            {
                string input1 = Console.ReadLine();
                int value;
                if (int.TryParse(input1, out value))
                {
                    switch (value)
                    {
                        case 1:
                            Segment = "mini";                               
                            dobryInput = true;
                            break;
                        case 2:
                            Segment = "compact";
                            dobryInput = true;
                            break;
                        case 3:
                            {
                                if (difference >= 4)
                                {
                                    Segment = "premium";
                                    dobryInput=true;
                                    break;
                                }
                                goto default;
                            }
                        default:
                            Console.WriteLine("Opcja o danym numerze nie istnieje.");
                            System.Threading.Thread.Sleep(500);
                            printOpcjeSegment(WybranyKlient);
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Niepoprawny input");
                    System.Threading.Thread.Sleep(500);
                    printOpcjeSegment(WybranyKlient);
                    break;
                }
            }
            Console.Clear();
            Console.WriteLine("1. Benzyna");
            Console.WriteLine("2. Elektryczny");
            Console.WriteLine("3. Diesel");
            Console.WriteLine("Podaj preferowany rodzaj paliwa: ");
            string TypPaliwa = null;
            dobryInput = false;
            while (!dobryInput)
            {
                string input2 = Console.ReadLine();
                int value;
                if (int.TryParse(input2, out value))
                {
                    switch (value)
                    {
                        case 1:
                            TypPaliwa = "benzyna";
                            dobryInput = true;
                            break;
                        case 2:
                            TypPaliwa = "elektryczny";
                            dobryInput = true;
                            break;
                        case 3:
                            TypPaliwa = "diesel";
                            dobryInput = true;
                            break;
                        default:
                            Console.WriteLine("Opcja o danym numerze nie istnieje.");
                            System.Threading.Thread.Sleep(500);
                            printOpcjePaliwo();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Niepoprawny input");
                    System.Threading.Thread.Sleep(500);
                    printOpcjePaliwo();
                    break;
                }
            }
            Console.Clear();
            int dniWynajmu;
            Console.WriteLine("Podaj ilość dni wynajmu pojazdu: ");
            dobryInput = false;
            while (!dobryInput)
            {
                string input3 = Console.ReadLine();
                int value;
                if (int.TryParse(input3, out value))
                {
                    dniWynajmu = value;
                    break;
                }
                else
                {
                    Console.WriteLine("Niepoprawny input");
                    System.Threading.Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Podaj ilość dni wynajmu pojazdu: ");
                }
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime today = DateTime.Now;
            Console.WriteLine("Umowa wynajmu pojazdu");
            Console.WriteLine($"{today.ToShortDateString()}");
            Console.WriteLine(("").PadRight(24, '-'));
            Console.WriteLine($"Wynajmujący/a: {WybranyKlient.FullName}");
            Car WybraneAuto = cars.getCarBySegmentPaliwo(Segment,TypPaliwa);
            Console.WriteLine($"Rodzaj pojazdu: {WybraneAuto.Marka}");
            Console.WriteLine($"Rodzaj paliwa: {TypPaliwa}");
            Console.WriteLine($"Segment: {Segment}");
            Console.WriteLine(("").PadRight(24, '-'));
            Console.WriteLine();









        }

        public static void printOpcjeSegment(Client WybranyKlient)
        {
            Console.Clear();
            Console.WriteLine("1. Mini");
            Console.WriteLine("2. Kompakt");
            var someDate = DateTime.Now;
            var someDate1 = WybranyKlient.PrawoJazdy.Date;
            int difference = someDate.Year - someDate1.Year;
            if (difference >= 4)
            {
                Console.WriteLine("3. Premium");
            }
            Console.WriteLine("Podaj segment samochodu: ");
        }

        public static void printOpcjePaliwo()
        {
            Console.Clear();
            Console.WriteLine("1. Benzyna");
            Console.WriteLine("2. Elektryczny");
            Console.WriteLine("3. Diesel");
            Console.WriteLine("Podaj preferowany rodzaj paliwa: ");
        }

    }
}
