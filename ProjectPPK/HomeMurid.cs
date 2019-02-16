using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;

namespace ProjectPPK
{
    public partial class HomeMurid : Form
    {
        private String kodeUjian;
        private String kodeMapel;
        private String namaMapel;
        private double nilaiAkhir;
        private Boolean submit = false;
        Color kuning = Color.FromArgb(235, 208, 119);
        Color biru = Color.FromArgb(41, 128, 185);

        ArrayList soal = new ArrayList();
        ArrayList pila = new ArrayList();
        ArrayList pilb = new ArrayList();
        ArrayList pilc = new ArrayList();
        ArrayList pild = new ArrayList();
        ArrayList jawaban = new ArrayList();
        ArrayList jawabanMurid = new ArrayList();

        public static Form1 f1;
        private int nomorSoal = 1;

        System.Timers.Timer timer;
        int h, m, d;

        bool isValid = false;
        static string connect = "datasource=localhost; port=3306; username=root; password=; database=unbk; SslMode=none";
        MySqlConnection myConnection;

        public HomeMurid()
        {
            InitializeComponent();
            lblScore.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }

        private void btnKerjakan_Click(object sender, EventArgs e)
        {
            panelKodeUjian.Visible = true;
            panelPilih.Visible = false;
            btnBack.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(panelScore.Visible != true)
            {
                panelKodeUjian.Visible = false;
                panelPilih.Visible = true;
                panelScore.Visible = false;
                panelEditProfile.Visible = false;
                btnBack.Visible = false;
                btnClose.Visible = true;
            }
            else
            {
                panelScore.Visible = false;
                lblTimer.Visible = true;
                btnBack.Visible = false;
                btnSubmitJawaban.Visible = false;
                btnNext.Visible = true;
                btnPrev.Visible = true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Boolean kodeSubmit = true;
            lblKODEerror.Visible = false;
            btnBack.Visible = false;
            if(txtBoxKode.Text == "")
            {
                kodeSubmit = false;
                lblKODEerror.Visible = true;
            }
            if (kodeSubmit)
            {
                checkKodeMatpel();
                getSoal();
                getSoalFromArrayList(1);
                lblUjian.Visible = true;
                lblNama.Text = "Nama : "+Login.getNama();
                lblNama.Visible = true;
            }
        }

        private void checkKodeMatpel()
        {
            kodeUjian = txtBoxKode.Text;
            try
            {
                myConnection = new MySqlConnection(connect);
                myConnection.Open();

                MySqlCommand myCommand = new MySqlCommand("SELECT guru.kodeMapel, guru.namaMapel, ujian.kodeUjian FROM ujian INNER JOIN guru ON ujian.kodeMapel = guru.kodeMapel WHERE ujian.kodeUjian = @kodeUjian", myConnection);
                myCommand.Parameters.AddWithValue("@kodeUjian", kodeUjian);
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    isValid = true;
                    kodeMapel = myReader[0].ToString();
                    namaMapel = myReader[1].ToString();
                }
                myReader.Close();

                if (isValid)
                {
                    panelKodeUjian.Visible = false;
                    panelSoal.Visible = true;
                    lblTimer.Visible = true;

                    lblUjian.Text = "Mata Pelajaran : " + namaMapel + " (" + kodeMapel + ")";

                    timer = new System.Timers.Timer();
                    timer.Interval = 1000;
                    timer.Elapsed += OnTimeEvent;
                    timer.Start();
                }
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
        }

        private void checkWarna(int no)
        {
            int nomor = no - 1;
            if (jawabanMurid[nomor].Equals(pila[nomor]))
            {
                btnA.Normalcolor = kuning;
            } else if (jawabanMurid[nomor].Equals(pilb[nomor]))
            {
                btnB.Normalcolor = kuning;
            } else if (jawabanMurid[nomor].Equals(pilc[nomor]))
            {
                btnC.Normalcolor = kuning;
            } else if (jawabanMurid[nomor].Equals(pild[nomor]))
            {
                btnD.Normalcolor = kuning;
            }
        }

        private void getSoalFromArrayList(int no)
        {
            lblNomor.Text = nomorSoal + ".";
            int nomor = no - 1;
            txtBoxSoal.Text = soal[nomor].ToString();
            btnA.Text = pila[nomor].ToString();
            btnB.Text = pilb[nomor].ToString();
            btnC.Text = pilc[nomor].ToString();
            btnD.Text = pild[nomor].ToString();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            btnA.Normalcolor = biru;
            btnB.Normalcolor = biru;
            btnC.Normalcolor = biru;
            btnD.Normalcolor = biru;

            nomorSoal--;
            if(!jawabanMurid[nomorSoal-1].Equals(""))
            {
                checkWarna(nomorSoal);
            }

            checkNomorSoal(nomorSoal);
            getSoalFromArrayList(nomorSoal);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnA.Normalcolor = biru;
            btnB.Normalcolor = biru;
            btnC.Normalcolor = biru;
            btnD.Normalcolor = biru;
            nomorSoal++;
            if (nomorSoal<soal.Count && !(jawabanMurid[nomorSoal-1].Equals("")))
            {
                checkWarna(nomorSoal);
            }

            checkNomorSoal(nomorSoal);

            if ((nomorSoal-1) == soal.Count)
            {
                panelSoal.Visible = false;
                panelScore.Visible = true;
                lblTimer.Visible = false;
                lblScore.Visible = false;
                lblNilaiAkhir.Visible = false;
                btnSubmitJawaban.Visible = true;
                btnNext.Visible = false;
                btnPrev.Visible = false;
            }else
                getSoalFromArrayList(nomorSoal);
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            jawabanMurid[nomorSoal - 1] = btnA.Text;
            btnA.Normalcolor = kuning;
            btnB.Normalcolor = biru;
            btnC.Normalcolor = biru;
            btnD.Normalcolor = biru;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            jawabanMurid[nomorSoal - 1] = btnC.Text;
            btnC.Normalcolor = kuning;
            btnB.Normalcolor = biru;
            btnA.Normalcolor = biru;
            btnD.Normalcolor = biru;
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            jawabanMurid[nomorSoal - 1] = btnB.Text;
            btnB.Normalcolor = kuning;
            btnA.Normalcolor = biru;
            btnC.Normalcolor = biru;
            btnD.Normalcolor = biru;
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            jawabanMurid[nomorSoal - 1] = btnD.Text;

            btnD.Normalcolor = kuning;
            btnB.Normalcolor = biru;
            btnC.Normalcolor = biru;
            btnA.Normalcolor = biru;
        }

        private void hitungNilaiAkhir()
        {
            int score = 0;
            for (int i = 0; i < jawaban.Count; i++)
            {
                if (jawabanMurid[i].Equals(jawaban[i]))
                    score ++;
            }
            nilaiAkhir = (Double)score/soal.Count*100;
        }

        private void checkNomorSoal(int no)
        {
            if (no == 1)
            {
                btnPrev.Visible = false;
            } else
            {
                btnPrev.Visible = true;
            }
        }

        private void btnSubmitJawaban_Click(object sender, EventArgs e)
        {
            btnSubmitJawaban.Visible = false;
            hitungNilaiAkhir();
            lblNilaiAkhir.Text = "" + nilaiAkhir;
            submit = true;
            lblScore.Visible = true;
            lblNilaiAkhir.Visible = true;

            string connect = "datasource=localhost; port=3306; username=root; password=; database=unbk;SslMode=none";
            MySqlConnection myConnection = new MySqlConnection(connect);

            try
            {
                myConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO nilai(nis, kodeUjian, nilai) " +
                    "VALUES(@nis, @kodeUjian, @nilai)", myConnection);
                mySqlCommand.Parameters.AddWithValue("@nis", Login.nomorInduk);
                mySqlCommand.Parameters.AddWithValue("@nilai", nilaiAkhir);
                mySqlCommand.Parameters.AddWithValue("@kodeUjian", kodeUjian);
                mySqlCommand.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            panelPilih.Visible = false;
            panelKodeUjian.Visible = false;
            panelSoal.Visible = false;
            panelEditProfile.Visible = true;
            btnBack.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connect = "datasource=localhost; port=3306; username=root; password=; database=unbk;SslMode=none";
            MySqlConnection myConnection = new MySqlConnection(connect);

            try
            {
                myConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("UPDATE siswa SET namaSiswa=@nama, password=@pass WHERE idSiswa=@id", myConnection);
                mySqlCommand.Parameters.AddWithValue("@nama", txtBoxNama.Text);
                mySqlCommand.Parameters.AddWithValue("@pass", txtBoxPassBaru.Text);
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
                MySqlCommand mySqlCommand = new MySqlCommand("DELETE FROM siswa WHERE idSiswa=@id", myConnection);
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

        private void txtBoxPassBaru_OnValueChanged(object sender, EventArgs e)
        {
            txtBoxPassBaru.isPassword = true;
        }

        private void getSoal()
        {
            string connect = "datasource=localhost; port=3306; username=root; password=; database=unbk;SslMode=none";
            MySqlConnection myConnection = new MySqlConnection(connect);

            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM soal WHERE kodeUjian = @kodeUjian", myConnection);
            mySqlCommand.Parameters.AddWithValue("@kodeUjian", kodeUjian);

            MySqlDataReader reader;
            try
            {
                myConnection.Open();
                reader = mySqlCommand.ExecuteReader();
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        soal.Add(reader.GetString(1));
                        pila.Add(reader.GetString(2));
                        pilb.Add(reader.GetString(3));
                        pilc.Add(reader.GetString(4));
                        pild.Add(reader.GetString(5));
                        jawaban.Add(reader.GetString(6));
                        jawabanMurid.Add("");
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

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                d += 1;
                if (d == 60)
                {
                    d = 0;
                    m += 1;

                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }
                if (h == 1)
                {
                    timer.Stop();
                }
                lblTimer.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), d.ToString().PadLeft(2, '0'));
            }));
        }
    }
}
