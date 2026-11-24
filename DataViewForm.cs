using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConcreteSampleTransformers.Managers;

namespace ConcreteSampleTransformers
{
    //Preview of output data before saving (fullscreen, one tab per sample type)
    public partial class DataViewForm : Form
    {
        //Every sample is one head row (code; simple code; type; date) + 3 specimen rows
        private const int RowsPerSample = 4;

        private static readonly Color HeadRowBackColor = Color.FromArgb(225, 236, 248);
        private static readonly Color EmptyRowForeColor = Color.DarkGray;
        private static readonly Color HeaderBackColor = Color.FromArgb(60, 90, 130);

        ViewerManager ViewerTool;

        public DataViewForm(ViewerManager viewerTool)
        {
            InitializeComponent();
            ViewerTool = viewerTool;

            SetupGrid(dataGridView_Cube);
            SetupGrid(dataGridView_Cylinder);
        }

        private void DataViewForm_Load(object sender, EventArgs e)
        {
            BindSource();
            ShowData();
            ShowSummary();
        }

        private void BindSource(){
            dataGridView_Cube.DataSource = bindingSource_Cube;
            dataGridView_Cylinder.DataSource = bindingSource_Cylinder;
        }

        private void ShowData(){
            bindingSource_Cube.DataSource = ViewerTool.GenerateTableViewByType(TypesEnums.SampleType.Cube);
            bindingSource_Cube.ResetBindings(false);
            bindingSource_Cylinder.DataSource = ViewerTool.GenerateTableViewByType(TypesEnums.SampleType.Cylinder);
            bindingSource_Cylinder.ResetBindings(false);

            int cubes = CountSamples(bindingSource_Cube);
            int cylinders = CountSamples(bindingSource_Cylinder);
            page_CUBE.Text = $"CUBE ({cubes})";
            page_CYLINDER.Text = $"CYLINDER ({cylinders})";

            //Open tab which contains data
            tabControl.SelectedTab = (cubes == 0 && cylinders > 0) ? page_CYLINDER : page_CUBE;
        }

        private void ShowSummary()
        {
            int cubes = CountSamples(bindingSource_Cube);
            int cylinders = CountSamples(bindingSource_Cylinder);
            string output = Path.Combine(PropertiesManager.outputDataPath ?? string.Empty, PropertiesManager.fileNameOUT + "_*" + PropertiesManager.fileTypeCSV);

            l_summary.Text =
                $"Input:  {PropertiesManager.fileNameIN}\n" +
                $"Samples:  {cubes} cube, {cylinders} cylinder\n" +
                $"Output:  {output}";
        }

        private static int CountSamples(BindingSource source)
        {
            return source.Count / RowsPerSample;
        }

        //Readable table for fullscreen: grouped rows, no sorting (would break groups), frozen code column
        private void SetupGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = Color.Gainsboro;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor = HeaderBackColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(4);
            grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            grid.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 236, 179);
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.RowTemplate.Height = 26;

            grid.DataBindingComplete += (s, e) => StyleRows((DataGridView)s);
        }

        private void StyleRows(DataGridView grid)
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            if (grid.Columns.Count > 0) grid.Columns[0].Frozen = true;

            var headFont = new Font(grid.DefaultCellStyle.Font, FontStyle.Bold);
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Index % RowsPerSample == 0)
                {
                    //Sample head row: code, simple code, type, date
                    row.DefaultCellStyle.BackColor = HeadRowBackColor;
                    row.DefaultCellStyle.Font = headFont;
                    row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else if (IsEmptyRow(row))
                {
                    //Specimen without data (not measured)
                    row.DefaultCellStyle.ForeColor = EmptyRowForeColor;
                }
            }
            grid.ClearSelection();
        }

        //All values except first column are empty, zero or False
        private static bool IsEmptyRow(DataGridViewRow row)
        {
            for (int i = 1; i < row.Cells.Count; i++)
            {
                string value = Convert.ToString(row.Cells[i].Value)?.Trim() ?? string.Empty;
                if (value.Length == 0 || value == "False") continue;
                if (value.Trim('0', ',', '.').Length == 0) continue;
                return false;
            }
            return true;
        }

        //Enter = SAVE, Esc = REJECT even when grid has focus (grid would consume Enter to move to next row)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter) { btn_OK.PerformClick(); return true; }
            if (keyData == Keys.Escape) { btn_Reject.PerformClick(); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Reject_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}
