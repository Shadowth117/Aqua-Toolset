using AquaModelLibrary.Data.PSO2.Aqua;
using AquaModelLibrary.Data.PSO2.Aqua.AquaObjectData;
using AquaModelLibrary.Data.Utility;

namespace AquaModelTool
{
    public partial class ShaderEditor : UserControl
    {
        private AquaObject model;
        private int currentShaderId = 0;
        private int currentExtraId = 0;
        private SHAD ngsShad = null;
        bool canUpdate = false;
        private ColorDialog colorDialog = new ColorDialog();
        public ShaderEditor(AquaObject aquaModel)
        {
            model = aquaModel;
            InitializeComponent();
            SetExtraState(false);
            //Populate shaders dropdown 
            if (model.shadList.Count > 0)
            {
                currentShaderId = 0;
                currentExtraId = 0;
                for (int i = 0; i < model.shadList.Count; i++)
                {
                    shadIDCB.Items.Add(i);
                }
                if (model.shadList.Count == 1)
                {
                    shadIDCB.Enabled = false;
                }
                shadIDCB.SelectedIndex = 0;
                UpdateShaderDisplay();
            }
        }

        private void SetExtraState(bool state)
        {
            flags0UD.Enabled = state;
            flags1UD.Enabled = state;
            flags2UD.Enabled = state;
            valueXUD.Enabled = state;
            valueYUD.Enabled = state;
            valueZUD.Enabled = state;
            valueWUD.Enabled = state;
            diffuseRGBButton.Enabled = state;
        }

        public void ResetExtras()
        {
            SetExtraState(false);
            flags0UD.Value = 0;
            flags1UD.Value = 0;
            flags2UD.Value = 0;
            valueXUD.Value = 0;
            valueYUD.Value = 0;
            valueZUD.Value = 0;
            valueWUD.Value = 0;
            diffuseRGBButton.BackColor = System.Drawing.Color.White;
        }

        public void UpdateShaderDisplay()
        {
            shaderExtraLB.Items.Clear();
            currentExtraId = 0;

            pixelShaderTB.Text = model.shadList[currentShaderId].pixelShader.GetString();
            vShaderTB.Text = model.shadList[currentShaderId].vertexShader.GetString();
            unk0UD.Value = model.shadList[currentShaderId].unk0;

            if (model.shadList[currentShaderId].isNGS)
            {
                ngsShad = model.shadList[currentShaderId];

                //Populate listbox
                for (int i = 0; i < ngsShad.shadExtra.Count; i++)
                {
                    shaderExtraLB.Items.Add(ngsShad.shadExtra[i].entryString.GetString());
                }

                UpdateShaderExtraDisplay();
            }
            else
            {
                ngsShad = null;
                ResetExtras();
            }
        }

        public void UpdateShaderExtraDisplay()
        {
            if (ngsShad.shadExtra.Count > 0)
            {
                SetExtraState(true);

                flags0UD.Value = ngsShad.shadExtra[currentExtraId].entryFlag0;
                flags1UD.Value = ngsShad.shadExtra[currentExtraId].entryFlag1;
                flags2UD.Value = ngsShad.shadExtra[currentExtraId].entryFlag2;
                valueXUD.Value = (decimal)ngsShad.shadExtra[currentExtraId].entryFloats.X;
                valueYUD.Value = (decimal)ngsShad.shadExtra[currentExtraId].entryFloats.Y;
                valueZUD.Value = (decimal)ngsShad.shadExtra[currentExtraId].entryFloats.Z;
                valueWUD.Value = (decimal)ngsShad.shadExtra[currentExtraId].entryFloats.W;

                var color = ColorUtility.ARGBFromRGBAVector3(ngsShad.shadExtra[currentExtraId].entryFloats.X, ngsShad.shadExtra[currentExtraId].entryFloats.Y, ngsShad.shadExtra[currentExtraId].entryFloats.Z);
                diffuseRGBButton.BackColor = color;
                canUpdate = true;
            }
        }

        private void shadIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentShaderId = shadIDCB.SelectedIndex;
            UpdateShaderDisplay();
        }

        private void pixelShaderTB_TextChanged(object sender, EventArgs e)
        {
            model.shadList[currentShaderId].pixelShader.SetString(pixelShaderTB.Text);
        }

        private void vShaderTB_TextChanged(object sender, EventArgs e)
        {
            model.shadList[currentShaderId].vertexShader.SetString(vShaderTB.Text);
        }

        private void unk0UD_ValueChanged(object sender, EventArgs e)
        {
            model.shadList[currentShaderId].unk0 = (int)unk0UD.Value;
        }

