using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientReservasi_20190140077
{
    public partial class Login : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();

        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            string kategori = service.Login(username, password);

            if (kategori == "Admin")
            {
                Register fm = new Register();
                this.Hide();
                fm.Show();
            }
            else if (kategori == "Receptionist")
            {
                Form1 fm = new Form1();
                this.Hide();
                fm.Show();
            }
            else
            {
                MessageBox.Show("Username dan Password Salah, Silahkan Hubungi admin");
                tbUsername.Clear();
                tbPassword.Clear();
            }
        }
    }
}
