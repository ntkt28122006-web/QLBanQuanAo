using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class frmFogotPassword : Form
    {
        public frmFogotPassword()
        {
            InitializeComponent();
            ShowStep(1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void ShowStep(int step)
        {
            pnlEmail.Visible = (step == 1);
            pnlOTP.Visible = (step == 2);
            pnlNewPassword.Visible = (step == 3);
        }

        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            ShowStep(2);
        }

        private void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            ShowStep(3);
        }

        private void foxLinkLabel1_Click(object sender, EventArgs e)
        {

        }

        private void lnkBackToLogin_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();

            this.Close();
        }
    }
}
