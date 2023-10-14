namespace AquaModelTool
{
    partial class ModelEditor
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
            this.modelIDCB = new System.Windows.Forms.ComboBox();
            this.modelIDLabel = new System.Windows.Forms.Label();
            this.allAlphaCheckBox = new System.Windows.Forms.CheckBox();
            this.modelPanel = new System.Windows.Forms.Panel();
            this.editorCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // modelIDCB
            // 
            this.modelIDCB.FormattingEnabled = true;
            this.modelIDCB.Location = new System.Drawing.Point(10, 15);
            this.modelIDCB.Name = "modelIDCB";
            this.modelIDCB.Size = new System.Drawing.Size(43, 21);
            this.modelIDCB.TabIndex = 1;
            this.modelIDCB.SelectedIndexChanged += new System.EventHandler(this.modelIDCB_SelectedIndexChanged);
            // 
            // modelIDLabel
            // 
            this.modelIDLabel.AutoSize = true;
            this.modelIDLabel.Location = new System.Drawing.Point(3, 0);
            this.modelIDLabel.Name = "modelIDLabel";
            this.modelIDLabel.Size = new System.Drawing.Size(50, 13);
            this.modelIDLabel.TabIndex = 2;
            this.modelIDLabel.Text = "Model ID";
            // 
            // allAlphaCheckBox
            // 
            this.allAlphaCheckBox.AutoSize = true;
            this.allAlphaCheckBox.Location = new System.Drawing.Point(59, 19);
            this.allAlphaCheckBox.Name = "allAlphaCheckBox";
            this.allAlphaCheckBox.Size = new System.Drawing.Size(172, 17);
            this.allAlphaCheckBox.TabIndex = 4;
            this.allAlphaCheckBox.Text = "Make All Materials Transparent";
            this.allAlphaCheckBox.UseVisualStyleBackColor = true;
            // 
            // modelPanel
            // 
            this.modelPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modelPanel.AutoSize = true;
            this.modelPanel.Location = new System.Drawing.Point(4, 43);
            this.modelPanel.Name = "modelPanel";
            this.modelPanel.Size = new System.Drawing.Size(378, 204);
            this.modelPanel.TabIndex = 7;
            // 
            // editorCB
            // 
            this.editorCB.FormattingEnabled = true;
            this.editorCB.Location = new System.Drawing.Point(237, 5);
            this.editorCB.Name = "editorCB";
            this.editorCB.Size = new System.Drawing.Size(121, 21);
            this.editorCB.TabIndex = 8;
            this.editorCB.SelectedIndexChanged += new System.EventHandler(this.editorCB_SelectedIndexChanged);
            // 
            // ModelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editorCB);
            this.Controls.Add(this.modelPanel);
            this.Controls.Add(this.allAlphaCheckBox);
            this.Controls.Add(this.modelIDLabel);
            this.Controls.Add(this.modelIDCB);
            this.Name = "ModelEditor";
            this.Size = new System.Drawing.Size(384, 250);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox modelIDCB;
        private System.Windows.Forms.Label modelIDLabel;
        private System.Windows.Forms.CheckBox allAlphaCheckBox;
        private System.Windows.Forms.Panel modelPanel;
        private System.Windows.Forms.ComboBox editorCB;
    }
}
