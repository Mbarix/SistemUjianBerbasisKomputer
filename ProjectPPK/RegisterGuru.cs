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
    public partial class RegisterGuru : Form
    {
        public static Form1 f1;
        public RegisterGuru()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Boolean lengkap = true;
            lblPASSerror.Visible = false;
            lblNIPerror.Visible = false;
            lblNAMAerror.Visible = false;
            lblMATPELerror.Visible = false;
            lblKODEerror.Visible = false;
            lblPasslimit.Visible = false;
            lbl8digit.Visible = false;
            lbl18digit.Visible = false;

            if (txtBoxNIP.Text == "")
            {
                lbl18digit.Visible = false;
                lblNIPerror.Visible = true;
                lengkap = false;
            }
            else if (txtBoxNIP.Text.Length != 18)
            {
                lbl18digit.Visible = true;
                lengkap = false;
            }
            if (txtBoxNama.Text == "")
            {
                lblNAMAerror.Visible = true;
                lengkap = false;
            }
            if (txtBoxPass.Text == "")
            {
                lblPASSerror.Visible = false;
                lblPASSerror.Visible = true;
                lengkap = false;
            }
            else if (txtBoxPass.Text.Length < 8)
            {
                lblPasslimit.Visible = true;
                lengkap = false;
            }
            if (txtBoxMatpel.Text == "")
            {
                lblMATPELerror.Visible = true;
                lengkap = false;
            }
            if (txtBoxKode.Text == "")
            {
                lbl8digit.Visible = false;
                lblKODEerror.Visible = true;
                lengkap = false;
            }
            else if (txtBoxKode.Text.Length != 8)
            {
                lbl8digit.Visible = true;
                lengkap = false;
            }
            
            if (lengkap)
            {
                string connect = "datasource=localhost; port=3306; username=root; password=; database=unbk;SslMode=none";
                MySqlConnection myConnection = new MySqlConnection(connect);
                try
                {
                        myConnection.Open();
                        MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO guru (nip, nama, password, namaMapel, kodeMapel) " +
                            "VALUES (@nip, @nama, @password, @namaMapel, @kodeMapel)", myConnection);
                        mySqlCommand.Parameters.AddWithValue("@nip", txtBoxNIP.Text);
                        mySqlCommand.Parameters.AddWithValue("@nama", txtBoxNama.Text);
                        mySqlCommand.Parameters.AddWithValue("@password", txtBoxPass.Text);
                        mySqlCommand.Parameters.AddWithValue("@kodeMapel", txtBoxKode.Text);
                        mySqlCommand.Parameters.AddWithValue("@namaMapel", txtBoxMatpel.Text);
                        mySqlCommand.ExecuteNonQuery();
                        myConnection.Close();
                        MessageBox.Show("Anda telah terdaftar");
                        new Login().Show();
                        this.Hide();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    myConnection.Close();
                }
            }
        }

        private void txtBoxPass_OnValueChanged(object sender, EventArgs e)
        {
            txtBoxPass.isPassword = true;
        }
    }
}
