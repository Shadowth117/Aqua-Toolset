using AquaModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using static AquaModelLibrary.AquaUtil;
using static AquaModelLibrary.Utility.AquaUtilData;

namespace AquaModelTool
{
    public partial class AnimationEditor : UserControl
    {
        private AnimSet animSet;
        private AquaMotion currentMotion;
        private TreeNode selectedNode;
        private TextBoxPopUp textWindow;
        public AnimationEditor(AnimSet aquaAnimSet)
        {
            InitializeComponent();
            animSet = aquaAnimSet;

            //Populate anims dropdown 
            animIDCB.BeginUpdate();
            for (int i = 0; i < animSet.anims.Count; i++)
            {
                animIDCB.Items.Add(i);
            }
            animIDCB.EndUpdate();
            animIDCB.SelectedIndex = 0;
            currentMotion = animSet.anims[animIDCB.SelectedIndex];
            if (animIDCB.Items.Count < 2)
            {
                animIDCB.Enabled = false;
            }

            InitializeAnimTreeView();
            textWindow = new TextBoxPopUp(0x20);
            textWindow.Hide();
        }

        private void InitializeAnimTreeView()
        {
            loopUD.Value = currentMotion.moHeader.loopPoint;
            fpsUD.Value = (decimal)currentMotion.moHeader.frameSpeed;
            //Populate the anim tree
            animTreeView.Nodes.Clear();
            for (int i = 0; i < currentMotion.motionKeys.Count; i++)
            {
                TreeNode topNode = new TreeNode($" ({currentMotion.motionKeys[i].mseg.nodeId}) " + currentMotion.motionKeys[i].mseg.nodeName.GetString());
                topNode.Tag = 0;
                animTreeView.Nodes.Add(topNode);

                for (int j = 0; j < currentMotion.motionKeys[i].keyData.Count; j++)
                {
                    if (!currentMotion.keyTypeNames.ContainsKey(currentMotion.motionKeys[i].keyData[j].keyType))
                    {
                        throw new Exception($"Keyframe type {currentMotion.motionKeys[i].keyData[j].keyType.ToString("X")} not found!");
                    }
                    TreeNode midNode = new TreeNode(currentMotion.keyTypeNames[currentMotion.motionKeys[i].keyData[j].keyType]);
                    midNode.Tag = 1;
                    animTreeView.Nodes[i].Nodes.Add(midNode);
                    
                    //Account for VTBF motions not having to have frametimings if there's only one frame
                    if (currentMotion.motionKeys[i].keyData[j].frameTimings.Count > 0)
                    {
                        for (int k = 0; k < currentMotion.motionKeys[i].keyData[j].frameTimings.Count; k++)
                        {
                            TreeNode lowNode = new TreeNode("Frame " + (currentMotion.motionKeys[i].keyData[j].frameTimings[k] / currentMotion.motionKeys[i].keyData[j].GetTimeMultiplier()));
                            lowNode.Tag = 2;
                            animTreeView.Nodes[i].Nodes[j].Nodes.Add(lowNode);
                        }
                    }
                    else
                    {
                        TreeNode lowNode = new TreeNode("Frame 0");
                        lowNode.Tag = 2;
                        animTreeView.Nodes[i].Nodes[j].Nodes.Add(lowNode);
                    }
                }
            }
        }

        public void animTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node_here = animTreeView.GetNodeAt(e.X, e.Y);
            animTreeView.SelectedNode = node_here;
            //Return if there's nothing selected
            if (node_here == null) return;

            if (e.Button == MouseButtons.Right)
            {
                switch((int)node_here.Tag)
                {
                    case 0:
                        nodeMenuStrip.Show(animTreeView, new System.Drawing.Point(e.X, e.Y));
                        break;
                    case 1:
                        transformGroupMenuStrip.Show(animTreeView, new System.Drawing.Point(e.X, e.Y));
                        break;
                    case 2:
                        keyframeMenuStrip.Show(animTreeView, new System.Drawing.Point(e.X, e.Y));
                        break;
                }
            } else if (e.Button == MouseButtons.Left)
            {
                if ((int)node_here.Tag == 0x2)
                {
                    selectedNode = node_here;

                    //Set up panel data
                    var control = new KeyEditor(currentMotion, selectedNode, selectedNode.Parent.Parent.Index, selectedNode.Parent.Index, selectedNode.Index);
                    dataPanel.Controls.Clear();
                    dataPanel.Controls.Add(control);
                    control.Dock = DockStyle.Fill;

                } else
                {
                    dataPanel.Controls.Clear();
                }
            }

        }

