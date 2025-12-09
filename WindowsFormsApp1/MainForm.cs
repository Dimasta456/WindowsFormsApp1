using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.UsersClasses;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
            string.IsNullOrWhiteSpace(textBox2.Text) ||
            string.IsNullOrWhiteSpace(textBox3.Text) ||
            string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return; 
            }
            //Ввод данных с формы в объекты ранее созданных классов
            string smtp = "smtp.mail.ru";
            //Необходимо ввести свой mail.ru адрес!!! и своё ФИО
            StringPair fromInfo = new StringPair("bosdimon00111@mail.ru", "Босых Дмитрий Константинович");
            //Необходимо ввести свой пароль который вывел mail.ru !!!
            string password = "le3qRG9Je3jFhsKYfbz3";

            StringPair toInfo = new StringPair(textBox1.Text, textBox2.Text);
            string subject = textBox3.Text;
            string body = $"{DateTime.Now} \n" +
                $"{Dns.GetHostName()}\n" +
                $"{Dns.GetHostAddresses(Dns.GetHostName()).First()}\n" +
                $"{textBox4.Text}";

            InfoEmailSending info =
                new InfoEmailSending(smtp, fromInfo, password, toInfo, subject, body);
            //Отправка данных в виде электронного письма
            SendingEmail sendingEmail = new SendingEmail(info);
            sendingEmail.Send();

            //Уведомления для пользователя и очистка всех TextBox
            MessageBox.Show("Письмо отправлено!");
            foreach (TextBox textBox in Controls.OfType<TextBox>())
                textBox.Text = "";
        }
    }
}
