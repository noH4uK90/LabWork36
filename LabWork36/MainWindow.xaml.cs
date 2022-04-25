using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace LabWork36
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            if (MessageBox.Show("Закрыть окно?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //Close();
                Environment.Exit(0);
            }
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg; *.jpeg)|*.jpg;*.jpeg|bmp files (*.bmp)|*.bmp";
            if(openFileDialog.ShowDialog() == true)
            {
                image.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
    }
}
