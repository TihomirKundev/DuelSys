using SynthesisAssignment;
using SynthesisAssignment.Base_classes;
using SynthesisAssignment.Upload_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_app
{
    public partial class Form1 : Form
    {
        LoginRegister login;
        public Form1()
        {
            InitializeComponent();
            login = new LoginRegister(new UploadPeople());
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(EmailTxt.Text) || String.IsNullOrEmpty(PassTxt.Text))
            {
                MessageBox.Show("Some of the fields are empty!");
            }
            else
            {
                People people = login.Login(EmailTxt.Text, PassTxt.Text, "Staff");
                if (people == null)
                {
                    MessageBox.Show("Email or password is wrong!");
                }
                else
                {
                    MainForm mainForm = new MainForm();
                    mainForm.Visible = true;
                    this.Visible = false;
                }
                EmailTxt.Text = "";
                PassTxt.Text = "";
            }
        }
    }
}
