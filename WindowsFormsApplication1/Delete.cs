using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using NITGEN.SDK.NBioBSP;

namespace WindowsFormsApplication2
{
    public partial class Delete : Form
    {
        NBioAPI m_NBioAPI;
        NBioAPI.IndexSearch m_IndexSearch;
        DB dbcon;
        WINSCP sftp;
        public Delete()
        {
            InitializeComponent();
            m_NBioAPI = new NBioAPI();
            m_IndexSearch = new NBioAPI.IndexSearch(m_NBioAPI);
            dbcon = new DB();
            uint ret = m_IndexSearch.InitEngine();
            sftp = new WINSCP();
        }
        
        private void Delete_Load(object sender, EventArgs e)
        {

            NBioAPI.Type.VERSION version = new NBioAPI.Type.VERSION();
            m_NBioAPI.GetVersion(out version);

        }

        private void DisplayErrorMsg(uint ret)
        {
            MessageBox.Show(NBioAPI.Error.GetErrorDescription(ret) + " [" + ret.ToString() + "]", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            
            string roll = roll_tf.Text;
            if (roll_tf.Text == "")
            {
                label.Text="Please enter Id First";
                return;

            }
            string szFileName;
            string sno = "0";
            int flag = 1;
            string path = System.Environment.CurrentDirectory;
            szFileName = path + "\\data.fpdt";

            try
            {
                m_IndexSearch.ClearDB();
                uint ret = NBioAPI.Error.NONE;
                ret = m_IndexSearch.LoadDBFromFile(szFileName);
                if (ret != NBioAPI.Error.NONE)
                {
                    DisplayErrorMsg(ret);
                    return;
                }

                dbcon.OpenConnection();
                string select_query = "SELECT serial_no FROM registered WHERE id_no = @p_roll;";
                MySqlCommand cmd = new MySqlCommand(select_query, dbcon.connection);
                cmd.Parameters.AddWithValue("@p_roll", roll);
                MySqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    sno = dr["serial_no"] + "";
                    dr.Close();

                    select_query = "SELECT * FROM course_details WHERE id_no = @p_roll;";
                    cmd = new MySqlCommand(select_query, dbcon.connection);
                    cmd.Parameters.AddWithValue("@p_roll", roll);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("Faculty assigned to any course cannot be deleted");
                        flag = 0;
                    }

                }
                else
                {
                    MessageBox.Show("No such entry exist");
                    flag = 0;
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No connection found, Check your Internet settings");
                flag = 0;
            }
            finally
            {
                dbcon.CloseConnection();
            }
            if (flag == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Do you really want to delete this user, all data will be lost!", "Conform Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    flag = 0;
                }
            }

            if (flag == 0)
            {
                return;
            }


            try
            {
                label.Text = "Please wait.....";
                dbcon.OpenConnection();
                string query = "DELETE FROM registered WHERE id_no = @p_roll";
                //string query = "INSERT INTO fpa VALUES(@p_nUserID,@p_roll,@p_name)";
                MySqlCommand cmd = dbcon.connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@p_roll", roll);
                cmd.ExecuteNonQuery();

                uint nUserID = Convert.ToUInt32(sno, 10);

                
                uint ret = m_IndexSearch.RemoveUser(nUserID);
                ret = m_IndexSearch.SaveDBToFile(szFileName);
                if (ret != NBioAPI.Error.NONE)
                {
                    DisplayErrorMsg(ret);
                    label.Text = "Entry could not be deleted";
                    dbcon.CloseConnection();
                    return;
                }

                sftp.upload();
                label.Text = "Entry Deleted";
                roll_tf.Text = "";

            }

            catch (MySqlException ex)
            {
                label.Text = "Entry could not be deleted";
                MessageBox.Show("No connection found, Check your Internet settings");
                flag = 0;


            }
            finally
            {
                dbcon.CloseConnection();
            }
            try
            {
                sftp.delete_image(sno);
            }
            catch
            {
                MessageBox.Show("unable to delete image file");
            }
            
            
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void roll_tf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                del_btn_Click(sender, e);
            }
        }

        
    }
}