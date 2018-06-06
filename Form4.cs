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
    public partial class FormTransaksi : Form
    {
        MySqlConnection kon;
        int harga, jml, tharga, bayar, kembali;
        public FormTransaksi()
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

        public void autoNumberKodePembelian()
        {
            long hitung;
            string urut;

            kon.Open();

            MySqlCommand cmd = new MySqlCommand("Select kd_trx FROM pembelian WHERE kd_trx in(SELECT MAX(kd_trx) FROM pembelian) ORDER BY kd_trx desc",kon);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            if (dr.HasRows)
            {
                hitung = Convert.ToInt64(dr[0].ToString().Substring(dr["kd_trx"].ToString().Length - 4, 4)) + 1;
                String joinstr = "0000" + hitung;
                urut = "PEMB-" + joinstr.Substring(joinstr.Length - 4, 4);
            }
            else {
                urut = "PEMB-0001";
            }
            dr.Close();
            textBox1.Text = urut;
            kon.Close();
        }

        public void tampil()
        {
            try
            {
                kon.Open();
                textBox1.Focus();
                MySqlCommand cmdtampil = new MySqlCommand("SELECT obat.nama_obat AS Nama_Obat, SUM(det_pembelian.qty) AS Kuantitas, " 
                    + "SUM(det_pembelian.subtotal) AS SubTotal FROM pembelian "
                    + "INNER JOIN det_pembelian ON pembelian.kd_trx=det_pembelian.kd_trx INNER JOIN obat "
                    + "ON det_pembelian.kd_obat=obat.kd_obat WHERE pembelian.kd_trx='" + textBox1.Text + "'", kon);
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
            textBox3.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            button2.Text = "Save";
            comboBox1.Text = "PILIH";
            comboBox3.Text = "PILIH";
        }

        public void clear_beli()
        {
            textBox1.ReadOnly = true;
            textBox3.Clear();
            textBox6.Clear();
            textBox7.Clear();
            button2.Text = "Save";
            comboBox1.Text = "PILIH";
            comboBox3.Text = "PILIH";
        }

        public void tampil_namaPasien()
        {
            try
            {
                comboBox1.Items.Clear();
                kon.Open();
                MySqlCommand cm = new MySqlCommand("SELECT * FROM pelanggan WHERE id_pembeli!='1'", kon);
                MySqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[1].ToString());
                }
                kon.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void tampil_namaObat()
        {
            try
            {
                comboBox1.Items.Clear();
                kon.Open();
                MySqlCommand cm = new MySqlCommand("select * from obat", kon);
                MySqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr[1].ToString());
                }
                kon.Close();
                dr.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string kode_obat;

        private void Form4_Load(object sender, EventArgs e)
        {
            connection();
            tampil();
            tampil_namaObat();
            clear();
            comboBox1.Enabled = false;
            autoNumberKodePembelian();
        }

        string member,resep;
        public void memberORnon()
        {
            if (radioButton1.Checked == true)
            {
                try
                {
                    kon.Open();
                    MySqlCommand cm = new MySqlCommand("SELECT * FROM pelanggan WHERE nama=" + comboBox1.Text, kon);
                    MySqlDataReader dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        member = dr[0].ToString();
                    }
                    kon.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                member = "1";
            }
        }

        public void totalHarga()
        {
            try
            {
                kon.Open();
                MySqlCommand cm = new MySqlCommand("SELECT SUM(subtotal) FROM det_pembelian WHERE kd_trx='" + textBox1.Text + "'", kon);
                MySqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    textBox8.Text = dr[0].ToString();  
                }
                kon.Close();
            }
            catch (MySqlException ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void simpanPembelian()
        {
            jml = Convert.ToInt32(textBox6.Text);
            harga = Convert.ToInt32(textBox7.Text);
            tharga = jml * harga;
            kon.Open();
            try
            {
                MySqlCommand cmdinsert = new MySqlCommand("INSERT INTO pembelian(kd_trx,id_pembeli,tgl_trx,total) "
                                       + "values ('" + textBox1.Text + "','"
                                       + member + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','"
                                       + tharga + "')", kon);
                cmdinsert.Prepare();
                cmdinsert.ExecuteNonQuery();
                MessageBox.Show("Data pembelian berhasil disimpan");
            }
            catch (Exception)
            {
                MySqlCommand cmdinsert = new MySqlCommand("UPDATE pembelian SET total='" + textBox8.Text
                    + "',bayar='" + textBox9.Text + "',kembali='" + textBox10.Text + "' WHERE kd_trx='" + textBox1.Text + "'", kon);
                cmdinsert.Prepare();
                cmdinsert.ExecuteNonQuery();
            }
            kon.Close();
        }

        string nama_dokter;
        public void simpanDet_Pembelian()
        {
            jml = Convert.ToInt32(textBox6.Text);
            harga = Convert.ToInt32(textBox7.Text);
            tharga = jml * harga;

            if (radioButton1.Checked == true)
            {
                resep = "Y";
            }
            else 
            {
                resep = "T";
            }

            if (radioButton3.Checked == true)
            {
                nama_dokter = textBox3.Text;
            }
            else 
            {
                nama_dokter = "";
            }

            try
            {
                kon.Open();
                MySqlCommand cm = new MySqlCommand("select * from obat where nama_obat='" + comboBox3.Text + "'", kon);
                MySqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    kode_obat = dr[0].ToString();
                }
                kon.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                kon.Open();
                MySqlCommand cmdinsert = new MySqlCommand("INSERT INTO det_pembelian(kd_trx,resep,nama_dokter,kd_obat,qty,subtotal) "
                                       + "values ('" + textBox1.Text + "','" + resep + "','" + nama_dokter + "','" 
                                       + kode_obat + "','" + textBox7.Text + "','" + tharga +"')", kon);
                cmdinsert.Prepare();
                cmdinsert.ExecuteNonQuery();
                kon.Close();
                clear_beli();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            memberORnon();
            if ((textBox1.Text == "") && (comboBox1.Text == "PILIH")
                && (textBox6.Text == "") && (textBox7.Text == ""))
                MessageBox.Show("Mohon lengkapi data terlebih dahulu");
            else
            {
                try
                {
                    simpanPembelian();
                    simpanDet_Pembelian();
                    tampil();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                totalHarga();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
                        kon.Open();
                        MySqlCommand cmdinsert = new MySqlCommand("DELETE FROM det_pembelian where kd_obat ='" + kode_obat + "' AND kd_trx='" + textBox1.Text + "'", kon);
                        cmdinsert.Prepare();
                        cmdinsert.ExecuteNonQuery();
                        tampil();
                        totalHarga();
                        kon.Close();
                        clear_beli();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            simpanPembelian();
            clear();
            button1.Text = "Add";
        }

        public void cekharga()
        {
            kon.Open();
            try
            {
                MySqlCommand cm = new MySqlCommand("SELECT harga FROM obat WHERE nama_obat='" + comboBox3.Text  + "'", kon);
                MySqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    textBox6.Text = dr[0].ToString();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            kon.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cekharga();
            button1.Text = "Update";
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                tharga = int.Parse(textBox8.Text);
                bayar = int.Parse(textBox9.Text);
                kembali = bayar - tharga;
                textBox10.Text = Convert.ToString(kembali);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                comboBox1.Enabled = true;
                tampil_namaPasien();
            }
            else
            {
                comboBox1.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false)
            {
                comboBox1.Enabled = false;
                comboBox1.Items.Clear();
                comboBox1.Text = "PILIH";
            }
            else
            {
                comboBox1.Enabled = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                textBox3.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                textBox3.Enabled = false;
            }
            else
            {
                textBox3.Enabled = true;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cekharga();
        }
    }
}