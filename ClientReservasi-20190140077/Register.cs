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
    public partial class Register : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();

        public Register()
        {
            InitializeComponent();
            TampilData();
            textBoxID.Visible = false;
            btnUpdate.Enabled = false;
            btnHapus.Enabled = false;

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string kategori = comboBoxKategori.Text;
            string a = service.Register(username, password, kategori);

            if (textBoxUsername.Text == "" || textBoxPassword.Text == "" || comboBoxKategori.Text == "")
            {
                MessageBox.Show("Semua Data Wajib Diisi");
            }
            else
            {
                MessageBox.Show(a);
                Refresh();
                Clear();
                TampilData();
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string kategori = comboBoxKategori.Text;
            int id = Convert.ToInt32(textBoxID.Text);
            string a = service.UpdateRegister(username, password, kategori, id);

            if (textBoxUsername.Text == "" || textBoxPassword.Text == "" || comboBoxKategori.Text == "")
            {
                MessageBox.Show("Harap Isi Semua Data");
            }
            else
            {
                MessageBox.Show(a);
                Refresh();
                Clear();
                TampilData();
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();

        }

        public void TampilData()
        {
            var list = service.DataRegist();
            dtRegister.DataSource = list;
        }

        public void Clear()
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
            comboBoxKategori.SelectedItem = null;

            btnSimpan.Enabled = true;
            btnUpdate.Enabled = false;
            btnHapus.Enabled = false;
        }

        private void dtRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = Convert.ToString(dtRegister.Rows[e.RowIndex].Cells[0].Value);
            textBoxUsername.Text = Convert.ToString(dtRegister.Rows[e.RowIndex].Cells[1].Value);
            textBoxPassword.Text = Convert.ToString(dtRegister.Rows[e.RowIndex].Cells[2].Value);
            comboBoxKategori.Text = Convert.ToString(dtRegister.Rows[e.RowIndex].Cells[3].Value);

            btnUpdate.Enabled = true;
            btnHapus.Enabled = true;

            btnSimpan.Enabled = false;

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;

            DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data ini?", "Hapus Data", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string a = service.DeleteRegister(username);
                MessageBox.Show(a);
                Clear();
                TampilData();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
    }
}
