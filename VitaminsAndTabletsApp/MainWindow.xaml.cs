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
using VitaminsAndTabletsApp.BLL.Authorization;
using VitaminsAndTabletsApp.BLL.Tools;
using VitaminsAndTabletsApp.DAL;
using VitaminsAndTabletsApp.DAL.Entities;

namespace VitaminsAndTabletsApp
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

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string login = SignInLoginTextBox.Text;
            string password = SignInPasswordTextBox.Text;

            string result = AuthClass.SignIn(login, password);
            Tools.ChangeInfoLabel(result, UserExistsLabel, true);
            
        }


        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            string result = AuthClass.SignUp(login, email, password);
            Tools.ChangeInfoLabel(result, UserExistsLabel, true);
        }
        
    }
}
