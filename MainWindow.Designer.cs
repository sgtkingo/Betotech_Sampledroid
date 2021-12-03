namespace ConcreteSampleTransformers
{
    partial class MainWindow
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.txt_Console = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.chbox_autosave = new System.Windows.Forms.CheckBox();
            this.intxt_filename_out = new System.Windows.Forms.TextBox();
            this.l_fileout = new System.Windows.Forms.Label();
            this.intxt_filename_in = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.l_console = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txt_filetype = new System.Windows.Forms.TextBox();
            this.l_filetype = new System.Windows.Forms.Label();
            this.rdbtn_CSV = new System.Windows.Forms.RadioButton();
            this.rdbtn_Object = new System.Windows.Forms.RadioButton();
            this.label_FileType = new System.Windows.Forms.Label();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.btn_clearConsole = new System.Windows.Forms.Button();
            this.btn_reportConsole = new System.Windows.Forms.Button();
            this.btn_about = new System.Windows.Forms.Button();
            this.btn_savefile = new System.Windows.Forms.Button();
            this.btn_openfile = new System.Windows.Forms.Button();
            this.pic_Logo = new System.Windows.Forms.PictureBox();
            this.btn_Process = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Console
            // 
            this.txt_Console.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Console.Location = new System.Drawing.Point(192, 142);
            this.txt_Console.Name = "txt_Console";
            this.txt_Console.ReadOnly = true;
            this.txt_Console.Size = new System.Drawing.Size(241, 205);
            this.txt_Console.TabIndex = 6;
            this.txt_Console.Text = "";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.ShowHelp = true;
            // 
            // chbox_autosave
            // 
            this.chbox_autosave.AutoSize = true;
            this.chbox_autosave.Checked = true;
            this.chbox_autosave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbox_autosave.Location = new System.Drawing.Point(528, 115);
            this.chbox_autosave.Name = "chbox_autosave";
            this.chbox_autosave.Size = new System.Drawing.Size(84, 17);
            this.chbox_autosave.TabIndex = 9;
            this.chbox_autosave.Text = "AUTOSAVE";
            this.chbox_autosave.UseVisualStyleBackColor = true;
            this.chbox_autosave.CheckedChanged += new System.EventHandler(this.chbox_autosave_CheckedChanged);
            // 
            // intxt_filename_out
            // 
            this.intxt_filename_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.intxt_filename_out.Location = new System.Drawing.Point(439, 138);
            this.intxt_filename_out.Name = "intxt_filename_out";
            this.intxt_filename_out.Size = new System.Drawing.Size(173, 29);
            this.intxt_filename_out.TabIndex = 10;
            this.intxt_filename_out.TextChanged += new System.EventHandler(this.intxt_filename_out_TextChanged);
            // 
            // l_fileout
            // 
            this.l_fileout.AutoSize = true;
            this.l_fileout.Location = new System.Drawing.Point(439, 120);
            this.l_fileout.Name = "l_fileout";
            this.l_fileout.Size = new System.Drawing.Size(66, 13);
            this.l_fileout.TabIndex = 11;
            this.l_fileout.Text = "FILE NAME:";
            // 
            // intxt_filename_in
            // 
            this.intxt_filename_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.intxt_filename_in.Location = new System.Drawing.Point(13, 138);
            this.intxt_filename_in.Name = "intxt_filename_in";
            this.intxt_filename_in.ReadOnly = true;
            this.intxt_filename_in.Size = new System.Drawing.Size(173, 29);
            this.intxt_filename_in.TabIndex = 12;
            this.intxt_filename_in.TextChanged += new System.EventHandler(this.intxt_filename_in_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "FILE NAME (READ ONLY):";
            // 
            // l_console
            // 
            this.l_console.AutoSize = true;
            this.l_console.Location = new System.Drawing.Point(192, 126);
            this.l_console.Name = "l_console";
            this.l_console.Size = new System.Drawing.Size(153, 13);
            this.l_console.TabIndex = 19;
            this.l_console.Text = "CONSOLE (OUTPUT ONLY) : ";
            // 
            // txt_filetype
            // 
            this.txt_filetype.Location = new System.Drawing.Point(537, 168);
            this.txt_filetype.Name = "txt_filetype";
            this.txt_filetype.ReadOnly = true;
            this.txt_filetype.Size = new System.Drawing.Size(75, 20);
            this.txt_filetype.TabIndex = 25;
            // 
            // l_filetype
            // 
            this.l_filetype.AutoSize = true;
            this.l_filetype.Location = new System.Drawing.Point(465, 171);
            this.l_filetype.Name = "l_filetype";
            this.l_filetype.Size = new System.Drawing.Size(63, 13);
            this.l_filetype.TabIndex = 26;
            this.l_filetype.Text = "FILE TYPE:";
            // 
            // rdbtn_CSV
            // 
            this.rdbtn_CSV.AutoSize = true;
            this.rdbtn_CSV.Location = new System.Drawing.Point(439, 36);
            this.rdbtn_CSV.Name = "rdbtn_CSV";
            this.rdbtn_CSV.Size = new System.Drawing.Size(46, 17);
            this.rdbtn_CSV.TabIndex = 27;
            this.rdbtn_CSV.TabStop = true;
            this.rdbtn_CSV.Text = "CSV";
            this.rdbtn_CSV.UseVisualStyleBackColor = true;
            this.rdbtn_CSV.CheckedChanged += new System.EventHandler(this.rdbtn_CSV_CheckedChanged);
            // 
            // rdbtn_Object
            // 
            this.rdbtn_Object.AutoSize = true;
            this.rdbtn_Object.Location = new System.Drawing.Point(439, 59);
            this.rdbtn_Object.Name = "rdbtn_Object";
            this.rdbtn_Object.Size = new System.Drawing.Size(82, 17);
            this.rdbtn_Object.TabIndex = 28;
            this.rdbtn_Object.TabStop = true;
            this.rdbtn_Object.Text = "DATABASE";
            this.rdbtn_Object.UseVisualStyleBackColor = true;
            this.rdbtn_Object.CheckedChanged += new System.EventHandler(this.rdbtn_Object_CheckedChanged);
            // 
            // label_FileType
            // 
            this.label_FileType.AutoSize = true;
            this.label_FileType.Location = new System.Drawing.Point(420, 12);
            this.label_FileType.Name = "label_FileType";
            this.label_FileType.Size = new System.Drawing.Size(65, 13);
            this.label_FileType.TabIndex = 29;
            this.label_FileType.Text = "Output type:";
            // 
            // btn_Settings
            // 
            this.btn_Settings.Image = global::ConcreteSampleTransformers.Properties.Resources.gear;
            this.btn_Settings.Location = new System.Drawing.Point(552, 12);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(60, 60);
            this.btn_Settings.TabIndex = 30;
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // btn_clearConsole
            // 
            this.btn_clearConsole.Image = global::ConcreteSampleTransformers.Properties.Resources.clear;
            this.btn_clearConsole.Location = new System.Drawing.Point(126, 307);
            this.btn_clearConsole.Name = "btn_clearConsole";
            this.btn_clearConsole.Size = new System.Drawing.Size(60, 40);
            this.btn_clearConsole.TabIndex = 21;
            this.btn_clearConsole.UseVisualStyleBackColor = true;
            this.btn_clearConsole.Click += new System.EventHandler(this.btn_clearConsole_Click);
            // 
            // btn_reportConsole
            // 
            this.btn_reportConsole.Image = global::ConcreteSampleTransformers.Properties.Resources.chat;
            this.btn_reportConsole.Location = new System.Drawing.Point(445, 307);
            this.btn_reportConsole.Name = "btn_reportConsole";
            this.btn_reportConsole.Size = new System.Drawing.Size(60, 40);
            this.btn_reportConsole.TabIndex = 20;
            this.btn_reportConsole.UseVisualStyleBackColor = true;
            this.btn_reportConsole.Click += new System.EventHandler(this.btn_reportConsole_Click);
            // 
            // btn_about
            // 
            this.btn_about.Image = global::ConcreteSampleTransformers.Properties.Resources.about;
            this.btn_about.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btn_about.Location = new System.Drawing.Point(12, 305);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(101, 42);
            this.btn_about.TabIndex = 18;
            this.btn_about.Text = "ABOUT";
            this.btn_about.UseVisualStyleBackColor = true;
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            // 
            // btn_savefile
            // 
            this.btn_savefile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_savefile.Image = global::ConcreteSampleTransformers.Properties.Resources.diskette;
            this.btn_savefile.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_savefile.Location = new System.Drawing.Point(439, 194);
            this.btn_savefile.Name = "btn_savefile";
            this.btn_savefile.Size = new System.Drawing.Size(173, 72);
            this.btn_savefile.TabIndex = 8;
            this.btn_savefile.Text = "SAVE";
            this.btn_savefile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_savefile.UseVisualStyleBackColor = true;
            this.btn_savefile.Click += new System.EventHandler(this.btn_savefile_Click);
            // 
            // btn_openfile
            // 
            this.btn_openfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_openfile.Image = global::ConcreteSampleTransformers.Properties.Resources.loading;
            this.btn_openfile.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_openfile.Location = new System.Drawing.Point(12, 194);
            this.btn_openfile.Name = "btn_openfile";
            this.btn_openfile.Size = new System.Drawing.Size(173, 72);
            this.btn_openfile.TabIndex = 7;
            this.btn_openfile.Text = "OPEN FILE";
            this.btn_openfile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_openfile.UseVisualStyleBackColor = true;
            this.btn_openfile.Click += new System.EventHandler(this.btn_openfile_Click);
            // 
            // pic_Logo
            // 
            this.pic_Logo.Image = global::ConcreteSampleTransformers.Properties.Resources.betotech_logo;
            this.pic_Logo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pic_Logo.InitialImage")));
            this.pic_Logo.Location = new System.Drawing.Point(12, 12);
            this.pic_Logo.Name = "pic_Logo";
            this.pic_Logo.Size = new System.Drawing.Size(208, 80);
            this.pic_Logo.TabIndex = 3;
            this.pic_Logo.TabStop = false;
            this.pic_Logo.WaitOnLoad = true;
            // 
            // btn_Process
            // 
            this.btn_Process.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Process.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Process.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btn_Process.Image = global::ConcreteSampleTransformers.Properties.Resources.gear_proccess;
            this.btn_Process.Location = new System.Drawing.Point(236, 12);
            this.btn_Process.Name = "btn_Process";
            this.btn_Process.Size = new System.Drawing.Size(178, 102);
            this.btn_Process.TabIndex = 0;
            this.btn_Process.Text = "PROCESS";
            this.btn_Process.UseVisualStyleBackColor = false;
            this.btn_Process.Click += new System.EventHandler(this.btn_Process_Click);
            // 
            // MainWindow
            // 
            this.AcceptButton = this.btn_Process;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 365);
            this.Controls.Add(this.btn_Settings);
            this.Controls.Add(this.label_FileType);
            this.Controls.Add(this.rdbtn_Object);
            this.Controls.Add(this.rdbtn_CSV);
            this.Controls.Add(this.l_filetype);
            this.Controls.Add(this.txt_filetype);
            this.Controls.Add(this.btn_clearConsole);
            this.Controls.Add(this.btn_reportConsole);
            this.Controls.Add(this.l_console);
            this.Controls.Add(this.btn_about);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.intxt_filename_in);
            this.Controls.Add(this.l_fileout);
            this.Controls.Add(this.intxt_filename_out);
            this.Controls.Add(this.chbox_autosave);
            this.Controls.Add(this.btn_savefile);
            this.Controls.Add(this.btn_openfile);
            this.Controls.Add(this.txt_Console);
            this.Controls.Add(this.pic_Logo);
            this.Controls.Add(this.btn_Process);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "BETOTECH -Sampledroid";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Process;
        private System.Windows.Forms.PictureBox pic_Logo;
        private System.Windows.Forms.RichTextBox txt_Console;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btn_openfile;
        private System.Windows.Forms.Button btn_savefile;
        private System.Windows.Forms.CheckBox chbox_autosave;
        private System.Windows.Forms.TextBox intxt_filename_out;
        private System.Windows.Forms.Label l_fileout;
        private System.Windows.Forms.TextBox intxt_filename_in;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_about;
        private System.Windows.Forms.Label l_console;
        private System.Windows.Forms.Button btn_reportConsole;
        private System.Windows.Forms.Button btn_clearConsole;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox txt_filetype;
        private System.Windows.Forms.Label l_filetype;
        private System.Windows.Forms.RadioButton rdbtn_CSV;
        private System.Windows.Forms.RadioButton rdbtn_Object;
        private System.Windows.Forms.Label label_FileType;
        private System.Windows.Forms.Button btn_Settings;
    }
}

