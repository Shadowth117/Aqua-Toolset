
namespace AquaModelTool.Forms.ModelSubpanels
{
    partial class TextureListEditor
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
            this.texListCB = new System.Windows.Forms.ComboBox();
            this.texListLabel = new System.Windows.Forms.Label();
            this.texListSelectPanel = new System.Windows.Forms.Panel();
            this.texSlotCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.addSlotButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.insertListButton = new System.Windows.Forms.Button();
            this.removeListButton = new System.Windows.Forms.Button();
            this.addListButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.texListSelectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // texListCB
            // 
            this.texListCB.FormattingEnabled = true;
            this.texListCB.Location = new System.Drawing.Point(4, 21);
            this.texListCB.Name = "texListCB";
            this.texListCB.Size = new System.Drawing.Size(49, 21);
            this.texListCB.TabIndex = 3;
            this.texListCB.SelectedIndexChanged += new System.EventHandler(this.texListCB_SelectedIndexChanged);
            // 
            // texListLabel
            // 
            this.texListLabel.AutoSize = true;
            this.texListLabel.Location = new System.Drawing.Point(3, 5);
            this.texListLabel.Name = "texListLabel";
            this.texListLabel.Size = new System.Drawing.Size(62, 13);
            this.texListLabel.TabIndex = 2;
            this.texListLabel.Text = "Texture List";
            // 
            // texListSelectPanel
            // 
            this.texListSelectPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.texListSelectPanel.Controls.Add(this.texListCB);
            this.texListSelectPanel.Controls.Add(this.texListLabel);
            this.texListSelectPanel.Location = new System.Drawing.Point(-1, -1);
            this.texListSelectPanel.Name = "texListSelectPanel";
            this.texListSelectPanel.Size = new System.Drawing.Size(171, 81);
            this.texListSelectPanel.TabIndex = 11;
            // 
            // texSlotCB
            // 
            this.texSlotCB.FormattingEnabled = true;
            this.texSlotCB.Location = new System.Drawing.Point(177, 21);
            this.texSlotCB.Name = "texSlotCB";
            this.texSlotCB.Size = new System.Drawing.Size(198, 21);
            this.texSlotCB.TabIndex = 12;
            this.texSlotCB.SelectedIndexChanged += new System.EventHandler(this.texSlotCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Texture Slot";
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(310, 48);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(60, 23);
            this.removeButton.TabIndex = 17;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addSlotButton
            // 
            this.addSlotButton.Location = new System.Drawing.Point(178, 48);
            this.addSlotButton.Name = "addSlotButton";
            this.addSlotButton.Size = new System.Drawing.Size(60, 23);
            this.addSlotButton.TabIndex = 18;
            this.addSlotButton.Text = "Add";
            this.addSlotButton.UseVisualStyleBackColor = true;
            this.addSlotButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-1, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 171);
            this.panel1.TabIndex = 19;
            // 
            // insertListButton
            // 
            this.insertListButton.Location = new System.Drawing.Point(82, 28);
            this.insertListButton.Name = "insertListButton";
            this.insertListButton.Size = new System.Drawing.Size(83, 23);
            this.insertListButton.TabIndex = 22;
            this.insertListButton.Text = "Insert List";
            this.insertListButton.UseVisualStyleBackColor = true;
            this.insertListButton.Click += new System.EventHandler(this.insertListButton_Click);
            // 
            // removeListButton
            // 
            this.removeListButton.Location = new System.Drawing.Point(82, 53);
            this.removeListButton.Name = "removeListButton";
            this.removeListButton.Size = new System.Drawing.Size(83, 23);
            this.removeListButton.TabIndex = 21;
            this.removeListButton.Text = "Remove List";
            this.removeListButton.UseVisualStyleBackColor = true;
            this.removeListButton.Click += new System.EventHandler(this.removeListButton_Click);
            // 
            // addListButton
            // 
            this.addListButton.Location = new System.Drawing.Point(82, 3);
            this.addListButton.Name = "addListButton";
            this.addListButton.Size = new System.Drawing.Size(83, 23);
            this.addListButton.TabIndex = 20;
            this.addListButton.Text = "Add List";
            this.addListButton.UseVisualStyleBackColor = true;
            this.addListButton.Click += new System.EventHandler(this.addListButton_Click);
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(244, 48);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(60, 23);
            this.insertButton.TabIndex = 23;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // TextureListEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.insertListButton);
            this.Controls.Add(this.removeListButton);
            this.Controls.Add(this.addListButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addSlotButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.texSlotCB);
            this.Controls.Add(this.texListSelectPanel);
            this.Name = "TextureListEditor";
            this.Size = new System.Drawing.Size(378, 253);
            this.texListSelectPanel.ResumeLayout(false);
            this.texListSelectPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox texListCB;
        private System.Windows.Forms.Label texListLabel;
        private System.Windows.Forms.Panel texListSelectPanel;
        private System.Windows.Forms.ComboBox texSlotCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addSlotButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button insertListButton;
        private System.Windows.Forms.Button removeListButton;
        private System.Windows.Forms.Button addListButton;
        private System.Windows.Forms.Button insertButton;
    }
}
