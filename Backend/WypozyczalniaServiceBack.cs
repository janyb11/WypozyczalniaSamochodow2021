using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaBack
{
    public class Client
    {
        public Client(int clientId, string fullName, DateTime prawoJazdy)
        {
            ClientId = clientId;
            FullName = fullName;
            PrawoJazdy = prawoJazdy;

        }
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public DateTime PrawoJazdy { get; set; }
        

    }
    public class Car
    {
        public Car(int carId, string marka,string segment, string paliwo, decimal cena)
        {
            CarId = carId;
            Marka = marka;
            Segment = segment;
            Paliwo = paliwo;
            Cena = cena;

        }
        public int CarId { get; set; }
        public string Marka { get; set; }
        public string Segment { get; set; }
        public string Paliwo { get; set; }
        public decimal Cena { get; set; }

    }
}
