using AquaModelLibrary.Data.PSO2.Aqua;
using AquaModelLibrary.Data.Utility;
using AquaModelTool.Forms.ModelSubpanels.Material;
using System.Numerics;

namespace AquaModelTool
{
    public partial class MaterialEditor : UserControl
    {
        private BlendTypePresetPicker blendDialog = new BlendTypePresetPicker();
        public MaterialVec3Editor colorEditor = null;
        public List<Form> windows = new List<Form>();
        AquaObject model;
        bool loaded = false;
        public MaterialEditor(AquaObject aquaModel)
        {
            InitializeComponent();
            model = aquaModel;

            //Populate materials dropdown 
            if (model.mateList.Count > 0)
            {
                for (int i = 0; i < model.mateList.Count; i++)
                {
                    matIDCB.Items.Add(i);
                }
                if (model.mateList.Count == 1)
                {
                    matIDCB.Enabled = false;
                }
                matIDCB.SelectedIndex = 0;
                UpdateMaterialDisplay();
            }
        }

        private void UpdateMaterialDisplay()
        {
            var mat = model.mateList[matIDCB.SelectedIndex];
            loaded = false;
            alphaTextBox.Text = mat.alphaType.GetString();
            matNameTextBox.Text = mat.matName.GetString();
            diffuseRGBButton.BackColor = ColorUtility.ARGBFromRGBAVector4(mat.diffuseRGBA);
            tex2RGBAButton.BackColor = ColorUtility.ARGBFromRGBAVector4(mat.unkRGBA0);
            tex3RGBAButton.BackColor = ColorUtility.ARGBFromRGBAVector4(mat._sRGBA);
            tex4RGBAButton.BackColor = ColorUtility.ARGBFromRGBAVector4(mat.unkRGBA1);
            diffuseUD.Value = (decimal)mat.diffuseRGBA.W;
            tex2UD.Value = (decimal)mat.unkRGBA0.W;
            tex3SpecUD.Value = (decimal)mat._sRGBA.W;
            //tex4UD.Value = (decimal)mat.unkRGBA1.W; Seems like a real float, but waaaaay too extreme in value. Unsure how to properly deal with it.
            tex4UD.Value = BitConverter.ToUInt32(BitConverter.GetBytes(mat.unkRGBA1.W), 0);
            specLevelUD.Value = (decimal)mat.unkFloat0;
            unkF32UD.Value = (decimal)mat.unkFloat1;
            unkInt0UD.Value = mat.unkInt0;
            unkInt1UD.Value = mat.unkInt1;
            loaded = true;
        }

        private void diffuseRGBButton_Click(object sender, EventArgs e)
        {
            if (colorEditor != null)
            {
                windows.Remove(colorEditor);
                colorEditor.Close();
            }
            colorEditor = new MaterialVec3Editor(model.mateList, matIDCB.SelectedIndex, 0, diffuseRGBButton);
            windows.Add(colorEditor);
            colorEditor.Show();
        }

        private void tex2RGBAButton_Click(object sender, EventArgs e)
        {
            if (colorEditor != null)
            {
                windows.Remove(colorEditor);
                colorEditor.Close();
            }
            colorEditor = new MaterialVec3Editor(model.mateList, matIDCB.SelectedIndex, 1, tex2RGBAButton);
            windows.Add(colorEditor);
            colorEditor.Show();
        }

        private void tex3RGBAButton_Click(object sender, EventArgs e)
        {
            if (colorEditor != null)
            {
                windows.Remove(colorEditor);
                colorEditor.Close();
            }
            colorEditor = new MaterialVec3Editor(model.mateList, matIDCB.SelectedIndex, 2, tex3RGBAButton);
            windows.Add(colorEditor);
            colorEditor.Show();
        }

        private void tex4RGBAButton_Click(object sender, EventArgs e)
        {
            if (colorEditor != null)
            {
                windows.Remove(colorEditor);
                colorEditor.Close();
            }
            colorEditor = new MaterialVec3Editor(model.mateList, matIDCB.SelectedIndex, 3, tex4RGBAButton);
            windows.Add(colorEditor);
            colorEditor.Show();
        }

