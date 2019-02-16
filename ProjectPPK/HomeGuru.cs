using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;

namespace ProjectPPK
{
    public partial class HomeGuru : Form
    {
        public static String kodeUjian;
        private String nomor;
        private ArrayList idSoal = new ArrayList();
        public static Form1 f1;

        public static String getKodeUjian()
        {
            return kodeUjian;
        }

        String textUbah = "UBAH SOAL UJIAN";
        String textTambah = "TAMBAH SOAL UJIAN BARU";
        String textLihat = "MASUKKAN KODE UJIAN";
        public HomeGuru()
        {
            InitializeComponent();
            lblSelamatDatang.Text = "Selamat Datang\n" + Login.getNama() + " (" + Login.getNomorInduk() + ")";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            lblSubmitKode.Text = textUbah;
            btnBack.Visible = true;
            panelPilih.Visible = false;
            panelSubmit.Visible = true;
        }

        private void btnBuat_Click(object sender, EventArgs e)
        {
            lblSubmitKode.Text = textTambah;
            btnBack.Visible = true;
            panelPilih.Visible = false;
            panelSubmit.Visible = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Boolean lengkap = true;
            lblKODEerror.Visible = false;
            if (txtBoxKode.Text == "")
            {
                lblKODEerror.Visible = true;
                lengkap = false;
            }

            if (lengkap)
            {
                string connect = "datasource=localhost; port=3306; username=root; password=; database=unbk;SslMode=none";
                MySqlConnection myConnection = new MySqlConnection(connect);

                if (lblSubmitKode.Text == textUbah)
                {
                    //ubah di database
                    kodeUjian = txtBoxKode.Text;

                    myConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM ujian WHERE kodeMapel = @kodeMapel AND kodeUjian = @kodeUjian", myConnection);
                    mySqlCommand.Parameters.AddWithValue("@kodeMapel", Login.getKodeMapel());
                    mySqlCommand.Parameters.AddWithValue("@kodeUjian", kodeUjian);
                    mySqlCommand.ExecuteNonQuery();
                    
                    try
                    {
                        MySqlDataReader reader;

                        reader = mySqlCommand.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Close();

                            mySqlCommand = new MySqlCommand("SELECT * FROM soal WHERE kodeUjian = @kodeUjian", myConnection);
                            mySqlCommand.Parameters.AddWithValue("@kodeUjian", txtBoxKode.Text);
                            mySqlCommand.ExecuteNonQuery();

                            reader = mySqlCommand.ExecuteReader();

                            int no = 1;
                            while (reader.Read())
                            {
                                string[] row = { no.ToString(), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6) };
                                var listViewItem = new ListViewItem(row);
                                ListSoalUjian.Items.Add(listViewItem);
                                idSoal.Add(reader.GetString(0));
                                no++;
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                        

                        reader.Close();
                        myConnection.Close();
                        panelSubmit.Visible = false;
                        panelSoalUjian.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        myConnection.Close();
                    }
                }
                else if (lblSubmitKode.Text == textTambah)
                {
                    //tambah di database
                    rtBoxSoal.Text = "";
                    txtBoxA.Text = "";
                    txtBoxB.Text = "";
                    txtBoxC.Text = "";
                    txtBoxD.Text = "";
                    txtBoxJawaban.Text = "";
                    ListSoalUjian.Items.Clear();
                    try
                    {
                        kodeUjian = txtBoxKode.Text;
                        myConnection.Open();
                        MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO ujian (kodeUjian, kodeMapel) " +
                            "VALUES (@kodeUjian, @kodeMapel)", myConnection);
                        mySqlCommand.Parameters.AddWithValue("@kodeUjian", kodeUjian);
                        mySqlCommand.Parameters.AddWithValue("@kodeMapel", Login.getKodeMapel());
                        mySqlCommand.ExecuteNonQuery();
                        myConnection.Close();
                        panelSubmit.Visible = false;
                        panelSoalUjian.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        myConnection.Close();
                    }
                }else if(lblSubmitKode.Text == textLihat)
                {
                    myConnection.Open();
                    MySqlCommand mySqlCommandCek = new MySqlCommand("SELECT * FROM guru join ujian on guru.kodeMapel=ujian.kodeMapel WHERE kodeUjian=@kodeUjian AND guru.nip =@nip",myConnection);

                    mySqlCommandCek.Parameters.AddWithValue("@kodeUjian", txtBoxKode.Text);
                    mySqlCommandCek.Parameters.AddWithValue("@nip", Login.nomorInduk);
                    mySqlCommandCek.ExecuteNonQuery();
                    MySqlDataReader reader = mySqlCommandCek.ExecuteReader();
                    if (reader.HasRows)
                   {
                        reader.Close();
                        MySqlCommand mySqlCommand = new MySqlCommand("SELECT s.nis, s.namaSiswa, n.nilai FROM nilai n INNER JOIN siswa s ON s.nis = n.nis WHERE n.kodeUjian=@kodeUjian", myConnection);
                        mySqlCommand.Parameters.AddWithValue("@kodeUjian", txtBoxKode.Text);
                        mySqlCommand.ExecuteNonQuery();

                        try
                       {
                            reader = mySqlCommand.ExecuteReader();
                            if (reader.HasRows)
                            {
                                int no = 1;
                                while (reader.Read())
                                {
                                    string[] row = { no.ToString(), reader[0].ToString(), reader[1].ToString(), reader[2].ToString() };
                                    var listViewItem = new ListViewItem(row);
                                    listNilai.Items.Add(listViewItem);
                                    no++;
                                }
                            reader.Close();
                        }
                            else
                            {
                                Console.WriteLine("No rows found.");
                            }

                            reader.Close();
                            myConnection.Close();
                            panelSubmit.Visible = false;
                            panelLihatNilai.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            myConnection.Close();
                       }
                    }
                    else
                    {
                        MessageBox.Show("kode soal tidak ditemukan");
                    }
                    
               }
            }
        }

