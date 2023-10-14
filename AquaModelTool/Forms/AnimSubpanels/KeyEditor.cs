using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace AquaModelTool
{
    public partial class KeyEditor : UserControl
    {
        AquaModelLibrary.AquaMotion motion;
        int keyNodeId;
        int keyDataId;
        int keyId;
        int nodeIndex;
        TreeNode node;
        public KeyEditor(AquaModelLibrary.AquaMotion aquaMotion, TreeNode thisNode, int nodeId, int dataId, int id)
        {
            InitializeComponent();
            node = thisNode;
            nodeIndex = node.Index;
            motion = aquaMotion;
            keyNodeId = nodeId;
            keyDataId = dataId;
            keyId = id;
            if(motion.motionKeys[nodeId].keyData[keyDataId].frameTimings.Count > 0)
            {
                internalTimeUD.Value = motion.motionKeys[nodeId].keyData[keyDataId].frameTimings[keyId];
                timeUD.Value = motion.motionKeys[nodeId].keyData[keyDataId].frameTimings[keyId] / motion.motionKeys[nodeId].keyData[keyDataId].GetTimeMultiplier();
            }
            var dataType = motion.motionKeys[nodeId].keyData[keyDataId].dataType;
            if ((dataType & 0x80) > 0)
            {
                dataType -= 0x80;
            }
            switch (dataType)
            {
                //0x1, 0x2, and 0x3 are Vector4 arrays essentially. 0x1 is seemingly a Vector3 with alignment padding, but could potentially have things.
                case 0x1:
                case 0x2:
                case 0x3:
                    SetVector4Layout();
                    break;

                case 0x5:
                    SetIntLayout();
                    break;

                //0x4 is texture/uv related, 0x6 is Camera related - Array of floats. 0x4 seems to be used for every .aqv frame set interestingly
                case 0x4:
                case 0x6:
                    SetFloatLayout();
                    break;
                default:
                    throw new Exception("Unexpected data type!");
            }

            nodeLabel.Text = motion.motionKeys[nodeId].mseg.nodeName.GetString();
        }

        private void SetVector4Layout()
        {
            data0Label.Visible = true;
            data0Label.Text = "X";
            data1Label.Visible = true;
            data1Label.Text = "Y";
            data2Label.Visible = true;
            data2Label.Text = "Z";
            data3Label.Visible = true;
            data3Label.Text = "W";

            data0UD.DecimalPlaces = 6;
            data0UD.Visible = true;
            data0UD.Value = (decimal)motion.motionKeys[keyNodeId].keyData[keyDataId].vector4Keys[keyId].X;
            data1UD.DecimalPlaces = 6;
            data1UD.Visible = true;
            data1UD.Value = (decimal)motion.motionKeys[keyNodeId].keyData[keyDataId].vector4Keys[keyId].Y;
            data2UD.DecimalPlaces = 6;
            data2UD.Visible = true;
            data2UD.Value = (decimal)motion.motionKeys[keyNodeId].keyData[keyDataId].vector4Keys[keyId].Z;
            data3UD.DecimalPlaces = 6;
            data3UD.Visible = true;
            data3UD.Value = (decimal)motion.motionKeys[keyNodeId].keyData[keyDataId].vector4Keys[keyId].W;
        }

        private void SetIntLayout()
        {
            data0Label.Visible = true;
            data0Label.Text = "Int Value";
            data1Label.Visible = false;
            data2Label.Visible = false;
            data3Label.Visible = false;

            data0UD.DecimalPlaces = 0;
            data0UD.Visible = true;
            if(motion.motionKeys[keyNodeId].keyData[keyDataId].intKeys.Count > 0)
            {
                data0UD.Value = (decimal)motion.motionKeys[keyNodeId].keyData[keyDataId].intKeys[keyId];
            } else
            {
                data0UD.Value = (decimal)motion.motionKeys[keyNodeId].keyData[keyDataId].byteKeys[keyId];
            }
            data1UD.Visible = false;
            data2UD.Visible = false;
            data3UD.Visible = false;
        }

        private void SetFloatLayout()
        {
            data0Label.Visible = true;
            data0Label.Text = "Float Value";
            data1Label.Visible = false;
            data2Label.Visible = false;
            data3Label.Visible = false;

            data0UD.DecimalPlaces = 6;
            data0UD.Visible = true;
            data0UD.Value = (decimal)motion.motionKeys[keyNodeId].keyData[keyDataId].floatKeys[keyId];
            data1UD.Visible = false;
            data2UD.Visible = false;
            data3UD.Visible = false;
        }

        private void TimeUDChanged(object sender, EventArgs e)
        {
            if (motion.motionKeys[keyNodeId].keyData[keyDataId].frameTimings.Count > 0)
            {
                motion.motionKeys[keyNodeId].keyData[keyDataId].frameTimings[keyId] = ((uint)(timeUD.Value * motion.motionKeys[keyNodeId].keyData[keyDataId].GetTimeMultiplier()));
                internalTimeUD.Value = motion.motionKeys[keyNodeId].keyData[keyDataId].frameTimings[keyId];
            }
            else
            {
                MessageBox.Show("Cannot change frame time when there is only one keyframe in this section!");
            }
            if (timeUD.Value > motion.moHeader.endFrame)
            {
                motion.moHeader.endFrame = (int)timeUD.Value;
            }
            node.Text = "Frame " + timeUD.Value;

            ReorderNodes();
        }

        private void ReorderNodes()
        {
            //Handle node ordering
            motion.motionKeys[keyNodeId].keyData[keyDataId].frameTimings.Sort();
            int index = motion.motionKeys[keyNodeId].keyData[keyDataId].frameTimings.IndexOf((uint)internalTimeUD.Value);

            var parent = node.Parent;
            parent.Nodes.RemoveAt(nodeIndex);
            parent.Nodes.Insert(index, node);

            switch (motion.motionKeys[keyNodeId].keyData[keyDataId].dataType)
            {
                case 0x1:
                case 0x2:
                case 0x3:
                    var vec = motion.motionKeys[keyNodeId].keyData[keyDataId].vector4Keys[keyId];
                    motion.motionKeys[keyNodeId].keyData[keyDataId].vector4Keys.RemoveAt(nodeIndex);
                    motion.motionKeys[keyNodeId].keyData[keyDataId].vector4Keys.Insert(index, vec);
                    break;

                case 0x5:
                    if (motion.motionKeys[keyNodeId].keyData[keyDataId].intKeys.Count > 0)
                    {
                        motion.motionKeys[keyNodeId].keyData[keyDataId].intKeys.RemoveAt(nodeIndex);
                        motion.motionKeys[keyNodeId].keyData[keyDataId].intKeys.Insert(index, (int)data0UD.Value);
                    }
                    else
                    {
                        motion.motionKeys[keyNodeId].keyData[keyDataId].byteKeys.RemoveAt(nodeIndex);
                        motion.motionKeys[keyNodeId].keyData[keyDataId].byteKeys.Insert(index, (byte)data0UD.Value);
                    }
                    break;

                //0x4 is texture/uv related, 0x6 is Camera related - Array of floats. 0x4 seems to be used for every .aqv frame set interestingly
                case 0x4:
                case 0x6:
                    motion.motionKeys[keyNodeId].keyData[keyDataId].floatKeys.RemoveAt(nodeIndex);
                    motion.motionKeys[keyNodeId].keyData[keyDataId].floatKeys.Insert(index, (float)data0UD.Value);
                    break;
            }

            nodeIndex = index;
        }

        private void InternalTimeUDChanged(object sender, EventArgs e)
        {
            if(motion.motionKeys[keyNodeId].keyData[keyDataId].frameTimings.Count > 0)
            {
                motion.motionKeys[keyNodeId].keyData[keyDataId].frameTimings[keyId] = (uint)internalTimeUD.Value;
                timeUD.Value = internalTimeUD.Value / motion.motionKeys[keyNodeId].keyData[keyDataId].GetTimeMultiplier();
            } else
            {
                MessageBox.Show("Cannot change frame time when there is only one keyframe in this section!");
            }
            if (timeUD.Value > motion.moHeader.endFrame)
            {
                motion.moHeader.endFrame = (int)timeUD.Value;
            }
            node.Text = "Frame " + timeUD.Value;

            ReorderNodes();
        }

        private void Data0UDChanged(object sender, EventArgs e)
        {
            switch(motion.motionKeys[keyNodeId].keyData[keyDataId].dataType)
            {
                case 0x1:
                case 0x2:
                case 0x3:
                    var vec = motion.motionKeys[keyNodeId].keyData[keyDataId].vector4Keys[keyId];
                    vec.X = (float)data0UD.Value;
                    motion.motionKeys[keyNodeId].keyData[keyDataId].vector4Keys[keyId] = vec;
                    break;

                case 0x5:
                    if(motion.motionKeys[keyNodeId].keyData[keyDataId].intKeys.Count > 0)
                    {
                        motion.motionKeys[keyNodeId].keyData[keyDataId].intKeys[keyId] = (int)data0UD.Value;
                    } else
                    {
                        motion.motionKeys[keyNodeId].keyData[keyDataId].byteKeys[keyId] = (byte)data0UD.Value;
                    }
                    break;

                //0x4 is texture/uv related, 0x6 is Camera related - Array of floats. 0x4 seems to be used for every .aqv frame set interestingly
                case 0x4:
                case 0x6:
                    motion.motionKeys[keyNodeId].keyData[keyDataId].floatKeys[keyId] = (float)data0UD.Value;
                    break;
            }
        }

        private void Data1UDChanged(object sender, EventArgs e)
        {
            var vec = motion.motionKeys[keyNodeId].keyData[keyDataId].vector4Keys[keyId];
            vec.Y = (float)data1UD.Value;
            motion.motionKeys[keyNodeId].keyData[keyDataId].vector4Keys[keyId] = vec;
        }

        private void Data2UDChanged(object sender, EventArgs e)
        {
            var vec = motion.motionKeys[keyNodeId].keyData[keyDataId].vector4Keys[keyId];
            vec.Z = (float)data2UD.Value;
            motion.motionKeys[keyNodeId].keyData[keyDataId].vector4Keys[keyId] = vec;
        }

        private void Data3UDChanged(object sender, EventArgs e)
        {
            var vec = motion.motionKeys[keyNodeId].keyData[keyDataId].vector4Keys[keyId];
            vec.W = (float)data3UD.Value;
            motion.motionKeys[keyNodeId].keyData[keyDataId].vector4Keys[keyId] = vec;
        }


    }
}