        private void opaqueRB_CheckedChanged()
        {
            var mate = model.mateList[matIDCB.SelectedIndex];
            alphaTextBox.Text = "opaque";
            mate.alphaType.SetString(alphaTextBox.Text);
            AdjustRends(alphaTextBox.Text);
            model.mateList[matIDCB.SelectedIndex] = mate;
        }

        private void blendAlphaRB_CheckedChanged()
        {
            var mate = model.mateList[matIDCB.SelectedIndex];
            alphaTextBox.Text = "blendalpha";
            mate.alphaType.SetString(alphaTextBox.Text);
            AdjustRends(alphaTextBox.Text);
            model.mateList[matIDCB.SelectedIndex] = mate;
        }

        private void hollowRB_CheckedChanged()
        {
            var mate = model.mateList[matIDCB.SelectedIndex];
            alphaTextBox.Text = "hollow";
            mate.alphaType.SetString(alphaTextBox.Text);
            AdjustRends(alphaTextBox.Text);
            model.mateList[matIDCB.SelectedIndex] = mate;
        }

        private void addRB_CheckedChanged()
        {
            var mate = model.mateList[matIDCB.SelectedIndex];
            alphaTextBox.Text = "add";
            mate.alphaType.SetString(alphaTextBox.Text);
            AdjustRends(alphaTextBox.Text);
            model.mateList[matIDCB.SelectedIndex] = mate;
        }

        //Checks through the various meshes for instances of the material being paired with a particular REND.
        //If another material is also using the same rend, we duplicate it to make a unique vrsion and set the mesh to use it
        private void AdjustRends(string type)
        {
            if (loaded)
            {
                Dictionary<int, List<int>> rendDict = new Dictionary<int, List<int>>(); //Contains the render ids matched to a list of meshes they're used in
                List<int> rendIds = new List<int>();

                for (int i = 0; i < model.meshList.Count; i++)
                {
                    if (model.meshList[i].mateIndex == matIDCB.SelectedIndex)
                    {
                        if (!rendDict.ContainsKey(model.meshList[i].rendIndex))
                        {
                            rendDict.Add(model.meshList[i].rendIndex, new List<int>() { i });
                        }
                        else
                        {
                            rendDict[model.meshList[i].rendIndex].Add(i);
                        }
                    }
                }

                for (int i = 0; i < model.meshList.Count; i++)
                {
                    //Check if there's another material using the same rend. If so, we need to duplicate this one and fix the indices
                    if (model.meshList[i].mateIndex != matIDCB.SelectedIndex && rendDict.ContainsKey(model.meshList[i].rendIndex))
                    {
                        var meshIdList = rendDict[model.meshList[i].rendIndex];
                        rendDict.Remove(model.meshList[i].rendIndex);
                        model.rendList.Add(model.rendList[model.meshList[i].rendIndex]);
                        rendDict.Add(model.rendList.Count - 1, meshIdList);

                        foreach (var id in meshIdList)
                        {
                            var mesh = model.meshList[id];
                            mesh.rendIndex = model.rendList.Count - 1;
                            model.meshList[id] = mesh;
                        }
                    }
                }

                foreach (var key in rendDict.Keys)
                {
                    var rend = model.rendList[key];
                    switch (type)
                    {
                        case "opaque":
                            rend.int_0C = 0;
                            rend.unk8 = 0;
                            rend.alphaCutoff = 0;
                            rend.destinationAlpha = 6;
                            rend.unk0 = 3;
                            break;
                        case "blendalpha":
                            rend.int_0C = 1;
                            rend.unk8 = 1;
                            rend.alphaCutoff = 0;
                            rend.destinationAlpha = 6;
                            rend.unk0 = 3;
                            break;
                        case "hollow":
                            rend.int_0C = 0;
                            rend.unk8 = 1;
                            rend.alphaCutoff = 0;
                            rend.destinationAlpha = 6;
                            rend.unk0 = 3;
                            break;
                        case "add":
                            rend.int_0C = 1;
                            rend.unk8 = 1;
                            rend.alphaCutoff = 0;
                            rend.destinationAlpha = 2;
                            rend.unk0 = 1;
                            break;
                    }

                    model.rendList[key] = rend;
                }
            }
        }

