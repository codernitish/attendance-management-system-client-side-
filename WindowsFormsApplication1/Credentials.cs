using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApplication2
{
    public partial class Credentials : Form
    {
        public Credentials()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
             string id = oid_tf.Text;
            string pass = opass_tf.Text;
            string actpass = Secure.Decrypt(ConfigurationManager.AppSettings["password"]);
            string actid = ConfigurationManager.AppSettings["id"];


            if (id == actid && pass == actpass)
            {
                if (newpass_tf.Text == "")
                {
                    warn_label.Text = "Please enter the new password!";
                }
                else
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["password"].Value = Secure.Encrypt(newpass_tf.Text);
                    if(newid_tf.Text!="")
                    {
                    config.AppSettings.Settings["id"].Value = newid_tf.Text;
                    }

                    if (db_server_tf.Text != "")
                    {
                        config.AppSettings.Settings["server"].Value = db_server_tf.Text;
                    }

                    if (db_name_tf.Text != "")
                    {
                        config.AppSettings.Settings["db_name"].Value = db_name_tf.Text;
                    }

                    if (db_user_tf.Text != "")
                    {
                        config.AppSettings.Settings["db_id"].Value = db_user_tf.Text;
                    }

                    if (db_pass_tf.Text != "")
                    {
                        config.AppSettings.Settings["db_pass"].Value = Secure.Encrypt(db_pass_tf.Text);
                    }
                    if (db_pass_tf.Text == "")
                    {
                        config.AppSettings.Settings["db_pass"].Value = db_pass_tf.Text;
                    }

                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    MessageBox.Show("Some changes require application to be restarted");
                    this.Close();
                }
            }
            else
            {
                warn_label.Text = "Wrong Id or Password. Try Again!";
                opass_tf.Text = "";
                oid_tf.Text = "";
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
