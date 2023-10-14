
namespace AquaModelTool.Forms.ModelSubpanels.Material
{
    partial class BlendTypePresetPicker
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.blendTypeLabel = new System.Windows.Forms.Label();
            this.addRB = new System.Windows.Forms.RadioButton();
            this.hollowRB = new System.Windows.Forms.RadioButton();
            this.blendAlphaRB = new System.Windows.Forms.RadioButton();
            this.opaqueRB = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // blendTypeLabel
            // 
            this.blendTypeLabel.AutoSize = true;
            this.blendTypeLabel.Location = new System.Drawing.Point(12, 9);
            this.blendTypeLabel.Name = "blendTypeLabel";
            this.blendTypeLabel.Size = new System.Drawing.Size(61, 13);
            this.blendTypeLabel.TabIndex = 11;
            this.blendTypeLabel.Text = "Blend Type";
            // 
            // addRB
            // 
            this.addRB.AutoSize = true;
            this.addRB.Location = new System.Drawing.Point(198, 26);
            this.addRB.Name = "addRB";
            this.addRB.Size = new System.Drawing.Size(44, 17);
            this.addRB.TabIndex = 10;
            this.addRB.TabStop = true;
            this.addRB.Text = "Add";
            this.addRB.UseVisualStyleBackColor = true;
            // 
            // hollowRB
            // 
            this.hollowRB.AutoSize = true;
            this.hollowRB.Location = new System.Drawing.Point(145, 26);
            this.hollowRB.Name = "hollowRB";
            this.hollowRB.Size = new System.Drawing.Size(57, 17);
            this.hollowRB.TabIndex = 9;
            this.hollowRB.TabStop = true;
            this.hollowRB.Text = "Hollow";
            this.hollowRB.UseVisualStyleBackColor = true;
            // 
            // blendAlphaRB
            // 
            this.blendAlphaRB.AutoSize = true;
            this.blendAlphaRB.Checked = true;
            this.blendAlphaRB.Location = new System.Drawing.Point(71, 26);
            this.blendAlphaRB.Name = "blendAlphaRB";
            this.blendAlphaRB.Size = new System.Drawing.Size(78, 17);
            this.blendAlphaRB.TabIndex = 8;
            this.blendAlphaRB.TabStop = true;
            this.blendAlphaRB.Text = "Blendalpha";
            this.blendAlphaRB.UseVisualStyleBackColor = true;
            // 
            // opaqueRB
            // 
            this.opaqueRB.AutoSize = true;
            this.opaqueRB.Location = new System.Drawing.Point(12, 26);
            this.opaqueRB.Name = "opaqueRB";
            this.opaqueRB.Size = new System.Drawing.Size(63, 17);
            this.opaqueRB.TabIndex = 7;
            this.opaqueRB.TabStop = true;
            this.opaqueRB.Text = "Opaque";
            this.opaqueRB.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(46, 49);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 12;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(127, 49);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // BlendTypePresetPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 82);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.blendTypeLabel);
            this.Controls.Add(this.addRB);
            this.Controls.Add(this.hollowRB);
            this.Controls.Add(this.blendAlphaRB);
            this.Controls.Add(this.opaqueRB);
            this.Name = "BlendTypePresetPicker";
            this.Text = "Blend Type Preset Picker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label blendTypeLabel;
        public System.Windows.Forms.RadioButton addRB;
        public System.Windows.Forms.RadioButton hollowRB;
        public System.Windows.Forms.RadioButton blendAlphaRB;
        public System.Windows.Forms.RadioButton opaqueRB;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}