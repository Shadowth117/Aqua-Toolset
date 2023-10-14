using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace AquaModelTool
{
    public unsafe partial class EmitEditor : UserControl
    {
        AquaModelLibrary.AquaEffect.EMITObject emit;
        TreeNode node;
        public EmitEditor(AquaModelLibrary.AquaEffect.EMITObject emitObj, TreeNode thisNode)
        {
            InitializeComponent();
            node = thisNode;
            emit = emitObj;
            animButton.Text += $" ({emit.curvs.Count})";
            if (emit.curvs.Count == 0)
            {
                animButton.Enabled = false;
            }
            startFrameUD.Value = (decimal)emit.emit.startFrame;
            endFrameUD.Value = (decimal)emit.emit.endFrame;

            posXUD.Value = (decimal)emit.emit.unkVec3_00.X;
            posYUD.Value = (decimal)emit.emit.unkVec3_00.Y;
            posZUD.Value = (decimal)emit.emit.unkVec3_00.Z;

            rotXUD.Value = (decimal)emit.emit.unkVec3_10.X;
            rotYUD.Value = (decimal)emit.emit.unkVec3_10.Y;
            rotZUD.Value = (decimal)emit.emit.unkVec3_10.Z;

            scaleXUD.Value = (decimal)emit.emit.unkVec3_20.X;
            scaleYUD.Value = (decimal)emit.emit.unkVec3_20.Y;
            scaleZUD.Value = (decimal)emit.emit.unkVec3_20.Z;

            vec3_40XUD.Value = (decimal)emit.emit.unkVec3_40.X;
            vec3_40YUD.Value = (decimal)emit.emit.unkVec3_40.Y;
            vec3_40ZUD.Value = (decimal)emit.emit.unkVec3_40.Z;

            vec3_50XUD.Value = (decimal)emit.emit.unkVec3_50.X;
            vec3_50YUD.Value = (decimal)emit.emit.unkVec3_50.Y;
            vec3_50ZUD.Value = (decimal)emit.emit.unkVec3_50.Z;

            vec3_60XUD.Value = (decimal)emit.emit.unkVec3_60.X;
            vec3_60YUD.Value = (decimal)emit.emit.unkVec3_60.Y;
            vec3_60ZUD.Value = (decimal)emit.emit.unkVec3_60.Z;

            vec3_C0XUD.Value = (decimal)emit.emit.unkVec3_C0.X;
            vec3_C0YUD.Value = (decimal)emit.emit.unkVec3_C0.Y;
            vec3_C0ZUD.Value = (decimal)emit.emit.unkVec3_C0.Z;

            vec3_D0XUD.Value = (decimal)emit.emit.unkVec3_D0.X;
            vec3_D0YUD.Value = (decimal)emit.emit.unkVec3_D0.Y;
            vec3_D0ZUD.Value = (decimal)emit.emit.unkVec3_D0.Z;

            float30UD.Value = (decimal)emit.emit.float_30;
            int78UD.Value = emit.emit.int_78;
            float7CUD.Value = (decimal)emit.emit.float_7C;

            int80UD.Value = emit.emit.int_80;
            int84UD.Value = emit.emit.int_84;
            int88UD.Value = emit.emit.int_88;
            float8CUD.Value = (decimal)emit.emit.float_8C;

            float90UD.Value = (decimal)emit.emit.float_90;
            int94UD.Value = emit.emit.int_94;
            float98UD.Value = (decimal)emit.emit.float_98;
            short9CUD.Value = emit.emit.short_9C;
            short9EUD.Value = emit.emit.short_9E;

            shortA0UD.Value = emit.emit.short_A0;
            shortA2UD.Value = emit.emit.short_A2;
            shortA4UD.Value = emit.emit.short_A4;
            shortA6UD.Value = emit.emit.short_A6;
            intA8UD.Value = emit.emit.int_A8;
            fieldACUD.Value = emit.emit.field_AC;

            fieldB0UD.Value = emit.emit.field_B0;
            fieldB4UD.Value = emit.emit.field_B4;
            intB8UD.Value = emit.emit.int_B8;
            intBCUD.Value = emit.emit.int_BC;

            intE0UD.Value = emit.emit.int_E0;
            fieldE4UD.Value = emit.emit.field_E4;
            fieldE8UD.Value = emit.emit.field_E8;
            fieldECUD.Value = emit.emit.field_EC;

            fieldF8UD.Value = emit.emit.field_F8;
            fieldFCUD.Value = emit.emit.field_FC;
        }


        private void startFrameUDValue_Changed(object sender, EventArgs e)
        {
            emit.emit.startFrame = (float)startFrameUD.Value;

            startFrameUD.Value = (decimal)emit.emit.startFrame;
        }

        private void endFrameUD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.endFrame = (float)endFrameUD.Value;

            endFrameUD.Value = (decimal)emit.emit.endFrame;
        }

        private void float30UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.float_30 = (float)float30UD.Value;

            float30UD.Value = (decimal)emit.emit.float_30;
        }

        private void int78UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.int_78 = (int)int78UD.Value;

            int78UD.Value = emit.emit.int_78;
        }

        private void posXUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_00;
            vec3.X = (float)posXUD.Value;
            emit.emit.unkVec3_00 = vec3;
            
            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            posXUD.Value = (decimal)emit.emit.unkVec3_00.X;
        }

        private void posYUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_00;
            vec3.Y = (float)posYUD.Value;
            emit.emit.unkVec3_00 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            posYUD.Value = (decimal)emit.emit.unkVec3_00.Y;
        }

        private void posZUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_00;
            vec3.Z = (float)posZUD.Value;
            emit.emit.unkVec3_00 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            posZUD.Value = (decimal)emit.emit.unkVec3_00.Z;
        }

        private void rotXUD_ValueChanged(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_10;
            vec3.X = (float)rotXUD.Value;
            emit.emit.unkVec3_10 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            rotXUD.Value = (decimal)emit.emit.unkVec3_10.X;
        }

        private void rotYUD_ValueChanged(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_10;
            vec3.Y = (float)rotYUD.Value;
            emit.emit.unkVec3_10 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            rotYUD.Value = (decimal)emit.emit.unkVec3_10.Y;
        }

        private void rotZUD_ValueChanged(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_10;
            vec3.Z = (float)rotZUD.Value;
            emit.emit.unkVec3_10 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            rotZUD.Value = (decimal)emit.emit.unkVec3_10.Z;
        }

        private void scaleXUD_ValueChanged(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_20;
            vec3.X = (float)scaleXUD.Value;
            emit.emit.unkVec3_20 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            scaleXUD.Value = (decimal)emit.emit.unkVec3_20.X;
        }

        private void scaleYUD_ValueChanged(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_20;
            vec3.Y = (float)scaleYUD.Value;
            emit.emit.unkVec3_20 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            scaleYUD.Value = (decimal)emit.emit.unkVec3_20.Y;
        }

        private void scaleZUD_ValueChanged(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_20;
            vec3.Z = (float)scaleZUD.Value;
            emit.emit.unkVec3_20 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            scaleZUD.Value = (decimal)emit.emit.unkVec3_20.Z;
        }

        private void vec340XUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_40;
            vec3.X = (float)vec3_40XUD.Value;
            emit.emit.unkVec3_40 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            vec3_40XUD.Value = (decimal)emit.emit.unkVec3_40.X;
        }
        private void vec340YUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_40;
            vec3.Y = (float)vec3_40YUD.Value;
            emit.emit.unkVec3_40 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            vec3_40YUD.Value = (decimal)emit.emit.unkVec3_40.Y;
        }
        private void vec340ZUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_40;
            vec3.Z = (float)vec3_40ZUD.Value;
            emit.emit.unkVec3_40 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            vec3_40ZUD.Value = (decimal)emit.emit.unkVec3_40.Z;
        }
        private void vec350XUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_50;
            vec3.X = (float)vec3_50XUD.Value;
            emit.emit.unkVec3_50 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            vec3_50XUD.Value = (decimal)emit.emit.unkVec3_50.X;
        }
        private void vec350YUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_50;
            vec3.Y = (float)vec3_50YUD.Value;
            emit.emit.unkVec3_50 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            vec3_50YUD.Value = (decimal)emit.emit.unkVec3_50.Y;
        }
        private void vec350ZUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_50;
            vec3.Z = (float)vec3_50ZUD.Value;
            emit.emit.unkVec3_50 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            vec3_50ZUD.Value = (decimal)emit.emit.unkVec3_50.Z;
        }
        private void vec360XUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_60;
            vec3.X = (float)vec3_60XUD.Value;
            emit.emit.unkVec3_60 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            vec3_60XUD.Value = (decimal)emit.emit.unkVec3_60.X;
        }
        private void vec360YUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_60;
            vec3.Y = (float)vec3_60YUD.Value;
            emit.emit.unkVec3_60 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            vec3_60YUD.Value = (decimal)emit.emit.unkVec3_60.Y;
        }
        private void vec360ZUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_60;
            vec3.Z = (float)vec3_60ZUD.Value;
            emit.emit.unkVec3_60 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            vec3_60ZUD.Value = (decimal)emit.emit.unkVec3_60.Z;
        }
        private void vec3C0XUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_C0;
            vec3.X = (float)vec3_C0XUD.Value;
            emit.emit.unkVec3_C0 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            vec3_C0XUD.Value = (decimal)emit.emit.unkVec3_C0.X;
        }
        private void vec3C0YUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_C0;
            vec3.Y = (float)vec3_C0YUD.Value;
            emit.emit.unkVec3_C0 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            vec3_C0YUD.Value = (decimal)emit.emit.unkVec3_C0.Y;
        }
        private void vec3C0ZUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_C0;
            vec3.Z = (float)vec3_C0ZUD.Value;
            emit.emit.unkVec3_C0 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            vec3_C0ZUD.Value = (decimal)emit.emit.unkVec3_C0.Z;
        }
        private void vec3D0XUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_D0;
            vec3.X = (float)vec3_D0XUD.Value;
            emit.emit.unkVec3_D0 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            vec3_D0XUD.Value = (decimal)emit.emit.unkVec3_D0.X;
        }
        private void vec3D0YUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_D0;
            vec3.Y = (float)vec3_D0YUD.Value;
            emit.emit.unkVec3_D0 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            vec3_D0YUD.Value = (decimal)emit.emit.unkVec3_D0.Y;
        }
        private void vec3D0ZUDValue_Changed(object sender, EventArgs e)
        {
            var vec3 = emit.emit.unkVec3_D0;
            vec3.Z = (float)vec3_D0ZUD.Value;
            emit.emit.unkVec3_D0 = vec3;

            //Set from the casted number so it's clear to the user what the new value will be. Decimals don't match to floats well
            vec3_D0ZUD.Value = (decimal)emit.emit.unkVec3_D0.Z;
        }
        private void shortA4UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.short_A4 = (short)shortA4UD.Value;

            shortA4UD.Value = emit.emit.short_A4;
        }
        private void float7CUD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.float_7C = (float)float7CUD.Value;

            float7CUD.Value = (decimal)emit.emit.float_7C;
        }
        private void int80UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.int_80 = (int)int80UD.Value;

            int80UD.Value = emit.emit.int_80;
        }
        private void int88UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.int_88 = (int)int88UD.Value;

            int88UD.Value = emit.emit.int_88;
        }
        private void float8CUD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.float_8C = (float)float8CUD.Value;

            float8CUD.Value = (decimal)emit.emit.float_8C;
        }
        private void float90UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.float_90 = (float)float90UD.Value;

            float90UD.Value = (decimal)emit.emit.float_90;
        }
        private void int94UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.int_94 = (int)int94UD.Value;

            int94UD.Value = emit.emit.int_94;
        }
        private void float98UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.float_98 = (float)float98UD.Value;

            float98UD.Value = (decimal)emit.emit.float_98;
        }
        private void short9CUD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.short_9C = (short)short9CUD.Value;

            short9CUD.Value = emit.emit.short_9C;
        }
        private void short9EUD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.short_9E = (short)short9EUD.Value;

            short9EUD.Value = emit.emit.short_9E;
        }
        private void shortA0UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.short_A0 = (short)shortA0UD.Value;

            shortA0UD.Value = emit.emit.short_A0;
        }
        private void shortA2UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.short_A2 = (short)shortA2UD.Value;

            shortA2UD.Value = emit.emit.short_A2;
        }
        private void shortA6UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.short_A6 = (short)shortA6UD.Value;

            shortA6UD.Value = emit.emit.short_A6;
        }
        private void intA8UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.int_A8 = (int)intA8UD.Value;

            intA8UD.Value = emit.emit.int_A8;
        }
        private void intACUD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.field_AC = (int)fieldACUD.Value;

            fieldACUD.Value = emit.emit.field_AC;
        }
        private void intB0UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.field_B0 = (int)fieldB0UD.Value;

            fieldB0UD.Value = emit.emit.field_B0;
        }
        private void intB4UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.field_B4 = (int)fieldB4UD.Value;

            fieldB4UD.Value = emit.emit.field_B4;
        }
        private void intB8UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.int_88 = (int)int88UD.Value;

            int88UD.Value = emit.emit.int_88;
        }
        private void intBCUD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.int_BC = (int)intBCUD.Value;

            intBCUD.Value = emit.emit.int_BC;
        }
        private void intE0UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.int_E0 = (int)intE0UD.Value;

            intE0UD.Value = emit.emit.int_E0;
        }
        private void fieldE4UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.field_E4 = (int)fieldE4UD.Value;

            fieldE4UD.Value = emit.emit.field_E4;
        }
        private void fieldE8UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.field_E8 = (int)fieldE8UD.Value;

            fieldE8UD.Value = emit.emit.field_E8;
        }
        private void fieldECUD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.field_EC = (int)fieldECUD.Value;

            fieldECUD.Value = emit.emit.field_EC;
        }
        private void fieldF8UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.field_F8 = (int)fieldF8UD.Value;

            fieldF8UD.Value = emit.emit.field_F8;
        }
        private void fieldFCUD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.field_FC = (int)fieldFCUD.Value;

            fieldFCUD.Value = emit.emit.field_FC;
        }
        private void int84UD_ValueChanged(object sender, EventArgs e)
        {
            emit.emit.int_84 = (int)int84UD.Value;

            int84UD.Value = emit.emit.int_84;
        }

        private void animButton_Click(object sender, EventArgs e)
        {
            ((EffectEditor)(this.Parent.Parent)).loadAnimEditor(emit, node);
        }
    }
}

