namespace WindowsFormsApplication2
{
    partial class main_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.regc_btn = new System.Windows.Forms.Button();
            this.del_btn = new System.Windows.Forms.Button();
            this.ver_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.configure = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.con_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // regc_btn
            // 
            this.regc_btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.regc_btn.FlatAppearance.BorderSize = 50;
            this.regc_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.regc_btn.Location = new System.Drawing.Point(91, 117);
            this.regc_btn.Name = "regc_btn";
            this.regc_btn.Size = new System.Drawing.Size(101, 58);
            this.regc_btn.TabIndex = 0;
            this.regc_btn.Text = "Register Entitities";
            this.regc_btn.UseVisualStyleBackColor = true;
            this.regc_btn.Click += new System.EventHandler(this.regc_btn_Click);
            // 
            // del_btn
            // 
            this.del_btn.Location = new System.Drawing.Point(275, 117);
            this.del_btn.Name = "del_btn";
            this.del_btn.Size = new System.Drawing.Size(101, 58);
            this.del_btn.TabIndex = 1;
            this.del_btn.Text = "Delete";
            this.del_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.del_btn.UseVisualStyleBackColor = true;
            this.del_btn.Click += new System.EventHandler(this.del_btn_Click);
            // 
            // ver_btn
            // 
            this.ver_btn.Location = new System.Drawing.Point(91, 217);
            this.ver_btn.Name = "ver_btn";
            this.ver_btn.Size = new System.Drawing.Size(285, 58);
            this.ver_btn.TabIndex = 3;
            this.ver_btn.Text = "Verify";
            this.ver_btn.UseVisualStyleBackColor = true;
            this.ver_btn.Click += new System.EventHandler(this.ver_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Attendance Management System ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(318, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Client Application";
            // 
            // configure
            // 
            this.configure.BackgroundImage = global::WindowsFormsApplication2.Properties.Resources.settings;
            this.configure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.configure.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.configure.Location = new System.Drawing.Point(12, 66);
            this.configure.Name = "configure";
            this.configure.Size = new System.Drawing.Size(37, 37);
            this.configure.TabIndex = 6;
            this.configure.UseVisualStyleBackColor = true;
            this.configure.Click += new System.EventHandler(this.configure_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Connection Status:";
            // 
            // con_label
            // 
            this.con_label.AutoSize = true;
            this.con_label.Location = new System.Drawing.Point(105, 319);
            this.con_label.Name = "con_label";
            this.con_label.Size = new System.Drawing.Size(0, 13);
            this.con_label.TabIndex = 8;
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 337);
            this.Controls.Add(this.con_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.configure);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ver_btn);
            this.Controls.Add(this.del_btn);
            this.Controls.Add(this.regc_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FingerPrint Attendance System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button regc_btn;
        private System.Windows.Forms.Button del_btn;
        private System.Windows.Forms.Button ver_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button configure;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label con_label;
    }
}