        private void shaderExtraLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentExtraId = shaderExtraLB.SelectedIndex;
            if (currentExtraId >= 0 && ngsShad != null)
            {
                UpdateShaderExtraDisplay();
            }
            else
            {
                ResetExtras();
            }
        }

        private void flags0UD_ValueChanged(object sender, EventArgs e)
        {
            if (ngsShad != null && shaderExtraLB.SelectedIndex != -1)
            {
                var extra = ngsShad.shadExtra[currentExtraId];
                extra.entryFlag0 = (short)flags0UD.Value;
                ngsShad.shadExtra[currentExtraId] = extra;
            }
        }

        private void flags1UD_ValueChanged(object sender, EventArgs e)
        {
            if (ngsShad != null && shaderExtraLB.SelectedIndex != -1)
            {
                var extra = ngsShad.shadExtra[currentExtraId];
                extra.entryFlag1 = (short)flags1UD.Value;
                ngsShad.shadExtra[currentExtraId] = extra;
            }
        }

        private void flags2UD_ValueChanged(object sender, EventArgs e)
        {
            if (ngsShad != null && shaderExtraLB.SelectedIndex != -1 && canUpdate)
            {
                var extra = ngsShad.shadExtra[currentExtraId];
                extra.entryFlag2 = (short)flags2UD.Value;
                ngsShad.shadExtra[currentExtraId] = extra;
            }
        }

        private void valueXUD_ValueChanged(object sender, EventArgs e)
        {
            if (ngsShad != null && shaderExtraLB.SelectedIndex != -1 && canUpdate)
            {
                canUpdate = false;
                var extra = ngsShad.shadExtra[currentExtraId];
                var vec4 = extra.entryFloats;
                vec4.X = (float)valueXUD.Value;
                var color = System.Drawing.Color.FromArgb(1, (byte)(vec4.X * 255f), diffuseRGBButton.BackColor.G, diffuseRGBButton.BackColor.B);
                diffuseRGBButton.BackColor = color;
                extra.entryFloats = vec4;
                ngsShad.shadExtra[currentExtraId] = extra;
                diffuseRGBButton.Update();

                canUpdate = true;
            }
        }

        private void valueYUD_ValueChanged(object sender, EventArgs e)
        {
            if (ngsShad != null && shaderExtraLB.SelectedIndex != -1 && canUpdate)
            {
                canUpdate = false;
                var extra = ngsShad.shadExtra[currentExtraId];
                var vec4 = extra.entryFloats;
                vec4.Y = (float)valueYUD.Value;
                var color = System.Drawing.Color.FromArgb(1, diffuseRGBButton.BackColor.R, (byte)(vec4.Y * 255f), diffuseRGBButton.BackColor.B);
                diffuseRGBButton.BackColor = color;
                extra.entryFloats = vec4;
                ngsShad.shadExtra[currentExtraId] = extra;
                diffuseRGBButton.Update();

                canUpdate = true;
            }
        }

        private void valueZUD_ValueChanged(object sender, EventArgs e)
        {
            if (ngsShad != null && shaderExtraLB.SelectedIndex != -1 && canUpdate)
            {
                canUpdate = false;
                var extra = ngsShad.shadExtra[currentExtraId];
                var vec4 = extra.entryFloats;
                vec4.Z = (float)valueZUD.Value;
                var color = System.Drawing.Color.FromArgb(1, diffuseRGBButton.BackColor.R, diffuseRGBButton.BackColor.G, (byte)(vec4.Z * 255f));
                diffuseRGBButton.BackColor = color;
                extra.entryFloats = vec4;
                ngsShad.shadExtra[currentExtraId] = extra;
                diffuseRGBButton.Update();

                canUpdate = true;
            }
        }

        private void valueWUD_ValueChanged(object sender, EventArgs e)
        {
            if (ngsShad != null && shaderExtraLB.SelectedIndex != -1 && canUpdate)
            {
                canUpdate = false;
                var extra = ngsShad.shadExtra[currentExtraId];
                var vec4 = extra.entryFloats;
                vec4.W = (float)valueWUD.Value;
                extra.entryFloats = vec4;
                ngsShad.shadExtra[currentExtraId] = extra;

                canUpdate = true;
            }
        }

        private void diffuseRGBButton_Click(object sender, EventArgs e)
        {
            if (ngsShad != null && shaderExtraLB.SelectedIndex != -1 && canUpdate)
            {
                canUpdate = false;
                var extra = ngsShad.shadExtra[currentExtraId];
                var vec4 = extra.entryFloats;

                colorDialog.Color = ColorUtility.ARGBFromRGBAVector3((float)valueXUD.Value, (float)valueYUD.Value, (float)valueZUD.Value);
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    vec4.X = (float)colorDialog.Color.R / 255;
                    vec4.Y = (float)colorDialog.Color.G / 255;
                    vec4.Z = (float)colorDialog.Color.B / 255;
                    diffuseRGBButton.BackColor = colorDialog.Color;
                }
                valueXUD.Value = (decimal)vec4.X;
                valueYUD.Value = (decimal)vec4.Y;
                valueZUD.Value = (decimal)vec4.Z;
                extra.entryFloats = vec4;
                ngsShad.shadExtra[currentExtraId] = extra;

                canUpdate = true;
            }
        }
    }
}
