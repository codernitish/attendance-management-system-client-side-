using System;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Renci.SshNet;

namespace WindowsFormsApplication2
{
    class WINSCP
    {
        DB dbcon;
        string inpath;
        string outpath;
        string out_image;
        string in_image;
        string txtDownloadServer;
        string txtDownloadUsername;
        string txtDownloadPassword;
        string txtDownloadSHHostKeyFingerprint;

        public WINSCP()
        {
            Initialize();
        }

        private void Initialize()
        {
            dbcon = new DB();
            inpath = System.Environment.CurrentDirectory + "\\data.fpdt";
            outpath ="ams/data.fpdt";
            out_image = "ams/user_pics/";
            in_image=System.Environment.CurrentDirectory+"\\user_pics\\";

            try
            {
                dbcon.OpenConnection();
               
                string select_query = "SELECT * from server_details where field='server'";
               
                MySqlCommand cmd = new MySqlCommand(select_query, dbcon.connection);
                MySqlDataReader dr = cmd.ExecuteReader();

                
                if (dr.Read())
                {
                   
                    txtDownloadServer = dr["value"] + "";
                    dr.Close();
                }
               
                select_query = "SELECT * from server_details where field='username'";
                cmd = new MySqlCommand(select_query, dbcon.connection);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    txtDownloadUsername = dr["value"] + "";
                    dr.Close();
                }
                
                select_query = "SELECT * from server_details where field='password'";
                cmd = new MySqlCommand(select_query, dbcon.connection);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    txtDownloadPassword = dr["value"] + "";
                    dr.Close();
                }
               
                select_query = "SELECT * from server_details where field='hostkey'";
                cmd = new MySqlCommand(select_query, dbcon.connection);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    txtDownloadSHHostKeyFingerprint = dr["value"] + "";
                    dr.Close();
                }
                
   
                
                dbcon.CloseConnection();
                
            }
            catch (Exception)
            {
                dbcon.CloseConnection();
                throw;  
            }
               
               

            

        }


        public void download()
        {
            
            try
            {
                using (SftpClient sftp = new SftpClient(txtDownloadServer.Trim(), 22, txtDownloadUsername.Trim(), txtDownloadPassword.Trim()))
                {
                    sftp.Connect();
                    if (sftp.Exists(outpath))
                    {
                        bool same_file = false;
                        if (File.Exists(inpath))
                        {
                            

                            if (DateTime.Compare(sftp.GetLastWriteTime(outpath), File.GetLastWriteTime(inpath)) == 0)
                            {
                                same_file = true;
                                
                            }
                        }
                        if (!same_file)
                        {
                            using (var file = File.OpenWrite(inpath.Trim()))
                            {
                                sftp.DownloadFile(outpath.Trim(), file);
                                
                                
                               
                            }
                            File.SetLastWriteTime(inpath, sftp.GetLastWriteTime(outpath));
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Finger Print data not found on server. Contact Server. Application will close now.");
                        Application.Exit();
                    }
                    sftp.Disconnect();
                }

            }
            catch (Exception exc)
            {
               
                throw;
            }
        }

        public void upload()
        {
            
            try
            {
                using (SftpClient sftp = new SftpClient(txtDownloadServer.Trim(), 22, txtDownloadUsername.Trim(), txtDownloadPassword.Trim()))
                {
                    sftp.Connect();
                    if (sftp.Exists(outpath) && File.Exists(inpath))
                    {
                        using (var file = File.OpenRead(inpath.Trim()))
                        {
                            sftp.UploadFile(file,outpath.Trim());
                            
                        }
                        
                        
                    }
                    sftp.Disconnect();
                }

            }
            catch (Exception exc)
            {
                throw;
            }
        }



        public void upload_image(string id,string path)
        {
            string outpath = out_image + id+".jpg";
            string inpath = path;
            
            try
            {
                using (SftpClient sftp = new SftpClient(txtDownloadServer.Trim(), 22, txtDownloadUsername.Trim(), txtDownloadPassword.Trim()))
                {
                    sftp.Connect();
                    using (var file = File.OpenRead(inpath.Trim()))
                    {
                        sftp.UploadFile(file, outpath.Trim());

                    }

                    sftp.Disconnect();
                    }
                

            }
            catch (Exception exc)
            {
                throw;
            }
        }





        public void image_download(string id)
        {
           
            string outpath = out_image + id + ".jpg";
            string inpath = in_image + id + ".jpg";

            try
            {
                using (SftpClient sftp = new SftpClient(txtDownloadServer.Trim(), 22, txtDownloadUsername.Trim(), txtDownloadPassword.Trim()))
                {
                    sftp.Connect();
                    if (sftp.Exists(outpath))
                    {
                        bool same_file = false;
                        if (File.Exists(inpath))
                        {
                            
                            if (DateTime.Compare(sftp.GetLastWriteTime(outpath), File.GetLastWriteTime(inpath)) == 0)
                            {
                                same_file = true;
                               
                                
                            }
                        }
                        if (!same_file)
                        {
                            using (var file = File.OpenWrite(inpath.Trim()))
                            {
                                sftp.DownloadFile(outpath.Trim(), file);
                                
                            }
                            File.SetLastWriteTime(inpath, sftp.GetLastWriteTime(outpath));
                        }

                    }
                    sftp.Disconnect();
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("" + exc);

            }
        }


        public void delete_image(string id)
        {

            string outpath = out_image + id + ".jpg";
            string inpath = in_image + id + ".jpg";

            try
            {
                using (SftpClient sftp = new SftpClient(txtDownloadServer.Trim(), 22, txtDownloadUsername.Trim(), txtDownloadPassword.Trim()))
                {
                    sftp.Connect();
                    if (sftp.Exists(outpath))
                    {
                        sftp.Delete(outpath);
                    }
                    if (File.Exists(inpath))
                    {
                        File.Delete(inpath);
                    }
                    sftp.Disconnect();
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
