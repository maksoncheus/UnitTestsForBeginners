using System.Linq.Expressions;

namespace Task_01_10
{
    public class TaskMethods
    {
        /// <summary>
        /// Метод получения разности двух массивов. 
        /// (Удалить из массива a все элементы массива b)
        /// </summary>
        /// <param name="a">Массив, из которого удаляем</param>
        /// <param name="b">Массив, элементы которого требуется удалить из первого</param>
        /// <returns>Разница массивов</returns>
        /// Для тестов: 1) в массиве a могут быть значения-дубликаты, содержащиеся в b
        /// 2) один из массивов может быть пустым
        /// 3) положительный случай: a = [1, 2], b = [1] => [2]
        public int[] ArrayDiff(int[] a, int[] b)
        {
            var list_A = a.ToList();
            for (int i = 0; i < b.Length; i++)
                list_A.RemoveAll(q => q == b[i]);
            return list_A.ToArray();
        }
        /// <summary>
        /// Получение квадратной матрицы умножения
        /// </summary>
        /// <param name="size">Размер матрицы</param>
        /// <returns>Квадратная матрица умножения размера NxN</returns>
        /// Для тестов: 1) size < 0
        /// 2) Матрица размера 3: 3 => [[1,2,3],[2,4,6],[3,6,9]]
        public int[,] MultiplicationTable(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException(nameof(size));
            int[,] multi = new int[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    multi[i, j] = (i + 1) * (j + 1);
            return multi;
        }

        public double TaskFunction(double x)
        {
            if (x <= 0) return -x;
            if (x < 2) return x * x;
            return 4;
        }
        public string GetSeason(int monthNumber)
        {
            if (monthNumber < 1 || monthNumber > 12)
                throw new ArgumentOutOfRangeException(nameof(monthNumber));
            string result = string.Empty;
            switch (monthNumber)
            {
                case 1:
                case 2:
                case 12:
                    result = "Зима";
                    break;
                case 3:
                case 4:
                case 5:
                    result = "Весна";
                    break;
                case 6:
                case 7:
                case 8:
                    result = "Лето";
                    break;
                case 9:
                case 10:
                case 11:
                    result = "Осень";
                    break;
            }
            return result;
        }
    }
}
