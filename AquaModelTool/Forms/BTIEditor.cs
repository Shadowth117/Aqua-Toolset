using System;
using System.Windows.Forms;

namespace AquaModelTool
{
    public partial class BTIEditor : UserControl
    {
        public AquaModelLibrary.AquaBTI_MotionConfig bti;
        public BTIEditor(AquaModelLibrary.AquaBTI_MotionConfig newBti)
        {
            bti = newBti;

            InitializeComponent();
            PopulateModelDropdown();
            startFrameUD.Value = (decimal)bti.header.animLength;
        }

        public void PopulateEntryVariables()
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            additionTB.Text = curEntry.addition;
            nodeTB.Text = curEntry.node;
            short08UD.Value = curEntry.entry.sht_08;
            short0AUD.Value = curEntry.entry.sht_0A;
            startingFrameUD.Value = (decimal)curEntry.entry.startFrame;
            float10UD.Value = (decimal)curEntry.entry.float_10;
            posXUD.Value = (decimal)curEntry.entry.pos.X;
            posYUD.Value = (decimal)curEntry.entry.pos.Y;
            posZUD.Value = (decimal)curEntry.entry.pos.Z;
            float_20UD.Value = (decimal)curEntry.entry.float_20;
            rotXUD.Value = (decimal)curEntry.entry.eulerRot.X;
            rotYUD.Value = (decimal)curEntry.entry.eulerRot.Y;
            rotZUD.Value = (decimal)curEntry.entry.eulerRot.Z;
            float_30UD.Value = (decimal)curEntry.entry.float_30;
            scaleXUD.Value = (decimal)curEntry.entry.scale.X;
            scaleYUD.Value = (decimal)curEntry.entry.scale.Y;
            scaleZUD.Value = (decimal)curEntry.entry.scale.Z;
            endFrameUD.Value = (decimal)curEntry.entry.endFrame;
            unkVecXUD.Value = (decimal)curEntry.entry.vec3_68.X;
            unkVecYUD.Value = (decimal)curEntry.entry.vec3_68.Y;
            unkVecZUD.Value = (decimal)curEntry.entry.vec3_68.Z;
            float44UD.Value = (decimal)curEntry.entry.float_44;
            float48UD.Value = (decimal)curEntry.entry.float_48;
            float4CUD.Value = (decimal)curEntry.entry.float_4C;
            float50UD.Value = (decimal)curEntry.entry.float_50;
            field54UD.Value = curEntry.entry.field_54;
            field58UD.Value = curEntry.entry.field_58;
            field5CUD.Value = curEntry.entry.field_5C;
            field60UD.Value = curEntry.entry.field_60;
            field64UD.Value = curEntry.entry.field_64;
        }

        public void PopulateModelDropdown()
        {
            btiIEntryCB.BeginUpdate();
            btiIEntryCB.Items.Clear();
            for (int i = 0; i < bti.btiEntries.Count; i++)
            {
                btiIEntryCB.Items.Add(i);
            }
            btiIEntryCB.EndUpdate();
            btiIEntryCB.SelectedIndex = 0;
            if (btiIEntryCB.Items.Count < 2)
            {
                btiIEntryCB.Enabled = false;
            }
        }

        private void modelIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateEntryVariables();
        }

        private void UdpateEditor()
        {
            modelPanel.Controls.Clear();
            UserControl control;
            control = new BtiEntryEditor();

            modelPanel.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            bti.btiEntries.Add(new AquaModelLibrary.AquaBTI_MotionConfig.BTIEntryObject());
            PopulateModelDropdown();
        }

        private void duplicateBtn_Click(object sender, EventArgs e)
        {
            if(bti.btiEntries.Count > 0 && btiIEntryCB.SelectedIndex > -1)
            {
                var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
                bti.btiEntries.Insert(btiIEntryCB.SelectedIndex, new AquaModelLibrary.AquaBTI_MotionConfig.BTIEntryObject() { entry = curEntry.entry, addition = curEntry.addition, node = curEntry.node});
                PopulateModelDropdown();
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (bti.btiEntries.Count > 0 && btiIEntryCB.SelectedIndex > -1)
            {
                bti.btiEntries.RemoveAt(btiIEntryCB.SelectedIndex);
                PopulateModelDropdown();
            }
        }
        private void endFrameUD_Changed(object sender, EventArgs e)
        {
            var head = bti.header;
            head.animLength = (float)startFrameUD.Value;
            bti.header = head;
        }

        private void additionTB_TextChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.addition = additionTB.Text;
        }

        private void nodeTB_TextChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.node = nodeTB.Text;
        }

        private void short08UD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.sht_08 = (short)short08UD.Value;
        }

        private void short0AUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.sht_0A = (short)short0AUD.Value;
        }

        private void float0CUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.startFrame = (float)startingFrameUD.Value;
        }

        private void float10UD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.float_10 = (float)float10UD.Value;
        }

        private void posXUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.pos.X = (float)posXUD.Value;
        }

        private void posYUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.pos.Y = (float)posYUD.Value;
        }

        private void posZUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.pos.Z = (float)posZUD.Value;
        }

        private void float_20UD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.float_20 = (float)float_20UD.Value;
        }

        private void rotXUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.eulerRot.X = (float)rotXUD.Value;
        }

        private void rotYUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.eulerRot.Y = (float)rotYUD.Value;
        }

        private void rotZUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.eulerRot.Z = (float)rotZUD.Value;
        }

        private void float_30UD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.float_30 = (float)float_30UD.Value;
        }

        private void scaleXUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.scale.X = (float)scaleXUD.Value;
        }

        private void scaleYUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.scale.Y = (float)scaleYUD.Value;
        }

        private void scaleZUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.scale.Z = (float)scaleZUD.Value;
        }
        private void unkFrameUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.endFrame = (float)endFrameUD.Value;
        }

        private void unkVecXUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.vec3_68.X = (float)unkVecXUD.Value;
        }

        private void unkVecYUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.vec3_68.Y = (float)unkVecYUD.Value;
        }

        private void unkVecZUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.vec3_68.Z = (float)unkVecZUD.Value;
        }

        private void float44UD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.float_44 = (float)float44UD.Value;
        }

        private void float48UD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.float_48 = (float)float48UD.Value;
        }

        private void float4CUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.float_4C = (float)float4CUD.Value;
        }

        private void float50UD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.float_50 = (float)float50UD.Value;
        }

        private void field54UD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.field_54 = (int)field54UD.Value;
        }

        private void field58UD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.field_58 = (int)field58UD.Value;
        }

        private void field5CUD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.field_5C = (int)field5CUD.Value;
        }

        private void field60UD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.field_60 = (int)field60UD.Value;
        }

        private void field64UD_ValueChanged(object sender, EventArgs e)
        {
            var curEntry = bti.btiEntries[btiIEntryCB.SelectedIndex];
            curEntry.entry.field_64 = (int)field64UD.Value;
        }
    }
}
