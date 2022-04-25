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

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = @"C:\";

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
                Environment.Exit(0);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new();
            saveFileDialog.Filter = "Текстовый файл (*.txt)|*.txt|cs-файл (*.cs)|*.cs|html-файл (*.html)|*.html|css-файл (*.css)|*.css|js-файл (*.js)|*.js|sql-файл (*.sql)|*.sql";
            saveFileDialog.InitialDirectory = path;

            if (saveFileDialog.ShowDialog() == true)
            {
                TextRange documentTextRange = new(
                    richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

                using FileStream fileStream = File.Create(saveFileDialog.FileName);
                documentTextRange.Save(fileStream, DataFormats.Text);
            }
        }
    }
}
