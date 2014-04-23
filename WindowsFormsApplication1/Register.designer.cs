namespace WindowsFormsApplication2
{
    partial class Register
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
            this.name_tf = new System.Windows.Forms.TextBox();
            this.id_tf = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dsf = new System.Windows.Forms.Label();
            this.rg_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.type_list = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.email_tf = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ph_tf = new System.Windows.Forms.TextBox();
            this.pass_label = new System.Windows.Forms.Label();
            this.pass_tf = new System.Windows.Forms.TextBox();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.img_tf = new System.Windows.Forms.TextBox();
            this.browse_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // name_tf
            // 
            this.name_tf.Location = new System.Drawing.Point(192, 75);
            this.name_tf.Name = "name_tf";
            this.name_tf.Size = new System.Drawing.Size(182, 20);
            this.name_tf.TabIndex = 2;
            // 
            // id_tf
            // 
            this.id_tf.Location = new System.Drawing.Point(192, 108);
            this.id_tf.Name = "id_tf";
            this.id_tf.Size = new System.Drawing.Size(182, 20);
            this.id_tf.TabIndex = 3;
            this.id_tf.TextChanged += new System.EventHandler(this.id_tf_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "NAME*";
            // 
            // dsf
            // 
            this.dsf.AutoSize = true;
            this.dsf.Location = new System.Drawing.Point(128, 112);
            this.dsf.Name = "dsf";
            this.dsf.Size = new System.Drawing.Size(22, 13);
            this.dsf.TabIndex = 5;
            this.dsf.Text = "ID*";
            // 
            // rg_btn
            // 
            this.rg_btn.Location = new System.Drawing.Point(97, 290);
            this.rg_btn.Name = "rg_btn";
            this.rg_btn.Size = new System.Drawing.Size(142, 23);
            this.rg_btn.TabIndex = 7;
            this.rg_btn.Text = "Register";
            this.rg_btn.UseVisualStyleBackColor = true;
            this.rg_btn.Click += new System.EventHandler(this.rg_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Type";
            // 
            // type_list
            // 
            this.type_list.FormattingEnabled = true;
            this.type_list.Items.AddRange(new object[] {
            "Student ",
            "Staff"});
            this.type_list.Location = new System.Drawing.Point(192, 45);
            this.type_list.Name = "type_list";
            this.type_list.Size = new System.Drawing.Size(182, 21);
            this.type_list.TabIndex = 1;
            this.type_list.Text = "Student";
            this.type_list.SelectedIndexChanged += new System.EventHandler(this.class_list_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Email ID*";
            // 
            // email_tf
            // 
            this.email_tf.Location = new System.Drawing.Point(191, 140);
            this.email_tf.Name = "email_tf";
            this.email_tf.Size = new System.Drawing.Size(182, 20);
            this.email_tf.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Phone NO";
            // 
            // ph_tf
            // 
            this.ph_tf.Location = new System.Drawing.Point(191, 171);
            this.ph_tf.Name = "ph_tf";
            this.ph_tf.Size = new System.Drawing.Size(182, 20);
            this.ph_tf.TabIndex = 5;
            // 
            // pass_label
            // 
            this.pass_label.AutoSize = true;
            this.pass_label.Location = new System.Drawing.Point(126, 238);
            this.pass_label.Name = "pass_label";
            this.pass_label.Size = new System.Drawing.Size(57, 13);
            this.pass_label.TabIndex = 14;
            this.pass_label.Text = "Password*";
            this.pass_label.Visible = false;
            // 
            // pass_tf
            // 
            this.pass_tf.Location = new System.Drawing.Point(192, 236);
            this.pass_tf.Name = "pass_tf";
            this.pass_tf.PasswordChar = '*';
            this.pass_tf.Size = new System.Drawing.Size(182, 20);
            this.pass_tf.TabIndex = 6;
            this.pass_tf.Visible = false;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(315, 290);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(142, 23);
            this.cancel_btn.TabIndex = 8;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(191, 13);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(0, 13);
            this.label.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Image Path";
            // 
            // img_tf
            // 
            this.img_tf.Location = new System.Drawing.Point(191, 204);
            this.img_tf.Name = "img_tf";
            this.img_tf.Size = new System.Drawing.Size(182, 20);
            this.img_tf.TabIndex = 16;
            // 
            // browse_btn
            // 
            this.browse_btn.Location = new System.Drawing.Point(379, 204);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(78, 23);
            this.browse_btn.TabIndex = 18;
            this.browse_btn.Text = "Browse";
            this.browse_btn.UseVisualStyleBackColor = true;
            this.browse_btn.Click += new System.EventHandler(this.browse_btn_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 341);
            this.Controls.Add(this.browse_btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.img_tf);
            this.Controls.Add(this.label);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.pass_label);
            this.Controls.Add(this.pass_tf);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ph_tf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.email_tf);
            this.Controls.Add(this.type_list);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rg_btn);
            this.Controls.Add(this.dsf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.id_tf);
            this.Controls.Add(this.name_tf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox name_tf;
        private System.Windows.Forms.TextBox id_tf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label dsf;
        private System.Windows.Forms.Button rg_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox type_list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox email_tf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ph_tf;
        private System.Windows.Forms.Label pass_label;
        private System.Windows.Forms.TextBox pass_tf;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox img_tf;
        private System.Windows.Forms.Button browse_btn;
    }
}

