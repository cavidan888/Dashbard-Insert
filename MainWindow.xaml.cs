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
using Play_Store.View;

namespace Play_Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RegisterButton.Click += OpenAndFillInfo;
        }

        private void OpenAndFillInfo(object sender, RoutedEventArgs e)
        {
            Register_Window rw = new Register_Window();
            rw.Show();
            this.Hide();
        }

        public void FillDatas()
        {

        }
    }
}
