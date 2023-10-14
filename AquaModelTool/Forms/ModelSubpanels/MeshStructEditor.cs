using AquaModelLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AquaModelTool
{
    public partial class MeshStructEditor : UserControl
    {
        AquaObject model;
        List<AquaObject.MESH> meshList;
        ToolTip partsToolTip = new ToolTip();

        public MeshStructEditor(AquaObject newModel, List<AquaObject.MESH> newMeshList, bool isList2 = false)
        {
            InitializeComponent();

            if (isList2)
            {
                meshLabel.Text = meshLabel.Text.Replace("Mesh", "Mesh2");
            }
            //test
            model = newModel;
            meshList = newMeshList;

            //Populate comboboxes. Check if id is within combobox's range and if not, add to the combobox
            //In the case of mesh2s with negative ids, the combobox will NOT get populated.
            var mesh = meshList[0];
            int matCount = newModel.mateList.Count;
            int rendCount = newModel.rendList.Count;
            int shadCount = newModel.shadList.Count;
            int tsetCount = newModel.tsetList.Count;

            int vsetCount = newModel.vsetList.Count;
            int psetCount = newModel.psetList.Count;

            SetComboBox(meshIDCB, meshList.Count, true);

            SetComboBox(matIDCB, matCount);
            SetComboBox(renderIDCB, rendCount);
            SetComboBox(shadIDCB, shadCount);
            SetComboBox(tsetIDCB, tsetCount);
            SetComboBox(vsetIDCB, vsetCount);
            SetComboBox(faceSetIDCB, psetCount);
            partsToolTip.SetToolTip(baseMeshDummyIdLabel, "Player body ids\ncostume = 0\nbreastNeck = 1\nfront = 2\naccessory1 = 3\nback = 4\nshoulder = 5\nforeArm = 6\nleg = 7\naccessory2 = 8");

            meshIDCB.SelectedIndex = 0;
        }

        public void SetComboBox(ComboBox cb, int count, bool meshCB = false)
        {
            for (int i = 0; i < count; i++)
            {
                cb.Items.Add(i);
            }

            if (meshCB == false)
            {
                cb.Items.Add(-1);
            }
        }

        public void UpdateUi()
        {
            var mesh = meshList[meshIDCB.SelectedIndex];

            flagsUD.Value = mesh.flags;
            unkShort0UD.Value = mesh.unkShort0;
            unkShort1UD.Value = mesh.unkShort1;
            unkByte0UD.Value = mesh.unkByte0;
            unkByte1UD.Value = mesh.unkByte1;
            unkInt0UD.Value = mesh.unkInt0;
            baseMeshNodeIdUD.Value = mesh.baseMeshNodeId;
            baseMeshDummyIdUD.Value = mesh.baseMeshDummyId;

            SetLastIfNegativeOne(matIDCB, mesh.mateIndex);
            SetLastIfNegativeOne(renderIDCB, mesh.rendIndex);
            SetLastIfNegativeOne(shadIDCB, mesh.shadIndex);
            SetLastIfNegativeOne(tsetIDCB, mesh.tsetIndex);
            SetLastIfNegativeOne(vsetIDCB, mesh.vsetIndex);
            SetLastIfNegativeOne(faceSetIDCB, mesh.psetIndex);
        }

        private void SetLastIfNegativeOne(ComboBox cb, int index)
        {
            if (index == -1)
            {
                cb.SelectedIndex = cb.Items.Count - 1;
            }
            else
            {
                cb.SelectedIndex = index;
            }
        }

        private void flagsUD_ValueChanged(object sender, EventArgs e)
        {
            var mesh = meshList[meshIDCB.SelectedIndex];
            mesh.flags = (short)flagsUD.Value;
            meshList[meshIDCB.SelectedIndex] = mesh;
        }

        private void unkShort0UD_ValueChanged(object sender, EventArgs e)
        {
            var mesh = meshList[meshIDCB.SelectedIndex];
            mesh.unkShort0 = (short)unkShort0UD.Value;
            meshList[meshIDCB.SelectedIndex] = mesh;
        }

        private void unkByte0UD_ValueChanged(object sender, EventArgs e)
        {
            var mesh = meshList[meshIDCB.SelectedIndex];
            mesh.unkByte0 = (byte)unkByte0UD.Value;
            meshList[meshIDCB.SelectedIndex] = mesh;
        }

        private void unkByte1UD_ValueChanged(object sender, EventArgs e)
        {
            var mesh = meshList[meshIDCB.SelectedIndex];
            mesh.unkByte1 = (byte)unkByte1UD.Value;
            meshList[meshIDCB.SelectedIndex] = mesh;
        }

        private void unkShort1UD_ValueChanged(object sender, EventArgs e)
        {
            var mesh = meshList[meshIDCB.SelectedIndex];
            mesh.unkShort1 = (short)unkShort1UD.Value;
            meshList[meshIDCB.SelectedIndex] = mesh;
        }

        private void baseMeshNodeIdUD_ValueChanged(object sender, EventArgs e)
        {
            var mesh = meshList[meshIDCB.SelectedIndex];
            mesh.baseMeshNodeId = (int)baseMeshNodeIdUD.Value;
            meshList[meshIDCB.SelectedIndex] = mesh;
        }

        private void baseMeshDummyIdUD_ValueChanged(object sender, EventArgs e)
        {
            var mesh = meshList[meshIDCB.SelectedIndex];
            mesh.baseMeshDummyId = (int)baseMeshDummyIdUD.Value;
            meshList[meshIDCB.SelectedIndex] = mesh;
        }

        private void unkInt0UD_ValueChanged(object sender, EventArgs e)
        {
            var mesh = meshList[meshIDCB.SelectedIndex];
            mesh.unkInt0 = (int)unkInt0UD.Value;
            meshList[meshIDCB.SelectedIndex] = mesh;
        }

        private void meshIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUi();
        }

        private void matIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mesh = meshList[meshIDCB.SelectedIndex];
            mesh.mateIndex = matIDCB.SelectedIndex == matIDCB.Items.Count - 1 ? -1 : matIDCB.SelectedIndex;
            meshList[meshIDCB.SelectedIndex] = mesh;
        }

        private void renderIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mesh = meshList[meshIDCB.SelectedIndex];
            mesh.rendIndex = renderIDCB.SelectedIndex == renderIDCB.Items.Count - 1 ? -1 : renderIDCB.SelectedIndex;
            meshList[meshIDCB.SelectedIndex] = mesh;
        }

        private void tsetIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mesh = meshList[meshIDCB.SelectedIndex];
            mesh.tsetIndex = tsetIDCB.SelectedIndex == tsetIDCB.Items.Count - 1 ? -1 : tsetIDCB.SelectedIndex;
            meshList[meshIDCB.SelectedIndex] = mesh;
        }

        private void vsetIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mesh = meshList[meshIDCB.SelectedIndex];
            mesh.vsetIndex = vsetIDCB.SelectedIndex == vsetIDCB.Items.Count - 1 ? -1 : vsetIDCB.SelectedIndex;
            meshList[meshIDCB.SelectedIndex] = mesh;
        }

        private void faceSetIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mesh = meshList[meshIDCB.SelectedIndex];
            mesh.psetIndex = faceSetIDCB.SelectedIndex == faceSetIDCB.Items.Count - 1 ? -1 : faceSetIDCB.SelectedIndex;
            meshList[meshIDCB.SelectedIndex] = mesh;
        }

        private void shadIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mesh = meshList[meshIDCB.SelectedIndex];
            mesh.shadIndex = shadIDCB.SelectedIndex == shadIDCB.Items.Count - 1 ? -1 : shadIDCB.SelectedIndex;
            meshList[meshIDCB.SelectedIndex] = mesh;
        }
    }
}
