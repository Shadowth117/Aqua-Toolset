using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AquaModelLibrary;

namespace AquaModelTool
{
    public partial class EffectEditor : UserControl
    {
        public AquaEffect effect;
        public TreeNode selectedNode;
        public EffectEditor(AquaEffect newEffect)
        {
            effect = newEffect;
            InitializeComponent();
            InitializeAQETreeView();
        }

        public void InitializeAQETreeView()
        {
            aqeTreeView.Nodes.Clear();
            var root = aqeTreeView.Nodes.Add("Root EFCT node");
            root.Tag = 0;
            for(int i = 0; i < effect.efct.emits.Count; i++)
            {
                var emit = root.Nodes.Add("Emitter " + i);
                emit.Tag = 1;
                for(int p = 0; p < effect.efct.emits[i].ptcls.Count; p++)
                {
                    var ptcl = emit.Nodes.Add("Particle " + p);
                    ptcl.Tag = 2;
                }
            }
            root.Expand();
        }

        public void aqeTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node_here = aqeTreeView.GetNodeAt(e.X, e.Y);
            aqeTreeView.SelectedNode = node_here;
            //Return if there's nothing selected
            if (node_here == null) return;

            if (e.Button == MouseButtons.Right)
            {
                /*
                switch ((int)node_here.Tag)
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
                }*/
            }
            else if (e.Button == MouseButtons.Left)
            {
                loadGeneralEditor(node_here);
            }

        }

        public void loadGeneralEditor(TreeNode node_here)
        {
            selectedNode = node_here;

            for (int ctrl = 0; ctrl < mainPanel.Controls.Count; ctrl++)
            {
                mainPanel.Controls[ctrl].Dispose();
            }
            mainPanel.Controls.Clear();

            switch ((int)selectedNode.Tag)
            {
                case 0:
                    mainPanel.Controls.Add(new EfctEditor(effect.efct, selectedNode));
                    break;
                case 1:
                    mainPanel.Controls.Add(new EmitEditor(effect.efct.emits[selectedNode.Index], selectedNode));
                    break;
                case 2:
                    mainPanel.Controls.Add(new PtclEditor(effect.efct.emits[selectedNode.Parent.Index].ptcls[selectedNode.Index], selectedNode));
                    break;
            }
            //Set up panel data
            mainPanel.Controls[mainPanel.Controls.Count - 1].Dock = DockStyle.Fill;
            mainPanel.Controls[mainPanel.Controls.Count - 1].BringToFront();
        }

        public void loadAnimEditor(AquaEffect.AnimObject animObj, TreeNode node)
        {
            for (int ctrl = 0; ctrl < mainPanel.Controls.Count; ctrl++)
            {
                mainPanel.Controls[ctrl].Dispose();
            }
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(new AqeAnimEditor(animObj, selectedNode));
            mainPanel.Controls[mainPanel.Controls.Count - 1].Dock = DockStyle.Fill;
            mainPanel.Controls[mainPanel.Controls.Count - 1].BringToFront();
        }

    }
}
