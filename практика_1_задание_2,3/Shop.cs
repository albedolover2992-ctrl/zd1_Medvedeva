using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практика_1_задание_2
{
    class Shop
    {
        private static Dictionary<Product, int> products; // Список продуктов
        public static decimal profit;  // Прибыль

        public Shop()
        {
            products = new Dictionary<Product, int>();
            profit = 0;
        }

        public static string WriteAllProducts()  // Вывести данные о всех продуктах
        {
            string info = "Лист товаров пуст";
            if (products.Count != 0)
            {
                info = "";
                foreach (KeyValuePair<Product, int> pair in products)
                {
                    info += $"Наименование: {pair.Key}, Кол-во товаров: {pair.Value}\n";
                }
            }
            return info;
        }

        public static void CreateProduct(string name, decimal price, int count)  // Создание продукта и добавление его в словарь
        {
            products.Add(new Product(name, price), count);
        }

        public static void Sell(Product product)  // Продажа продукта
        {
            if (products.ContainsKey(product))
            {
                if (products[product] == 0)
                {
                    Console.WriteLine("Нет в наличии!");
                }
                else
                {
                    products[product]--;
                    profit += products[product];
                }
            }
            else
            {
                Console.WriteLine("Товар не найден!");
            }
        }

        public static Product FindByName(string name)  // Поиск товара
        {
            foreach (var product in products.Keys)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;
        }

        public static void Sell(string ProductName)  // Перегрузка метода
        {
            Product ToSell = Shop.FindByName(ProductName);
            if (ToSell != null)
            {
                Shop.Sell(ToSell);
            }
            else
            {
                Console.WriteLine("Товар не найден!");
            }
        }
    }
}
