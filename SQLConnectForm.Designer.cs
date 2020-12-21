namespace ConcreteSampleTransformers
{
    partial class SQLConnectForm
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
            this.gbox_Server = new System.Windows.Forms.GroupBox();
            this.txt_server = new System.Windows.Forms.TextBox();
            this.gbox_Login = new System.Windows.Forms.GroupBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.l_status = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.l_uname = new System.Windows.Forms.Label();
            this.l_pass = new System.Windows.Forms.Label();
            this.btn_test = new System.Windows.Forms.Button();
            this.l_test = new System.Windows.Forms.Label();
            this.txt_database = new System.Windows.Forms.TextBox();
            this.l_sa = new System.Windows.Forms.Label();
            this.l_db = new System.Windows.Forms.Label();
            this.gbox_Server.SuspendLayout();
            this.gbox_Login.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbox_Server
            // 
            this.gbox_Server.Controls.Add(this.l_db);
            this.gbox_Server.Controls.Add(this.l_sa);
            this.gbox_Server.Controls.Add(this.txt_database);
            this.gbox_Server.Controls.Add(this.txt_server);
            this.gbox_Server.Location = new System.Drawing.Point(13, 13);
            this.gbox_Server.Name = "gbox_Server";
            this.gbox_Server.Size = new System.Drawing.Size(367, 72);
            this.gbox_Server.TabIndex = 0;
            this.gbox_Server.TabStop = false;
            this.gbox_Server.Text = "Server";
            // 
            // txt_server
            // 
            this.txt_server.Location = new System.Drawing.Point(77, 20);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new System.Drawing.Size(283, 20);
            this.txt_server.TabIndex = 0;
            // 
            // gbox_Login
            // 
            this.gbox_Login.Controls.Add(this.l_pass);
            this.gbox_Login.Controls.Add(this.l_uname);
            this.gbox_Login.Controls.Add(this.txt_password);
            this.gbox_Login.Controls.Add(this.txt_username);
            this.gbox_Login.Location = new System.Drawing.Point(13, 95);
            this.gbox_Login.Name = "gbox_Login";
            this.gbox_Login.Size = new System.Drawing.Size(367, 88);
            this.gbox_Login.TabIndex = 1;
            this.gbox_Login.TabStop = false;
            this.gbox_Login.Text = "Login ";
            // 
            // btn_Connect
            // 
            this.btn_Connect.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Connect.Location = new System.Drawing.Point(104, 274);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(183, 54);
            this.btn_Connect.TabIndex = 2;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = false;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // l_status
            // 
            this.l_status.AutoSize = true;
            this.l_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_status.ForeColor = System.Drawing.Color.Red;
            this.l_status.Location = new System.Drawing.Point(100, 247);
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(0, 24);
            this.l_status.TabIndex = 9;
            this.l_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(77, 20);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(283, 20);
            this.txt_username.TabIndex = 0;
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(77, 46);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(283, 20);
            this.txt_password.TabIndex = 1;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // l_uname
            // 
            this.l_uname.AutoSize = true;
            this.l_uname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_uname.Location = new System.Drawing.Point(13, 23);
            this.l_uname.Name = "l_uname";
            this.l_uname.Size = new System.Drawing.Size(58, 13);
            this.l_uname.TabIndex = 2;
            this.l_uname.Text = "Username:";
            // 
            // l_pass
            // 
            this.l_pass.AutoSize = true;
            this.l_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_pass.Location = new System.Drawing.Point(13, 49);
            this.l_pass.Name = "l_pass";
            this.l_pass.Size = new System.Drawing.Size(56, 13);
            this.l_pass.TabIndex = 3;
            this.l_pass.Text = "Password:";
            // 
            // btn_test
            // 
            this.btn_test.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btn_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_test.Location = new System.Drawing.Point(242, 189);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(138, 40);
            this.btn_test.TabIndex = 10;
            this.btn_test.Text = "Test";
            this.btn_test.UseVisualStyleBackColor = false;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // l_test
            // 
            this.l_test.AutoSize = true;
            this.l_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_test.ForeColor = System.Drawing.Color.SteelBlue;
            this.l_test.Location = new System.Drawing.Point(12, 201);
            this.l_test.Name = "l_test";
            this.l_test.Size = new System.Drawing.Size(82, 13);
            this.l_test.TabIndex = 11;
            this.l_test.Text = "Not tested yet...";
            // 
            // txt_database
            // 
            this.txt_database.Location = new System.Drawing.Point(77, 46);
            this.txt_database.Name = "txt_database";
            this.txt_database.Size = new System.Drawing.Size(283, 20);
            this.txt_database.TabIndex = 1;
            // 
            // l_sa
            // 
            this.l_sa.AutoSize = true;
            this.l_sa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_sa.Location = new System.Drawing.Point(28, 20);
            this.l_sa.Name = "l_sa";
            this.l_sa.Size = new System.Drawing.Size(41, 13);
            this.l_sa.TabIndex = 3;
            this.l_sa.Text = "Server:";
            // 
            // l_db
            // 
            this.l_db.AutoSize = true;
            this.l_db.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_db.Location = new System.Drawing.Point(15, 46);
            this.l_db.Name = "l_db";
            this.l_db.Size = new System.Drawing.Size(56, 13);
            this.l_db.TabIndex = 4;
            this.l_db.Text = "Database:";
            // 
            // SQLConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 340);
            this.Controls.Add(this.l_test);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.l_status);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.gbox_Login);
            this.Controls.Add(this.gbox_Server);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SQLConnectForm";
            this.Text = "SQL Connect";
            this.Load += new System.EventHandler(this.SQLConnectForm_Load);
            this.gbox_Server.ResumeLayout(false);
            this.gbox_Server.PerformLayout();
            this.gbox_Login.ResumeLayout(false);
            this.gbox_Login.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbox_Server;
        private System.Windows.Forms.TextBox txt_server;
        private System.Windows.Forms.GroupBox gbox_Login;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Label l_status;
        private System.Windows.Forms.Label l_pass;
        private System.Windows.Forms.Label l_uname;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Label l_test;
        private System.Windows.Forms.Label l_db;
        private System.Windows.Forms.Label l_sa;
        private System.Windows.Forms.TextBox txt_database;
    }
}