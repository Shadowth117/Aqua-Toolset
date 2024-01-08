using AquaModelLibrary.Data.PSO2.Aqua.AquaEffectData;
using System.Numerics;

namespace AquaModelTool
{
    public unsafe partial class PtclEditor : UserControl
    {
        PTCLObject ptcl;
        private ColorDialog colorDialog = new ColorDialog();
        TreeNode node;
        public PtclEditor(PTCLObject ptclObj, TreeNode thisNode)
        {
            InitializeComponent();
            node = thisNode;
            ptcl = ptclObj;
            animButton.Text += $" ({ptclObj.curvs.Count})";
            if (ptclObj.curvs.Count == 0)
            {
                animButton.Enabled = false;
            }
            modelNameBox.Text = ptclObj.strings.assetName.GetString();
            subDirBox.Text = ptclObj.strings.subDirectory.GetString();
            diffuseBox.Text = ptclObj.strings.diffuseTex.GetString();
            opacityBox.Text = ptclObj.strings.opacityTex.GetString();
            unkStringTB.Text = ptclObj.strings.unkString.GetString();

            diffuseRGBButton.BackColor = Color.FromArgb(ptcl.ptcl.color[3], ptcl.ptcl.color[2], ptcl.ptcl.color[1], ptcl.ptcl.color[0]);
            diffuseUD.Value = ptcl.ptcl.color[3];

            speedUD.Value = (decimal)ptcl.ptcl.speed;
            speedRandomUD.Value = (decimal)ptcl.ptcl.speedRandom;

            sizeXUD.Value = (decimal)ptcl.ptcl.size.X;
            sizeYUD.Value = (decimal)ptcl.ptcl.size.Y;
            sizeZUD.Value = (decimal)ptcl.ptcl.size.Z;

            sizeRandomXUD.Value = (decimal)ptcl.ptcl.sizeRandom.X;
            sizeRandomYUD.Value = (decimal)ptcl.ptcl.sizeRandom.Y;
            sizeRandomZUD.Value = (decimal)ptcl.ptcl.sizeRandom.Z;

            rotXUD.Value = (decimal)ptcl.ptcl.rotation.X;
            rotYUD.Value = (decimal)ptcl.ptcl.rotation.Y;
            rotZUD.Value = (decimal)ptcl.ptcl.rotation.Z;

            rotationRandomXUD.Value = (decimal)ptcl.ptcl.rotationRandom.X;
            rotationRandomYUD.Value = (decimal)ptcl.ptcl.rotationRandom.Y;
            rotationRandomZUD.Value = (decimal)ptcl.ptcl.rotationRandom.Z;

            rotationAddXUD.Value = (decimal)ptcl.ptcl.rotationAdd.X;
            rotationAddYUD.Value = (decimal)ptcl.ptcl.rotationAdd.Y;
            rotationAddZUD.Value = (decimal)ptcl.ptcl.rotationAdd.Z;

            rotationAddRandomXUD.Value = (decimal)ptcl.ptcl.rotationAddRandom.X;
            rotationAddRandomYUD.Value = (decimal)ptcl.ptcl.rotationAddRandom.Y;
            rotationAddRandomZUD.Value = (decimal)ptcl.ptcl.rotationAddRandom.Z;

            directionXUD.Value = (decimal)ptcl.ptcl.direction.X;
            directionYUD.Value = (decimal)ptcl.ptcl.direction.Y;
            directionZUD.Value = (decimal)ptcl.ptcl.direction.Z;

            directionRandomXUD.Value = (decimal)ptcl.ptcl.directionRandom.X;
            directionRandomYUD.Value = (decimal)ptcl.ptcl.directionRandom.Y;
            directionRandomZUD.Value = (decimal)ptcl.ptcl.directionRandom.Z;

            gravitationalAccelXUD.Value = (decimal)ptcl.ptcl.gravitationalAccel.X;
            gravitationalAccelYUD.Value = (decimal)ptcl.ptcl.gravitationalAccel.Y;
            gravitationalAccelZUD.Value = (decimal)ptcl.ptcl.gravitationalAccel.Z;

            externalAccelXUD.Value = (decimal)ptcl.ptcl.externalAccel.X;
            externalAccelYUD.Value = (decimal)ptcl.ptcl.externalAccel.Y;
            externalAccelZUD.Value = (decimal)ptcl.ptcl.externalAccel.Z;

            externalAccelRandomXUD.Value = (decimal)ptcl.ptcl.externalAccelRandom.X;
            externalAccelRandomYUD.Value = (decimal)ptcl.ptcl.externalAccelRandom.Y;
            externalAccelRandomZUD.Value = (decimal)ptcl.ptcl.externalAccelRandom.Z;

            floatB0UD.Value = (decimal)ptcl.ptcl.float_B0;
            floatB4UD.Value = (decimal)ptcl.ptcl.float_B4;
            floatB8UD.Value = (decimal)ptcl.ptcl.float_B8;
            floatBCUD.Value = (decimal)ptcl.ptcl.float_BC;

            intC0UD.Value = ptcl.ptcl.int_C0;
            floatC4UD.Value = (decimal)ptcl.ptcl.float_C4;
            byteC8UD.Value = ptcl.ptcl.byte_C8;
            byteC9UD.Value = ptcl.ptcl.byte_C9;
            byteCAUD.Value = ptcl.ptcl.byte_CA;
            byteCBUD.Value = ptcl.ptcl.byte_CB;
            floatCCUD.Value = (decimal)ptcl.ptcl.float_CC;

            floatD8UD.Value = (decimal)ptcl.ptcl.field_D8;
            floatDCUD.Value = (decimal)ptcl.ptcl.field_DC;

            floatE0UD.Value = (decimal)ptcl.ptcl.float_E0;
            floatE4UD.Value = (decimal)ptcl.ptcl.field_E4;
            floatE8UD.Value = (decimal)ptcl.ptcl.field_E8;

            intF0UD.Value = ptcl.ptcl.int_F0;
            intF4UD.Value = ptcl.ptcl.int_F4;
            intF8UD.Value = ptcl.ptcl.int_F8;
            byteFCUD.Value = ptcl.ptcl.byte_FC;
            byteFDUD.Value = ptcl.ptcl.byte_FD;
            byteFEUD.Value = ptcl.ptcl.byte_FE;
            byteFFUD.Value = ptcl.ptcl.byte_FF;

            int100UD.Value = ptcl.ptcl.int_100;
            int104UD.Value = ptcl.ptcl.int_104;
            int108UD.Value = ptcl.ptcl.int_108;
            short10CUD.Value = ptcl.ptcl.short_10C;
            short10EUD.Value = ptcl.ptcl.short_10E;

            field110UD.Value = ptcl.ptcl.field_110;
            field114UD.Value = ptcl.ptcl.field_114;
            field118UD.Value = ptcl.ptcl.field_118;
            field11CUD.Value = ptcl.ptcl.field_11C;

            float120UD.Value = (decimal)ptcl.ptcl.float_120;
            field124UD.Value = (decimal)ptcl.ptcl.float_124;
            field128UD.Value = (decimal)ptcl.ptcl.float_128;
            field12CUD.Value = (decimal)ptcl.ptcl.float_12C;

            field130UD.Value = (decimal)ptcl.ptcl.float_130;
            field134UD.Value = (decimal)ptcl.ptcl.float_134;
            field138UD.Value = (decimal)ptcl.ptcl.float_138;
            field13CUD.Value = (decimal)ptcl.ptcl.float_13C;

            field14CUD.Value = ptcl.ptcl.field_14C;
        }

