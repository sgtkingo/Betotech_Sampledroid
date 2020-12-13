namespace ConcreteSampleTransformers
{
    partial class AppSettingsForm
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
            this.components = new System.ComponentModel.Container();
            this.txtInputDataPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutputDataPath = new System.Windows.Forms.TextBox();
            this.cbox_inputLang = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbox_outputLang = new System.Windows.Forms.ComboBox();
            this.txt_langIn = new System.Windows.Forms.TextBox();
            this.txt_langOut = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_SaveAndClose = new System.Windows.Forms.Button();
            this.bindingSource_LanguageIN = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource_LanguageOUT = new System.Windows.Forms.BindingSource(this.components);
            this.gbox_Path = new System.Windows.Forms.GroupBox();
            this.btn_OutPathSet = new System.Windows.Forms.Button();
            this.btn_InPathSet = new System.Windows.Forms.Button();
            this.gbox_NumberFormat = new System.Windows.Forms.GroupBox();
            this.gpbox_SQL = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.l_sqladdr = new System.Windows.Forms.Label();
            this.txt_SQLAddr = new System.Windows.Forms.TextBox();
            this.l_status = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_LanguageIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_LanguageOUT)).BeginInit();
            this.gbox_Path.SuspendLayout();
            this.gbox_NumberFormat.SuspendLayout();
            this.gpbox_SQL.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInputDataPath
            // 
            this.txtInputDataPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtInputDataPath.Location = new System.Drawing.Point(99, 13);
            this.txtInputDataPath.Name = "txtInputDataPath";
            this.txtInputDataPath.ReadOnly = true;
            this.txtInputDataPath.Size = new System.Drawing.Size(349, 26);
            this.txtInputDataPath.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(25, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Input path:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(15, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Output path:";
            // 
            // txtOutputDataPath
            // 
            this.txtOutputDataPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtOutputDataPath.Location = new System.Drawing.Point(99, 45);
            this.txtOutputDataPath.Name = "txtOutputDataPath";
            this.txtOutputDataPath.ReadOnly = true;
            this.txtOutputDataPath.Size = new System.Drawing.Size(349, 26);
            this.txtOutputDataPath.TabIndex = 2;
            // 
            // cbox_inputLang
            // 
            this.cbox_inputLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbox_inputLang.FormattingEnabled = true;
            this.cbox_inputLang.Location = new System.Drawing.Point(6, 54);
            this.cbox_inputLang.Name = "cbox_inputLang";
            this.cbox_inputLang.Size = new System.Drawing.Size(202, 28);
            this.cbox_inputLang.TabIndex = 4;
            this.cbox_inputLang.SelectedIndexChanged += new System.EventHandler(this.cbox_inputLang_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Input number format:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(278, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Output number format:";
            // 
            // cbox_outputLang
            // 
            this.cbox_outputLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbox_outputLang.FormattingEnabled = true;
            this.cbox_outputLang.Location = new System.Drawing.Point(282, 54);
            this.cbox_outputLang.Name = "cbox_outputLang";
            this.cbox_outputLang.Size = new System.Drawing.Size(202, 28);
            this.cbox_outputLang.TabIndex = 9;
            this.cbox_outputLang.SelectedIndexChanged += new System.EventHandler(this.cbox_outputLang_SelectedIndexChanged);
            // 
            // txt_langIn
            // 
            this.txt_langIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_langIn.Location = new System.Drawing.Point(178, 85);
            this.txt_langIn.Name = "txt_langIn";
            this.txt_langIn.ReadOnly = true;
            this.txt_langIn.Size = new System.Drawing.Size(30, 31);
            this.txt_langIn.TabIndex = 10;
            this.txt_langIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_langOut
            // 
            this.txt_langOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_langOut.Location = new System.Drawing.Point(454, 85);
            this.txt_langOut.Name = "txt_langOut";
            this.txt_langOut.ReadOnly = true;
            this.txt_langOut.Size = new System.Drawing.Size(30, 31);
            this.txt_langOut.TabIndex = 11;
            this.txt_langOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Separator:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(392, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Separator:";
            // 
            // btn_SaveAndClose
            // 
            this.btn_SaveAndClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_SaveAndClose.Image = global::ConcreteSampleTransformers.Properties.Resources.diskette;
            this.btn_SaveAndClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_SaveAndClose.Location = new System.Drawing.Point(146, 330);
            this.btn_SaveAndClose.Name = "btn_SaveAndClose";
            this.btn_SaveAndClose.Size = new System.Drawing.Size(228, 64);
            this.btn_SaveAndClose.TabIndex = 8;
            this.btn_SaveAndClose.Text = "Save";
            this.btn_SaveAndClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_SaveAndClose.UseVisualStyleBackColor = true;
            this.btn_SaveAndClose.Click += new System.EventHandler(this.btn_SaveAndClose_Click);
            // 
            // gbox_Path
            // 
            this.gbox_Path.Controls.Add(this.btn_OutPathSet);
            this.gbox_Path.Controls.Add(this.btn_InPathSet);
            this.gbox_Path.Controls.Add(this.label2);
            this.gbox_Path.Controls.Add(this.label1);
            this.gbox_Path.Controls.Add(this.txtInputDataPath);
            this.gbox_Path.Controls.Add(this.txtOutputDataPath);
            this.gbox_Path.Location = new System.Drawing.Point(12, 12);
            this.gbox_Path.Name = "gbox_Path";
            this.gbox_Path.Size = new System.Drawing.Size(495, 100);
            this.gbox_Path.TabIndex = 14;
            this.gbox_Path.TabStop = false;
            this.gbox_Path.Text = "Path";
            // 
            // btn_OutPathSet
            // 
            this.btn_OutPathSet.BackgroundImage = global::ConcreteSampleTransformers.Properties.Resources.folder;
            this.btn_OutPathSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_OutPathSet.Location = new System.Drawing.Point(454, 47);
            this.btn_OutPathSet.Name = "btn_OutPathSet";
            this.btn_OutPathSet.Size = new System.Drawing.Size(35, 25);
            this.btn_OutPathSet.TabIndex = 5;
            this.btn_OutPathSet.UseVisualStyleBackColor = true;
            this.btn_OutPathSet.Click += new System.EventHandler(this.btn_OutPathSet_Click);
            // 
            // btn_InPathSet
            // 
            this.btn_InPathSet.BackgroundImage = global::ConcreteSampleTransformers.Properties.Resources.folder;
            this.btn_InPathSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_InPathSet.Location = new System.Drawing.Point(454, 14);
            this.btn_InPathSet.Name = "btn_InPathSet";
            this.btn_InPathSet.Size = new System.Drawing.Size(35, 25);
            this.btn_InPathSet.TabIndex = 4;
            this.btn_InPathSet.UseVisualStyleBackColor = true;
            this.btn_InPathSet.Click += new System.EventHandler(this.btn_InPathSet_Click);
            // 
            // gbox_NumberFormat
            // 
            this.gbox_NumberFormat.Controls.Add(this.cbox_inputLang);
            this.gbox_NumberFormat.Controls.Add(this.label3);
            this.gbox_NumberFormat.Controls.Add(this.label6);
            this.gbox_NumberFormat.Controls.Add(this.cbox_outputLang);
            this.gbox_NumberFormat.Controls.Add(this.txt_langOut);
            this.gbox_NumberFormat.Controls.Add(this.label5);
            this.gbox_NumberFormat.Controls.Add(this.txt_langIn);
            this.gbox_NumberFormat.Controls.Add(this.label4);
            this.gbox_NumberFormat.Location = new System.Drawing.Point(12, 118);
            this.gbox_NumberFormat.Name = "gbox_NumberFormat";
            this.gbox_NumberFormat.Size = new System.Drawing.Size(495, 127);
            this.gbox_NumberFormat.TabIndex = 15;
            this.gbox_NumberFormat.TabStop = false;
            this.gbox_NumberFormat.Text = "Number format";
            // 
            // gpbox_SQL
            // 
            this.gpbox_SQL.Controls.Add(this.label7);
            this.gpbox_SQL.Controls.Add(this.btn_Connect);
            this.gpbox_SQL.Controls.Add(this.l_sqladdr);
            this.gpbox_SQL.Controls.Add(this.txt_SQLAddr);
            this.gpbox_SQL.Controls.Add(this.l_status);
            this.gpbox_SQL.Location = new System.Drawing.Point(12, 252);
            this.gpbox_SQL.Name = "gpbox_SQL";
            this.gpbox_SQL.Size = new System.Drawing.Size(495, 72);
            this.gpbox_SQL.TabIndex = 16;
            this.gpbox_SQL.TabStop = false;
            this.gpbox_SQL.Text = "SQL Database ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(285, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Status: ";
            // 
            // btn_Connect
            // 
            this.btn_Connect.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Connect.Location = new System.Drawing.Point(350, 35);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(134, 31);
            this.btn_Connect.TabIndex = 7;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = false;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // l_sqladdr
            // 
            this.l_sqladdr.AutoSize = true;
            this.l_sqladdr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_sqladdr.Location = new System.Drawing.Point(6, 23);
            this.l_sqladdr.Name = "l_sqladdr";
            this.l_sqladdr.Size = new System.Drawing.Size(104, 16);
            this.l_sqladdr.TabIndex = 6;
            this.l_sqladdr.Text = "Server address:";
            // 
            // txt_SQLAddr
            // 
            this.txt_SQLAddr.Location = new System.Drawing.Point(9, 42);
            this.txt_SQLAddr.Name = "txt_SQLAddr";
            this.txt_SQLAddr.ReadOnly = true;
            this.txt_SQLAddr.Size = new System.Drawing.Size(332, 20);
            this.txt_SQLAddr.TabIndex = 1;
            // 
            // l_status
            // 
            this.l_status.AutoSize = true;
            this.l_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_status.ForeColor = System.Drawing.Color.Red;
            this.l_status.Location = new System.Drawing.Point(347, 16);
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(13, 16);
            this.l_status.TabIndex = 0;
            this.l_status.Text = "-";
            // 
            // AppSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 406);
            this.Controls.Add(this.gpbox_SQL);
            this.Controls.Add(this.gbox_NumberFormat);
            this.Controls.Add(this.gbox_Path);
            this.Controls.Add(this.btn_SaveAndClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AppSettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.AppSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_LanguageIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_LanguageOUT)).EndInit();
            this.gbox_Path.ResumeLayout(false);
            this.gbox_Path.PerformLayout();
            this.gbox_NumberFormat.ResumeLayout(false);
            this.gbox_NumberFormat.PerformLayout();
            this.gpbox_SQL.ResumeLayout(false);
            this.gpbox_SQL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtInputDataPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOutputDataPath;
        private System.Windows.Forms.ComboBox cbox_inputLang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_SaveAndClose;
        private System.Windows.Forms.ComboBox cbox_outputLang;
        private System.Windows.Forms.TextBox txt_langIn;
        private System.Windows.Forms.TextBox txt_langOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bindingSource_LanguageIN;
        private System.Windows.Forms.BindingSource bindingSource_LanguageOUT;
        private System.Windows.Forms.GroupBox gbox_Path;
        private System.Windows.Forms.GroupBox gbox_NumberFormat;
        private System.Windows.Forms.Button btn_OutPathSet;
        private System.Windows.Forms.Button btn_InPathSet;
        private System.Windows.Forms.GroupBox gpbox_SQL;
        private System.Windows.Forms.Label l_sqladdr;
        private System.Windows.Forms.TextBox txt_SQLAddr;
        private System.Windows.Forms.Label l_status;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label7;
    }
}