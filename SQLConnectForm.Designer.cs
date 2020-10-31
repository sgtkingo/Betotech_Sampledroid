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
            this.l_serverType = new System.Windows.Forms.Label();
            this.txt_ServerAddr = new System.Windows.Forms.TextBox();
            this.gbox_Login = new System.Windows.Forms.GroupBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.l_status = new System.Windows.Forms.Label();
            this.gbox_Server.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbox_Server
            // 
            this.gbox_Server.Controls.Add(this.l_serverType);
            this.gbox_Server.Controls.Add(this.txt_ServerAddr);
            this.gbox_Server.Location = new System.Drawing.Point(13, 13);
            this.gbox_Server.Name = "gbox_Server";
            this.gbox_Server.Size = new System.Drawing.Size(367, 74);
            this.gbox_Server.TabIndex = 0;
            this.gbox_Server.TabStop = false;
            this.gbox_Server.Text = "Server";
            // 
            // l_serverType
            // 
            this.l_serverType.AutoSize = true;
            this.l_serverType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_serverType.Location = new System.Drawing.Point(6, 46);
            this.l_serverType.Name = "l_serverType";
            this.l_serverType.Size = new System.Drawing.Size(13, 16);
            this.l_serverType.TabIndex = 1;
            this.l_serverType.Text = "-";
            // 
            // txt_ServerAddr
            // 
            this.txt_ServerAddr.Location = new System.Drawing.Point(6, 19);
            this.txt_ServerAddr.Name = "txt_ServerAddr";
            this.txt_ServerAddr.Size = new System.Drawing.Size(354, 20);
            this.txt_ServerAddr.TabIndex = 0;
            // 
            // gbox_Login
            // 
            this.gbox_Login.Location = new System.Drawing.Point(13, 93);
            this.gbox_Login.Name = "gbox_Login";
            this.gbox_Login.Size = new System.Drawing.Size(367, 123);
            this.gbox_Login.TabIndex = 1;
            this.gbox_Login.TabStop = false;
            this.gbox_Login.Text = "Login ";
            // 
            // btn_Connect
            // 
            this.btn_Connect.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Connect.Location = new System.Drawing.Point(106, 250);
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
            this.l_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_status.ForeColor = System.Drawing.Color.Red;
            this.l_status.Location = new System.Drawing.Point(187, 219);
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(13, 16);
            this.l_status.TabIndex = 9;
            this.l_status.Text = "-";
            // 
            // SQLConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 316);
            this.Controls.Add(this.l_status);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.gbox_Login);
            this.Controls.Add(this.gbox_Server);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SQLConnectForm";
            this.Text = "SQL Connect";
            this.gbox_Server.ResumeLayout(false);
            this.gbox_Server.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbox_Server;
        private System.Windows.Forms.TextBox txt_ServerAddr;
        private System.Windows.Forms.GroupBox gbox_Login;
        private System.Windows.Forms.Label l_serverType;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Label l_status;
    }
}