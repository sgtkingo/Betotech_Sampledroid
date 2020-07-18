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
            this.btn_Process = new System.Windows.Forms.Button();
            this.pic_Logo = new System.Windows.Forms.PictureBox();
            this.txt_Console = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btn_openfile = new System.Windows.Forms.Button();
            this.btn_savefile = new System.Windows.Forms.Button();
            this.chbox_autosave = new System.Windows.Forms.CheckBox();
            this.intxt_filename_out = new System.Windows.Forms.TextBox();
            this.l_fileout = new System.Windows.Forms.Label();
            this.intxt_filename_in = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_about = new System.Windows.Forms.Button();
            this.l_console = new System.Windows.Forms.Label();
            this.btn_reportConsole = new System.Windows.Forms.Button();
            this.btn_clearConsole = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_input = new System.Windows.Forms.Button();
            this.btn_output = new System.Windows.Forms.Button();
            this.txt_filetype = new System.Windows.Forms.TextBox();
            this.l_filetype = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Process
            // 
            this.btn_Process.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Process.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Process.Location = new System.Drawing.Point(236, 12);
            this.btn_Process.Name = "btn_Process";
            this.btn_Process.Size = new System.Drawing.Size(178, 102);
            this.btn_Process.TabIndex = 0;
            this.btn_Process.Text = "PROCESS";
            this.btn_Process.UseVisualStyleBackColor = false;
            this.btn_Process.Click += new System.EventHandler(this.btn_Process_Click);
            // 
            // pic_Logo
            // 
            this.pic_Logo.Image = ((System.Drawing.Image)(resources.GetObject("pic_Logo.Image")));
            this.pic_Logo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pic_Logo.InitialImage")));
            this.pic_Logo.Location = new System.Drawing.Point(12, 12);
            this.pic_Logo.Name = "pic_Logo";
            this.pic_Logo.Size = new System.Drawing.Size(208, 80);
            this.pic_Logo.TabIndex = 3;
            this.pic_Logo.TabStop = false;
            this.pic_Logo.WaitOnLoad = true;
            // 
            // txt_Console
            // 
            this.txt_Console.Font = new System.Drawing.Font("Myriad Pro Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // btn_openfile
            // 
            this.btn_openfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_openfile.Location = new System.Drawing.Point(12, 194);
            this.btn_openfile.Name = "btn_openfile";
            this.btn_openfile.Size = new System.Drawing.Size(173, 72);
            this.btn_openfile.TabIndex = 7;
            this.btn_openfile.Text = "OPEN FILE";
            this.btn_openfile.UseVisualStyleBackColor = true;
            this.btn_openfile.Click += new System.EventHandler(this.btn_openfile_Click);
            // 
            // btn_savefile
            // 
            this.btn_savefile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_savefile.Location = new System.Drawing.Point(439, 194);
            this.btn_savefile.Name = "btn_savefile";
            this.btn_savefile.Size = new System.Drawing.Size(173, 72);
            this.btn_savefile.TabIndex = 8;
            this.btn_savefile.Text = "SAVE FILE";
            this.btn_savefile.UseVisualStyleBackColor = true;
            this.btn_savefile.Click += new System.EventHandler(this.btn_savefile_Click);
            // 
            // chbox_autosave
            // 
            this.chbox_autosave.AutoSize = true;
            this.chbox_autosave.Checked = true;
            this.chbox_autosave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbox_autosave.Location = new System.Drawing.Point(528, 60);
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
            // btn_about
            // 
            this.btn_about.Location = new System.Drawing.Point(511, 12);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(101, 42);
            this.btn_about.TabIndex = 18;
            this.btn_about.Text = "ABOUT";
            this.btn_about.UseVisualStyleBackColor = true;
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
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
            // btn_reportConsole
            // 
            this.btn_reportConsole.Location = new System.Drawing.Point(445, 307);
            this.btn_reportConsole.Name = "btn_reportConsole";
            this.btn_reportConsole.Size = new System.Drawing.Size(60, 40);
            this.btn_reportConsole.TabIndex = 20;
            this.btn_reportConsole.Text = "SAVE";
            this.btn_reportConsole.UseVisualStyleBackColor = true;
            this.btn_reportConsole.Click += new System.EventHandler(this.btn_reportConsole_Click);
            // 
            // btn_clearConsole
            // 
            this.btn_clearConsole.Location = new System.Drawing.Point(126, 307);
            this.btn_clearConsole.Name = "btn_clearConsole";
            this.btn_clearConsole.Size = new System.Drawing.Size(60, 40);
            this.btn_clearConsole.TabIndex = 21;
            this.btn_clearConsole.Text = "CLEAR";
            this.btn_clearConsole.UseVisualStyleBackColor = true;
            this.btn_clearConsole.Click += new System.EventHandler(this.btn_clearConsole_Click);
            // 
            // btn_input
            // 
            this.btn_input.Location = new System.Drawing.Point(13, 307);
            this.btn_input.Name = "btn_input";
            this.btn_input.Size = new System.Drawing.Size(75, 40);
            this.btn_input.TabIndex = 23;
            this.btn_input.Text = "INPUT";
            this.btn_input.UseVisualStyleBackColor = true;
            this.btn_input.Click += new System.EventHandler(this.btn_input_Click);
            // 
            // btn_output
            // 
            this.btn_output.Location = new System.Drawing.Point(537, 307);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(75, 40);
            this.btn_output.TabIndex = 24;
            this.btn_output.Text = "OUTPUT";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 365);
            this.Controls.Add(this.l_filetype);
            this.Controls.Add(this.txt_filetype);
            this.Controls.Add(this.btn_output);
            this.Controls.Add(this.btn_input);
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
            this.Text = "BETOTECH - Concrete Samples Autoformator";
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
        private System.Windows.Forms.Button btn_input;
        private System.Windows.Forms.Button btn_output;
        private System.Windows.Forms.TextBox txt_filetype;
        private System.Windows.Forms.Label l_filetype;
    }
}

