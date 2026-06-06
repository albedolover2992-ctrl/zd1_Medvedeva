using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

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

        public Song CurrentSong()
        {
            if (list_of_songs.Count > 0)
                return list_of_songs[currentIndex];
            else
                throw new IndexOutOfRangeException("Невозможно получить текущую аудиозапись для пустого плейлиста!");
        }

        public static void Clear_list ()  // Очищение плейлиста
        {
            list_of_songs.Clear();
        }

        public static void Remove_at_list_by_number (int n)  // Удаление элемента по индексу
        {
            list_of_songs.RemoveAt(n);
        }

        public static void Remove_at_list_by_name (string name)  // Удаление элемента по имени
        {

            //list_of_songs.RemoveAt(num);
        }

        public static Song Go_to_next(int n)  // Переход к следующей записи 
        {
            if (n < list_of_songs.Count)
                return list_of_songs[n];
            else
                return list_of_songs[n - 1];  // Если введена уже последняя запись, то вернется она же
        }

        public static Song Go_to_previous (int n)  // Переход к предыдущей записи
        {
            if (n > -1)
                return list_of_songs[n];
            else
                return list_of_songs[0]; // Если введена уже первая запись, то вернется она же
        }

        public static Song Go_to_first ()  // Переход к первой записи
        {
            return list_of_songs[0];
        }

        public static Song Go_to_index (int n)  // Переход к записи по индексу
        {
            if (n > -1 && n < list_of_songs.Count)
                return list_of_songs[n];
            else
                return list_of_songs[0];  // Если индекст невозможен, то вернет первый
        }
    }
}
