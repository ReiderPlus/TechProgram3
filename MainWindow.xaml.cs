using System;
using System.IO;
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
using System.Collections.ObjectModel;

namespace TechProgram3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<FunctionResult> FunctionValues { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            double F1(double x)
            {
                return Math.Sinh(x * x);
            }

            double F2(double x)
            {
                return Math.Sin(Math.Sqrt(x - 1));
            }

            double F3(double x)
            {
                return Math.Pow(Math.Exp(1 - Math.Abs(x)), 0.2);
            }

            double F4(double x)
            {
                for (int j = 1; j < 1000; j++)
                {
                    x += (1 / (x + Math.Sqrt(j)));
                }
                return x;
            }

            double F(double x)
            {
                return F1(x) + F2(x) + F3(x) + F4(x);
            }
            string TB1 = textBox1.Text;
            string TB2 = textBox2.Text;
            string TB3 = textBox3.Text;
            if (int.TryParse(TB1, out int x1) && int.TryParse(TB2, out int x2) && double.TryParse(TB3, out double n))
            {
                double nx = Math.Abs((x2 - x1) / n);
                double xl = x1;
                List<FunctionResult> results = new List<FunctionResult>();

                while (xl <= x2)
                {
                    double f1 = F1(xl);
                    double f2 = F2(xl);
                    double f3 = F3(xl);
                    double f4 = F4(xl);
                    double totalF = F(xl);

                    results.Add(new FunctionResult
                    {
                        X = xl,
                        F1 = f1,
                        F2 = f2,
                        F3 = f3,
                        F4 = f4,
                        TotalF = totalF
                    });

                    xl += nx;
                }

                dataGrid.ItemsSource = results;
            }
            else
            {
                MessageBox.Show("Введены некорректные данные", "Тип данных", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }
    }
}
