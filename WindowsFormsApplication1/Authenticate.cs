using System;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApplication2
{
    public partial class Authenticate : Form
    {
        public Authenticate()
        {
            InitializeComponent();
        }

        public string UserName
        {
            get { return id_tf.Text; } 
            set { id_tf.Text = value; } 
        }
        public string Password
        {
            get { return pass_tf.Text; }
            set { pass_tf.Text = value; }
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string id = id_tf.Text;
            string pass = pass_tf.Text;
            string actpass = Secure.Decrypt(ConfigurationManager.AppSettings["password"]);
            string actid = ConfigurationManager.AppSettings["id"];
            
           
            if (id == actid)
            {
                if (pass == actpass)
                {
                    login_btn.DialogResult = DialogResult.OK;

                    lg_btn.Visible = true;
                    lg_btn.PerformClick();
                }
                else
                {

                    warn_label.Text = "Wrong Password. Try Again!";
                    pass_tf.Text = "";

                }
            }
            else
            {
               
                warn_label.Text = "Wrong Id. Try Again!";
                pass_tf.Text = "";
                id_tf.Text = "";
            }
            
        }

        private void pass_tf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login_btn_Click(sender, e);
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
