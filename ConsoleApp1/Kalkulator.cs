using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WypozyczalniaBack;
using WypozyczalniaFront;

namespace WypozyczalniaBack
{
    public class Kalkulator
    {
        public static void WypozyczalniaKalkulator()
        {
            Console.Clear();
            Console.WriteLine("Proszę podać Id klienta, który wypożycza samochód:");
            Client WybranyKlient = null;
            WypozyczalniaClients clients = new();
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
            string Segment = null;
            var someDate = DateTime.Now;
            var someDate1 = WybranyKlient.PrawoJazdy.Date;
            int difference = someDate.Year - someDate1.Year;
            if (difference >= 4)
            {
                Console.WriteLine("3. Premium");
            }
            Console.WriteLine("Podaj segment samochodu: ");
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
                            Segment = "kompakt";
                            dobryInput = true;
                            break;
                        case 3:
                            {
                                if (difference >= 4)
                                {
                                    Segment = "premium";
                                    dobryInput = true;
                                    break;
                                }
                                goto default;
                            }
                        default:
                            Console.WriteLine("Opcja o danym numerze nie istnieje.");
                            System.Threading.Thread.Sleep(500);
                            Console.Clear();
                            printOpcjeSegment(WybranyKlient);
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Niepoprawny input");
                    System.Threading.Thread.Sleep(500);
                    Console.Clear();
                    printOpcjeSegment(WybranyKlient);
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
                }
            }
            Console.Clear();
            int dniWynajmu = 1;
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
            Car WybraneAuto = null;
            while (true)
            {
                WybraneAuto = cars.getCarBySegmentPaliwo(Segment, TypPaliwa);
                if (WybraneAuto == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Console.WriteLine("Auto o danych parametrach nie znajduję się w naszej przechowywalni, prosze wybrać ponownie: ");
                    System.Threading.Thread.Sleep(2000);
                    printWyborSegment(WybranyKlient,ref Segment);
                    printWyborPaliwo(ref TypPaliwa);
                    
                }
                else
                {
                    break;
                }
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime today = DateTime.Now;
            Console.WriteLine("UMOWA WYNAJMU POJAZDU");
            Console.WriteLine();
            Console.WriteLine($"Data zawarcia: {today.ToShortDateString()}");
            Console.WriteLine();
            Console.WriteLine(("").PadRight(24, '-'));
            Console.WriteLine();
            Console.WriteLine($"Wynajmujący/a: {WybranyKlient.FullName}");
            Console.WriteLine();
            Console.WriteLine($"Rodzaj pojazdu: {WybraneAuto.Marka}");
            Console.WriteLine();
            Console.WriteLine($"Rodzaj paliwa: {TypPaliwa}");
            Console.WriteLine();
            Console.WriteLine($"Segment: {Segment}");
            Console.WriteLine();
            Console.WriteLine(("").PadRight(24, '-'));
            Console.WriteLine();
            int dniWynajmuGratis = 1;
            if (dniWynajmu > 30)
            {
                dniWynajmuGratis = dniWynajmu + 3;
            }
            else if (dniWynajmu > 7)
            {
                dniWynajmuGratis = dniWynajmu + 1;
            }
            DateTime zwrot = today.AddDays(dniWynajmuGratis);
            Console.WriteLine($"Data zwrotu pojazdu: {zwrot.ToString("dd/MM/yyyy")}");
            Console.WriteLine();
            decimal opłata = WybraneAuto.Cena * dniWynajmu;
            decimal dopłata = 1.2m;
            if (difference > 4)
                opłata = Decimal.Multiply(opłata, dopłata);
            Console.WriteLine($"Opłata: {opłata} PLN");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Ekran.PokazOpcje();

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

        public static void printWyborSegment(Client WybranyKlient,ref string Segment)
        {
            Console.ForegroundColor = ConsoleColor.White;
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
                            Segment = "kompakt";
                            dobryInput = true;
                            break;
                        case 3:
                            {
                                if (difference >= 4)
                                {
                                    Segment = "premium";
                                    dobryInput = true;
                                    break;
                                }
                                goto default;
                            }
                        default:
                            Console.WriteLine("Opcja o danym numerze nie istnieje.");
                            System.Threading.Thread.Sleep(500);
                            printOpcjeSegment(WybranyKlient);
                            return;

                    }
                }
                else
                {
                    Console.WriteLine("Niepoprawny input");
                    System.Threading.Thread.Sleep(500);
                    printOpcjeSegment(WybranyKlient);
                    return;
                }
            }
        }
        public static void printWyborPaliwo(ref string TypPaliwa)
        {   Console.Clear();
            Console.WriteLine("1. Benzyna");
            Console.WriteLine("2. Elektryczny");
            Console.WriteLine("3. Diesel");
            Console.WriteLine("Podaj preferowany rodzaj paliwa: ");
            bool dobryInput = false;
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
                }
            }
            Console.Clear();
            int dniWynajmu = 1;
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
        }
    }
}    
