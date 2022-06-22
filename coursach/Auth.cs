using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursach
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() == "admin")
            {
                this.Hide();
                All all = new All();
                all.Show();
            }
            else
            {
                MessageBox.Show(
                           "Неправильный пароль! " +
                           "\nАварийное завершение работы.",
                           "Ошибка",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error
                           );
                Application.Exit();
            }
            
        }

        private void Auth_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainMenu mm = new MainMenu();
            mm.Show();
        }
    }
}
