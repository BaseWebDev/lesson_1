using System;
using System.Collections.Generic;
using System.Linq;

namespace lesson_1 {

    /// <summary>
    /// Разработать программу, которая выводит, перемешанный в случайной порядке список имен 
    /// </summary>
    class Program {
       static void Main(string[] args) {
            // Используя Random и Sort
            List<Name> Names = new List<Name>();  
            Random randomN = new Random();           
            Names.Add(new Name(randomN.Next(0,100),"Вахид"));
            Names.Add(new Name(randomN.Next(0,100),"Антон"));
            Names.Add(new Name(randomN.Next(0,100),"Николай"));
            Names.Add(new Name(randomN.Next(0,100),"Антон"));
            Names.Add(new Name(randomN.Next(0,100),"Паша"));
            Names.Add(new Name(randomN.Next(0,100),"Евгений"));
            Console.WriteLine("Последовательно: ");
            foreach (Name key in Names) {
                Console.WriteLine("Случайное число: "+ key.RandomNomer + " имя ученика: " + key.Disciple);
            }
            Console.WriteLine();
            Names.Sort();  // Сортируем, точнее перемешиваем
            Console.WriteLine("Случайно: ");
            foreach (Name key in Names) {
                Console.WriteLine("Случайное число: " + key.RandomNomer + " имя ученика: " + key.Disciple);
            }
            Console.WriteLine();
            // Случайные числа в зависимости от кол-ва строк (учеников)
            foreach (Name key in Names) { 
                key.RandomNomer = randomN.Next(-Names.Count() * 4, Names.Count() * 4);
            }
            Names.Sort();  // Сортируем, точнее перемешиваем
            Console.WriteLine("Случайно, в зависимости от кол-ва учеников: ");
            foreach (Name key in Names) {
                Console.WriteLine("Случайное число: " + key.RandomNomer + " имя ученика: " + key.Disciple);
            }
            Console.WriteLine();
            // Используя GetHash для однократного перемешивания
            List<Name> NamesUseHash = new List<Name>();
            NamesUseHash.Add(new Name( "Вахид"));
            NamesUseHash.Add(new Name("Антон"));
            NamesUseHash.Add(new Name("Николай"));
            NamesUseHash.Add(new Name("Антон"));
            NamesUseHash.Add(new Name("Паша"));
            NamesUseHash.Add(new Name("Евгений"));
            NamesUseHash.Sort();
            Console.WriteLine("Используя GetHash и Sort: ");
            foreach (Name key in NamesUseHash) {
                Console.WriteLine("\t " + key.Disciple);
            }
            Console.WriteLine();
            // Перемешать используя алгоритм Фишера-Йетса
            Shuffle(NamesUseHash);
            Console.WriteLine("Используя Алгоритм Фишера – Йетса: ");
            foreach (Name key in NamesUseHash) {
                Console.WriteLine("\t " + key.Disciple);
            }
            Console.WriteLine();           
            Console.ReadKey();
        }

        private static Random rng = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

        /// <summary>
        /// Алгоритм Фишера – Йетса (Современная версия)
        /// http://vscode.ru/prog-lessons/kak-peremeshat-massiv-ili-spisok.html
        /// https://ru.stackoverflow.com/questions/547996/%D0%9A%D0%B0%D0%BA-%D0%BF%D0%B5%D1%80%D0%B5%D0%BC%D0%B5%D1%88%D0%B0%D1%82%D1%8C-%D1%81%D0%BB%D1%83%D1%87%D0%B0%D0%B9%D0%BD%D0%BE-%D0%BF%D0%B5%D1%80%D0%B5%D1%81%D1%82%D0%B0%D0%B2%D0%B8%D1%82%D1%8C-%D1%8D%D0%BB%D0%B5%D0%BC%D0%B5%D0%BD%D1%82%D1%8B-%D0%B2-%D0%BC%D0%B0%D1%81%D1%81%D0%B8%D0%B2%D0%B5
        /// <param name="list"> IList - представляет неуниверсальную коллекцию объектов, к каждому из которых можно получить индивидуальный доступ по индексу.</param>
        /// </summary>
        public static void Shuffle<T>( IList<T> list) {  // Переделать
            for (int n = list.Count-1; n >= 1; n--) {
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
