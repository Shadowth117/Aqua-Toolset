using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace AquaModelTool
{
    public unsafe partial class AqeAnimEditor : UserControl
    {
        AquaModelLibrary.AquaEffect.AnimObject anim;
        private int currentCurv = 0;
        private int currentKey = 0;
        private ColorDialog colorDialog = new ColorDialog();
        TreeNode node;
        public AqeAnimEditor(AquaModelLibrary.AquaEffect.AnimObject animObj, TreeNode thisNode)
        {
            InitializeComponent();
            node = thisNode;
            anim = animObj;
            currentCurv = 0;
            
            for(int i = 0; i < anim.curvs.Count; i++)
            {
                curvSetCB.Items.Add(i);
            }
            curvSetCB.SelectedIndex = currentCurv;

            InitializeCurv();
        }

        public void InitializeCurv()
        {
            currentKey = 0;
            startFrameUD.Value = (decimal)anim.curvs[currentCurv].curv.startFrame;
            endFrameUD.Value = (decimal)anim.curvs[currentCurv].curv.endFrame;
            int0CUD.Value = (decimal)anim.curvs[currentCurv].curv.int_0C;
            float10UD.Value = (decimal)anim.curvs[currentCurv].curv.float_10;
            int14UD.Value = (decimal)anim.curvs[currentCurv].curv.int_14;

            keysListBox.Items.Clear();
            for (int i = 0; i < anim.curvs[currentCurv].keys.Count; i++)
            {
                keysListBox.Items.Add("Frame " + anim.curvs[currentCurv].keys[i].time);
            }
            InitializeKey();
        }

        private void InitializeKey()
        {
            keysListBox.SelectedIndex = currentKey;
            timeUD.Value = (decimal)anim.curvs[currentCurv].keys[currentKey].time;
            valueUD.Value = (decimal)anim.curvs[currentCurv].keys[currentKey].value;
            keysTypeUD.Value = (decimal)anim.curvs[currentCurv].keys[currentKey].type;
            inParamUD.Value = (decimal)anim.curvs[currentCurv].keys[currentKey].inParam;
            outParamUD.Value = (decimal)anim.curvs[currentCurv].keys[currentKey].outParam;
            field18UD.Value = (decimal)anim.curvs[currentCurv].keys[currentKey].field_0x18;
            field1CUD.Value = (decimal)anim.curvs[currentCurv].keys[currentKey].field_0x1C;
        }

        private void curvSetCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCurv = curvSetCB.SelectedIndex;
            InitializeCurv();
        }

        private void keysListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentKey = keysListBox.SelectedIndex;
            InitializeKey();
        }

        private void startFrameUDValue_Changed(object sender, EventArgs e)
        {
            anim.curvs[currentCurv].curv.startFrame = (float)startFrameUD.Value;

            startFrameUD.Value = (decimal)anim.curvs[currentCurv].curv.startFrame;
        }

        private void endFrameUD_ValueChanged(object sender, EventArgs e)
        {
            anim.curvs[currentCurv].curv.endFrame = (float)endFrameUD.Value;

            endFrameUD.Value = (decimal)anim.curvs[currentCurv].curv.endFrame;
        }

        private void int0CUD_ValueChanged(object sender, EventArgs e)
        {
            anim.curvs[currentCurv].curv.int_0C = (int)int0CUD.Value;

            int0CUD.Value = (decimal)anim.curvs[currentCurv].curv.int_0C;
        }

        private void float10UD_ValueChanged(object sender, EventArgs e)
        {
            anim.curvs[currentCurv].curv.float_10 = (float)float10UD.Value;

            float10UD.Value = (decimal)anim.curvs[currentCurv].curv.float_10;
        }

        private void int14UD_ValueChanged(object sender, EventArgs e)
        {
            anim.curvs[currentCurv].curv.int_14 = (int)int14UD.Value;

            int14UD.Value = (decimal)anim.curvs[currentCurv].curv.int_14;
        }

        private void curvTypeUDValue_Changed(object sender, EventArgs e)
        {
            anim.curvs[currentCurv].curv.type = (int)curvTypeUD.Value;

            curvTypeUD.Value = (decimal)anim.curvs[currentCurv].curv.type;
        }

        private void timeUD_ValueChanged(object sender, EventArgs e)
        {
            var key = anim.curvs[currentCurv].keys[currentKey];
            key.time = (float)timeUD.Value;
            anim.curvs[currentCurv].keys[currentKey] = key;

            timeUD.Value = (decimal)anim.curvs[currentCurv].keys[currentKey].time;
        }

        private void valueUD_ValueChanged(object sender, EventArgs e)
        {
            var key = anim.curvs[currentCurv].keys[currentKey];
            key.value = (float)valueUD.Value;
            anim.curvs[currentCurv].keys[currentKey] = key;

            valueUD.Value = (decimal)anim.curvs[currentCurv].keys[currentKey].value;
        }

        private void keysTypeUD_ValueChanged(object sender, EventArgs e)
        {
            var key = anim.curvs[currentCurv].keys[currentKey];
            key.type = (int)keysTypeUD.Value;
            anim.curvs[currentCurv].keys[currentKey] = key;

            keysTypeUD.Value = (decimal)anim.curvs[currentCurv].keys[currentKey].type;
        }

        private void field18UD_ValueChanged(object sender, EventArgs e)
        {
            var key = anim.curvs[currentCurv].keys[currentKey];
            key.field_0x18 = (int)field18UD.Value;
            anim.curvs[currentCurv].keys[currentKey] = key;

            field18UD.Value = (decimal)anim.curvs[currentCurv].keys[currentKey].field_0x18;
        }

        private void field1CUD_ValueChanged(object sender, EventArgs e)
        {
            var key = anim.curvs[currentCurv].keys[currentKey];
            key.field_0x1C = (int)field1CUD.Value;
            anim.curvs[currentCurv].keys[currentKey] = key;

            field1CUD.Value = (decimal)anim.curvs[currentCurv].keys[currentKey].field_0x1C;
        }

        private void inParamUD_ValueChanged(object sender, EventArgs e)
        {
            var key = anim.curvs[currentCurv].keys[currentKey];
            key.inParam = (int)inParamUD.Value;
            anim.curvs[currentCurv].keys[currentKey] = key;

            inParamUD.Value = (decimal)anim.curvs[currentCurv].keys[currentKey].inParam;
        }

        private void outParamUD_ValueChanged(object sender, EventArgs e)
        {
            var key = anim.curvs[currentCurv].keys[currentKey];
            key.outParam = (int)outParamUD.Value;
            anim.curvs[currentCurv].keys[currentKey] = key;

            outParamUD.Value = (decimal)anim.curvs[currentCurv].keys[currentKey].outParam;
        }

        private void animButton_Click(object sender, EventArgs e)
        {
            ((EffectEditor)(this.Parent.Parent)).loadGeneralEditor(node);
        }
    }
}
