using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NITGEN.SDK.NBioBSP;
using System.Threading;
using System.Net;
using System.Configuration;

namespace WindowsFormsApplication2
{
    public partial class main_form : Form
    {
        DB dbcon;
        DB dbcon_check;
        NBioAPI m_NBioAPI;
        NBioAPI.IndexSearch m_IndexSearch;
        WINSCP sftp;
        WINSCP sftp_image;
        public int conflag = 0;
        string tempfile = System.Environment.CurrentDirectory + "\\temp.fpasql";
        string in_image;
        
        public main_form(int flag)
        {
            
            conflag = flag;
            if (conflag == 1)
            {
                sftp_image = new WINSCP();
            }
            InitializeComponent();
            in_image = System.Environment.CurrentDirectory + "\\user_pics\\";
            m_NBioAPI = new NBioAPI();
            m_IndexSearch = new NBioAPI.IndexSearch(m_NBioAPI);
            
            dbcon = new DB();
            dbcon_check = new DB();
            uint ret = m_IndexSearch.InitEngine();
            if (conflag == 0)
            {
                regc_btn.Enabled = false;
                del_btn.Enabled = false;
                con_label.Text = "Offline";
            }
            backgroundWorker1.RunWorkerAsync();

        }



        private void startwin_Load(object sender, EventArgs e)
        {

            NBioAPI.Type.VERSION version = new NBioAPI.Type.VERSION();
            m_NBioAPI.GetVersion(out version);

        }


        private void regc_btn_Click(object sender, EventArgs e)
        {
           
                Authenticate _Authenticate = new Authenticate();
                DialogResult dialogResult1 = _Authenticate.ShowDialog();
                if (dialogResult1 == DialogResult.OK)
                {
                    var a = new Register();
                    a.Show();
                   
                }
                _Authenticate.Dispose();

           
        }


        private void del_btn_Click(object sender, EventArgs e)
        {
            Authenticate _Authenticate = new Authenticate();
            DialogResult dialogResult1 = _Authenticate.ShowDialog();
            if (dialogResult1 == DialogResult.OK)
            {
                var a = new Delete();
                a.Show();

            }
            _Authenticate.Dispose();
        }


