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
        Playlist playlist;
        public MainWindow()
        {
            InitializeComponent();
            shop = new Shop();
            playlist = new Playlist();
        }

        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            Task1_Panel.Visibility = Visibility.Visible;
            Task2_Panel.Visibility = Visibility.Hidden;
        }

        private void Playlist_Click(object sender, RoutedEventArgs e)
        {
            Task1_Panel.Visibility = Visibility.Hidden;
            Task2_Panel.Visibility = Visibility.Visible;

        }


        private void Update()  // Обновляет магазин
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

        public void updatePlaylistGrid()  // Обновляет плейлист
        {
            Grid_Playlist.Items.Clear();
            foreach (var item in playlist.List)
            {
                Grid_Playlist.Items.Add(item);
            }
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



        private void Add_song_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SongTitle.Text))
            {
                if (!string.IsNullOrWhiteSpace(AuthorName.Text))
                {
                    if (!string.IsNullOrWhiteSpace(FileName.Text))
                    {
                        if (playlist.ContainsByFileName(FileName.Text) == false)
                        {
                            playlist.AddSong(SongTitle.Text, AuthorName.Text, FileName.Text);
                            updatePlaylistGrid();
                        }
                        else
                        {
                            MessageBox.Show("Данный файл уже находится в плейлисте");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Введите путь к файлу");
                    }
                }
                else
                {
                    MessageBox.Show("Введите имя автора");
                }
            }
            else
            {
                MessageBox.Show("Введите название песни");
            }
        }

        private void Previous_Click(object sender, RoutedEventArgs e) // переход к предыдущей песне
        {
            if (playlist != null)
            {
                playlist.Go_to_previous();
                Grid_Playlist.SelectedIndex = playlist.CurrentIndex;
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e) // переход к следующей песне
        {
            if (playlist != null)
            {
                playlist.Go_to_next();
                Grid_Playlist.SelectedIndex = playlist.CurrentIndex;
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e) // возвращение в начало плейлиста
        {
            if (playlist != null)
            {
                playlist.Go_to_first();
                Grid_Playlist.SelectedIndex = playlist.CurrentIndex;
            }
        }

        private void Clear_Playlist_Click(object sender, RoutedEventArgs e) // кнопка очистки плейлиста
        {
            if (playlist != null)
            {
                playlist.Clear_list();
                updatePlaylistGrid();
            }
        }

        private void Delete_Song_Click(object sender, RoutedEventArgs e) // кнопка удаления песни
        {
            if (playlist != null)
            {
                playlist.Remove_at_list_by_number();
                updatePlaylistGrid();
            }
        }
    }
}