        private void matNameTextBox_TextChanged(object sender, EventArgs e)
        {
            var mate = model.mateList[matIDCB.SelectedIndex];
            mate.matName.SetString(matNameTextBox.Text);
            model.mateList[matIDCB.SelectedIndex] = mate;
        }

        private void matIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMaterialDisplay();
        }

        private void diffuseUD_ValueChanged(object sender, EventArgs e)
        {
            var mate = model.mateList[matIDCB.SelectedIndex];
            mate.diffuseRGBA = new Vector4(mate.diffuseRGBA.X, mate.diffuseRGBA.Y, mate.diffuseRGBA.Z, (float)diffuseUD.Value);
            model.mateList[matIDCB.SelectedIndex] = mate;
        }

        private void tex2UD_ValueChanged(object sender, EventArgs e)
        {
            var mate = model.mateList[matIDCB.SelectedIndex];
            mate.unkRGBA0 = new Vector4(mate.unkRGBA0.X, mate.unkRGBA0.Y, mate.unkRGBA0.Z, (float)tex2UD.Value);
            model.mateList[matIDCB.SelectedIndex] = mate;
        }

        private void tex3SpecUD_ValueChanged(object sender, EventArgs e)
        {
            var mate = model.mateList[matIDCB.SelectedIndex];
            mate._sRGBA = new Vector4(mate._sRGBA.X, mate._sRGBA.Y, mate._sRGBA.Z, (float)tex3SpecUD.Value);
            model.mateList[matIDCB.SelectedIndex] = mate;
        }

        private void tex4UD_ValueChanged(object sender, EventArgs e)
        {
            var mate = model.mateList[matIDCB.SelectedIndex];
            mate.unkRGBA1 = new Vector4(mate.unkRGBA1.X, mate.unkRGBA1.Y, mate.unkRGBA1.Z, (float)BitConverter.ToSingle(BitConverter.GetBytes((uint)tex4UD.Value), 0));
            model.mateList[matIDCB.SelectedIndex] = mate;
        }

        private void specLevelUD_ValueChanged(object sender, EventArgs e)
        {
            var mate = model.mateList[matIDCB.SelectedIndex];
            mate.unkFloat0 = (float)specLevelUD.Value;
            model.mateList[matIDCB.SelectedIndex] = mate;
        }

        private void unkInt0UD_ValueChanged(object sender, EventArgs e)
        {
            var mate = model.mateList[matIDCB.SelectedIndex];
            mate.unkInt0 = (int)unkInt0UD.Value;
            model.mateList[matIDCB.SelectedIndex] = mate;
        }

        private void unkF32UD_ValueChanged(object sender, EventArgs e)
        {
            var mate = model.mateList[matIDCB.SelectedIndex];
            mate.unkFloat1 = (float)unkF32UD.Value;
            model.mateList[matIDCB.SelectedIndex] = mate;
        }

        private void unkInt1UD_ValueChanged(object sender, EventArgs e)
        {
            var mate = model.mateList[matIDCB.SelectedIndex];
            mate.unkInt1 = (int)unkInt1UD.Value;
            model.mateList[matIDCB.SelectedIndex] = mate;
        }

        private void alphaTextBox_TextChanged(object sender, EventArgs e)
        {
            var mate = model.mateList[matIDCB.SelectedIndex];
            mate.alphaType.SetString(alphaTextBox.Text);
            model.mateList[matIDCB.SelectedIndex] = mate;
        }

        private void blendTypePresetButton_Click(object sender, EventArgs e)
        {
            if (blendDialog.ShowDialog() == DialogResult.OK)
            {
                if (blendDialog.opaqueRB.Checked)
                {
                    opaqueRB_CheckedChanged();
                    return;
                }
                if (blendDialog.blendAlphaRB.Checked)
                {
                    blendAlphaRB_CheckedChanged();
                    return;
                }
                if (blendDialog.hollowRB.Checked)
                {
                    hollowRB_CheckedChanged();
                    return;
                }
                if (blendDialog.addRB.Checked)
                {
                    addRB_CheckedChanged();
                    return;
                }
            }
        }
    }
}
