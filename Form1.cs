using System;//
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class FormLogin : Form
    {
        MySqlConnection kon;
        public FormLogin()
        {
            InitializeComponent();
        }

        public void connection()
        {
            try
            {
                string koneksi = @"Data Source=localhost; port=3306; Initial Catalog=apotik; user Id=root; password=";
                kon = new MySqlConnection(koneksi);
            }
            catch(Exception err){
                MessageBox.Show("Koneksi Error " + err.Message);
            }
        }

        private void clear() {
            textBox1.Focus();
            textBox1.Clear();
            textBox2.Clear();
            textBox2.UseSystemPasswordChar = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection();
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand con = new MySqlCommand();
            con.Connection = kon;
            kon.Open();
            con.CommandType = CommandType.Text;
            con.CommandText = "SELECT * FROM login WHERE user='" + textBox1.Text + "' and pass='" + textBox2.Text + "'";
            MySqlDataReader dtr = con.ExecuteReader();
            if (dtr.Read())
            {
                MessageBox.Show("Selamat Datang, " + dtr.GetString(2) + " ... ", "APLIKASI APOTEK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormMenu menu = new FormMenu();
                menu.Show();
                FormLogin lg = new FormLogin();
                lg.Close();
            }
            else {
                MessageBox.Show("Data tidak sesuai, mohon diperiksa kembali","Peringatan!!!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            kon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
