using AquaModelLibrary.Data.PSO2.Aqua.AquaEffectData;

namespace AquaModelTool
{
    public unsafe partial class EfctEditor : UserControl
    {
        EFCTObject efct;
        private ColorDialog colorDialog = new ColorDialog();
        TreeNode node;
        public EfctEditor(EFCTObject efctObj, TreeNode thisNode)
        {
            InitializeComponent();
            node = thisNode;
            efct = efctObj;
            animButton.Text += $" ({efct.curvs.Count})";
            if (efct.curvs.Count == 0)
            {
                animButton.Enabled = false;
            }
            startFrameUD.Value = (decimal)efct.efct.startFrame;
            endFrameUD.Value = (decimal)efct.efct.endFrame;
            soundNameBox.Text = efctObj.efct.soundName.GetString();
            diffuseRGBButton.BackColor = Color.FromArgb(efct.efct.color[3], efct.efct.color[2], efct.efct.color[1], efct.efct.color[0]);
            diffuseUD.Value = efct.efct.color[3];

            posXUD.Value = (decimal)efct.efct.unkVec3_0.X;
            posYUD.Value = (decimal)efct.efct.unkVec3_0.Y;
            posZUD.Value = (decimal)efct.efct.unkVec3_0.Z;

            rotXUD.Value = (decimal)efct.efct.unkVec3_1.X;
            rotYUD.Value = (decimal)efct.efct.unkVec3_1.Y;
            rotZUD.Value = (decimal)efct.efct.unkVec3_1.Z;

            scaleXUD.Value = (decimal)efct.efct.unkVec3_2.X;
            scaleYUD.Value = (decimal)efct.efct.unkVec3_2.Y;
            scaleZUD.Value = (decimal)efct.efct.unkVec3_2.Z;

            float30UD.Value = (decimal)efct.efct.float_30;
            int48UD.Value = efct.efct.int_48;
            int50UD.Value = efct.efct.int_50;
            loopEffectUD.Value = efct.efct.loopEffect;
            boolInt58UD.Value = efct.efct.boolInt_58;
            boolInt5CUD.Value = efct.efct.boolInt_5C;
            float60UD.Value = (decimal)efct.efct.float_60;
            float64UD.Value = (decimal)efct.efct.float_64;
        }


        private void startFrameUDValue_Changed(object sender, EventArgs e)
        {
            efct.efct.startFrame = (float)startFrameUD.Value;

            startFrameUD.Value = (decimal)efct.efct.startFrame;
        }

        private void endFrameUD_ValueChanged(object sender, EventArgs e)
        {
            efct.efct.endFrame = (float)endFrameUD.Value;

            endFrameUD.Value = (decimal)efct.efct.endFrame;
        }

