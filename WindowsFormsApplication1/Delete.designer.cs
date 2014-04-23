namespace WindowsFormsApplication2
{
    partial class Delete
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
            this.label1 = new System.Windows.Forms.Label();
            this.roll_tf = new System.Windows.Forms.TextBox();
            this.del_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter ID No to delete";
            // 
            // roll_tf
            // 
            this.roll_tf.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.roll_tf.Location = new System.Drawing.Point(163, 81);
            this.roll_tf.Name = "roll_tf";
            this.roll_tf.Size = new System.Drawing.Size(100, 20);
            this.roll_tf.TabIndex = 1;
            this.roll_tf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.roll_tf_KeyDown);
            // 
            // del_btn
            // 
            this.del_btn.Location = new System.Drawing.Point(31, 160);
            this.del_btn.Name = "del_btn";
            this.del_btn.Size = new System.Drawing.Size(105, 23);
            this.del_btn.TabIndex = 11;
            this.del_btn.Text = "Delete";
            this.del_btn.UseVisualStyleBackColor = true;
            this.del_btn.Click += new System.EventHandler(this.del_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_btn.Location = new System.Drawing.Point(158, 160);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(105, 23);
            this.cancel_btn.TabIndex = 12;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(83, 13);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(0, 13);
            this.label.TabIndex = 13;
            // 
            // Delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel_btn;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.del_btn);
            this.Controls.Add(this.roll_tf);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Delete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox roll_tf;
        private System.Windows.Forms.Button del_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Label label;
    }
}