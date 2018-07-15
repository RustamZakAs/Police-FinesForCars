using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Police_FinesForCars
{
    [DataContract]
    public class Cars
    {
        [DataMember]
        public string SerialNumber { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string Marka { get; set; }
        [DataMember]
        public string Make { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public string CarType { get; set; }    //Тип магины (Sedan Jeep)
        [DataMember]
        public int Year { get; set; }          //Год выпуска
        [DataMember]
        public int Doors { get; set; }         //Количество дверей
        [DataMember]
        public int Seats { get; set; }         //Количество сидячих мест
        [DataMember]
        public string BodyNumber { get; set; }    //Номер кузова
        [DataMember]
        public string EngineNumber { get; set; }  //Номер двигателя

        public Cars()
        {

        }

        public Cars(string serial_number, string model, string marka, string make, string color, string carType, int year, int doors, int seats, string bodyNumber, string engineNumber)
        {
            SerialNumber = serial_number ?? throw new ArgumentNullException(nameof(serial_number));
            Model = model ?? throw new ArgumentNullException(nameof(model));
            Marka = marka ?? throw new ArgumentNullException(nameof(marka));
            Make = make ?? throw new ArgumentNullException(nameof(make));
            Color = color ?? throw new ArgumentNullException(nameof(color));
            CarType = carType ?? throw new ArgumentNullException(nameof(carType));
            Year = year;
            Doors = doors;
            Seats = seats;
            BodyNumber = bodyNumber ?? throw new ArgumentNullException(nameof(bodyNumber));
            EngineNumber = engineNumber ?? throw new ArgumentNullException(nameof(engineNumber));
        }

        public void Add()
        {
            Console.WriteLine("Please Insert Car Information");
            Console.WriteLine("Maşını nömrəsi: ");
            SerialNumber = Console.ReadLine();
            Console.WriteLine("Model: ");
            Model = Console.ReadLine();
            Console.WriteLine("Marka: ");
            Marka = Console.ReadLine();
            Console.WriteLine("Rəngi: ");
            Color = Console.ReadLine();
            Console.WriteLine("İstehsalçı ölkə: ");
            Make = Console.ReadLine();
            Console.WriteLine("Növü: ");
            CarType = Console.ReadLine();
            Console.WriteLine("İli: ");
            Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Qapıların sayı: ");
            Doors = int.Parse(Console.ReadLine());
            Console.WriteLine("Oturacaqların sayı: ");
            Seats = int.Parse(Console.ReadLine());
            Console.WriteLine("Kuzanın nömrəsi: ");
            BodyNumber = Console.ReadLine();
            Console.WriteLine("Motorun nömrəsi: ");
            EngineNumber = Console.ReadLine();
        }
        public override string ToString()
        {
            return $"{ SerialNumber } { Model } { Marka } { Make } {Color} { CarType } { Year } { Doors } { Seats } { BodyNumber } { EngineNumber }";
        }
    }
}
