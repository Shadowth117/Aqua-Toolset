using AquaModelLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using static AquaModelLibrary.Utility.ColorUtility;

namespace AquaModelTool.Forms.ModelSubpanels.Material
{
    public partial class MaterialVec3Editor : Form
    {
        private ColorDialog colorDialog = new ColorDialog();
        private List<AquaModelLibrary.AquaObject.MATE> _matList;
        private int _matIndex;
        private int _vec3Index;
        private Button _matButton;
        private bool isActive = false;

        public MaterialVec3Editor(List<AquaModelLibrary.AquaObject.MATE> matList, int matIndex, int vec3Index, Button matButton)
        {
            _matList = matList;
            _matIndex = matIndex;
            _vec3Index = vec3Index;
            _matButton = matButton;

            var mat = _matList[_matIndex];
            var name = matList[matIndex].matName;
            Vector4 vec4 = new Vector4();
            InitializeComponent();
            switch (vec3Index)
            {
                case 0:
                    this.Text = $"{name} Diffuse RGBA Editor";
                    rGBButton.BackColor = ARGBFromRGBAVector4(mat.diffuseRGBA);
                    vec4 = mat.diffuseRGBA;
                    break;
                case 1:
                    this.Text = $"{name} Tex 2 RGBA Editor";
                    rGBButton.BackColor = ARGBFromRGBAVector4(mat.unkRGBA0);
                    vec4 = mat.unkRGBA0;
                    break;
                case 2:
                    this.Text = $"{name} Tex 3 RGBA Editor";
                    rGBButton.BackColor = ARGBFromRGBAVector4(mat._sRGBA);
                    vec4 = mat._sRGBA;
                    break;
                case 3:
                    this.Text = $"{name} Tex 4 RGBA Editor";
                    rGBButton.BackColor = ARGBFromRGBAVector4(mat.unkRGBA1);
                    vec4 = mat.unkRGBA1;
                    break;
            }
            matXUD.Value = (decimal)vec4.X;
            matYUD.Value = (decimal)vec4.Y;
            matZUD.Value = (decimal)vec4.Z;
            isActive = true;
        }

        private void Vec3UD_Click(object sender, EventArgs e)
        {
            if(!isActive)
            {
                return;
            }
            Vector4 vec4;
            AquaModelLibrary.AquaObject.MATE mate = _matList[_matIndex];
            switch (_vec3Index)
            {
                case 0:
                    vec4 = mate.diffuseRGBA;
                    vec4.X = (float)matXUD.Value;
                    vec4.Y = (float)matYUD.Value;
                    vec4.Z = (float)matZUD.Value;
                    mate.diffuseRGBA = vec4;
                    break;
                case 1:
                    vec4 = mate.unkRGBA0;
                    vec4.X = (float)matXUD.Value;
                    vec4.Y = (float)matYUD.Value;
                    vec4.Z = (float)matZUD.Value;
                    mate.unkRGBA0 = vec4;
                    break;
                case 2:
                    vec4 = mate._sRGBA;
                    vec4.X = (float)matXUD.Value;
                    vec4.Y = (float)matYUD.Value;
                    vec4.Z = (float)matZUD.Value;
                    mate._sRGBA = vec4;
                    break;
                case 3:
                    vec4 = mate.unkRGBA1;
                    vec4.X = (float)matXUD.Value;
                    vec4.Y = (float)matYUD.Value;
                    vec4.Z = (float)matZUD.Value;
                    mate.unkRGBA1 = vec4;
                    break;
            }
            var color = ColorUtility.ARGBFromRGBAVector3((float)matXUD.Value, (float)matYUD.Value, (float)matZUD.Value);
            _matButton.BackColor = color;
            _matList[_matIndex] = mate;
        }

        private void rGBButton_Click(object sender, EventArgs e)
        {
            AquaModelLibrary.AquaObject.MATE mate = _matList[_matIndex];

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                switch (_vec3Index)
                {
                    case 0:
                        rGBButton.BackColor = colorDialog.Color;
                        mate.diffuseRGBA = new Vector4((float)colorDialog.Color.R / 255, (float)colorDialog.Color.G / 255, (float)colorDialog.Color.B / 255, mate.diffuseRGBA.W);
                        break;
                    case 1:
                        rGBButton.BackColor = colorDialog.Color;
                        mate.unkRGBA0 = new Vector4((float)colorDialog.Color.R / 255, (float)colorDialog.Color.G / 255, (float)colorDialog.Color.B / 255, mate.unkRGBA0.W);
                        break;
                    case 2:
                        rGBButton.BackColor = colorDialog.Color;
                        mate._sRGBA = new Vector4((float)colorDialog.Color.R / 255, (float)colorDialog.Color.G / 255, (float)colorDialog.Color.B / 255, mate._sRGBA.W);
                        break;
                    case 3:
                        rGBButton.BackColor = colorDialog.Color;
                        mate.unkRGBA1 = new Vector4((float)colorDialog.Color.R / 255, (float)colorDialog.Color.G / 255, (float)colorDialog.Color.B / 255, mate.unkRGBA1.W);
                        break;
                }
                _matButton.BackColor = colorDialog.Color;
            }
            matXUD.Value = (decimal)((float)colorDialog.Color.R / 255);
            matYUD.Value = (decimal)((float)colorDialog.Color.G / 255);
            matZUD.Value = (decimal)((float)colorDialog.Color.B / 255);
            _matList[_matIndex] = mate;
        }
    }
}
