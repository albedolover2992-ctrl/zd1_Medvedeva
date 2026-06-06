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

        //
        bool open_or_close = false;  // Открыт/закрыт список товаров
        public MainWindow()
        {
            InitializeComponent();
            Shop shop = new Shop();
        }

        private void Product_list_Click(object sender, RoutedEventArgs e)  // Отображение листа с товарами
        {
            if(open_or_close == false)
            {
                list_products.Visibility = Visibility.Visible;
                open_or_close = true;
            }
            else
            {
                list_products.Visibility = Visibility.Hidden;
                open_or_close = false;
            }

        }


        private void Create_Product_Click(object sender, RoutedEventArgs e)  // Открытие элементов отвечающих за добавление товаров
        {
            create_product_panel.Visibility = Visibility.Visible;
            find_product_panel.Visibility = Visibility.Hidden;
        }

        private void Find_Prosuct_Click(object sender, RoutedEventArgs e)  // Открытие элементов отвечающих за покупку и поиск товара
        {
            create_product_panel.Visibility = Visibility.Hidden;
            find_product_panel.Visibility = Visibility.Visible;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)  // Закрытие формы
        {
            this.Close();
        }

        private void Add_Product_Click(object sender, RoutedEventArgs e)  // Добавление товара в лист в зависимости от наполнения строк
        {
            if(!string.IsNullOrWhiteSpace(Product.Text))
            {
                if (!string.IsNullOrWhiteSpace(Price.Text))
                {
                    if(!string.IsNullOrWhiteSpace(Count.Text))
                    {
                        Shop.CreateProduct(Product.Text, decimal.Parse(Price.Text), int.Parse(Count.Text));
                        Shop.WriteAllProducts();
                    }
                }
            }
        }

        private void Find_Click(object sender, RoutedEventArgs e)  // Поиск товара и его покупка
        {
            if(!string.IsNullOrWhiteSpace(Product_to_find.Text))
            {
                Shop.Sell(Product_to_find.Text);
                List_products.Text = Shop.WriteAllProducts();
            }
        }
    }
}
