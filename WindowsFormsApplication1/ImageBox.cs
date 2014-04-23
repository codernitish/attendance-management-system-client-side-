using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace WindowsFormsApplication2
{
    public partial class ImageBox : Form
    {
        
        private string in_image;
        private string id;
        private string name;
        public ImageBox(string s_no)
        {
            InitializeComponent();
            
            this.in_image = System.Environment.CurrentDirectory + "\\user_pics\\"+s_no+".jpg";
        }

        public ImageBox(string id,string name)
        {
            InitializeComponent();

            this.in_image = "";
            this.id= id;
            this.name = name;
            
        }

        private void ImageBox_Load(object sender, EventArgs e)
        {
            if (this.in_image != "")
            {
                this.BackgroundImage = Image.FromFile(this.in_image);

            }
            
            
            
        }

        private void ImageBox_Shown(object sender, EventArgs e)
        {
            if(this.in_image=="")
            {
                this.id_label.Text = this.id + ":" + this.name;

                this.Refresh();
            }
            
            Thread.Sleep(1000);
            this.Close();
        }
    }
}
