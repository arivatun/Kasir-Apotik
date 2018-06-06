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
    public partial class FormObat : Form
    {
        MySqlConnection kon;
        public FormObat()
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
            catch (Exception err)
            {
                MessageBox.Show("Koneksi Error " + err.Message);
            }
        }

        private void clear() {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "PILIH";
            button1.Text = "Save";
        }

        public void autoNumberKodePembelian()
        {
            long hitung;
            string urut;

            kon.Open();

            MySqlCommand cmd = new MySqlCommand("Select kd_obat FROM obat WHERE kd_obat in(SELECT MAX(kd_obat) FROM obat) ORDER BY kd_obat desc", kon);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            if (dr.HasRows)
            {
                hitung = Convert.ToInt64(dr[0].ToString().Substring(dr["kd_obat"].ToString().Length - 4, 4)) + 1;
                String joinstr = "0000" + hitung;
                urut = "OBAT-" + joinstr.Substring(joinstr.Length - 4, 4);
            }
            else
            {
                urut = "OBAT-0001";
            }
            dr.Close();
            textBox1.Text = urut;
            kon.Close();
        }

        public void tampil()
        {
            textBox1.Focus();
            MySqlCommand cmdtampil = new MySqlCommand("SELECT * FROM obat", kon);
            cmdtampil.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(cmdtampil);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
            connection();
            clear();
            tampil();
            autoNumberKodePembelian();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") && (textBox2.Text == "") && (comboBox1.Text == "PILIH") && (textBox3.Text == "") && (textBox4.Text == ""))
                MessageBox.Show("Mohon lengkapi data terlebih dahulu");
            else
            {
                kon.Open();
                try
                {
                    MySqlCommand cmdinsert = new MySqlCommand("INSERT INTO obat values ('" + textBox1.Text + "','"
                                                   + textBox2.Text + "','" + comboBox1.Text + "','"
                                                   + textBox3.Text + "','" + textBox4.Text + "')", kon);
                    cmdinsert.Prepare();
                    cmdinsert.ExecuteNonQuery();
                    tampil();
                    clear();
                }
                catch (Exception)
                {
                    MySqlCommand cmdupdate = new MySqlCommand("UPDATE obat SET nama_obat='" + textBox2.Text
                                                   + "',j_obat='" + comboBox1.Text
                                                   + "',harga='" + textBox3.Text
                                                   + "',stok='" + textBox4.Text
                                                   + "' WHERE kd_obat='" + textBox1.Text + "'", kon);
                    cmdupdate.Prepare();
                    cmdupdate.ExecuteNonQuery();
                    tampil();
                    clear();
                }
                kon.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { 
                kon.Open();
                MySqlCommand cmddelete = new MySqlCommand("DELETE FROM obat WHERE kd_obat='" 
                                               + textBox1.Text + "'", kon);
                cmddelete.Prepare();
                cmddelete.ExecuteNonQuery();
                tampil();
                clear();
                kon.Close();
            }
            catch(Exception err){
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Enabled = false;
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            button1.Text = "Update";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
            tampil();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
