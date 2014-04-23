namespace WindowsFormsApplication2
{
    partial class Authenticate
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
            this.warn_label = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.login_btn = new System.Windows.Forms.Button();
            this.pass_tf = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.id_tf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lg_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // warn_label
            // 
            this.warn_label.AutoSize = true;
            this.warn_label.Location = new System.Drawing.Point(42, 39);
            this.warn_label.Name = "warn_label";
            this.warn_label.Size = new System.Drawing.Size(191, 13);
            this.warn_label.TabIndex = 13;
            this.warn_label.Text = "You need to login as admin to continue";
            // 
            // cancel_btn
            // 
            this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_btn.Location = new System.Drawing.Point(165, 189);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(96, 32);
            this.cancel_btn.TabIndex = 12;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(24, 189);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(96, 32);
            this.login_btn.TabIndex = 11;
            this.login_btn.Text = "Login";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // pass_tf
            // 
            this.pass_tf.AcceptsReturn = true;
            this.pass_tf.Location = new System.Drawing.Point(116, 130);
            this.pass_tf.Name = "pass_tf";
            this.pass_tf.PasswordChar = '*';
            this.pass_tf.Size = new System.Drawing.Size(100, 20);
            this.pass_tf.TabIndex = 10;
            this.pass_tf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pass_tf_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password";
            // 
            // id_tf
            // 
            this.id_tf.Location = new System.Drawing.Point(116, 82);
            this.id_tf.Name = "id_tf";
            this.id_tf.Size = new System.Drawing.Size(100, 20);
            this.id_tf.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID";
            // 
            // lg_btn
            // 
            this.lg_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.lg_btn.Location = new System.Drawing.Point(140, 200);
            this.lg_btn.Name = "lg_btn";
            this.lg_btn.Size = new System.Drawing.Size(10, 10);
            this.lg_btn.TabIndex = 14;
            this.lg_btn.Text = "Login";
            this.lg_btn.UseVisualStyleBackColor = true;
            this.lg_btn.Visible = false;
            // 
            // Authenticate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lg_btn);
            this.Controls.Add(this.warn_label);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.pass_tf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.id_tf);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Authenticate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authenticate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label warn_label;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.TextBox pass_tf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox id_tf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button lg_btn;
    }
}