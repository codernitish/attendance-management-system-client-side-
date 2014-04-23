namespace WindowsFormsApplication2
{
    partial class Credentials
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
            this.opass_tf = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.oid_tf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.newpass_tf = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.newid_tf = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.login_btn = new System.Windows.Forms.Button();
            this.warn_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.db_server_tf = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.db_name_tf = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.db_user_tf = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.db_pass_tf = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // opass_tf
            // 
            this.opass_tf.AcceptsReturn = true;
            this.opass_tf.Location = new System.Drawing.Point(125, 63);
            this.opass_tf.Name = "opass_tf";
            this.opass_tf.PasswordChar = '*';
            this.opass_tf.Size = new System.Drawing.Size(100, 20);
            this.opass_tf.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Old Password";
            // 
            // oid_tf
            // 
            this.oid_tf.Location = new System.Drawing.Point(125, 37);
            this.oid_tf.Name = "oid_tf";
            this.oid_tf.Size = new System.Drawing.Size(100, 20);
            this.oid_tf.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Old ID";
            // 
            // newpass_tf
            // 
            this.newpass_tf.AcceptsReturn = true;
            this.newpass_tf.Location = new System.Drawing.Point(125, 154);
            this.newpass_tf.Name = "newpass_tf";
            this.newpass_tf.PasswordChar = '*';
            this.newpass_tf.Size = new System.Drawing.Size(100, 20);
            this.newpass_tf.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "New Password";
            // 
            // newid_tf
            // 
            this.newid_tf.Location = new System.Drawing.Point(125, 128);
            this.newid_tf.Name = "newid_tf";
            this.newid_tf.Size = new System.Drawing.Size(100, 20);
            this.newid_tf.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "New ID";
            // 
            // cancel_btn
            // 
            this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_btn.Location = new System.Drawing.Point(161, 325);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(96, 32);
            this.cancel_btn.TabIndex = 20;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(20, 325);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(96, 32);
            this.login_btn.TabIndex = 19;
            this.login_btn.Text = "Change";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // warn_label
            // 
            this.warn_label.AutoSize = true;
            this.warn_label.Location = new System.Drawing.Point(44, 9);
            this.warn_label.Name = "warn_label";
            this.warn_label.Size = new System.Drawing.Size(0, 13);
            this.warn_label.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Optional database settings";
            // 
            // db_server_tf
            // 
            this.db_server_tf.Location = new System.Drawing.Point(125, 206);
            this.db_server_tf.Name = "db_server_tf";
            this.db_server_tf.Size = new System.Drawing.Size(100, 20);
            this.db_server_tf.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Server";
            // 
            // db_name_tf
            // 
            this.db_name_tf.Location = new System.Drawing.Point(125, 232);
            this.db_name_tf.Name = "db_name_tf";
            this.db_name_tf.Size = new System.Drawing.Size(100, 20);
            this.db_name_tf.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "DB Name";
            // 
            // db_user_tf
            // 
            this.db_user_tf.Location = new System.Drawing.Point(125, 259);
            this.db_user_tf.Name = "db_user_tf";
            this.db_user_tf.Size = new System.Drawing.Size(100, 20);
            this.db_user_tf.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "User";
            // 
            // db_pass_tf
            // 
            this.db_pass_tf.Location = new System.Drawing.Point(125, 285);
            this.db_pass_tf.Name = "db_pass_tf";
            this.db_pass_tf.PasswordChar = '*';
            this.db_pass_tf.Size = new System.Drawing.Size(100, 20);
            this.db_pass_tf.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Password";
            // 
            // Credentials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 396);
            this.Controls.Add(this.db_pass_tf);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.db_user_tf);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.db_name_tf);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.db_server_tf);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.warn_label);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.newpass_tf);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newid_tf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.opass_tf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.oid_tf);
            this.Controls.Add(this.label1);
            this.Name = "Credentials";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credentials";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox opass_tf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox oid_tf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newpass_tf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox newid_tf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Label warn_label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox db_server_tf;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox db_name_tf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox db_user_tf;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox db_pass_tf;
        private System.Windows.Forms.Label label9;

    }
}