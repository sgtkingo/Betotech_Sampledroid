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
            this.bindingSource_Cylinder = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.page_CUBE = new System.Windows.Forms.TabPage();
            this.dataGridView_Cube = new System.Windows.Forms.DataGridView();
            this.page_CYLINDER = new System.Windows.Forms.TabPage();
            this.dataGridView_Cylinder = new System.Windows.Forms.DataGridView();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.l_summary = new System.Windows.Forms.Label();
            this.btn_Reject = new System.Windows.Forms.Button();
            this.panel_ButtonSpacer = new System.Windows.Forms.Panel();
            this.btn_OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Cube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Cylinder)).BeginInit();
            this.tabControl.SuspendLayout();
            this.page_CUBE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cube)).BeginInit();
            this.page_CYLINDER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cylinder)).BeginInit();
            this.panel_Bottom.SuspendLayout();
            this.SuspendLayout();
            //
            // tabControl
            //
            this.tabControl.Controls.Add(this.page_CUBE);
            this.tabControl.Controls.Add(this.page_CYLINDER);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabControl.Location = new System.Drawing.Point(8, 8);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(16, 6);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(968, 342);
            this.tabControl.TabIndex = 0;
            //
            // page_CUBE
            //
            this.page_CUBE.Controls.Add(this.dataGridView_Cube);
            this.page_CUBE.Location = new System.Drawing.Point(4, 33);
            this.page_CUBE.Name = "page_CUBE";
            this.page_CUBE.Padding = new System.Windows.Forms.Padding(3);
            this.page_CUBE.Size = new System.Drawing.Size(960, 305);
            this.page_CUBE.TabIndex = 0;
            this.page_CUBE.Text = "CUBE";
            this.page_CUBE.UseVisualStyleBackColor = true;
            //
            // dataGridView_Cube
            //
            this.dataGridView_Cube.AllowUserToAddRows = false;
            this.dataGridView_Cube.AllowUserToDeleteRows = false;
            this.dataGridView_Cube.AllowUserToResizeRows = false;
            this.dataGridView_Cube.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Cube.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Cube.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Cube.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_Cube.Name = "dataGridView_Cube";
            this.dataGridView_Cube.ReadOnly = true;
            this.dataGridView_Cube.RowHeadersVisible = false;
            this.dataGridView_Cube.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Cube.Size = new System.Drawing.Size(954, 299);
            this.dataGridView_Cube.TabIndex = 0;
            //
            // page_CYLINDER
            //
            this.page_CYLINDER.Controls.Add(this.dataGridView_Cylinder);
            this.page_CYLINDER.Location = new System.Drawing.Point(4, 33);
            this.page_CYLINDER.Name = "page_CYLINDER";
            this.page_CYLINDER.Padding = new System.Windows.Forms.Padding(3);
            this.page_CYLINDER.Size = new System.Drawing.Size(960, 305);
            this.page_CYLINDER.TabIndex = 1;
            this.page_CYLINDER.Text = "CYLINDER";
            this.page_CYLINDER.UseVisualStyleBackColor = true;
            //
            // dataGridView_Cylinder
            //
            this.dataGridView_Cylinder.AllowUserToAddRows = false;
            this.dataGridView_Cylinder.AllowUserToDeleteRows = false;
            this.dataGridView_Cylinder.AllowUserToResizeRows = false;
            this.dataGridView_Cylinder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Cylinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Cylinder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Cylinder.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_Cylinder.Name = "dataGridView_Cylinder";
            this.dataGridView_Cylinder.ReadOnly = true;
            this.dataGridView_Cylinder.RowHeadersVisible = false;
            this.dataGridView_Cylinder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Cylinder.Size = new System.Drawing.Size(954, 299);
            this.dataGridView_Cylinder.TabIndex = 0;
            //
            // panel_Bottom
            //
            this.panel_Bottom.Controls.Add(this.l_summary);
            this.panel_Bottom.Controls.Add(this.btn_Reject);
            this.panel_Bottom.Controls.Add(this.panel_ButtonSpacer);
            this.panel_Bottom.Controls.Add(this.btn_OK);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Bottom.Location = new System.Drawing.Point(8, 350);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel_Bottom.Size = new System.Drawing.Size(968, 72);
            this.panel_Bottom.TabIndex = 1;
            //
            // l_summary
            //
            this.l_summary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_summary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_summary.Location = new System.Drawing.Point(0, 10);
            this.l_summary.Name = "l_summary";
            this.l_summary.Size = new System.Drawing.Size(524, 62);
            this.l_summary.TabIndex = 0;
            this.l_summary.Text = "-";
            this.l_summary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btn_Reject
            //
            this.btn_Reject.BackColor = System.Drawing.Color.Firebrick;
            this.btn_Reject.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Reject.FlatAppearance.BorderSize = 0;
            this.btn_Reject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reject.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Reject.ForeColor = System.Drawing.Color.White;
            this.btn_Reject.Location = new System.Drawing.Point(524, 10);
            this.btn_Reject.Name = "btn_Reject";
            this.btn_Reject.Size = new System.Drawing.Size(200, 62);
            this.btn_Reject.TabIndex = 2;
            this.btn_Reject.Text = "REJECT (Esc)";
            this.btn_Reject.UseVisualStyleBackColor = false;
            this.btn_Reject.Click += new System.EventHandler(this.btn_Reject_Click);
            //
            // panel_ButtonSpacer
            //
            this.panel_ButtonSpacer.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_ButtonSpacer.Location = new System.Drawing.Point(724, 10);
            this.panel_ButtonSpacer.Name = "panel_ButtonSpacer";
            this.panel_ButtonSpacer.Size = new System.Drawing.Size(12, 62);
            this.panel_ButtonSpacer.TabIndex = 3;
            //
            // btn_OK
            //
            this.btn_OK.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_OK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_OK.FlatAppearance.BorderSize = 0;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_OK.ForeColor = System.Drawing.Color.White;
            this.btn_OK.Location = new System.Drawing.Point(736, 10);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(232, 62);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "SAVE (Enter)";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            //
            // DataViewForm
            //
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Reject;
            this.ClientSize = new System.Drawing.Size(984, 430);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel_Bottom);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "DataViewForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preview - check data before saving";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DataViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Cube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Cylinder)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.page_CUBE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cube)).EndInit();
            this.page_CYLINDER.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cylinder)).EndInit();
            this.panel_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource_Cube;
        private System.Windows.Forms.BindingSource bindingSource_Cylinder;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage page_CUBE;
        private System.Windows.Forms.DataGridView dataGridView_Cube;
        private System.Windows.Forms.TabPage page_CYLINDER;
        private System.Windows.Forms.DataGridView dataGridView_Cylinder;
        private System.Windows.Forms.Panel panel_Bottom;
        private System.Windows.Forms.Label l_summary;
        private System.Windows.Forms.Button btn_Reject;
        private System.Windows.Forms.Panel panel_ButtonSpacer;
        private System.Windows.Forms.Button btn_OK;
    }
}
