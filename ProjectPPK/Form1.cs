using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProjectPPK
{
    public partial class Form1 : Form
    {
        public static Login lgn;
        public static RegisterMurid mrd;
        public static RegisterGuru gru;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            btnRgstrMurid.Text = "REGISTER"+ Environment.NewLine + "sebagai Murid";
            btnRgstrGuru.Text = "REGISTER" + Environment.NewLine + "sebagai Guru";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Register_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }

        private void btnLoginMurid_Click(object sender, EventArgs e)
        {
            lgn = new Login();
            this.Hide();
            lgn.Show();
        }

        private void btnRgstrMurid_Click(object sender, EventArgs e)
        {
            mrd = new RegisterMurid();
            this.Hide();
            mrd.Show();
        }

        private void btnRgstrGuru_Click(object sender, EventArgs e)
        {
            gru = new RegisterGuru();
            this.Hide();
            gru.Show();
        }
    }
}
