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

namespace ProjectPPK
{
    public partial class Login : Form
    {
        bool isValid = false;
        static string connect = "datasource=localhost; port=3306; username=root; password=; database=unbk; SslMode=none";
        MySqlConnection myConnection = new MySqlConnection(connect);
        public static Form1 f1 = new Form1();

        public static String kodeMapel;
        public static String nama;
        public static String nomorInduk;
        public static String id;

        public static String getKodeMapel()
        {
            return kodeMapel;
        }

        public static String getNama()
        {
            return nama;
        }

        public static string getNomorInduk()
        {
            return nomorInduk;
        }

        public Login()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }

        private void txtBoxPass_OnValueChanged(object sender, EventArgs e)
        {
            txtBoxPass.isPassword = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            f1.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Boolean lengkap = true;
            lblPasserror.Visible = false;
            lblIndukerror.Visible = false;
            if (txtBoxNomor.Text == "")
            {
                lblIndukerror.Visible = true;
                lengkap = false;
            }
            if (txtBoxPass.Text == "")
            {
                lblPasserror.Visible = true;
                lengkap = false;
            }

            if (lengkap)
            {
                try
                {
                    myConnection.Open();
                    checkSiswa();
                    checkGuru();
                    if (!isValid)
                    {
                        MessageBox.Show("Username atau password yang anda masukkan salah!");
                    }
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    myConnection.Close();
                }
            }
        }

        private void checkSiswa()
        {
            MySqlCommand myCommand = new MySqlCommand("SELECT * FROM siswa WHERE nis = @nis AND password = @passwordSiswa", myConnection);
            myCommand.Parameters.AddWithValue("@nis", txtBoxNomor.Text);
            myCommand.Parameters.AddWithValue("@passwordSiswa", txtBoxPass.Text);
            MySqlDataReader myReader;
            myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                id = myReader[0].ToString();
                nomorInduk =  myReader[1].ToString();
                nama = myReader[2].ToString();
                new HomeMurid().Show();
                this.Hide();
                isValid = true;
            }
            myReader.Close();
        }
        private void checkGuru()
        {
            MySqlCommand myCommand = new MySqlCommand("SELECT * FROM guru WHERE nip = @NIP AND password = @passwordGuru", myConnection);
            myCommand.Parameters.AddWithValue("@NIP", txtBoxNomor.Text);
            myCommand.Parameters.AddWithValue("@passwordGuru", txtBoxPass.Text);
            MySqlDataReader myReader;
            myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                id = myReader[0].ToString();
                nomorInduk = myReader[1].ToString();
                nama = myReader[2].ToString();
                kodeMapel = myReader[5].ToString();
                
                new HomeGuru().Show();
                this.Hide();
                isValid = true;
            }
            myReader.Close();
        }
    }
}