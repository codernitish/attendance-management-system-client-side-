using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace WindowsFormsApplication2
{
    public partial class SplashScreen : Form
    {
        DB dbcon;
        WINSCP sftp;
        int conflag = 0;
        string tempfile = System.Environment.CurrentDirectory + "\\temp.fpasql";
        
        public SplashScreen()
        {
            InitializeComponent();
            dbcon = new DB();
            
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {

            progressBar.Step = 1;
            progressBar.Value = 1;
            progressBar.Maximum = 2;
            try
            {
                
                sftp = new WINSCP();
                label.Text = "Updating fingerprintdata from the  server";
                sftp.download();
                progressBar.PerformStep();
                label.Text = "Updation complete";
                conflag = 1;
                
            }
            catch (Exception exc)
            {
                conflag = 0;
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
            }

            // 
            if (conflag == 1)
            {
                if (File.Exists(tempfile))
                {
                    
                        label.Text = "Syncing old attendance data with server";
                        var lineCount = File.ReadLines(tempfile).Count();
                        progressBar.Maximum = lineCount;
                        progressBar.Value = 1;
                        string[] array_line = File.ReadAllLines(tempfile);
                        
                        string data;

                        int count = 0;
                        bool flag = true;
                        while (count<lineCount && flag)
                        {
                            progressBar.PerformStep();

                            try
                            {
                                data = Secure.Decrypt(array_line[count]);

                                try
                                {

                                    dbcon.OpenConnection();
                                    string select_query = "SELECT * from registered WHERE serial_no=@p_val";
                                    MySqlCommand cmd = new MySqlCommand(select_query, dbcon.connection);
                                    cmd.Parameters.AddWithValue("@p_val", data.Split(',')[0]);

                                    MySqlDataReader dr = cmd.ExecuteReader();

                                    if (dr.Read())
                                    {

                                        string roll_num = dr["id_no"] + "";
                                        string name = dr["name"] + "";

                                        dr.Close();

                                        string temp = data.Split(',')[1];

                                        string query = "INSERT INTO attendance VALUES(@p_userid,@p_time)";
                                        cmd = dbcon.connection.CreateCommand();
                                        cmd.CommandText = query;

                                        // cmd.Parameters.AddWithValue("@p_class", class_sel);
                                        cmd.Parameters.AddWithValue("@p_userid", roll_num);
                                        cmd.Parameters.AddWithValue("@p_time", temp);
                                        //cmd.Parameters.AddWithValue("@p_timestamp", dt);
                                        cmd.ExecuteNonQuery();

                                        

                                    }
                                   


                                }

                                catch (Exception ex)
                                {
                                    flag = false;

                                }
                                finally
                                {
                                    dbcon.CloseConnection();
                                }

                            }
                            catch
                            {
                                MessageBox.Show("one of the data was not entered due to some exception, it will be skipped" );
                            }


                            count++;
                        }


                      
                        File.Delete(tempfile);
                        if (count != lineCount)
                        {
                            File.WriteAllLines(tempfile,array_line.Skip(count-1));
                            label.Text = "Syncing Complete";
                        }
                        
                    
                    
                    
                }

                
            }
            

            this.Hide();
            var a = new main_form(conflag);
           
            a.Closed += (sender1 , args) => this.Close();
            
            a.Show();
            
            
            
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }


    
        }

        

        
}
