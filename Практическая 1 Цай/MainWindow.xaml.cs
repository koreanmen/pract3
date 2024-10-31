using System.Data.Common;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_11;
using Lib_11Mas;

namespace Практическая_1_Цай
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[,] matrix;

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    bool f1;
        //    f1 = Int32.TryParse(tbv.Text,out int n);
        //    if (f1)
        //    {
        //        n = Convert.ToInt32(tbv.Text);
        //        string s = "";
        //        Random rnd = new Random();
        //        for (int i = 0; i < n; i++)
        //        {
        //            int x = rnd.Next(1, n);
        //            s += x + " ";
        //        }
        //        tbs.Text = s;
        //        float mult = 0;
        //        Class1.Func(n, s, out mult);
        //        tbr.Text = mult.ToString();
        //    }
        //    else MessageBox.Show("Введите верные значения","Ошибка",MessageBoxButton.OK);
        //}

        // О программе
        private void MenuItem_inf(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Цай Владислав, ИСП-31, Практическая 3, Вариант-11 \r\nДана матрица размера M × N. \r\nНайти количество ее строк, элементы которых упорядочены по возрастанию.", "Информация",MessageBoxButton.OK);
        }
        //Очистить
        private void MenuItem_Clear(object sender, RoutedEventArgs e)
        {
            tbrez.Clear();
            tbdiapmin.Clear();
            tbdiapmax.Clear();
            tbcol.Clear();
            tbrow.Clear();
            dataGrid.ItemsSource = VisualArray.ToDataTable(Mas.Del(ref matrix)).DefaultView;
        }
        // Выход
        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void tbv_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    tbr.Clear();
        //    tbs.Clear();
        //}
        
        //Сохранить
        private void MenuItem_save(object sender, RoutedEventArgs e)
        {
            Mas.Save(matrix);
        }

        // Открыть
        private void MenuItem_open(object sender, RoutedEventArgs e)
        {
            matrix = Mas.Open();
            dataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
        }

        // Заполнить
        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbdiapmin.Text, out int min) && int.TryParse(tbdiapmax.Text, out int max) && int.TryParse(tbrow.Text, out int row) && int.TryParse(tbcol.Text, out int col))
            {
                matrix = Mas.Fill(min,max,row,col);
                if (matrix != null)
                {
                    dataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
                }
                else MessageBox.Show("Введите корректные значения", "Ошибка", MessageBoxButton.OK);
            }
            else MessageBox.Show("Введите корректные значения", "Ошибка");
        }

        //Ввод из ячейки в массив
        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            int indRow = e.Row.GetIndex();
            int indColumn = e.Column.DisplayIndex;
            if (Int32.TryParse(((TextBox)e.EditingElement).Text, out int newValue))
            {
                matrix[indRow, indColumn] = newValue;
                dataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
            else
            {
                e.Cancel = true;
            }
        }

        //Решение
        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            if (matrix != null)
            {
                Class1.Func(matrix, out string result);
                tbrez.Text = result;
            }
        }

        //Создать
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            int col = Convert.ToInt32(tbcol.Text);
            int row = Convert.ToInt32(tbrow.Text);
            matrix =new int[row,col];
            dataGrid.ItemsSource= VisualArray.ToDataTable(matrix).DefaultView;
        }

    }
}