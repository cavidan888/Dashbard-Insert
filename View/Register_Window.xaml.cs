using Microsoft.Win32;
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
using System.Windows.Shapes;

using System.Data.SqlClient;

namespace Play_Store.View
{
    /// <summary>
    /// Interaction logic for Register_Window.xaml
    /// </summary>
    public partial class Register_Window : Window
    {
        public Register_Window()
        {
            InitializeComponent();
            dialogOpener.Click += openFileDialogWindow;
        }


        public void getImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.ShowDialog();

            string filename = ofd.FileName;

            //picBox.Source = new BitmapImage(new Uri(filename, UriKind.Absolute));

            Uri uri = new Uri(filename, UriKind.Absolute);

            ImageSource imgSource = new BitmapImage(uri);
            imageBox.Text = imgSource.ToString();

            picBox.Source = imgSource;
        }
        public void FillDatas()
        {

            SqlConnection connect = new SqlConnection(@"Data Source=CAVIDAN-PC\SQLEXPRESS;Initial Catalog=Agents;Integrated Security=True");
            connect.Open();

            var _insertQuery = "INSERT INTO AgentsView(UserName,PassWord,Name,Position,Admission,Rating,Picture) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7)";

            SqlCommand command = new SqlCommand(_insertQuery, connect);

            command.Parameters.AddWithValue("@p1", usernameBox.Text);
            command.Parameters.AddWithValue("@p2", passwordBox.Text);
            command.Parameters.AddWithValue("@p3", nameBox.Text);
            command.Parameters.AddWithValue("@p4", positionBox.Text);
            command.Parameters.AddWithValue("@p5", admissionBox.Text);
            command.Parameters.AddWithValue("@p6", ratingBox.Text);
            command.Parameters.AddWithValue("@p7", imageBox.Text);

            command.ExecuteNonQuery();

            connect.Close();
        }
        private void openFileDialogWindow(object sender, RoutedEventArgs e)
        {
            getImage();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

            FillDatas();
            MessageBox.Show("Your register comppleted succesfuly!!!!!!");
        }
    }
}
