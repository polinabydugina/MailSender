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

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MailCodeWindow.xaml
    /// </summary>
    public partial class MailCodeWindow : Window
    {
        string code;
        public MailCodeWindow(string msg, string code)
        {
            InitializeComponent();
            this.code = code;
            CodeTB.Text = msg;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(CodeTB.Text == code)
            {
                MessageBox.Show("Success!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong code");
            }
        }
    }
}
