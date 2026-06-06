using System;

namespace практика_задание_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите сколько будет котов: ");
                int n = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    Cat cat = new Cat("", 0);
                    Console.Write("Введите имя кота: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите вес кота: ");
                    double weight = double.Parse(Console.ReadLine());
                    cat.Name = name;
                    cat.Weight = weight;
                    cat.Meow();
                    cat.Info();
                }
            }
            catch
            {
                Console.WriteLine("Неверный формат для веса");
            }
        }
    }
}
