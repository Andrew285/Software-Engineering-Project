using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace VitaminsAndTabletsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String connectionString; 
        public MainWindow()
        {
            InitializeComponent();

            connectionString = "Server=DESKTOP-BT5VFT8;Database=Vitamins&Tablets;Trusted_Connection=true";
        }


        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string login = SignInLoginTextBox.Text;
                string password = SignInPasswordTextBox.Text;
                conn.Open();

                SqlCommand selectUser = new SqlCommand("SELECT 1 FROM Users " +
                                                       "WHERE Name = @0 AND Password = @1", conn);
                selectUser.Parameters.Add(new SqlParameter("0", login));
                selectUser.Parameters.Add(new SqlParameter("1", password));

                using (SqlDataReader dataRead = selectUser.ExecuteReader())
                {
                    if (!dataRead.HasRows)
                    {
                        ChangeInfoLabel("Please, sign up firstly", true);
                    }
                    else
                    {
                        //Log into the system
                        ChangeInfoLabel("You are in the system", true);
                    }

                }
                conn.Close();

            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                string login = LoginTextBox.Text;
                string email = EmailTextBox.Text;
                string password = PasswordTextBox.Text;


                conn.Open();
                SqlCommand selectUser = new SqlCommand("SELECT 1 FROM Users " +
                                                        "WHERE Name = @0 AND Email = @1 AND Password = @2", conn);
                selectUser.Parameters.Add(new SqlParameter("0", login));
                selectUser.Parameters.Add(new SqlParameter("1", email));
                selectUser.Parameters.Add(new SqlParameter("2", password));
                selectUser.ExecuteNonQuery();

                using (SqlDataReader dataRead = selectUser.ExecuteReader())
                {
                    if (!dataRead.HasRows)
                    {
                        dataRead.Close();
                        SqlCommand insertCommand = new SqlCommand("INSERT INTO Users (Name, Email, Password) VALUES (@0, @1, @2)", conn);
                        insertCommand.Parameters.Add(new SqlParameter("0", login));
                        insertCommand.Parameters.Add(new SqlParameter("1", email));
                        insertCommand.Parameters.Add(new SqlParameter("2", password));
                        insertCommand.ExecuteNonQuery();

                        ChangeInfoLabel("You are signed up!. Please sign in", true);
                    }
                    else
                    {
                        ChangeInfoLabel("Such user already exists", true);
                        
                    }
                }

                conn.Close();
            }
        }

        private void ChangeInfoLabel(string str, bool isVisible)
        {

            // Create a background worker to sleep for 2 seconds...
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += (s, ea) => Thread.Sleep(TimeSpan.FromSeconds(2));

            // ...and then set the text back to the original when the sleep is done
            // (also, re-enable the button)
            backgroundWorker.RunWorkerCompleted += (s, ea) =>
            {
                UserExistsLabel.Visibility = Visibility.Collapsed;
            };

            if (isVisible)
            {
                UserExistsLabel.Visibility = Visibility.Visible;
            }
            else
            {
                UserExistsLabel.Visibility = Visibility.Collapsed;
            }
            UserExistsLabel.Content = str;
            UserExistsLabel.Foreground = new SolidColorBrush(Colors.White);
            UserExistsLabel.Background = new SolidColorBrush(Colors.Black);

            // Start the background worker
            backgroundWorker.RunWorkerAsync();
        }
    }
}