        private void DisplayErrorMsg(uint ret)
        {
            MessageBox.Show(NBioAPI.Error.GetErrorDescription(ret) + " [" + ret.ToString() + "]", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void ver_btn_Click(object sender, EventArgs e)
        {
            string path = System.Environment.CurrentDirectory;
            string szFileName = path + "\\data.fpdt";
            uint ret = NBioAPI.Error.NONE;

            if (File.Exists(szFileName))
            {
                m_IndexSearch.ClearDB();
                ret = m_IndexSearch.LoadDBFromFile(szFileName);

                if (ret != NBioAPI.Error.NONE)
                {
                    DisplayErrorMsg(ret);
                    return;
                }

            }

            NBioAPI.Type.HFIR hCapturedFIR;
            m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
            ret = m_NBioAPI.Capture(out hCapturedFIR);

            if (ret != NBioAPI.Error.NONE)
            {
                DisplayErrorMsg(ret);
                m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                return;
            }

            m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
            uint nMax;

            // Identify FIR to IndexSearch DB
            NBioAPI.IndexSearch.FP_INFO fpInfo;
            NBioAPI.IndexSearch.CALLBACK_INFO_0 cbInfo0 = new NBioAPI.IndexSearch.CALLBACK_INFO_0();
            cbInfo0.CallBackFunction = new NBioAPI.IndexSearch.INDEXSEARCH_CALLBACK(myCallback);
            ret = m_IndexSearch.IdentifyData(hCapturedFIR, NBioAPI.Type.FIR_SECURITY_LEVEL.NORMAL, out fpInfo, cbInfo0);
            
            if (ret != NBioAPI.Error.NONE)
            {
                DisplayErrorMsg(ret);
                return;
            }

            if (ret != NBioAPI.Error.NONE)
            {
                DisplayErrorMsg(ret);
                return;
            }

            string sno = fpInfo.ID.ToString();
            
            //database connection
            if (conflag == 1)
            {

                try
                {
                    
                    dbcon.OpenConnection();

                    string select_query = "SELECT * from registered WHERE serial_no=@p_val";
                    MySqlCommand cmd = new MySqlCommand(select_query, dbcon.connection);
                    cmd.Parameters.AddWithValue("@p_val", sno);

                    MySqlDataReader dr = cmd.ExecuteReader();



                    if (dr.Read())
                    {
                        string roll_num = dr["id_no"] + "";
                        string name = dr["name"] + "";

                        dr.Close();

                        string query = "INSERT INTO attendance VALUES(@p_userid,NOW())";
                        cmd = dbcon.connection.CreateCommand();
                        cmd.CommandText = query;


                        // cmd.Parameters.AddWithValue("@p_class", class_sel);
                        cmd.Parameters.AddWithValue("@p_userid", roll_num);
                        //cmd.Parameters.AddWithValue("@p_timestamp", dt);
                        cmd.ExecuteNonQuery();

                        sftp_image.image_download(sno);
                       
                        if (File.Exists(in_image + sno + ".jpg"))
                        {
                            var a = new ImageBox(sno);
                            a.Show();

                        }
                        else
                        {
                            var a = new ImageBox(roll_num,name);
                            a.Show();
                        }
                        //MessageBox.Show("Added Successfully to attendance");


                    }


                }


                catch (Exception)
                {
                    MessageBox.Show("User not verified, Please Try again ");
                    
                }
                finally
                {
                    dbcon.CloseConnection();
                }
                
            }

            else
            {
                DateTime time = DateTime.Now;              // Use current time
                string format = "yyyy-MM-dd HH:mm:ss ";    // Use this format
                string curtime = time.ToString(format);
                if (!File.Exists(tempfile))
                {
                    // Create a file to write to. 
                    using (StreamWriter sw = File.CreateText(tempfile))
                    {
                        sw.WriteLine(Secure.Encrypt(sno + "," + curtime));

                    }
                }

                else
                {
                    using (StreamWriter sw = File.AppendText(tempfile))
                    {
                        sw.WriteLine(Secure.Encrypt(sno + "," + curtime));

                    }
                }
                if (File.Exists(in_image + sno + ".jpg"))
                {
                    var a = new ImageBox(sno);
                    a.Show();

                }
                else
                {
                    MessageBox.Show("Cannot Connect to server.\nAttendance has been recorded and will be stored to server later");
                }
            }
        }







        public uint myCallback(ref NBioAPI.IndexSearch.CALLBACK_PARAM_0 cbParam0, IntPtr userParam)
        {
            // progressIdentify.Value = Convert.ToInt32(cbParam0.ProgressPos);
            return NBioAPI.IndexSearch.CALLBACK_RETURN.OK;
        }

        private void configure_Click(object sender, EventArgs e)
        {
            var a = new Credentials();
            a.Show();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int conflag;
            while (1 == 1)
            {
                try
                {
                    /* using(var client =new WebClient())
                     using (var stream =client.OpenRead("http://athena.nitc.ac.in"))*/
                    dbcon_check.OpenConnection();

                    if (this.conflag == 0)
                    {
                        sftp = new WINSCP();
                        sftp.download();
                        sftp = null;
                    }
                    conflag = 1;
                    Thread.Sleep(100);
                    backgroundWorker1.ReportProgress(conflag);
                }
                catch (Exception exc)
                {
                    conflag = 0;
                    Thread.Sleep(100);
                    backgroundWorker1.ReportProgress(conflag);
                }
                finally
                {
                    dbcon_check.CloseConnection();
                }


            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //MessageBox.Show(""+e.ProgressPercentage);
            if (this.conflag == 1 && e.ProgressPercentage == 0)
            {
                this.conflag = 0;
               
                    DialogResult dialogResult = MessageBox.Show("No Internet Connection found, Please check your internet connection.\nDo you want to continue offline", "Continue", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        Authenticate _Authenticate = new Authenticate();
                        DialogResult dialogResult1 = _Authenticate.ShowDialog();
                        if (dialogResult1 == DialogResult.OK)
                        {
                            _Authenticate.Dispose();
                        }
                        else
                        {
                            this.Close();
                        }

                    }
                    else
                    {
                        this.Close();
                    }
                

                
                regc_btn.Enabled = false;
                del_btn.Enabled = false;
                con_label.Text = "Offline";
            }

            this.conflag = e.ProgressPercentage;
            if (conflag == 1)
            {
           
                regc_btn.Enabled = true;
                del_btn.Enabled = true;
                con_label.Text = "Online";
            }
        }






    }
}
