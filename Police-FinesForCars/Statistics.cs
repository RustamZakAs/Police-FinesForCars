using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Police_FinesForCars
{
    public class Statistics
    {
        private Dictionary<string, int> tempFinesTypeDic = new Dictionary<string, int>();

        public Statistics(ref List<Owner> owners)
        {
            //Dictionary<string,int> tempFinesTypeDic = new Dictionary<string,int>();
            for (int i = 0; i < owners.Count; i++)
            {
                for (int j = 0; j < owners[i].MyFines.Count; j++)
                {
                    if (tempFinesTypeDic.Count == 0)
                    {
                        tempFinesTypeDic.Add(owners[i].MyFines[j].Type, 1);
                    }
                    else
                    {
                        if (tempFinesTypeDic.ContainsKey(owners[i].MyFines[j].Type) == false)
                        {
                            tempFinesTypeDic.Add(owners[i].MyFines[j].Type, 1);
                        }
                        else
                        {
                            tempFinesTypeDic[owners[i].MyFines[j].Type]++;
                        }
                    }
                }
            }

            int left = 43, top = 0;
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Персон  в базе данных - {owners.Count}");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Машин   в базе данных - {owners.Sum(x => x.MyCars.Count)}");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Номеров в базе данных - {owners.Sum(x => x.MyDocuments.Sum(y => y.CarSerialNumber?.Count))}");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Штрафов в базе данных - {tempFinesTypeDic.Sum(x => x.Value)}");

            Console.SetCursorPosition(0, 7);

            foreach (var item in tempFinesTypeDic)
            {
                Console.ForegroundColor = GetRandomConsoleColor();
                Console.WriteLine($"{item.Key} - {item.Value}");
                Console.ForegroundColor = default(ConsoleColor);
            }

        }
        private static Random _random = new Random();
        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }
        public void Show(ref List<Owner> owners)
        {
            for (int i = 0; i < owners.Count; i++)
            {
                for (int j = 0; j < owners[i].MyFines.Count; j++)
                {
                    if (tempFinesTypeDic.Count == 0)
                    {
                        tempFinesTypeDic.Add(owners[i].MyFines[j].Type, 1);
                    }
                    else
                    {
                        if (tempFinesTypeDic.ContainsKey(owners[i].MyFines[j].Type) == false)
                        {
                            tempFinesTypeDic.Add(owners[i].MyFines[j].Type, 1);
                        }
                        else
                        {
                            tempFinesTypeDic[owners[i].MyFines[j].Type]++;
                        }
                    }
                }
            }

            int left = 43, top = 0;
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Персон  в базе данных - {owners.Count}");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Машин   в базе данных - {owners.Sum(x => x.MyCars.Count)}");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Номеров в базе данных - {owners.Sum(x => x.MyDocuments.Sum(y => y.CarSerialNumber?.Count))}");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Штрафов в базе данных - {tempFinesTypeDic.Sum(x => x.Value)}");

            Console.SetCursorPosition(0, 7);

            foreach (var item in tempFinesTypeDic)
            {
                Console.ForegroundColor = GetRandomConsoleColor();
                Console.WriteLine($"{item.Key} - {item.Value}");
                Console.ForegroundColor = default(ConsoleColor);
            }
        }
    }
}
