using System;
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
    public partial class FormCustomer : Form
    {
        MySqlConnection kon;
        public FormCustomer()
        {
            InitializeComponent();
        }

        private void connection()
        {
            try
            {
                string koneksi = @"Data Source=localhost; port=3306; Initial Catalog=apotik; user Id=root; password=";
                kon = new MySqlConnection(koneksi);
            }
            catch (Exception err)
            {
                MessageBox.Show("Koneksi Error " + err.Message);
            }
        }

        public void tampil()
        {
            try
            {
                kon.Open();
                textBox1.Focus();
                MySqlCommand cmdtampil = new MySqlCommand("SELECT * FROM pelanggan", kon);
                cmdtampil.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(cmdtampil);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                kon.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            richTextBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kon.Open();
            try
            {
                MySqlCommand cmdinsert = new MySqlCommand("INSERT INTO pelanggan(id_pembeli,nama,alamat,kota,no_hp) "
                                       + "values ('" + textBox1.Text + "','"
                                       + textBox2.Text + "','" + richTextBox1.Text + "','"
                                       + textBox3.Text + "','" + textBox4.Text + "')", kon);
                cmdinsert.Prepare();
                cmdinsert.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MySqlCommand cmdinsert = new MySqlCommand("UPDATE pelanggan SET nama='" + textBox2.Text
                    + "',alamat='" + richTextBox1.Text + "',kota='" + textBox3.Text + "',no_hp='" + textBox4.Text
                    +"' WHERE id_pembeli='" + textBox1.Text + "'", kon);
                cmdinsert.Prepare();
                cmdinsert.ExecuteNonQuery();
            }
            kon.Close();
            tampil();
            button3.Enabled = true;
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            connection();
            button3.Enabled = false;
            tampil();
            clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox1.Enabled = false;
            button3.Enabled = true;
            button1.Text = "Update";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kon.Open();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Pilih data yang akan dihapus terlebih dahulu!!", "Warning");
                textBox1.Focus();
            }
            else
            {
                DialogResult result = MessageBox.Show("Apakah anda yakin akan menghapus data tersebut?", "Pilihan", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        MySqlCommand cmdinsert = new MySqlCommand("DELETE FROM pelanggan WHERE id_pembeli='" + textBox1.Text + "'", kon);
                        cmdinsert.Prepare();
                        cmdinsert.ExecuteNonQuery();
                        MessageBox.Show("Data berhasil dihapus");
                        clear();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Data gagal dihapus");
                    }
                }
            }
            kon.Close();
            tampil();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
            button3.Enabled = false;
            textBox1.Enabled = true;
            button1.Text = "Save";
            textBox1.Focus();
        }
    }
}