        public void animTreeView_Rename(object sender, EventArgs e)
        {
            TreeNode node = animTreeView.SelectedNode;

            if((int)node.Tag == 0)
            {
                var textArr = node.Text.Split(')');
                var num = textArr[0] + ")";
                textWindow.textBox1.Text = node.Text.Split(')')[1];
                
                if(textWindow.ShowDialog() == DialogResult.OK)
                {
                    node.Text = num + textWindow.textBox1.Text;
                    currentMotion.motionKeys[node.Index].mseg.nodeName.SetString(textWindow.textBox1.Text);
                }
            }
        }

        public void animTreeView_Insert(object sender, EventArgs e)
        {
            int mainId = -1;
            int keyDataId = -1;
            int frameId = -1;
            TreeNode node = animTreeView.SelectedNode;
            //Camera motions should only ever have one node
            if ((int)node.Tag == 0 && currentMotion.moHeader.variant == AquaMotion.cameraAnim)
            {
                MessageBox.Show("You cannot have multiple camera nodes!");
                return;
            }

            //If node.Tag is 1, check that the transform categories aren't maxed already
            if ((int)node.Tag == 1)
            {
                switch(currentMotion.moHeader.variant)
                {
                    case AquaMotion.cameraAnim:
                    case AquaMotion.stdAnim:
                    case AquaMotion.stdPlayerAnim:
                        if(node.Parent.Nodes.Count >= 4)
                        {
                            MessageBox.Show("All allowed transform types have already been used!");
                            return;
                        }
                        break;
                    case AquaMotion.materialAnim:
                        if (node.Parent.Nodes.Count >= 9)
                        {
                            MessageBox.Show("All allowed transform types have already been used!");
                            return;
                        }
                        break;
                    default:
                        MessageBox.Show($"Unknown motion variant {currentMotion.moHeader.variant}");
                        return;
                }
            }

            //Since frames must be whole numbers, prevent more frames than the endframe count from being added
            if ((int)node.Tag == 2)
            {
                currentMotion.motionKeys[node.Parent.Parent.Index].keyData[node.Parent.Index].keyCount += 1;
            }

            //Insert the new node
            switch ((int)node.Tag)
            {
                case 0:
                    SetupNewTopNode(node);
                    break;
                case 1:
                    mainId = node.Parent.Index;
                    keyDataId = AddTransformType(node.Parent);
                    break;
                case 2:
                    mainId = node.Parent.Parent.Index;
                    keyDataId = node.Parent.Index;
                    frameId = node.Index;
                    var keySet = currentMotion.motionKeys[node.Parent.Parent.Index].keyData[node.Parent.Index];
                    keySet.keyCount++;

                    if(keySet.frameTimings.Count == 0)
                    {
                        keySet.frameTimings.Add(0);
                        keySet.frameTimings.Insert(0, 0);
                    } else
                    {
                        keySet.frameTimings.Insert(node.Index, currentMotion.motionKeys[node.Parent.Parent.Index].keyData[node.Parent.Index].frameTimings[node.Index]);
                    }
                    if (keySet.frameTimings.Count == 1)
                    {
                        
                    }

                    var dataType = keySet.dataType;
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
                            keySet.vector4Keys.Insert(node.Index, new Vector4(0, 0, 0, 0));
                            break;

                        case 0x5:
                            keySet.intKeys.Insert(node.Index, 0);
                            break;

                        //0x4 is texture/uv related, 0x6 is Camera related - Array of floats. 0x4 seems to be used for every .aqv frame set interestingly
                        case 0x4:
                        case 0x6:
                            keySet.floatKeys.Insert(node.Index, 0);
                            break;
                        default:
                            throw new Exception("Unexpected data type!");
                    }
                    break;
            }

            InitializeAnimTreeView();

