using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender
{
    public partial class MainWindow : Window
    {


        private async void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTB.Text;
            string password = PasswordTB.Password;

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    await MailSender1.SendCode(email);
                    MessageBox.Show("Код успешно отправлен.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при отправке кода: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите адрес электронной почты и пароль.");
            }
        }
    }
   
    public static class MailSender1
    {
        public static async Task SendCode(string recipient)
        {
            try
            {
                Random rnd = new Random();
                int code = rnd.Next(1000, 9999);
                MailAddress fromM = new MailAddress("potalon.pechkin@mail.ru", "C#");
                MailAddress toM = new MailAddress(recipient); //куда отправить

                using (MailMessage message = new MailMessage(fromM, toM))
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    message.Subject = "Welcome to prop.online!"; // Заголовок
                    message.Body = $"<h1>This is code for your registration: {code}</h1>"; //Содержание
                    message.IsBodyHtml = true;

                    smtpClient.Host = "smtp.mail.ru";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("potalon.pechkin@mail.ru", "T6qCnpYX56dpZZYDwzPm");

                    await smtpClient.SendMailAsync(message);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MailCodeWindow mailCodeWindow = new MailCodeWindow("", Convert.ToString(code));
                        mailCodeWindow.Show();
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке кода: {ex.Message}");
            }
        }
    }

}
