using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Police_FinesForCars
{
    class Cars
    {
        public string Model { get; set; }        
        public string Make { get; set; }
        public string CarType { get; set; }    //Тип магины (Sedan Jeep)
        public int Year { get; set; }          //Год выпуска
        public int Doors { get; set; }         //Количество дверей
        public int Seats { get; set; }         //Количество сидячих мест
        public int BodyNumber { get; set; }    //Номер кузова
        public int EngineNumber { get; set; }  //Номер двигателя

        public Cars()
        {
        }

        public Cars(string model, string make, string carType, int year, int doors, int seats, int bodyNumber, int engineNumber)
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

        void AddCar()
        {
            Console.WriteLine("Please Insert Car Information");
            Console.WriteLine("Model: ");
            Model = Console.ReadLine(); 

        }

    }
}
