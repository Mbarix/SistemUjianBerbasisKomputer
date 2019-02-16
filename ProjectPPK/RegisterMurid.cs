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
    public partial class RegisterMurid : Form
    {
        public static Form1 f1 = new Form1();
        public RegisterMurid()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            Environment.Exit(1);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            f1.Show();
        }

        private void txtBoxPass_OnValueChanged(object sender, EventArgs e)
        {
            txtBoxPass.isPassword = true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Boolean lengkap=true;
            lblPASSerror.Visible = false;
            lblNISerror.Visible = false;
            lblNAMAerror.Visible = false;
            lbl8digit.Visible = false;
            lblPASSerror.Visible = false;

            if (txtBoxNIS.Text == "") {
                lbl8digit.Visible = false;
                lblNISerror.Visible = true;
                lengkap = false;
            }
            else if (txtBoxNIS.Text.Length != 8)
            {
                lbl8digit.Visible = true;
                lengkap = false;
            }
            if (txtBoxNama.Text == "")
            {
                lblNAMAerror.Visible = true;
                lengkap = false;
            }
            if (txtBoxPass.Text == "")
            {
                lblPasslimit.Visible = false;
                lblPASSerror.Visible = true;
                lengkap = false;
            }
            else if (txtBoxPass.Text.Length < 8)
            {
                lblPasslimit.Visible = true;
                lengkap = false;
            }
            
            
            if (lengkap)
            {
                string connect = "datasource=localhost; port=3306; username=root; password=; database=unbk;SslMode=none";
                MySqlConnection myConnection = new MySqlConnection(connect);
                try
                {
                    
                        myConnection.Open();
                        MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO siswa (nis, namaSiswa, password) VALUES (@nis, @nama, @pass)", myConnection);
                        mySqlCommand.Parameters.AddWithValue("@nis", txtBoxNIS.Text);
                        mySqlCommand.Parameters.AddWithValue("@nama", txtBoxNama.Text);
                        mySqlCommand.Parameters.AddWithValue("@pass", txtBoxPass.Text);
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
    }
}
