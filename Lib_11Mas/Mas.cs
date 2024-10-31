
using Microsoft.Win32;
using System.Data;
using System.IO;

namespace Lib_11Mas
{

    /// Класс для работы с массивами.
    public class Mas
    {
        /// Создает и инициализирует массив числами от 0 до 50
        public static int[,] Fill(int min, int max,int row, int column)
        {
            if (column >= 0 && row >= 0 && max >= min)
            {
                Random rnd = new Random();
                int rNum = 0;
                int[,] mas = new int[row, column];
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        rNum = rnd.Next(min, max);
                        mas[i, j] = rNum;
                    }
                }
                return mas;
            }
            else return null;
        }
        
        /// Метод читает из файла разрешения *.txt числовые символы, и записывает их в массив
        public static int[,] Open()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Все файлы (*.*)|*.*| Текстовые файлы (.txt) | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            int row = 0;
            int column = 0;
            List<int> values = new List<int>();
            if (open.ShowDialog() == true)
            {
                using (StreamReader file = new StreamReader(open.FileName))
                {
                    while (!file.EndOfStream)
                    {
                        string line = file.ReadLine();
                        string[] valuesStr = line.Split(' ');
                        foreach (string valueStr in valuesStr)
                        {
                            if (Int32.TryParse(valueStr, out int value))
                            {
                                values.Add(value);
                                column++;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        row++;
                    }
                }
                column /= row;
                int indexList = 0;
                int[,] mas = new int[row, column];
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        mas[i, j] = values[indexList];
                        indexList++;
                    }
                }
                return mas;
            }
            return null;
        }
        /// Метод записывает массив в файл формата *.txt
        public static void Save(int[,] mas)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Текстовые файлы (.txt) | *.txt";
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true && mas != null)
            {
                using (StreamWriter file = new StreamWriter(save.FileName))
                {
                    for (int i = 0; i < mas.GetLength(0); i++)
                    {
                        for (int j = 0; j < mas.GetLength(1); j++)
                        {
                            file.Write(mas[i, j].ToString());
                            if (j < mas.GetLength(1) - 1)
                            {
                                file.Write(" ");
                            }
                        }
                        file.WriteLine();
                    }
                }
            }
        }
        public static int[,] Del(ref int[,] matrix)
        {
            return matrix = null;
        }
    }
}