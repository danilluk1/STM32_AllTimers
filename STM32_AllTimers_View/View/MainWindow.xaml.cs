using STM32_AllTimers_BL.ViewModel;
using System;
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

namespace STM32_AllTimers_View {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        MainWindowViewModel mwvm =
            new MainWindowViewModel();

        public MainWindow() {
            InitializeComponent();

            DataContext = mwvm;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {
            float result = mwvm.BasicTimer.CalculatePeriodMs();
            resultTextBox.Text = $"{result}";
        }
    }
}
