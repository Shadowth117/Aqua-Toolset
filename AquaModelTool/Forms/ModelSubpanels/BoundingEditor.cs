using System;
using System.Windows.Forms;

namespace AquaModelTool.Forms.ModelSubpanels
{
    public partial class BoundingEditor : UserControl
    {
        private AquaModelLibrary.AquaObject model;

        public BoundingEditor(AquaModelLibrary.AquaObject aquaModel)
        {
            model = aquaModel;
            InitializeComponent();

            centerXUD.Value = (decimal)model.objc.bounds.modelCenter.X;
            centerYUD.Value = (decimal)model.objc.bounds.modelCenter.Y;
            centerZUD.Value = (decimal)model.objc.bounds.modelCenter.Z;
            center2XUD.Value = (decimal)model.objc.bounds.modelCenter2.X;
            center2YUD.Value = (decimal)model.objc.bounds.modelCenter2.Y;
            center2ZUD.Value = (decimal)model.objc.bounds.modelCenter2.Z;
            halfXUD.Value = (decimal)model.objc.bounds.halfExtents.X;
            halfYUD.Value = (decimal)model.objc.bounds.halfExtents.Y;
            halfZUD.Value = (decimal)model.objc.bounds.halfExtents.Z;
            reserve0UD.Value = (decimal)model.objc.bounds.reserve0;
            reserve1UD.Value = (decimal)model.objc.bounds.reserve1;
            boundingUD.Value = (decimal)model.objc.bounds.boundingRadius;
            unkCount0UD.Value = (decimal)model.objc.unkCount0;
        }

        private void centerXUD_ValueChanged(object sender, EventArgs e)
        {
            model.objc.bounds.modelCenter.X = (float)centerXUD.Value;
        }

        private void centerYUD_ValueChanged(object sender, EventArgs e)
        {
            model.objc.bounds.modelCenter.Y = (float)centerYUD.Value;
        }

        private void centerZUD_ValueChanged(object sender, EventArgs e)
        {
            model.objc.bounds.modelCenter.Z = (float)centerZUD.Value;
        }

        private void center2XUD_ValueChanged(object sender, EventArgs e)
        {
            model.objc.bounds.modelCenter2.X = (float)center2XUD.Value;
        }

        private void center2YUD_ValueChanged(object sender, EventArgs e)
        {
            model.objc.bounds.modelCenter2.Y = (float)center2YUD.Value;
        }

        private void center2ZUD_ValueChanged(object sender, EventArgs e)
        {
            model.objc.bounds.modelCenter2.Z = (float)center2ZUD.Value;
        }

        private void halfXUD_ValueChanged(object sender, EventArgs e)
        {
            model.objc.bounds.halfExtents.X = (float)halfXUD.Value;
        }

        private void halfYUD_ValueChanged(object sender, EventArgs e)
        {
            model.objc.bounds.halfExtents.Y = (float)halfYUD.Value;
        }

        private void halfZUD_ValueChanged(object sender, EventArgs e)
        {
            model.objc.bounds.halfExtents.Z = (float)halfZUD.Value;
        }

        private void boundingUD_ValueChanged(object sender, EventArgs e)
        {
            model.objc.bounds.boundingRadius = (float)boundingUD.Value;
        }

        private void unkCount0UD_ValueChanged(object sender, EventArgs e)
        {
            model.objc.unkCount0 = (int)unkCount0UD.Value;
        }

        private void reserve0UD_ValueChanged(object sender, EventArgs e)
        {
            model.objc.bounds.reserve0 = (float)reserve0UD.Value;
        }

        private void reserve1UD_ValueChanged(object sender, EventArgs e)
        {
            model.objc.bounds.reserve1 = (float)reserve1UD.Value;
        }
    }
}
