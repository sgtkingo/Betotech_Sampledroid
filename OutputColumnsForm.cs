using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ConcreteSampleTransformers
{
    //Configurator of output columns (visibility + order) for every sample type
    public class OutputColumnsForm : Form
    {
        private class ColumnState
        {
            public OutputColumn Column;
            public bool Selected;
        }

        private static readonly TypesEnums.SampleType[] sampleTypes = { TypesEnums.SampleType.Cube, TypesEnums.SampleType.Cylinder };

        private readonly Dictionary<TypesEnums.SampleType, List<ColumnState>> states = new Dictionary<TypesEnums.SampleType, List<ColumnState>>();
        private TypesEnums.SampleType currentType;

        private ComboBox cbox_SampleType;
        private CheckedListBox clb_Columns;
        private Button btn_Up;
        private Button btn_Down;
        private Button btn_Reset;
        private Button btn_OK;
        private Button btn_Cancel;

        //Result config strings (valid after DialogResult.OK)
        public Dictionary<TypesEnums.SampleType, string> ResultConfigs { get; private set; } = new Dictionary<TypesEnums.SampleType, string>();

        public OutputColumnsForm(Dictionary<TypesEnums.SampleType, string> currentConfigs)
        {
            InitializeComponent();

            foreach (var type in sampleTypes)
            {
                string config;
                currentConfigs.TryGetValue(type, out config);
                states[type] = CreateStates(type, config);
            }

            cbox_SampleType.Items.AddRange(sampleTypes.Cast<object>().ToArray());
            currentType = sampleTypes[0];
            cbox_SampleType.SelectedIndex = 0;
        }

        //Selected columns in configured order first, then not selected columns in default order
        private static List<ColumnState> CreateStates(TypesEnums.SampleType type, string config)
        {
            var selected = ProperitiesSamples.ParseColumnConfig(type, config);
            var result = selected.Select(c => new ColumnState { Column = c, Selected = true }).ToList();
            foreach (var column in ProperitiesSamples.GetColumnCatalog(type).Where(c => !selected.Contains(c)))
            {
                result.Add(new ColumnState { Column = column, Selected = false });
            }
            return result;
        }

        private void InitializeComponent()
        {
            var labelFont = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            var controlFont = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);

            var l_type = new Label { Text = "Sample type:", Font = labelFont, AutoSize = true, Location = new Point(12, 15) };
            cbox_SampleType = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Font = controlFont, Location = new Point(110, 10), Size = new Size(180, 28) };
            cbox_SampleType.SelectedIndexChanged += cbox_SampleType_SelectedIndexChanged;

            var l_columns = new Label { Text = "Output columns (checked = in output, order = top to bottom):", Font = labelFont, AutoSize = true, Location = new Point(12, 48) };
            clb_Columns = new CheckedListBox { Font = controlFont, Location = new Point(12, 70), Size = new Size(278, 260), CheckOnClick = true, IntegralHeight = false };

            btn_Up = new Button { Text = "Up", Font = labelFont, Location = new Point(300, 70), Size = new Size(90, 32) };
            btn_Up.Click += (s, e) => MoveSelected(-1);
            btn_Down = new Button { Text = "Down", Font = labelFont, Location = new Point(300, 108), Size = new Size(90, 32) };
            btn_Down.Click += (s, e) => MoveSelected(1);
            btn_Reset = new Button { Text = "Default", Font = labelFont, Location = new Point(300, 160), Size = new Size(90, 32) };
            btn_Reset.Click += btn_Reset_Click;

            btn_OK = new Button { Text = "OK", Font = labelFont, Location = new Point(204, 345), Size = new Size(90, 32) };
            btn_OK.Click += btn_OK_Click;
            btn_Cancel = new Button { Text = "Cancel", Font = labelFont, Location = new Point(300, 345), Size = new Size(90, 32), DialogResult = DialogResult.Cancel };

            Controls.AddRange(new Control[] { l_type, cbox_SampleType, l_columns, clb_Columns, btn_Up, btn_Down, btn_Reset, btn_OK, btn_Cancel });

            Text = "Output columns";
            ClientSize = new Size(402, 389);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            AcceptButton = btn_OK;
            CancelButton = btn_Cancel;
        }

        //Copy list box state (order + checks) back to current type
        private void StoreCurrentList()
        {
            if (clb_Columns.Items.Count == 0) return;

            var list = new List<ColumnState>();
            for (int i = 0; i < clb_Columns.Items.Count; i++)
            {
                list.Add(new ColumnState { Column = (OutputColumn)clb_Columns.Items[i], Selected = clb_Columns.GetItemChecked(i) });
            }
            states[currentType] = list;
        }

        private void ShowList(TypesEnums.SampleType type)
        {
            clb_Columns.Items.Clear();
            foreach (var state in states[type])
            {
                clb_Columns.Items.Add(state.Column, state.Selected);
            }
            currentType = type;
        }

        private void cbox_SampleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            StoreCurrentList();
            ShowList((TypesEnums.SampleType)cbox_SampleType.SelectedItem);
        }

        private void MoveSelected(int direction)
        {
            int index = clb_Columns.SelectedIndex;
            int newIndex = index + direction;
            if (index < 0 || newIndex < 0 || newIndex >= clb_Columns.Items.Count) return;

            object item = clb_Columns.Items[index];
            bool isChecked = clb_Columns.GetItemChecked(index);
            clb_Columns.Items.RemoveAt(index);
            clb_Columns.Items.Insert(newIndex, item);
            clb_Columns.SetItemChecked(newIndex, isChecked);
            clb_Columns.SelectedIndex = newIndex;
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            states[currentType] = CreateStates(currentType, string.Empty);
            ShowList(currentType);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            StoreCurrentList();

            foreach (var type in sampleTypes)
            {
                if (!states[type].Any(s => s.Selected))
                {
                    MessageBox.Show($"Select at least one output column for {type}!", "Output columns", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            ResultConfigs.Clear();
            foreach (var type in sampleTypes)
            {
                ResultConfigs[type] = ProperitiesSamples.BuildColumnConfig(states[type].Where(s => s.Selected).Select(s => s.Column));
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
