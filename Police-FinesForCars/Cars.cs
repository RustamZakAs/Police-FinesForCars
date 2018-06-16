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
        public string Model { get; set; }
        [DataMember]
        public string Marka { get; set; }
        [DataMember]
        public string Make { get; set; }
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

        public Cars(string model, string make, string carType, int year, int doors, int seats, string bodyNumber, string engineNumber)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
            Make = make ?? throw new ArgumentNullException(nameof(make));
            CarType = carType ?? throw new ArgumentNullException(nameof(carType));
            Year = year;
            Doors = doors;
            Seats = seats;
            BodyNumber = bodyNumber;
            EngineNumber = engineNumber;
        }

        public void AddCar()
        {
            Console.WriteLine("Please Insert Car Information");
            Console.WriteLine("Model: ");
            Model = Console.ReadLine();
            Console.WriteLine("Marka: ");
            Marka = Console.ReadLine();
            Console.WriteLine("İstehsalçı ölkə: ");
            Make = Console.ReadLine();
            Console.WriteLine("Növü: ");
            CarType = Console.ReadLine();
            Console.WriteLine("İli: ");
            Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Qapıların sayı: ");
            Doors = int.Parse(Console.ReadLine());
            Console.WriteLine("Qapıların sayı: ");
            Seats = int.Parse(Console.ReadLine());
            Console.WriteLine("Qapıların sayı: ");
            BodyNumber = Console.ReadLine();
            Console.WriteLine("Qapıların sayı: ");
            EngineNumber = Console.ReadLine();
        }

    }
}
