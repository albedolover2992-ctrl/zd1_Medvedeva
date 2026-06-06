using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практика_задание_1
{
    class Cat
    {
        // Поля
        private string name;
        private double weight;

        List<Cat> cats = new List<Cat>();  // Лист для котов вводимых в цикле

        public Cat(string CatName, double CatWeight)
        {
            Name = CatName;
            Weight = CatWeight;
            cats.Add(this);
        }

        public void Meow()
        {
            Console.WriteLine($"{name}: МЯУ ");
        }

        public void Info ()
        {
            Console.WriteLine($"{name} - {weight}");
        }

        public string Name
        {
            get { return name; }
            set
            {
                bool OnlyLetters = true;

                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        OnlyLetters = false;
                    }
                }

                if (OnlyLetters)
                    name = value;
                else
                    Console.WriteLine($"{value} - неправильное имя");
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                bool Right = false ;
                if (value > 0 && value < 25)
                {
                    Right = true;
                }

                if (Right)
                    weight = value;
                else
                {
                    Console.WriteLine($"{value} - неверное значение");
                    weight = 5.0;
                }

            }
        }
    }
}