        private void diffuseRGBButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                diffuseRGBButton.BackColor = colorDialog.Color;
                ptcl.ptcl.color[0] = colorDialog.Color.B;
                ptcl.ptcl.color[1] = colorDialog.Color.G;
                ptcl.ptcl.color[2] = colorDialog.Color.R;
            }
        }

        private void diffuseUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.color[3] = (byte)diffuseUD.Value;

            diffuseUD.Value = ptcl.ptcl.color[3];
        }

        private void modelNameBoxValue_Changed(object sender, EventArgs e)
        {
            ptcl.strings.assetName.SetString(modelNameBox.Text);
        }

        private void subDirBox_TextChanged(object sender, EventArgs e)
        {
            ptcl.strings.subDirectory.SetString(subDirBox.Text);
        }

        private void diffuseBox_TextChanged(object sender, EventArgs e)
        {
            ptcl.strings.diffuseTex.SetString(diffuseBox.Text);
        }

        private void opacityBox_TextChanged(object sender, EventArgs e)
        {
            ptcl.strings.opacityTex.SetString(opacityBox.Text);
        }

        private void unkStringTB_TextChanged(object sender, EventArgs e)
        {
            ptcl.strings.unkString.SetString(unkStringTB.Text);
        }

        public void setVector3Element(ref Vector3 vec3, NumericUpDown UD, string axis)
        {
            switch (axis)
            {
                case "x":
                case "X":
                    vec3.X = (float)UD.Value;
                    //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
                    UD.Value = (decimal)vec3.X;
                    break;
                case "y":
                case "Y":
                    vec3.Y = (float)UD.Value;
                    UD.Value = (decimal)vec3.Y;
                    break;
                case "z":
                case "Z":
                    vec3.Z = (float)UD.Value;
                    UD.Value = (decimal)vec3.Z;
                    break;
            }
        }

        private void sizeXUDValue_Changed(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.size, sizeXUD, "x");
        }

        private void sizeYUDValue_Changed(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.size, sizeYUD, "y");
        }

        private void sizeZUDValue_Changed(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.size, sizeZUD, "z");
        }

        private void sizeRandomXUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.sizeRandom, sizeRandomXUD, "x");
        }

        private void sizeRandomYUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.sizeRandom, sizeRandomYUD, "y");
        }

        private void sizeRandomZUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.sizeRandom, sizeRandomZUD, "z");
        }

        private void rotXUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.rotation, rotXUD, "x");
        }

        private void rotYUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.rotation, rotYUD, "y");
        }

        private void rotZUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.rotation, rotZUD, "z");
        }

        private void rotationRandomXUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.rotationRandom, rotationRandomXUD, "x");
        }

        private void rotationRandomYUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.rotationRandom, rotationRandomYUD, "y");
        }

        private void rotationRandomZUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.rotationRandom, rotationRandomZUD, "z");
        }

        private void rotationAddXUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.rotationAdd, rotationAddXUD, "x");
        }

        private void rotationAddYUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.rotationAdd, rotationAddYUD, "y");
        }

        private void rotationAddZUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.rotationAdd, rotationAddZUD, "z");
        }

        private void rotationAddRandomXUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.rotationAddRandom, rotationAddRandomXUD, "x");
        }

        private void rotationAddRandomYUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.rotationAddRandom, rotationAddRandomYUD, "y");
        }

        private void rotationAddRandomZUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.rotationAddRandom, rotationAddRandomZUD, "z");
        }

        private void directionXUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.direction, directionXUD, "x");
        }

        private void directionYUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.direction, directionYUD, "y");
        }

        private void directionZUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.direction, directionZUD, "z");
        }

        private void directionRandomXUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.directionRandom, directionRandomXUD, "x");
        }

        private void directionRandomYUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.directionRandom, directionRandomYUD, "y");
        }

        private void directionRandomZUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.directionRandom, directionRandomZUD, "z");
        }

        private void gravitationalAccelXUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.gravitationalAccel, gravitationalAccelXUD, "x");
        }

        private void gravitationalAccelYUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.gravitationalAccel, gravitationalAccelYUD, "y");
        }

        private void gravitationalAccelZUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.gravitationalAccel, gravitationalAccelZUD, "z");
        }

        private void externalAccelXUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.externalAccel, externalAccelXUD, "x");
        }

        private void externalAccelYUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.externalAccel, externalAccelYUD, "y");
        }

        private void externalAccelZUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.externalAccel, externalAccelZUD, "z");
        }

        private void externalAccelRandomXUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.externalAccelRandom, externalAccelRandomXUD, "x");
        }

        private void externalAccelRandomYUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.externalAccelRandom, externalAccelRandomYUD, "y");
        }

        private void externalAccelRandomZUD_ValueChanged(object sender, EventArgs e)
        {
            setVector3Element(ref ptcl.ptcl.externalAccelRandom, externalAccelRandomZUD, "z");
        }

        private void speedUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.speed = (float)speedUD.Value;

            speedUD.Value = (decimal)ptcl.ptcl.speed;
        }

        private void speedRandomUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.speedRandom = (float)speedRandomUD.Value;

            speedRandomUD.Value = (decimal)ptcl.ptcl.speedRandom;
        }

        private void floatB0UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.float_B0 = (float)floatB0UD.Value;

            floatB0UD.Value = (decimal)ptcl.ptcl.float_B0;
        }

        private void floatB4UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.float_B4 = (float)floatB4UD.Value;

            floatB4UD.Value = (decimal)ptcl.ptcl.float_B4;
        }

        private void floatB8UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.float_B8 = (float)floatB8UD.Value;

            floatB8UD.Value = (decimal)ptcl.ptcl.float_B8;
        }

        private void floatBCUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.float_BC = (float)floatBCUD.Value;

            floatBCUD.Value = (decimal)ptcl.ptcl.float_BC;
        }

        private void intC0UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.int_C0 = (int)intC0UD.Value;

            intC0UD.Value = ptcl.ptcl.int_C0;
        }

        private void floatC4UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.float_C4 = (float)floatC4UD.Value;

            floatC4UD.Value = (decimal)ptcl.ptcl.float_C4;
        }

        private void byteC8UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.byte_C8 = (byte)byteC8UD.Value;

            byteC8UD.Value = ptcl.ptcl.byte_C8;
        }

        private void byteC9UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.byte_C9 = (byte)byteC9UD.Value;

            byteC9UD.Value = ptcl.ptcl.byte_C9;
        }

        private void byteCAUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.byte_CA = (byte)byteCAUD.Value;

            byteCAUD.Value = ptcl.ptcl.byte_CA;
        }

        private void byteCBUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.byte_CB = (byte)byteCBUD.Value;

            byteCBUD.Value = ptcl.ptcl.byte_CB;
        }

        private void floatCCUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.float_CC = (float)floatCCUD.Value;

            floatCCUD.Value = (decimal)ptcl.ptcl.float_CC;
        }

        private void floatD8UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.field_D8 = (float)floatD8UD.Value;

            floatD8UD.Value = (decimal)ptcl.ptcl.field_D8;
        }

        private void intF0UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.int_F0 = (int)intF0UD.Value;

            intF0UD.Value = ptcl.ptcl.int_F0;
        }

        private void intF4UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.int_F4 = (int)intF4UD.Value;

            intF4UD.Value = ptcl.ptcl.int_F4;
        }

        private void intF8UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.int_F8 = (int)intF8UD.Value;

            intF8UD.Value = ptcl.ptcl.int_F8;
        }

        private void byteFCUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.byte_FC = (byte)byteFCUD.Value;

            byteFCUD.Value = ptcl.ptcl.byte_FC;
        }

        private void byteFDUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.byte_FD = (byte)byteFDUD.Value;

            byteFDUD.Value = ptcl.ptcl.byte_FD;
        }

        private void byteFEUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.byte_FE = (byte)byteFEUD.Value;

            byteFEUD.Value = ptcl.ptcl.byte_FE;
        }

        private void byteFFUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.byte_FF = (byte)byteFFUD.Value;

            byteFFUD.Value = ptcl.ptcl.byte_FF;
        }

        private void int100UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.int_100 = (int)int100UD.Value;

            int100UD.Value = ptcl.ptcl.int_100;
        }

        private void int104UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.int_104 = (int)int104UD.Value;

            int104UD.Value = ptcl.ptcl.int_104;
        }

        private void int108UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.int_108 = (int)int108UD.Value;

            int108UD.Value = ptcl.ptcl.int_108;
        }

        private void short10CUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.short_10C = (short)short10CUD.Value;

            short10CUD.Value = ptcl.ptcl.short_10C;
        }

        private void short10EUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.short_10E = (short)short10EUD.Value;

            short10EUD.Value = ptcl.ptcl.short_10E;
        }

        private void field110UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.field_110 = (int)field110UD.Value;

            field110UD.Value = ptcl.ptcl.field_110;
        }

        private void field114UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.field_114 = (int)field114UD.Value;

            field114UD.Value = ptcl.ptcl.field_114;
        }

        private void field118UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.field_118 = (int)field118UD.Value;

            field118UD.Value = ptcl.ptcl.field_118;
        }

        private void field11CUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.field_11C = (int)field11CUD.Value;

            field11CUD.Value = ptcl.ptcl.field_11C;
        }

        private void float120UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.float_120 = (float)float120UD.Value;

            float120UD.Value = (decimal)ptcl.ptcl.float_120;
        }

        private void field124UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.float_124 = (float)field124UD.Value;

            field124UD.Value = (decimal)ptcl.ptcl.float_124;
        }

        private void field128UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.float_128 = (float)field128UD.Value;

            field128UD.Value = (decimal)ptcl.ptcl.float_128;
        }

        private void field12CUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.float_12C = (float)field12CUD.Value;

            field12CUD.Value = (decimal)ptcl.ptcl.float_12C;
        }

        private void field130UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.float_130 = (float)field130UD.Value;

            field130UD.Value = (decimal)ptcl.ptcl.float_130;
        }

        private void field134UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.float_134 = (float)field134UD.Value;

            field134UD.Value = (decimal)ptcl.ptcl.float_134;
        }

        private void field138UD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.float_138 = (float)field138UD.Value;

            field138UD.Value = (decimal)ptcl.ptcl.float_138;
        }

        private void field13CUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.float_13C = (float)field13CUD.Value;

            field13CUD.Value = (decimal)ptcl.ptcl.float_13C;
        }

        private void field14CUD_ValueChanged(object sender, EventArgs e)
        {
            ptcl.ptcl.field_14C = (int)field14CUD.Value;

            field14CUD.Value = ptcl.ptcl.field_14C;
        }

        private void animButton_Click(object sender, EventArgs e)
        {
            ((EffectEditor)(this.Parent.Parent)).loadAnimEditor(ptcl, node);
        }

    }
}
