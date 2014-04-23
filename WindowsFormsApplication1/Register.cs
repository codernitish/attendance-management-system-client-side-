using System;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

using NITGEN.SDK.NBioBSP;
namespace WindowsFormsApplication2
{
    public partial class Register : Form
    {
        NBioAPI m_NBioAPI;
        NBioAPI.IndexSearch m_IndexSearch;
        DB dbcon;
        WINSCP sftp;

        public Register()
        {
            InitializeComponent();
            m_NBioAPI = new NBioAPI();
            m_IndexSearch = new NBioAPI.IndexSearch(m_NBioAPI);
            dbcon = new DB();
            sftp = new WINSCP();
        }



        private void Register_Load(object sender, EventArgs e)
        {

            uint ret = m_IndexSearch.InitEngine();
            if (ret != NBioAPI.Error.NONE)
            {
                DisplayErrorMsg(ret);
            }

            NBioAPI.Type.VERSION version = new NBioAPI.Type.VERSION();
            m_NBioAPI.GetVersion(out version);

        }

        private void DisplayErrorMsg(uint ret)
        {
            MessageBox.Show(NBioAPI.Error.GetErrorDescription(ret) + " [" + ret.ToString() + "]", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void rg_btn_Click(object sender, EventArgs e)
        {

            label.Text = "Please wait......";
            string type = type_list.SelectedItem + "";

            string roll = id_tf.Text;
            string name = name_tf.Text;
            string email = email_tf.Text;
            string phone = ph_tf.Text;
            string pass;
            int flag = 1;
            if (roll == "" || name == "" || email == "")
            {
                
                MessageBox.Show("Fields marked with * are necessary!");
                return;
            }
            if (type == "Staff")
            {
                pass = pass_tf.Text;
                if (pass == "")
                {
                    MessageBox.Show("Fields marked with * are necessary!");
                    return;
                }
            }
            
            string sno="0";

            string path = System.Environment.CurrentDirectory;
           
           // string szFileName = path.Substring(0, path.LastIndexOf("bin")) + "data\\" + "data.txt";
            string szFileName = path+"\\data.fpdt";
            
            uint ret = NBioAPI.Error.NONE;
            if (File.Exists(szFileName))
            {
                m_IndexSearch.ClearDB();
                ret = m_IndexSearch.LoadDBFromFile(szFileName);
                if (ret != NBioAPI.Error.NONE)
                {
                    DisplayErrorMsg(ret);
                    label.Text = "Unable to register";
                    return;
                }
            }


            try
            {
                dbcon.OpenConnection();
                string select_query = "SELECT count from count;";
                MySqlCommand cmd = new MySqlCommand(select_query, dbcon.connection);
                MySqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    sno = dr["count"] + "";
                    dr.Close();
                    
                }
                else
                {
                    flag = 0;
                }

                select_query = "SELECT * from registered where id_no=@id;";
                cmd = new MySqlCommand(select_query, dbcon.connection);
                cmd.Parameters.AddWithValue("@id", roll);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    flag = 0;
                    MessageBox.Show("Id Should be unique");

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No Connection Found");
                flag = 0;
            }

            finally
            {
                dbcon.CloseConnection();
            }


            uint  nUserID = Convert.ToUInt32(sno, 10)+1;
            if (flag == 0)
            {
                label.Text = "Unable to register";
                return;
            }

            try
            {
                NBioAPI.Type.HFIR hNewFIR;
                m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                ret = m_NBioAPI.Enroll(out hNewFIR, null);
                if (ret != NBioAPI.Error.NONE)
                {
                    DisplayErrorMsg(ret);
                    m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                    label.Text = "Unable to register";
                    return;

                }

                m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);

                NBioAPI.IndexSearch.FP_INFO[] fpInfo;
                ret = m_IndexSearch.AddFIR(hNewFIR, nUserID, out fpInfo);
                if (ret != NBioAPI.Error.NONE)
                {
                    label.Text = "Unable to register";
                    return;
                }

                ret = m_IndexSearch.SaveDBToFile(szFileName);
                if (ret != NBioAPI.Error.NONE)
                {
                    DisplayErrorMsg(ret);

                    label.Text = "Unable to register";
                    return;
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
                label.Text = "Unable to register";
                return;
            }

           try
           {
               dbcon.OpenConnection();
               string query;
               //string query = "INSERT INTO fpa VALUES(@p_nUserID,@p_roll,@p_name)";
               MySqlCommand cmd = dbcon.connection.CreateCommand();
               MySqlTransaction transaction;
               transaction = dbcon.connection.BeginTransaction();
               query = "INSERT Ignore INTO registered VALUES(@p_nUserID,@p_name,@p_roll,@p_ph,@p_email)";
               cmd.CommandText = query;

               cmd.Parameters.AddWithValue("@p_nUserID", nUserID);
               cmd.Parameters.AddWithValue("@p_roll", roll);
               cmd.Parameters.AddWithValue("@p_name", name);
               cmd.Parameters.AddWithValue("@p_ph", phone);
               cmd.Parameters.AddWithValue("@p_email", email);
               cmd.ExecuteNonQuery();
               


               if (type == "Staff")
               {
                   pass = pass_tf.Text;
                   query = "INSERT INTO faculty VALUES(@p_nUserID1,@p_pass)";
                   //string query = "INSERT INTO fpa VALUES(@p_nUserID,@p_roll,@p_name)";
                   // MySqlCommand cmd = dbcon.connection.CreateCommand();
                   cmd.CommandText = query;

                   cmd.Parameters.AddWithValue("@p_nUserID1", roll);
                   cmd.Parameters.AddWithValue("@p_pass", pass);

                   cmd.ExecuteNonQuery();
               }

               query = "update count set count=@p_count where count=@p_count1;";
               cmd = new MySqlCommand(query, dbcon.connection);
               cmd.Parameters.AddWithValue("@p_count", nUserID);
               cmd.Parameters.AddWithValue("@p_count1", nUserID - 1);
               cmd.ExecuteNonQuery();
               sftp.upload();
               transaction.Commit();
           }

           catch (MySqlException ex)
           {
               MessageBox.Show("Problems with Internet connectivity");
               label.Text = "Unable to register";
               nUserID = Convert.ToUInt32(sno, 10);

               ret = m_IndexSearch.RemoveUser(nUserID);
               ret = m_IndexSearch.SaveDBToFile(szFileName);
               return;

           }
           finally
           {
               dbcon.CloseConnection();
           }

           try
           {
               if (img_tf.Text != "")
               {
                   label.Text = "uploading Image..";
                   sftp.upload_image("" + nUserID, img_tf.Text);
                   sftp.image_download("" + nUserID);
                   label.Text = "Registration complete";
               }
               else
               {
                   label.Text = "Registration complete";
               }
           }
           catch
           {
               label.Text = "Registration complete but image upload failed";
           }

           
            
            
            name_tf.Text = "";
            id_tf.Text = "";
            ph_tf.Text = "";
            email_tf.Text = "";
            img_tf.Text = "";
            pass_tf.Text = "";


        }

        private void class_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = type_list.SelectedItem + "";
            if (type == "Staff")
            {
                pass_label.Visible = true;
                pass_tf.Visible = true;
            }
            else
            {
                pass_label.Visible = false;
                pass_tf.Visible = false;
            }

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void id_tf_TextChanged(object sender, EventArgs e)
        {
            string type = type_list.SelectedItem + "";
            if (type == "Staff")
            {

                pass_tf.Text = id_tf.Text;
            }
        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPEG|*.jpg;*.jpeg";
            
            DialogResult result = dialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                img_tf.Text = dialog.FileName;
            }
        }



    }

}



