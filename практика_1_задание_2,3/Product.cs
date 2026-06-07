using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace практика_1_задание_2
{
    class Product
    {
        public decimal price;
        public string name;
        public int count;

        public Product(string Name, decimal Price, int count)
        {
            this.Name = Name;
            this.Price = Price;
            this.Count = count;
        }

        public decimal Price // свойство цены
        {
            get { return price; }
            set { price = value; }
        }

        public string Name // свойство названия
        {
            get { return name; }
            set { name = value; }
        }

        public int Count // свойство кол-ва товара
        {
            get { return count; }
            set { count = value; }
        }
    }
}
