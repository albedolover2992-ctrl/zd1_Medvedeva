using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace практика_1_задание_2
{
    class Playlist
    {
        private static List<Song> list_of_songs;
        private int currentIndex;

        public Playlist()
        {
            list_of_songs = new List<Song>();
            currentIndex = 0;
        }

        public int CurrentIndex { get { return currentIndex; } set { currentIndex = value; } }

        public Song CurrentSong()
        {
            if (list_of_songs.Count > 0)
                return list_of_songs[currentIndex];
            else
                throw new IndexOutOfRangeException("Невозможно получить текущую аудиозапись для пустого плейлиста!");
        }

        public void Clear_list ()  // Очищение плейлиста
        {
            list_of_songs.Clear();
        }

        public void Remove_at_list_by_number ()  // Удаление элемента по индексу
        {
            if (list_of_songs.Count > 0)
            {
                list_of_songs.RemoveAt(currentIndex);
                Go_to_first();
            }

        }

        public void Remove_at_list_by_name (Song song)  // Удаление элемента по имени
        {
            list_of_songs.Remove(song);
        }

        public void Go_to_next()  // Переход к следующей песне
        {
            if (currentIndex >= list_of_songs.Count - 1)
                currentIndex = 0;
            else
                currentIndex++; 
        }

        public void Go_to_previous ()  // Переход к предыдущей песне
        {
            if (currentIndex == 0)
                currentIndex = list_of_songs.Count - 1;
            else
                currentIndex--;
        }

        public void Go_to_first ()  // Переход к первой песне
        {
            currentIndex = 0;
        }

        public void Go_to_index (int index)  // Переход к песне по индексу
        {
            if (index > list_of_songs.Count - 1 && index < 0)
            {
                throw new IndexOutOfRangeException("Невозможно получить аудиозапись по индексу");
            }
            else
            {
                currentIndex = index;
            }
        }

        public void AddSong(string title, string authorName, string fileName) // создает и добавляет песню в список
        {
            if (File.Exists(fileName))
            {
                Song song = new Song { Title = title, Author = authorName, Filename = fileName };
                AddSong(song);

            }

        }

        public void AddSong(Song song) // добавляет песню в список
        {
            list_of_songs.Add(song);

        }

        public List<Song> List  // возвращает список песен
        {
            get { return list_of_songs; }
        }

        public bool ContainsByFileName(string filename) // поиск песни по пути к файлу
        {
            foreach (var item in list_of_songs)
            {
                if (item.Filename == filename)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