        private void ListSoalUjian_MouseClick(object sender, MouseEventArgs e)
        {
            nomor = ListSoalUjian.SelectedItems[0].SubItems[0].Text;
            rtBoxSoal.Text = ListSoalUjian.SelectedItems[0].SubItems[1].Text;
            txtBoxA.Text = ListSoalUjian.SelectedItems[0].SubItems[2].Text;
            txtBoxB.Text = ListSoalUjian.SelectedItems[0].SubItems[3].Text;
            txtBoxC.Text = ListSoalUjian.SelectedItems[0].SubItems[4].Text;
            txtBoxD.Text = ListSoalUjian.SelectedItems[0].SubItems[5].Text;
            txtBoxJawaban.Text = ListSoalUjian.SelectedItems[0].SubItems[6].Text;

        }

        private void showSoal()
        {
            ListSoalUjian.Items.Clear();
            idSoal.Clear();
            string connect = "datasource=localhost; port=3306; username=root; password=; database=unbk;SslMode=none";
            MySqlConnection myConnection = new MySqlConnection(connect);

            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM soal WHERE kodeUjian = @kodeUjian", myConnection);
            mySqlCommand.Parameters.AddWithValue("@kodeUjian", kodeUjian);
            mySqlCommand.CommandTimeout = 60;

            MySqlDataReader reader;
            try
            {
                myConnection.Open();
                reader = mySqlCommand.ExecuteReader();
                int no;
                if (reader.HasRows)
                {
                    no = 1;
                    while (reader.Read())
                    {
                        string[] row = { no.ToString(), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6) };
                        var listViewItem = new ListViewItem(row);
                        ListSoalUjian.Items.Add(listViewItem);
                        idSoal.Add(reader.GetString(0));
                        no++;
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connect = "datasource=localhost; port=3306; username=root; password=; database=unbk;SslMode=none";
            MySqlConnection myConnection = new MySqlConnection(connect);

            try
            {
                myConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO soal(soal, pilihanA, pilihanB, pilihanC, pilihanD, jawaban, kodeUjian) " +
                    "VALUES(@soal, @pila, @pilb, @pilc, @pild, @jawaban, @kodeUjian)", myConnection);
                mySqlCommand.Parameters.AddWithValue("@soal", rtBoxSoal.Text);
                mySqlCommand.Parameters.AddWithValue("@pila", txtBoxA.Text);
                mySqlCommand.Parameters.AddWithValue("@pilb", txtBoxB.Text);
                mySqlCommand.Parameters.AddWithValue("@pilc", txtBoxC.Text);
                mySqlCommand.Parameters.AddWithValue("@pild", txtBoxD.Text);
                mySqlCommand.Parameters.AddWithValue("@jawaban", txtBoxJawaban.Text);
                mySqlCommand.Parameters.AddWithValue("@kodeUjian", kodeUjian);
                mySqlCommand.ExecuteNonQuery();
                myConnection.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            showSoal();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connect = "datasource=localhost; port=3306; username=root; password=; database=unbk;SslMode=none";
            MySqlConnection myConnection = new MySqlConnection(connect);

            try
            {
                myConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("UPDATE soal SET soal=@soal, pilihanA=@pila, pilihanB=@pilb, pilihanC=@pilc, pilihanD=@pild, jawaban=@jawaban, kodeUjian=@kodeUjian WHERE idSoal=@id", myConnection);
                mySqlCommand.Parameters.AddWithValue("@soal", rtBoxSoal.Text);
                mySqlCommand.Parameters.AddWithValue("@pila", txtBoxA.Text);
                mySqlCommand.Parameters.AddWithValue("@pilb", txtBoxB.Text);
                mySqlCommand.Parameters.AddWithValue("@pilc", txtBoxC.Text);
                mySqlCommand.Parameters.AddWithValue("@pild", txtBoxD.Text);
                mySqlCommand.Parameters.AddWithValue("@jawaban", txtBoxJawaban.Text);
                mySqlCommand.Parameters.AddWithValue("@kodeUjian", kodeUjian);
                int no = Int32.Parse(nomor)-1;
                mySqlCommand.Parameters.AddWithValue("@id", idSoal[no]);
                mySqlCommand.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            showSoal();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            showSoal();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connect = "datasource=localhost; port=3306; username=root; password=; database=unbk;SslMode=none";
            MySqlConnection myConnection = new MySqlConnection(connect);

            try
            {
                myConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("DELETE FROM soal WHERE idSoal=@id", myConnection);
                int no = Int32.Parse(nomor) - 1;
                mySqlCommand.Parameters.AddWithValue("@id", idSoal[no]);
                mySqlCommand.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            showSoal();
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            panelPilih.Visible = false;
            panelEditProfile.Visible = true;
            btnBack.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnBack.Visible = false;
            panelSubmit.Visible = false;
            panelSoalUjian.Visible = false;
            panelEditProfile.Visible = false;
            panelPilih.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connect = "datasource=localhost; port=3306; username=root; password=; database=unbk;SslMode=none";
            MySqlConnection myConnection = new MySqlConnection(connect);

            try
            {
                myConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("UPDATE guru SET nama=@nama, password=@pass, namaMapel=@namaMapel, kodeMapel=@kodeMapel WHERE idGuru=@id", myConnection);
                mySqlCommand.Parameters.AddWithValue("@nama", txtBoxNama.Text);
                mySqlCommand.Parameters.AddWithValue("@pass", txtBoxPassBaru.Text);
                mySqlCommand.Parameters.AddWithValue("@namaMapel", txtBoxNamaMapel.Text);
                mySqlCommand.Parameters.AddWithValue("@kodeMapel", txtBoxKodeMapel.Text);
                mySqlCommand.Parameters.AddWithValue("@id", Login.id);
                mySqlCommand.ExecuteNonQuery();
                myConnection.Close();
                MessageBox.Show("Data diri telah diperbarui");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHapusAkun_Click(object sender, EventArgs e)
        {
            string connect = "datasource=localhost; port=3306; username=root; password=; database=unbk;SslMode=none";
            MySqlConnection myConnection = new MySqlConnection(connect);

            DialogResult dialogResult = MessageBox.Show("Yakin ingin menghapus akun Anda?", "HAPUS AKUN", MessageBoxButtons.YesNo);

            try
            {
                myConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("DELETE FROM guru WHERE idGuru=@id", myConnection);
                mySqlCommand.Parameters.AddWithValue("@id", Login.id);
                if (dialogResult == DialogResult.Yes)
                {
                    mySqlCommand.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("Akun telah dihapus");
                    this.Hide();
                    f1 = new Form1();
                    f1.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLihatNilai_Click(object sender, EventArgs e)
        {
            lblSubmitKode.Text = textLihat;
            panelSubmit.Visible = true;
            panelPilih.Visible = false;
            btnBack.Visible = true;
        }

        private void txtBoxPassBaru_OnValueChanged(object sender, EventArgs e)
        {
            txtBoxPassBaru.isPassword = true;
        }
    }
}