        private void diffuseRGBButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                diffuseRGBButton.BackColor = colorDialog.Color;
                efct.efct.color[0] = colorDialog.Color.B;
                efct.efct.color[1] = colorDialog.Color.G;
                efct.efct.color[2] = colorDialog.Color.R;
            }
        }

        private void diffuseUD_ValueChanged(object sender, EventArgs e)
        {
            efct.efct.color[3] = (byte)diffuseUD.Value;

            diffuseUD.Value = efct.efct.color[3];
        }

        private void soundNameBox_TextChanged(object sender, EventArgs e)
        {
            efct.efct.soundName.SetString(soundNameBox.Text);
        }

        private void posXUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = efct.efct.unkVec3_0;
            vec3.X = (float)posXUD.Value;
            efct.efct.unkVec3_0 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            posXUD.Value = (decimal)efct.efct.unkVec3_0.X;
        }

        private void posYUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = efct.efct.unkVec3_0;
            vec3.Y = (float)posYUD.Value;
            efct.efct.unkVec3_0 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            posYUD.Value = (decimal)efct.efct.unkVec3_0.Y;
        }

        private void posZUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = efct.efct.unkVec3_0;
            vec3.Z = (float)posZUD.Value;
            efct.efct.unkVec3_0 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            posZUD.Value = (decimal)efct.efct.unkVec3_0.Z;
        }

        private void rotXUD_ValueChanged(object sender, EventArgs e)
        {
            var vec3 = efct.efct.unkVec3_1;
            vec3.X = (float)rotXUD.Value;
            efct.efct.unkVec3_1 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            rotXUD.Value = (decimal)efct.efct.unkVec3_1.X;
        }

        private void rotYUD_ValueChanged(object sender, EventArgs e)
        {
            var vec3 = efct.efct.unkVec3_1;
            vec3.Y = (float)rotYUD.Value;
            efct.efct.unkVec3_1 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            rotYUD.Value = (decimal)efct.efct.unkVec3_1.Y;
        }

        private void rotZUD_ValueChanged(object sender, EventArgs e)
        {
            var vec3 = efct.efct.unkVec3_1;
            vec3.Z = (float)rotZUD.Value;
            efct.efct.unkVec3_1 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            rotZUD.Value = (decimal)efct.efct.unkVec3_1.Z;
        }

        private void scaleXUD_ValueChanged(object sender, EventArgs e)
        {
            var vec3 = efct.efct.unkVec3_2;
            vec3.X = (float)scaleXUD.Value;
            efct.efct.unkVec3_2 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            scaleXUD.Value = (decimal)efct.efct.unkVec3_2.X;
        }

        private void scaleYUD_ValueChanged(object sender, EventArgs e)
        {
            var vec3 = efct.efct.unkVec3_2;
            vec3.Y = (float)scaleYUD.Value;
            efct.efct.unkVec3_2 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            scaleYUD.Value = (decimal)efct.efct.unkVec3_2.Y;
        }

        private void scaleZUD_ValueChanged(object sender, EventArgs e)
        {
            var vec3 = efct.efct.unkVec3_2;
            vec3.Z = (float)scaleZUD.Value;
            efct.efct.unkVec3_2 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            scaleZUD.Value = (decimal)efct.efct.unkVec3_2.Z;
        }

        private void float30UD_ValueChanged(object sender, EventArgs e)
        {
            efct.efct.float_30 = (float)float30UD.Value;

            float30UD.Value = (decimal)efct.efct.float_30;
        }

        private void int48UD_ValueChanged(object sender, EventArgs e)
        {
            efct.efct.int_48 = (int)int48UD.Value;

            int48UD.Value = efct.efct.int_48;
        }

        private void int50UD_ValueChanged(object sender, EventArgs e)
        {
            efct.efct.int_50 = (int)int50UD.Value;

            int50UD.Value = efct.efct.int_50;
        }

        private void boolInt54UD_ValueChanged(object sender, EventArgs e)
        {
            efct.efct.loopEffect = (int)loopEffectUD.Value;

            loopEffectUD.Value = efct.efct.loopEffect;
        }

        private void boolInt58UD_ValueChanged(object sender, EventArgs e)
        {
            efct.efct.boolInt_58 = (int)boolInt58UD.Value;

            boolInt58UD.Value = efct.efct.boolInt_58;
        }

        private void boolInt5CUD_ValueChanged(object sender, EventArgs e)
        {
            efct.efct.boolInt_5C = (int)boolInt5CUD.Value;

            boolInt5CUD.Value = efct.efct.boolInt_5C;
        }

        private void float60UD_ValueChanged(object sender, EventArgs e)
        {
            efct.efct.float_60 = (float)float60UD.Value;

            float60UD.Value = (decimal)efct.efct.float_60;
        }

        private void float64UD_ValueChanged(object sender, EventArgs e)
        {
            efct.efct.float_64 = (float)float64UD.Value;

            float64UD.Value = (decimal)efct.efct.float_64;
        }

        private void animButton_Click(object sender, EventArgs e)
        {
            ((EffectEditor)(this.Parent.Parent)).loadAnimEditor(efct, node);
        }
    }
}
