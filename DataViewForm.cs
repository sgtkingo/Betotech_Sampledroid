using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConcreteSampleTransformers.Managers;

namespace ConcreteSampleTransformers
{
    public partial class DataViewForm : Form
    {
        ViewerManager ViewerTool;

        public DataViewForm(ViewerManager viewerTool)
        {
            InitializeComponent();
            ViewerTool = viewerTool;
        }

        private void DataViewForm_Load(object sender, EventArgs e)
        {
            BindSource();
            ShowData();
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( tabControl.SelectedIndex == 0 )
                l_dataName.Text = TypesEnums.SampleType.Cube.ToString();
            if (tabControl.SelectedIndex == 1)
                l_dataName.Text = TypesEnums.SampleType.Cylinder.ToString();
        }
    }
}
