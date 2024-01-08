using AquaModelLibrary.Data.PSO2.Aqua;
using AquaModelTool.Forms.ModelSubpanels;

namespace AquaModelTool
{
    public partial class ModelEditor : UserControl
    {
        public AquaPackage modelset;
        public ModelEditor(AquaPackage aquaModelset)
        {
            modelset = aquaModelset;

            InitializeComponent();
            PopulateModelDropdown();
            SetDropdown();
        }

        public void PopulateModelDropdown()
        {
            modelIDCB.BeginUpdate();
            modelIDCB.Items.Clear();
            for (int i = 0; i < modelset.models.Count; i++)
            {
                modelIDCB.Items.Add(i);
            }
            modelIDCB.EndUpdate();
            modelIDCB.SelectedIndex = 0;
            if (modelIDCB.Items.Count < 2)
            {
                modelIDCB.Enabled = false;
            }
        }

        public bool GetAllTransparentChecked()
        {
            return allAlphaCheckBox.Checked;
        }

        private void modelIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDropdown();
            UdpateEditor();
        }

        public void SetDropdown()
        {
            editorCB.Items.Clear();
            editorCB.Items.Add("Bounding");
            if (modelset.models[modelIDCB.SelectedIndex].mateList.Count > 0)
            {
                editorCB.Items.Add("Materials");
            }
            if (modelset.models[modelIDCB.SelectedIndex].meshList.Count > 0)
            {
                editorCB.Items.Add("Meshes");
            }
            if (modelset.models[modelIDCB.SelectedIndex].mesh2List.Count > 0)
            {
                editorCB.Items.Add("Mesh2s");
            }
            if (modelset.models[modelIDCB.SelectedIndex].rendList.Count > 0)
            {
                editorCB.Items.Add("Render");
            }
            if (modelset.models[modelIDCB.SelectedIndex].shadList.Count > 0)
            {
                editorCB.Items.Add("Shaders");
            }
            if (modelset.models[modelIDCB.SelectedIndex].tsetList.Count > 0)
            {
                editorCB.Items.Add("Texture Sets");
            }

            editorCB.SelectedIndex = 0;
        }

        private void editorCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            UdpateEditor();
        }

        private void UdpateEditor()
        {
            CloseControlWindows();
            modelPanel.Controls.Clear();
            UserControl control;
            switch (editorCB.Items[editorCB.SelectedIndex].ToString())
            {
                case "Bounding":
                    control = new BoundingEditor(modelset.models[modelIDCB.SelectedIndex]);
                    break;
                case "Materials":
                    control = new MaterialEditor(modelset.models[modelIDCB.SelectedIndex]);
                    break;
                case "Meshes":
                    control = new MeshStructEditor(modelset.models[modelIDCB.SelectedIndex], modelset.models[modelIDCB.SelectedIndex].meshList);
                    break;
                case "Mesh2s":
                    control = new MeshStructEditor(modelset.models[modelIDCB.SelectedIndex], modelset.models[modelIDCB.SelectedIndex].mesh2List, true);
                    break;
                case "Render":
                    control = new RenderEditor(modelset.models[modelIDCB.SelectedIndex]);
                    break;
                case "Shaders":
                    control = new ShaderEditor(modelset.models[modelIDCB.SelectedIndex]);
                    break;
                case "Texture Sets":
                    control = new TextureListEditor(modelset.models[modelIDCB.SelectedIndex]);
                    break;
                default:
                    throw new Exception("Unexpected selection!");
            }

            modelPanel.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        public void CloseControlWindows()
        {
            foreach (var control in modelPanel.Controls)
            {
                if (control is MaterialEditor)
                {
                    foreach (var window in ((MaterialEditor)control).windows)
                    {
                        window.Close();
                    }
                }
            }
        }
    }
}
