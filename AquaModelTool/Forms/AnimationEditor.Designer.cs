namespace AquaModelTool
{
    partial class AnimationEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.animTreeView = new System.Windows.Forms.TreeView();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.nodeMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transformGroupMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertTransformGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTransformGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyframeMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertKeyframeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateKeyframeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeKeyframeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animIDLabel = new System.Windows.Forms.Label();
            this.animIDCB = new System.Windows.Forms.ComboBox();
            this.fpsUD = new System.Windows.Forms.NumericUpDown();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.loopUD = new System.Windows.Forms.NumericUpDown();
            this.loopFrameLabel = new System.Windows.Forms.Label();
            this.nodeMenuStrip.SuspendLayout();
            this.transformGroupMenuStrip.SuspendLayout();
            this.keyframeMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpsUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loopUD)).BeginInit();
            this.SuspendLayout();
            // 
            // animTreeView
            // 
            this.animTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animTreeView.Location = new System.Drawing.Point(0, 46);
            this.animTreeView.Name = "animTreeView";
            this.animTreeView.Size = new System.Drawing.Size(154, 207);
            this.animTreeView.TabIndex = 0;
            this.animTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.animTreeView_MouseDown);
            // 
            // dataPanel
            // 
            this.dataPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dataPanel.Location = new System.Drawing.Point(160, 3);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(225, 253);
            this.dataPanel.TabIndex = 1;
            // 
            // nodeMenuStrip
            // 
            this.nodeMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertNodeToolStripMenuItem,
            this.duplicateNodeToolStripMenuItem,
            this.renameNodeToolStripMenuItem,
            this.removeNodeToolStripMenuItem});
            this.nodeMenuStrip.Name = "nodeMenuStrip";
            this.nodeMenuStrip.Size = new System.Drawing.Size(157, 92);
            // 
            // insertNodeToolStripMenuItem
            // 
            this.insertNodeToolStripMenuItem.Name = "insertNodeToolStripMenuItem";
            this.insertNodeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.insertNodeToolStripMenuItem.Text = "Insert Node";
            this.insertNodeToolStripMenuItem.Click += new System.EventHandler(animTreeView_Insert);
            // 
            // duplicateNodeToolStripMenuItem
            // 
            this.duplicateNodeToolStripMenuItem.Name = "duplicateNodeToolStripMenuItem";
            this.duplicateNodeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.duplicateNodeToolStripMenuItem.Text = "Duplicate Node";
            this.duplicateNodeToolStripMenuItem.Click += new System.EventHandler(animTreeView_Duplicate);
            // 
            // renameNodeToolStripMenuItem
            // 
            this.renameNodeToolStripMenuItem.Name = "renameNodeToolStripMenuItem";
            this.renameNodeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.renameNodeToolStripMenuItem.Text = "Rename Node";
            this.renameNodeToolStripMenuItem.Click += new System.EventHandler(animTreeView_Rename);
            // 
            // removeNodeToolStripMenuItem
            // 
            this.removeNodeToolStripMenuItem.Name = "removeNodeToolStripMenuItem";
            this.removeNodeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.removeNodeToolStripMenuItem.Text = "Remove Node";
            this.removeNodeToolStripMenuItem.Click += new System.EventHandler(animTreeView_Delete);
            // 
            // transformGroupMenuStrip
            // 
            this.transformGroupMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertTransformGroupToolStripMenuItem,
            this.removeTransformGroupToolStripMenuItem});
            this.transformGroupMenuStrip.Name = "transformGroupMenuStrip";
            this.transformGroupMenuStrip.Size = new System.Drawing.Size(210, 48);
            // 
            // insertTransformGroupToolStripMenuItem
            // 
            this.insertTransformGroupToolStripMenuItem.Name = "insertTransformGroupToolStripMenuItem";
            this.insertTransformGroupToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.insertTransformGroupToolStripMenuItem.Text = "Insert Transform Group";
            this.insertTransformGroupToolStripMenuItem.Click += new System.EventHandler(animTreeView_Insert);
            // 
            // removeTransformGroupToolStripMenuItem
            // 
            this.removeTransformGroupToolStripMenuItem.Name = "removeTransformGroupToolStripMenuItem";
            this.removeTransformGroupToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.removeTransformGroupToolStripMenuItem.Text = "Remove Transform Group";
            this.removeTransformGroupToolStripMenuItem.Click += new System.EventHandler(animTreeView_Delete);
            // 
            // keyframeMenuStrip
            // 
            this.keyframeMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertKeyframeToolStripMenuItem,
            this.duplicateKeyframeToolStripMenuItem,
            this.removeKeyframeToolStripMenuItem});
            this.keyframeMenuStrip.Name = "keyframeMenuStrip";
            this.keyframeMenuStrip.Size = new System.Drawing.Size(178, 70);
            // 
            // insertKeyframeToolStripMenuItem
            // 
            this.insertKeyframeToolStripMenuItem.Name = "insertKeyframeToolStripMenuItem";
            this.insertKeyframeToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.insertKeyframeToolStripMenuItem.Text = "Insert Keyframe";
            this.insertKeyframeToolStripMenuItem.Click += new System.EventHandler(animTreeView_Insert);
            // 
            // duplicateKeyframeToolStripMenuItem
            // 
            this.duplicateKeyframeToolStripMenuItem.Name = "duplicateKeyframeToolStripMenuItem";
            this.duplicateKeyframeToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.duplicateKeyframeToolStripMenuItem.Text = "Duplicate Keyframe";
            this.duplicateKeyframeToolStripMenuItem.Click += new System.EventHandler(animTreeView_Duplicate);
            // 
            // removeKeyframeToolStripMenuItem
            // 
            this.removeKeyframeToolStripMenuItem.Name = "removeKeyframeToolStripMenuItem";
            this.removeKeyframeToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.removeKeyframeToolStripMenuItem.Text = "Remove Keyframe";
            this.removeKeyframeToolStripMenuItem.Click += new System.EventHandler(animTreeView_Delete);
            // 
            // animIDLabel
            // 
            this.animIDLabel.AutoSize = true;
            this.animIDLabel.Location = new System.Drawing.Point(3, 3);
            this.animIDLabel.Name = "animIDLabel";
            this.animIDLabel.Size = new System.Drawing.Size(53, 13);
            this.animIDLabel.TabIndex = 4;
            this.animIDLabel.Text = "Motion ID";
            // 
            // animIDCB
            // 
            this.animIDCB.FormattingEnabled = true;
            this.animIDCB.Location = new System.Drawing.Point(13, 19);
            this.animIDCB.Name = "animIDCB";
            this.animIDCB.Size = new System.Drawing.Size(43, 21);
            this.animIDCB.TabIndex = 3;
            this.animIDCB.SelectedIndexChanged += new System.EventHandler(this.animIDCB_SelectedIndexChanged);
            // 
            // fpsUD
            // 
            this.fpsUD.Location = new System.Drawing.Point(118, 19);
            this.fpsUD.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.fpsUD.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.fpsUD.Name = "fpsUD";
            this.fpsUD.Size = new System.Drawing.Size(42, 20);
            this.fpsUD.TabIndex = 7;
            this.fpsUD.ValueChanged += new System.EventHandler(this.fpsUD_ValueChanged);
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Location = new System.Drawing.Point(127, 3);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(27, 13);
            this.fpsLabel.TabIndex = 6;
            this.fpsLabel.Text = "FPS";
            // 
            // loopUD
            // 
            this.loopUD.Location = new System.Drawing.Point(62, 19);
            this.loopUD.Name = "loopUD";
            this.loopUD.Size = new System.Drawing.Size(50, 20);
            this.loopUD.TabIndex = 5;
            this.loopUD.ValueChanged += new System.EventHandler(this.loopUD_ValueChanged);
            // 
            // loopFrameLabel
            // 
            this.loopFrameLabel.AutoSize = true;
            this.loopFrameLabel.Location = new System.Drawing.Point(62, 3);
            this.loopFrameLabel.Name = "loopFrameLabel";
            this.loopFrameLabel.Size = new System.Drawing.Size(63, 13);
            this.loopFrameLabel.TabIndex = 8;
            this.loopFrameLabel.Text = "Loop Frame";
            // 
            // AnimationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.loopFrameLabel);
            this.Controls.Add(this.loopUD);
            this.Controls.Add(this.fpsLabel);
            this.Controls.Add(this.fpsUD);
            this.Controls.Add(this.animIDLabel);
            this.Controls.Add(this.animIDCB);
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.animTreeView);
            this.Name = "AnimationEditor";
            this.Size = new System.Drawing.Size(384, 256);
            this.nodeMenuStrip.ResumeLayout(false);
            this.transformGroupMenuStrip.ResumeLayout(false);
            this.keyframeMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpsUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loopUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView animTreeView;
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.ContextMenuStrip nodeMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem insertNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeNodeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip transformGroupMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem insertTransformGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTransformGroupToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip keyframeMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem insertKeyframeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateKeyframeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeKeyframeToolStripMenuItem;
        private System.Windows.Forms.Label animIDLabel;
        private System.Windows.Forms.ComboBox animIDCB;
        private System.Windows.Forms.NumericUpDown fpsUD;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.NumericUpDown loopUD;
        private System.Windows.Forms.Label loopFrameLabel;
    }
}
