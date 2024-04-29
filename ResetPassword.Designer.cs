namespace Pharmacy_Store_System
{
    partial class ResetPassword
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.resetpanel = new System.Windows.Forms.Panel();
            this.cancelreset = new System.Windows.Forms.Button();
            this.resetbutton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.newpass = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.phonenum = new System.Windows.Forms.Label();
            this.passnote = new System.Windows.Forms.Label();
            this.forgotpass = new System.Windows.Forms.Label();
            this.resetpass = new System.Windows.Forms.Label();
            this.title1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.resetpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.resetpanel);
            this.panel1.Controls.Add(this.resetpass);
            this.panel1.Controls.Add(this.title1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // resetpanel
            // 
            this.resetpanel.BackColor = System.Drawing.Color.Azure;
            this.resetpanel.Controls.Add(this.cancelreset);
            this.resetpanel.Controls.Add(this.resetbutton);
            this.resetpanel.Controls.Add(this.textBox2);
            this.resetpanel.Controls.Add(this.newpass);
            this.resetpanel.Controls.Add(this.textBox1);
            this.resetpanel.Controls.Add(this.phonenum);
            this.resetpanel.Controls.Add(this.passnote);
            this.resetpanel.Controls.Add(this.forgotpass);
            this.resetpanel.Location = new System.Drawing.Point(134, 108);
            this.resetpanel.Name = "resetpanel";
            this.resetpanel.Size = new System.Drawing.Size(480, 330);
            this.resetpanel.TabIndex = 3;
            // 
            // cancelreset
            // 
            this.cancelreset.Location = new System.Drawing.Point(277, 283);
            this.cancelreset.Name = "cancelreset";
            this.cancelreset.Size = new System.Drawing.Size(128, 35);
            this.cancelreset.TabIndex = 7;
            this.cancelreset.Text = "Cancel";
            this.cancelreset.UseVisualStyleBackColor = true;
            this.cancelreset.Click += new System.EventHandler(this.cancelreset_Click);
            // 
            // resetbutton
            // 
            this.resetbutton.Location = new System.Drawing.Point(80, 281);
            this.resetbutton.Name = "resetbutton";
            this.resetbutton.Size = new System.Drawing.Size(142, 37);
            this.resetbutton.TabIndex = 6;
            this.resetbutton.Text = "Reset Now";
            this.resetbutton.UseVisualStyleBackColor = true;
            this.resetbutton.Click += new System.EventHandler(this.resetbutton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(120, 228);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(253, 26);
            this.textBox2.TabIndex = 5;
            // 
            // newpass
            // 
            this.newpass.AutoSize = true;
            this.newpass.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newpass.Location = new System.Drawing.Point(76, 202);
            this.newpass.Name = "newpass";
            this.newpass.Size = new System.Drawing.Size(132, 23);
            this.newpass.TabIndex = 4;
            this.newpass.Text = "New Password";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 157);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(254, 26);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // phonenum
            // 
            this.phonenum.AutoSize = true;
            this.phonenum.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phonenum.Location = new System.Drawing.Point(72, 131);
            this.phonenum.Name = "phonenum";
            this.phonenum.Size = new System.Drawing.Size(136, 23);
            this.phonenum.TabIndex = 2;
            this.phonenum.Text = "Phone Number";
            // 
            // passnote
            // 
            this.passnote.AutoSize = true;
            this.passnote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passnote.Location = new System.Drawing.Point(91, 58);
            this.passnote.Name = "passnote";
            this.passnote.Size = new System.Drawing.Size(347, 44);
            this.passnote.TabIndex = 1;
            this.passnote.Text = "Please Enter Here your Phone Number to \r\n         continue Reset your Password.";
            // 
            // forgotpass
            // 
            this.forgotpass.AutoSize = true;
            this.forgotpass.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgotpass.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.forgotpass.Location = new System.Drawing.Point(145, 12);
            this.forgotpass.Name = "forgotpass";
            this.forgotpass.Size = new System.Drawing.Size(217, 32);
            this.forgotpass.TabIndex = 0;
            this.forgotpass.Text = "Forgot Password";
            // 
            // resetpass
            // 
            this.resetpass.AutoSize = true;
            this.resetpass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(253)))));
            this.resetpass.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetpass.Location = new System.Drawing.Point(280, 65);
            this.resetpass.Name = "resetpass";
            this.resetpass.Size = new System.Drawing.Size(166, 28);
            this.resetpass.TabIndex = 2;
            this.resetpass.Text = "Reset Password";
            // 
            // title1
            // 
            this.title1.AutoSize = true;
            this.title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(253)))));
            this.title1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title1.Location = new System.Drawing.Point(199, 19);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(340, 36);
            this.title1.TabIndex = 1;
            this.title1.Text = "Pharmacy Store System";
            this.title1.Click += new System.EventHandler(this.title1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Pharmacy_Store_System.Properties.Resources.bg_login;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "ResetPassword";
            this.Text = "ResetPassword";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.resetpanel.ResumeLayout(false);
            this.resetpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel resetpanel;
        private System.Windows.Forms.Label resetpass;
        private System.Windows.Forms.Label title1;
        private System.Windows.Forms.Label passnote;
        private System.Windows.Forms.Label forgotpass;
        private System.Windows.Forms.Label phonenum;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button cancelreset;
        private System.Windows.Forms.Button resetbutton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label newpass;
    }
}