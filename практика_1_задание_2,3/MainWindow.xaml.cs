using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace практика_1_задание_2
{
    public partial class MainWindow : Window
    {
        Shop shop;
        public MainWindow()
        {
            InitializeComponent();
            shop = new Shop();
            shop.Gain = 0;

        }
        private void Update() // Обновляет Grid.
        {
            Grid.Items.Clear();
            foreach (var item in shop.products.Keys)
            {
                if (item.Count != 0)
                {
                    Grid.Items.Add(item);
                }
            }
            profit_label.Content = $"Прибыль: {shop.Gain}";
        }

        private void Add_Click(object sender, RoutedEventArgs e) // Кнопка Добавить. Добавляет в Grid новый продукт.
        {

            if (!string.IsNullOrWhiteSpace(ProductName.Text))
            {
                if (decimal.TryParse(ProductPrice.Text, out decimal price))
                {
                    if (price > 0)
                    {
                        if (int.TryParse(ProductCount.Text, out int amount))
                        {
                            if (amount > 0)
                            {
                                Product prod = shop.CreateProduct(ProductName.Text, price, amount);
                                if (shop.FindCopy(prod) == false)
                                {
                                    shop.AddProduct(prod, amount);
                                    Update();
                                }
                                else
                                {
                                    MessageBox.Show("Данный товар уже существует");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Введено некорректное кол-во");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Введено некорректное кол-во");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введено некорректная цена");
                    }


                }
                else
                {
                    MessageBox.Show("Введено некорректная цена");
                }
            }
            else
            {
                MessageBox.Show("Заполните поле с названием товара");
            }

        }


        private void Sell_Click(object sender, RoutedEventArgs e) // Кнопка Продать. Продает выбранные продукты и обновляет Grid
        {
            foreach (var item in Grid.SelectedItems)
            {
                shop.Sell((Product)item);
            }
            Update();

        }

        private void Search_Click(object sender, RoutedEventArgs e) // Кнопка Поиск. Очищает Grid, а после добавляет в Grid все найденные элементы shop.products по названию
        {
            if (!string.IsNullOrWhiteSpace(ProductName.Text))
            {
                Grid.Items.Clear();
                foreach (var item in shop.FindMultipleByName(ProductName.Text))
                {
                    Grid.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Заполните поле с названием товара, чтобы начать поиск");
            }

        }
    }
}
