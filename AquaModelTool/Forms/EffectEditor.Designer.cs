
namespace AquaModelTool
{
    partial class EffectEditor
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
            this.aqeTreeView = new System.Windows.Forms.TreeView();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // aqeTreeView
            // 
            this.aqeTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.aqeTreeView.Location = new System.Drawing.Point(0, 0);
            this.aqeTreeView.Name = "aqeTreeView";
            this.aqeTreeView.Size = new System.Drawing.Size(219, 590);
            this.aqeTreeView.TabIndex = 2;
            this.aqeTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.aqeTreeView_MouseDown);
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.Location = new System.Drawing.Point(225, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(542, 587);
            this.mainPanel.TabIndex = 4;
            // 
            // EffectEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.aqeTreeView);
            this.Name = "EffectEditor";
            this.Size = new System.Drawing.Size(770, 590);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView aqeTreeView;
        private System.Windows.Forms.Panel mainPanel;
    }
}
