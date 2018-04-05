using System;

namespace lesson_1 {
    /// <summary>
    /// Каждому имени соответствует случайное число
    /// </summary>
    class Name : IComparable {
        private int randomNumber;
        private string disciple;
        public int RandomNomer { get { return randomNumber; } set { randomNumber = value; } }
        public string Disciple { get { return disciple; } set { disciple = value; } }
        /// <summary>
        /// Если не определено случаное число, то берем Хэш-код объекта
        /// </summary>
        /// <param name="name"></param>
        public Name(string name) {
            this.RandomNomer = this.GetHashCode();
            this.Disciple = name;
        }
        public Name(int number, string name) {
            this.RandomNomer = number;
            this.Disciple = name;
        }
       
        /// <summary>
        /// Переопределенный метод сравнения двух объектов
        /// </summary>
        /// <param name="obj">Случайное число</param>
        /// <returns></returns>
        public int CompareTo(Object obj) {
            if (obj == null) return 1;
            Name otherNumber = obj as Name; // Другой объект

            if (otherNumber != null) {   // Сортировку производим по RandomNumber
                if (this.RandomNomer > otherNumber.RandomNomer) {
                    return 1;
                } else if (this.RandomNomer < otherNumber.RandomNomer) {
                    return -1;
                }
            } else {
                throw new ArgumentException("Объект не может быть приведен к Name");
            }

            return 0;
        }
        
    }
    

}
