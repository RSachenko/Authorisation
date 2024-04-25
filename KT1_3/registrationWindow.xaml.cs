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

namespace KT1_3
{
    /// <summary>
    /// Логика взаимодействия для registrationWindow.xaml
    /// </summary>
    /// 

    public partial class registrationWindow : Window
    {


        public registrationWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            {
                string login = txtLogin.Text;
                string password = txtPassword.Password;
                string name = txtName.Text;
                string lastName = txtLastname.Text;
                string patronymic = txtPatronymic.Text;

                if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(password))
                {
                    // Проверка на уникальность логина
                    if (!DatabaseHelper.UserExists(login))
                    {
                        // Регистрация пользователя
                        DatabaseHelper.AddUser(login, password, name, lastName, patronymic);
                        // Можно также добавить автоматический переход на окно входа
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Close();
                    }
                    else
                    {
                    }
                }
                else
                {
                }

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }
    }
}