            switch ((int)node.Tag)
            {
                case 0:
                    animTreeView.SelectedNode = animTreeView.Nodes[animTreeView.Nodes.Count - 1];
                    break;
                case 1:
                    animTreeView.SelectedNode = animTreeView.Nodes[mainId].Nodes[keyDataId];
                    animTreeView.SelectedNode.Expand();
                    break;
                case 2:
                    animTreeView.SelectedNode = animTreeView.Nodes[mainId].Nodes[keyDataId].Nodes[frameId];
                    animTreeView.SelectedNode.Expand();
                    break;
            }
        }

        private void SetupNewTopNode(TreeNode node)
        {
            //Create MSEG and Keyset
            AquaMotion.KeyData keyData = new AquaMotion.KeyData();
            AquaMotion.MSEG newMseg = new AquaMotion.MSEG();
            newMseg.nodeDataCount = 1;
            newMseg.nodeId = currentMotion.motionKeys[node.Index].mseg.nodeId + 1;
            newMseg.nodeName.SetString("Node " + newMseg.nodeId);
            int transformType = GetTransformType(node, out int nodeType);

            if (nodeType == -1)
            {
                return;
            }

            newMseg.nodeType = nodeType;

            //Add an empty frame
            TreeNode keyNode = new TreeNode("Frame 0");
            keyNode.Tag = 2;

            //Add MKEY data
            keyData.mseg = newMseg;
            AquaMotion.MKEY newMkey = GenerateMKEY(transformType);
            keyData.keyData.Add(newMkey);
            currentMotion.motionKeys.Add(keyData);
        }

        private static AquaMotion.MKEY GenerateMKEY(int transformType)
        {
            AquaMotion.MKEY newMkey = new AquaMotion.MKEY();
            newMkey.keyType = transformType;
            newMkey.dataType = AquaMotion.GetKeyDataType(transformType);
            newMkey.unkInt0 = 0;
            newMkey.keyCount = 1;

            var dataType = newMkey.dataType;
            if ((dataType & 0x80) > 0)
            {
                dataType -= 0x80;
            }
            switch (dataType)
            {
                //0x1 0x2, and 0x3 are Vector4 arrays essentially. 0x1 is seemingly a Vector3 with alignment padding, but could potentially have things.
                case 0x1:
                case 0x2:
                case 0x3:
                    newMkey.vector4Keys.Add(new Vector4(0, 0, 0, 0));
                    break;

                case 0x5:
                    newMkey.intKeys.Add(0);
                    break;
                //0x4 is texture/uv related, 0x6 is Camera related - Array of floats. 0x4 seems to be used for every .aqv frame set interestingly
                case 0x4:
                case 0x6:
                    newMkey.floatKeys.Add(0);
                    break;
                default:
                    throw new Exception($"Unexpected data type: {newMkey.dataType}");
            }

            return newMkey;
        }

        private int AddTransformType(TreeNode node)
        {
            int tfmType = GetTransformType(node, out int check);
            if(check == -1)
            {
                return -1;
            }

            //Find where to insert this
            int id = -1;
            for(int i = 0; i < currentMotion.motionKeys[node.Index].keyData.Count; i++)
            {
                if(currentMotion.motionKeys[node.Index].keyData[i].keyType < tfmType)
                {
                    id = i;
                }
            }

            currentMotion.motionKeys[node.Index].keyData.Insert(id + 1, GenerateMKEY(tfmType));

            return id + 1;
        }

        private int GetTransformType(TreeNode node, out int nodeType)
        {
            List<int> activeCheck;
            List<int> usedKeys = new List<int>();

            //Set up the dialog
            AnimationTransformSelect tfmDialog = new AnimationTransformSelect(currentMotion.moHeader.variant);
            switch (currentMotion.moHeader.variant)
            {
                case AquaMotion.stdAnim:
                case AquaMotion.stdPlayerAnim:
                    nodeType = 0x2;
                    activeCheck = currentMotion.standardTypes;
                    break;
                case AquaMotion.cameraAnim:
                    nodeType = 0x20;
                    activeCheck = currentMotion.cameraTypes;
                    break;
                case AquaMotion.materialAnim:
                    nodeType = 0x10;
                    activeCheck = currentMotion.materialTypes;
                    break;
                default:
                    nodeType = -1;
                    activeCheck = currentMotion.standardTypes;
                    MessageBox.Show("Bad anim? " + currentMotion.moHeader.variant);
                    break;
            }

            //Find preused transform types 
            for (int i = 0; i < currentMotion.motionKeys[node.Index].keyData.Count; i++)
            {
                usedKeys.Add(currentMotion.motionKeys[node.Index].keyData[i].keyType);
            }

            //Set the first enabled type to checked
            bool set = false;
            for (int i = 0; i < tfmDialog.transformButtons.Count; i++)
            {
                //Disallow invalid and used tags
                int tag = (int)tfmDialog.transformButtons[i].Tag;
                if (!activeCheck.Contains(tag) || usedKeys.Contains(tag))
                {
                    tfmDialog.transformButtons[i].Enabled = false;
                }
                else if (activeCheck.Contains(tag))
                {
                    tfmDialog.transformButtons[i].Enabled = true;
                }

                //Set the button checked state
                if (tfmDialog.transformButtons[i].Enabled == false || set == true)
                {
                    tfmDialog.transformButtons[i].Checked = false;
                }
                else if (set == false)
                {
                    tfmDialog.transformButtons[i].Checked = true;
                    set = true;
                }
            }

            //Run Dialog and check results
            tfmDialog.ShowDialog();
            int transformType = tfmDialog.currentChoice;

            return transformType;
        }

        public void animTreeView_Duplicate(object sender, EventArgs e)
        {
            TreeNode node = animTreeView.SelectedNode;
            //Camera motions should only ever have one node
            if ((int)node.Tag == 0 && currentMotion.moHeader.variant == AquaMotion.cameraAnim)
            {
                MessageBox.Show("You cannot have multiple camera nodes!");
                return;
            }

            //Return if this is a transform category node. There should never be multiple of the same one. Ideally, don't show this option for this category.
            if ((int)node.Tag == 1)
            {
                MessageBox.Show("You can't duplicate transformation categories!");
                return;
            }

            //Since frames must be whole numbers, prevent more frames than the endframe count from being added
            if((int)node.Tag == 2)
            {
                currentMotion.motionKeys[node.Parent.Parent.Index].keyData[node.Parent.Index].keyCount += 1;
            }
            
            //Recreate and insert the new node
            TreeNode newNode = new TreeNode(node.Text);
            newNode.Tag = node.Tag;

            //Set the duplicate data
            switch ((int)node.Tag)
            {
                case 0:
                    //Duplicate Transform TreeNodes
                    for(int i = 0; i < node.Nodes.Count; i++)
                    {
                        TreeNode tfmNode = new TreeNode(node.Nodes[i].Text);
                        tfmNode.Tag = node.Nodes[i].Tag;

                        //Duplicate Key Treenodes
                        for (int j = 0; j < node.Nodes.Count; j++)
                        {
                            TreeNode keyNode = new TreeNode(node.Nodes[i].Nodes[j].Text);
                            keyNode.Tag = node.Nodes[i].Nodes[j].Tag;
                            tfmNode.Nodes.Add(keyNode);
                        }
                        newNode.Nodes.Add(tfmNode);
                    }

                    //Set actual data
                    AquaMotion.KeyData oldData = currentMotion.motionKeys[node.Index];
                    AquaMotion.KeyData keyData = new AquaMotion.KeyData();
                    keyData.mseg = new AquaMotion.MSEG();
                    keyData.mseg.nodeName = oldData.mseg.nodeName;
                    keyData.mseg.nodeDataCount = oldData.mseg.nodeDataCount;
                    keyData.mseg.nodeId = oldData.mseg.nodeId;
                    keyData.mseg.nodeType = oldData.mseg.nodeType;
                    
                    //Duplicate keydata
                    for(int i = 0; i < oldData.keyData.Count; i++)
                    {
                        //Duplicate MKEY value data
                        AquaMotion.MKEY oldKey = currentMotion.motionKeys[node.Index].keyData[i];
                        AquaMotion.MKEY newKey = new AquaMotion.MKEY();
                        newKey.dataType = oldKey.dataType;
                        newKey.keyCount = oldKey.keyCount;
                        newKey.keyType = oldKey.keyType;
                        newKey.unkInt0 = oldKey.unkInt0;
                        newKey.floatKeys.AddRange(oldKey.floatKeys);
                        newKey.frameTimings.AddRange(oldKey.frameTimings);
                        newKey.intKeys.AddRange(oldKey.intKeys);
                        newKey.vector4Keys.AddRange(oldKey.vector4Keys);

                        keyData.keyData.Add(newKey);
                    }
                    currentMotion.motionKeys.Insert(node.Index, keyData);
                    currentMotion.moHeader.nodeCount++;
                    break;
                case 2:
                    var keySet = currentMotion.motionKeys[node.Parent.Parent.Index].keyData[node.Parent.Index];

                    if (keySet.frameTimings.Count == 0)
                    {
                        keySet.frameTimings.Add(0);
                        keySet.frameTimings.Insert(0, 0);
                    }
                    else
                    {
                        keySet.frameTimings.Insert(node.Index, currentMotion.motionKeys[node.Parent.Parent.Index].keyData[node.Parent.Index].frameTimings[node.Index]);
                    }

                    var dataType = keySet.dataType;
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
                            keySet.vector4Keys.Insert(node.Index, currentMotion.motionKeys[node.Parent.Parent.Index].keyData[node.Parent.Index].vector4Keys[node.Index]);
                            break;

                        case 0x5:
                            keySet.intKeys.Insert(node.Index, currentMotion.motionKeys[node.Parent.Parent.Index].keyData[node.Parent.Index].intKeys[node.Index]);
                            break;
                        //0x4 is texture/uv related, 0x6 is Camera related - Array of floats. 0x4 seems to be used for every .aqv frame set interestingly
                        case 0x4:
                        case 0x6:
                            keySet.floatKeys.Insert(node.Index, currentMotion.motionKeys[node.Parent.Parent.Index].keyData[node.Parent.Index].floatKeys[node.Index]);
                            break;
                        default:
                            throw new Exception("Unexpected data type!");
                    }
                    break;
                default:
                    throw new Exception("Unexpected node tag!");
            }
            node.Parent.Nodes.Insert(node.Index, newNode);
        }

        public void animTreeView_Delete(object sender, EventArgs e)
        {
            TreeNode node = animTreeView.SelectedNode;
            //Make sure the user can't delete the first node; the game always needs one.
            if ((int)node.Tag == 2 && node.Index == 0)
            {
                MessageBox.Show("You can't delete the first node in a category!");
                return;
            }

            //Make sure the user can't create empty node categories.
            if (node.Parent?.Nodes.Count < 2)
            {
                MessageBox.Show("You can't delete the only node in a category!");
                return;
            }


            //Remove the actual data as well
            switch((int)node.Tag)
            {
                case 0:
                    currentMotion.motionKeys.RemoveAt(node.Index);
                    currentMotion.moHeader.nodeCount--;
                    break;
                case 1:
                    currentMotion.motionKeys[node.Parent.Index].keyData.RemoveAt(node.Index);
                    currentMotion.motionKeys[node.Parent.Index].mseg.nodeDataCount--;
                    break;
                case 2:
                    currentMotion.motionKeys[node.Parent.Parent.Index].keyData[node.Parent.Index].keyCount -= 1;
                    var keySet = currentMotion.motionKeys[node.Parent.Parent.Index].keyData[node.Parent.Index];
                    keySet.keyCount--;
                    keySet.frameTimings.RemoveAt(node.Index);
                    if(keySet.keyCount == 1)
                    {
                        keySet.frameTimings.Clear();
                    }
                    var dataType = keySet.dataType;
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
                            keySet.vector4Keys.RemoveAt(node.Index);
                            break;

                        case 0x5:
                            keySet.intKeys.RemoveAt(node.Index);
                            break;
                        //0x4 is texture/uv related, 0x6 is Camera related - Array of floats. 0x4 seems to be used for every .aqv frame set interestingly
                        case 0x4:
                        case 0x6:
                            keySet.floatKeys.RemoveAt(node.Index);
                            break;
                        default:
                            throw new Exception("Unexpected data type!");
                    }
                    break;
                default:
                    throw new Exception("Unexpected node tag!");
            }
            if(node.Parent != null)
            {
                node.Parent.Nodes.RemoveAt(node.Index);
            } else
            {
                animTreeView.Nodes.Remove(node);
            }
        }

        private void animIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentMotion = animSet.anims[animIDCB.SelectedIndex];

            InitializeAnimTreeView();
        }

        private void loopUD_ValueChanged(object sender, EventArgs e)
        {
            currentMotion.moHeader.loopPoint = (int)loopUD.Value;
        }

        private void fpsUD_ValueChanged(object sender, EventArgs e)
        {

            currentMotion.moHeader.frameSpeed = (float)fpsUD.Value;
        }

    }
}
