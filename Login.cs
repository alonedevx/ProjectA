using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjectA.LoginSettings;

namespace ProjectA
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        LoginSettings login = new LoginSettings();

        private void Form1_Load(object sender, EventArgs e)
        {
            if(login.IsRememberMe() == 1)
            {
                rememberMe.Checked = true;
                loginUsername.Text = login.GetLastUserInformation(0);
                loginPassword.Text = login.GetLastUserInformation(1);
            }
            tabControl1.Size = new Size(303, 198);
            this.Size = new Size(345, 264);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                tabControl1.Size = new Size(303, 198);
                this.Size = new Size(345, 264);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                tabControl1.Size = new Size(303, 268);
                this.Size = new Size(345, 335);
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            int returnCode = login.Register(registerUserName.Text, registerPassword.Text, registerPasswordRepeat.Text);

            if(returnCode == 0)
                MessageBox.Show(null, "Girilen şifrelerin aynı olmask gerekmektedir.\nLütfen kontrol edip tekrar deneyiniz.", "ProjectA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if(returnCode == 1)
                MessageBox.Show(null, "Bu kullanıcı zaten sisteme kayıtlı.", "ProjectA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if(returnCode == 10)
                MessageBox.Show(null, "Kullanıcı sisteme kayıt edildi!", "ProjectA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } 

        private void LoginButton_Click(object sender, EventArgs e)
        {
            int returnCode = login.Login(loginUsername.Text, loginPassword.Text, (int)rememberMe.CheckState);

            if (returnCode == 0)
                MessageBox.Show(null, "Username veya şifre hatalı!", "ProjectA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (returnCode == 10)
                MessageBox.Show(null, "Giriş başarılı.\nMerhaba, " + loginUsername.Text + "\nSisteme kayıt edildiği tarih : " + login.GetUserRegisterDate(loginUsername.Text), "ProjectA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
