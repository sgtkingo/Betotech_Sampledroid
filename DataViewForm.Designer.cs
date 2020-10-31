namespace ConcreteSampleTransformers
{
    partial class DataViewForm
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
            this.bindingSource_Cube = new System.Windows.Forms.BindingSource(this.components);
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Reject = new System.Windows.Forms.Button();
            this.bindingSource_Cylinder = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.page_CUBE = new System.Windows.Forms.TabPage();
            this.page_CYLINDER = new System.Windows.Forms.TabPage();
            this.dataGridView_Cube = new System.Windows.Forms.DataGridView();
            this.dataGridView_Cylinder = new System.Windows.Forms.DataGridView();
            this.l_dataName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Cube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Cylinder)).BeginInit();
            this.tabControl.SuspendLayout();
            this.page_CUBE.SuspendLayout();
            this.page_CYLINDER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cylinder)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_OK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_OK.Location = new System.Drawing.Point(215, 366);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(215, 52);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "SAVE";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Reject
            // 
            this.btn_Reject.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_Reject.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Reject.Location = new System.Drawing.Point(553, 366);
            this.btn_Reject.Name = "btn_Reject";
            this.btn_Reject.Size = new System.Drawing.Size(215, 52);
            this.btn_Reject.TabIndex = 3;
            this.btn_Reject.Text = "REJECT";
            this.btn_Reject.UseVisualStyleBackColor = false;
            this.btn_Reject.Click += new System.EventHandler(this.btn_Reject_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.page_CUBE);
            this.tabControl.Controls.Add(this.page_CYLINDER);
            this.tabControl.Location = new System.Drawing.Point(13, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(959, 347);
            this.tabControl.TabIndex = 4;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // page_CUBE
            // 
            this.page_CUBE.Controls.Add(this.dataGridView_Cube);
            this.page_CUBE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.page_CUBE.Location = new System.Drawing.Point(4, 22);
            this.page_CUBE.Name = "page_CUBE";
            this.page_CUBE.Padding = new System.Windows.Forms.Padding(3);
            this.page_CUBE.Size = new System.Drawing.Size(951, 321);
            this.page_CUBE.TabIndex = 0;
            this.page_CUBE.Text = "CUBE";
            this.page_CUBE.UseVisualStyleBackColor = true;
            // 
            // page_CYLINDER
            // 
            this.page_CYLINDER.Controls.Add(this.dataGridView_Cylinder);
            this.page_CYLINDER.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.page_CYLINDER.Location = new System.Drawing.Point(4, 22);
            this.page_CYLINDER.Name = "page_CYLINDER";
            this.page_CYLINDER.Padding = new System.Windows.Forms.Padding(3);
            this.page_CYLINDER.Size = new System.Drawing.Size(951, 321);
            this.page_CYLINDER.TabIndex = 1;
            this.page_CYLINDER.Text = "CYLINDER";
            this.page_CYLINDER.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Cube
            // 
            this.dataGridView_Cube.AllowUserToAddRows = false;
            this.dataGridView_Cube.AllowUserToDeleteRows = false;
            this.dataGridView_Cube.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Cube.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Cube.Location = new System.Drawing.Point(6, 6);
            this.dataGridView_Cube.Name = "dataGridView_Cube";
            this.dataGridView_Cube.ReadOnly = true;
            this.dataGridView_Cube.Size = new System.Drawing.Size(939, 311);
            this.dataGridView_Cube.TabIndex = 1;
            // 
            // dataGridView_Cylinder
            // 
            this.dataGridView_Cylinder.AllowUserToAddRows = false;
            this.dataGridView_Cylinder.AllowUserToDeleteRows = false;
            this.dataGridView_Cylinder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Cylinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Cylinder.Location = new System.Drawing.Point(6, 5);
            this.dataGridView_Cylinder.Name = "dataGridView_Cylinder";
            this.dataGridView_Cylinder.ReadOnly = true;
            this.dataGridView_Cylinder.Size = new System.Drawing.Size(939, 311);
            this.dataGridView_Cylinder.TabIndex = 2;
            // 
            // l_dataName
            // 
            this.l_dataName.AutoSize = true;
            this.l_dataName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_dataName.Location = new System.Drawing.Point(451, 7);
            this.l_dataName.Name = "l_dataName";
            this.l_dataName.Size = new System.Drawing.Size(20, 25);
            this.l_dataName.TabIndex = 5;
            this.l_dataName.Text = "-";
            // 
            // DataViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 430);
            this.Controls.Add(this.l_dataName);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btn_Reject);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DataViewForm";
            this.Text = "Show";
            this.Load += new System.EventHandler(this.DataViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Cube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Cylinder)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.page_CUBE.ResumeLayout(false);
            this.page_CYLINDER.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cylinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource_Cube;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Reject;
        private System.Windows.Forms.BindingSource bindingSource_Cylinder;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage page_CUBE;
        private System.Windows.Forms.DataGridView dataGridView_Cube;
        private System.Windows.Forms.TabPage page_CYLINDER;
        private System.Windows.Forms.DataGridView dataGridView_Cylinder;
        private System.Windows.Forms.Label l_dataName;
    }
}