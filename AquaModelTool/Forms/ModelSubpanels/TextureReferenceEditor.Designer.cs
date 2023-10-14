
namespace AquaModelTool.Forms.ModelSubpanels
{
    partial class TextureReferenceEditor
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
            this.texNameLabel = new System.Windows.Forms.Label();
            this.tagUD = new System.Windows.Forms.NumericUpDown();
            this.texNameTB = new System.Windows.Forms.TextBox();
            this.tagLabel = new System.Windows.Forms.Label();
            this.usageTypeLabel = new System.Windows.Forms.Label();
            this.orderUD = new System.Windows.Forms.NumericUpDown();
            this.uvSetUD = new System.Windows.Forms.NumericUpDown();
            this.uvSetLabel = new System.Windows.Forms.Label();
            this.unkVec3XLabel = new System.Windows.Forms.Label();
            this.unkVec3XUD = new System.Windows.Forms.NumericUpDown();
            this.unkVec3YLabel = new System.Windows.Forms.Label();
            this.unkVec3ZLabel = new System.Windows.Forms.Label();
            this.unkVec3YUD = new System.Windows.Forms.NumericUpDown();
            this.unkVec3ZUD = new System.Windows.Forms.NumericUpDown();
            this.unkFloat3UD = new System.Windows.Forms.NumericUpDown();
            this.unkFloat3Label = new System.Windows.Forms.Label();
            this.unkFloat2Label = new System.Windows.Forms.Label();
            this.unkFloat2UD = new System.Windows.Forms.NumericUpDown();
            this.unkFloat1UD = new System.Windows.Forms.NumericUpDown();
            this.unkFloat1Label = new System.Windows.Forms.Label();
            this.unkFloat0Label = new System.Windows.Forms.Label();
            this.unkFloat0UD = new System.Windows.Forms.NumericUpDown();
            this.unkFloat4Label = new System.Windows.Forms.Label();
            this.unkFloat4UD = new System.Windows.Forms.NumericUpDown();
            this.unkInt5UD = new System.Windows.Forms.NumericUpDown();
            this.unkInt5Label = new System.Windows.Forms.Label();
            this.unkInt4UD = new System.Windows.Forms.NumericUpDown();
            this.unkInt4Label = new System.Windows.Forms.Label();
            this.unkInt3Label = new System.Windows.Forms.Label();
            this.unkInt3UD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.tagUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvSetUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkVec3XUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkVec3YUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkVec3ZUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkFloat3UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkFloat2UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkFloat1UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkFloat0UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkFloat4UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkInt5UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkInt4UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkInt3UD)).BeginInit();
            this.SuspendLayout();
            // 
            // texNameLabel
            // 
            this.texNameLabel.AutoSize = true;
            this.texNameLabel.Location = new System.Drawing.Point(4, 4);
            this.texNameLabel.Name = "texNameLabel";
            this.texNameLabel.Size = new System.Drawing.Size(74, 13);
            this.texNameLabel.TabIndex = 0;
            this.texNameLabel.Text = "Texture Name";
            // 
            // tagUD
            // 
            this.tagUD.Location = new System.Drawing.Point(7, 37);
            this.tagUD.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.tagUD.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.tagUD.Name = "tagUD";
            this.tagUD.Size = new System.Drawing.Size(57, 20);
            this.tagUD.TabIndex = 1;
            this.tagUD.ValueChanged += new System.EventHandler(this.tagUD_ValueChanged);
            // 
            // texNameTB
            // 
            this.texNameTB.Location = new System.Drawing.Point(85, 1);
            this.texNameTB.MaxLength = 32;
            this.texNameTB.Name = "texNameTB";
            this.texNameTB.Size = new System.Drawing.Size(281, 20);
            this.texNameTB.TabIndex = 2;
            this.texNameTB.TextChanged += new System.EventHandler(this.texNameTB_TextChanged);
            // 
            // tagLabel
            // 
            this.tagLabel.AutoSize = true;
            this.tagLabel.Location = new System.Drawing.Point(4, 21);
            this.tagLabel.Name = "tagLabel";
            this.tagLabel.Size = new System.Drawing.Size(26, 13);
            this.tagLabel.TabIndex = 3;
            this.tagLabel.Text = "Tag";
            // 
            // usageTypeLabel
            // 
            this.usageTypeLabel.AutoSize = true;
            this.usageTypeLabel.Location = new System.Drawing.Point(72, 21);
            this.usageTypeLabel.Name = "usageTypeLabel";
            this.usageTypeLabel.Size = new System.Drawing.Size(96, 13);
            this.usageTypeLabel.TabIndex = 4;
            this.usageTypeLabel.Text = "Usage Order/Type";
            // 
            // orderUD
            // 
            this.orderUD.Location = new System.Drawing.Point(75, 37);
            this.orderUD.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.orderUD.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.orderUD.Name = "orderUD";
            this.orderUD.Size = new System.Drawing.Size(57, 20);
            this.orderUD.TabIndex = 5;
            this.orderUD.ValueChanged += new System.EventHandler(this.orderUD_ValueChanged);
            // 
            // uvSetUD
            // 
            this.uvSetUD.Location = new System.Drawing.Point(177, 37);
            this.uvSetUD.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.uvSetUD.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.uvSetUD.Name = "uvSetUD";
            this.uvSetUD.Size = new System.Drawing.Size(57, 20);
            this.uvSetUD.TabIndex = 7;
            this.uvSetUD.ValueChanged += new System.EventHandler(this.uvSetUD_ValueChanged);
            // 
            // uvSetLabel
            // 
            this.uvSetLabel.AutoSize = true;
            this.uvSetLabel.Location = new System.Drawing.Point(174, 21);
            this.uvSetLabel.Name = "uvSetLabel";
            this.uvSetLabel.Size = new System.Drawing.Size(41, 13);
            this.uvSetLabel.TabIndex = 6;
            this.uvSetLabel.Text = "UV Set";
            // 
            // unkVec3XLabel
            // 
            this.unkVec3XLabel.AutoSize = true;
            this.unkVec3XLabel.Location = new System.Drawing.Point(4, 63);
            this.unkVec3XLabel.Name = "unkVec3XLabel";
            this.unkVec3XLabel.Size = new System.Drawing.Size(62, 13);
            this.unkVec3XLabel.TabIndex = 9;
            this.unkVec3XLabel.Text = "UnkVec3.X";
            // 
            // unkVec3XUD
            // 
            this.unkVec3XUD.DecimalPlaces = 6;
            this.unkVec3XUD.Location = new System.Drawing.Point(7, 79);
            this.unkVec3XUD.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.unkVec3XUD.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.unkVec3XUD.Name = "unkVec3XUD";
            this.unkVec3XUD.Size = new System.Drawing.Size(57, 20);
            this.unkVec3XUD.TabIndex = 8;
            this.unkVec3XUD.ValueChanged += new System.EventHandler(this.unkVec3XUD_ValueChanged);
            // 
            // unkVec3YLabel
            // 
            this.unkVec3YLabel.AutoSize = true;
            this.unkVec3YLabel.Location = new System.Drawing.Point(70, 63);
            this.unkVec3YLabel.Name = "unkVec3YLabel";
            this.unkVec3YLabel.Size = new System.Drawing.Size(62, 13);
            this.unkVec3YLabel.TabIndex = 11;
            this.unkVec3YLabel.Text = "UnkVec3.Y";
            // 
            // unkVec3ZLabel
            // 
            this.unkVec3ZLabel.AutoSize = true;
            this.unkVec3ZLabel.Location = new System.Drawing.Point(138, 63);
            this.unkVec3ZLabel.Name = "unkVec3ZLabel";
            this.unkVec3ZLabel.Size = new System.Drawing.Size(62, 13);
            this.unkVec3ZLabel.TabIndex = 13;
            this.unkVec3ZLabel.Text = "UnkVec3.Z";
            // 
            // unkVec3YUD
            // 
            this.unkVec3YUD.DecimalPlaces = 6;
            this.unkVec3YUD.Location = new System.Drawing.Point(73, 79);
            this.unkVec3YUD.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.unkVec3YUD.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.unkVec3YUD.Name = "unkVec3YUD";
            this.unkVec3YUD.Size = new System.Drawing.Size(57, 20);
            this.unkVec3YUD.TabIndex = 14;
            this.unkVec3YUD.ValueChanged += new System.EventHandler(this.unkVec3YUD_ValueChanged);
            // 
            // unkVec3ZUD
            // 
            this.unkVec3ZUD.DecimalPlaces = 6;
            this.unkVec3ZUD.Location = new System.Drawing.Point(141, 79);
            this.unkVec3ZUD.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.unkVec3ZUD.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.unkVec3ZUD.Name = "unkVec3ZUD";
            this.unkVec3ZUD.Size = new System.Drawing.Size(57, 20);
            this.unkVec3ZUD.TabIndex = 15;
            this.unkVec3ZUD.ValueChanged += new System.EventHandler(this.unkVec3ZUD_ValueChanged);
            // 
            // unkFloat3UD
            // 
            this.unkFloat3UD.DecimalPlaces = 6;
            this.unkFloat3UD.Location = new System.Drawing.Point(306, 79);
            this.unkFloat3UD.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.unkFloat3UD.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.unkFloat3UD.Name = "unkFloat3UD";
            this.unkFloat3UD.Size = new System.Drawing.Size(57, 20);
            this.unkFloat3UD.TabIndex = 19;
            this.unkFloat3UD.ValueChanged += new System.EventHandler(this.unkFloat3UD_ValueChanged);
            // 
            // unkFloat3Label
            // 
            this.unkFloat3Label.AutoSize = true;
            this.unkFloat3Label.Location = new System.Drawing.Point(303, 63);
            this.unkFloat3Label.Name = "unkFloat3Label";
            this.unkFloat3Label.Size = new System.Drawing.Size(62, 13);
            this.unkFloat3Label.TabIndex = 18;
            this.unkFloat3Label.Text = "Unk Float 3";
            // 
            // unkFloat2Label
            // 
            this.unkFloat2Label.AutoSize = true;
            this.unkFloat2Label.Location = new System.Drawing.Point(237, 63);
            this.unkFloat2Label.Name = "unkFloat2Label";
            this.unkFloat2Label.Size = new System.Drawing.Size(62, 13);
            this.unkFloat2Label.TabIndex = 17;
            this.unkFloat2Label.Text = "Unk Float 2";
            // 
            // unkFloat2UD
            // 
            this.unkFloat2UD.DecimalPlaces = 6;
            this.unkFloat2UD.Location = new System.Drawing.Point(240, 79);
            this.unkFloat2UD.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.unkFloat2UD.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.unkFloat2UD.Name = "unkFloat2UD";
            this.unkFloat2UD.Size = new System.Drawing.Size(57, 20);
            this.unkFloat2UD.TabIndex = 16;
            this.unkFloat2UD.ValueChanged += new System.EventHandler(this.unkFloat2UD_ValueChanged);
            // 
            // unkFloat1UD
            // 
            this.unkFloat1UD.DecimalPlaces = 6;
            this.unkFloat1UD.Location = new System.Drawing.Point(304, 37);
            this.unkFloat1UD.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.unkFloat1UD.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.unkFloat1UD.Name = "unkFloat1UD";
            this.unkFloat1UD.Size = new System.Drawing.Size(57, 20);
            this.unkFloat1UD.TabIndex = 23;
            this.unkFloat1UD.ValueChanged += new System.EventHandler(this.unkFloat1UD_ValueChanged);
            // 
            // unkFloat1Label
            // 
            this.unkFloat1Label.AutoSize = true;
            this.unkFloat1Label.Location = new System.Drawing.Point(301, 21);
            this.unkFloat1Label.Name = "unkFloat1Label";
            this.unkFloat1Label.Size = new System.Drawing.Size(62, 13);
            this.unkFloat1Label.TabIndex = 22;
            this.unkFloat1Label.Text = "Unk Float 1";
            // 
            // unkFloat0Label
            // 
            this.unkFloat0Label.AutoSize = true;
            this.unkFloat0Label.Location = new System.Drawing.Point(235, 21);
            this.unkFloat0Label.Name = "unkFloat0Label";
            this.unkFloat0Label.Size = new System.Drawing.Size(62, 13);
            this.unkFloat0Label.TabIndex = 21;
            this.unkFloat0Label.Text = "Unk Float 0";
            // 
            // unkFloat0UD
            // 
            this.unkFloat0UD.DecimalPlaces = 6;
            this.unkFloat0UD.Location = new System.Drawing.Point(238, 37);
            this.unkFloat0UD.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.unkFloat0UD.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.unkFloat0UD.Name = "unkFloat0UD";
            this.unkFloat0UD.Size = new System.Drawing.Size(57, 20);
            this.unkFloat0UD.TabIndex = 20;
            this.unkFloat0UD.ValueChanged += new System.EventHandler(this.unkFloat0UD_ValueChanged);
            // 
            // unkFloat4Label
            // 
            this.unkFloat4Label.AutoSize = true;
            this.unkFloat4Label.Location = new System.Drawing.Point(239, 106);
            this.unkFloat4Label.Name = "unkFloat4Label";
            this.unkFloat4Label.Size = new System.Drawing.Size(62, 13);
            this.unkFloat4Label.TabIndex = 25;
            this.unkFloat4Label.Text = "Unk Float 4";
            // 
            // unkFloat4UD
            // 
            this.unkFloat4UD.DecimalPlaces = 6;
            this.unkFloat4UD.Location = new System.Drawing.Point(242, 122);
            this.unkFloat4UD.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.unkFloat4UD.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.unkFloat4UD.Name = "unkFloat4UD";
            this.unkFloat4UD.Size = new System.Drawing.Size(57, 20);
            this.unkFloat4UD.TabIndex = 24;
            this.unkFloat4UD.ValueChanged += new System.EventHandler(this.unkFloat4UD_ValueChanged);
            // 
            // unkInt5UD
            // 
            this.unkInt5UD.Location = new System.Drawing.Point(141, 122);
            this.unkInt5UD.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.unkInt5UD.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.unkInt5UD.Name = "unkInt5UD";
            this.unkInt5UD.Size = new System.Drawing.Size(57, 20);
            this.unkInt5UD.TabIndex = 31;
            this.unkInt5UD.ValueChanged += new System.EventHandler(this.unkInt5UD_ValueChanged);
            // 
            // unkInt5Label
            // 
            this.unkInt5Label.AutoSize = true;
            this.unkInt5Label.Location = new System.Drawing.Point(138, 106);
            this.unkInt5Label.Name = "unkInt5Label";
            this.unkInt5Label.Size = new System.Drawing.Size(51, 13);
            this.unkInt5Label.TabIndex = 30;
            this.unkInt5Label.Text = "Unk Int 5";
            // 
            // unkInt4UD
            // 
            this.unkInt4UD.Location = new System.Drawing.Point(73, 122);
            this.unkInt4UD.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.unkInt4UD.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.unkInt4UD.Name = "unkInt4UD";
            this.unkInt4UD.Size = new System.Drawing.Size(57, 20);
            this.unkInt4UD.TabIndex = 29;
            this.unkInt4UD.ValueChanged += new System.EventHandler(this.unkInt4UD_ValueChanged);
            // 
            // unkInt4Label
            // 
            this.unkInt4Label.AutoSize = true;
            this.unkInt4Label.Location = new System.Drawing.Point(70, 106);
            this.unkInt4Label.Name = "unkInt4Label";
            this.unkInt4Label.Size = new System.Drawing.Size(51, 13);
            this.unkInt4Label.TabIndex = 28;
            this.unkInt4Label.Text = "Unk Int 4";
            // 
            // unkInt3Label
            // 
            this.unkInt3Label.AutoSize = true;
            this.unkInt3Label.Location = new System.Drawing.Point(2, 106);
            this.unkInt3Label.Name = "unkInt3Label";
            this.unkInt3Label.Size = new System.Drawing.Size(51, 13);
            this.unkInt3Label.TabIndex = 27;
            this.unkInt3Label.Text = "Unk Int 3";
            // 
            // unkInt3UD
            // 
            this.unkInt3UD.Location = new System.Drawing.Point(5, 122);
            this.unkInt3UD.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.unkInt3UD.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.unkInt3UD.Name = "unkInt3UD";
            this.unkInt3UD.Size = new System.Drawing.Size(57, 20);
            this.unkInt3UD.TabIndex = 26;
            this.unkInt3UD.ValueChanged += new System.EventHandler(this.unkInt3UD_ValueChanged);
            // 
            // TextureReferenceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.unkInt5UD);
            this.Controls.Add(this.unkInt5Label);
            this.Controls.Add(this.unkInt4UD);
            this.Controls.Add(this.unkInt4Label);
            this.Controls.Add(this.unkInt3Label);
            this.Controls.Add(this.unkInt3UD);
            this.Controls.Add(this.unkFloat4Label);
            this.Controls.Add(this.unkFloat4UD);
            this.Controls.Add(this.unkFloat1UD);
            this.Controls.Add(this.unkFloat1Label);
            this.Controls.Add(this.unkFloat0Label);
            this.Controls.Add(this.unkFloat0UD);
            this.Controls.Add(this.unkFloat3UD);
            this.Controls.Add(this.unkFloat3Label);
            this.Controls.Add(this.unkFloat2Label);
            this.Controls.Add(this.unkFloat2UD);
            this.Controls.Add(this.unkVec3ZUD);
            this.Controls.Add(this.unkVec3YUD);
            this.Controls.Add(this.unkVec3ZLabel);
            this.Controls.Add(this.unkVec3YLabel);
            this.Controls.Add(this.unkVec3XLabel);
            this.Controls.Add(this.unkVec3XUD);
            this.Controls.Add(this.uvSetUD);
            this.Controls.Add(this.uvSetLabel);
            this.Controls.Add(this.orderUD);
            this.Controls.Add(this.usageTypeLabel);
            this.Controls.Add(this.tagLabel);
            this.Controls.Add(this.texNameTB);
            this.Controls.Add(this.tagUD);
            this.Controls.Add(this.texNameLabel);
            this.Name = "TextureReferenceEditor";
            this.Size = new System.Drawing.Size(379, 171);
            ((System.ComponentModel.ISupportInitialize)(this.tagUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvSetUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkVec3XUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkVec3YUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkVec3ZUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkFloat3UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkFloat2UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkFloat1UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkFloat0UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkFloat4UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkInt5UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkInt4UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkInt3UD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label texNameLabel;
        private System.Windows.Forms.NumericUpDown tagUD;
        private System.Windows.Forms.TextBox texNameTB;
        private System.Windows.Forms.Label tagLabel;
        private System.Windows.Forms.Label usageTypeLabel;
        private System.Windows.Forms.NumericUpDown orderUD;
        private System.Windows.Forms.NumericUpDown uvSetUD;
        private System.Windows.Forms.Label uvSetLabel;
        private System.Windows.Forms.Label unkVec3XLabel;
        private System.Windows.Forms.NumericUpDown unkVec3XUD;
        private System.Windows.Forms.Label unkVec3YLabel;
        private System.Windows.Forms.Label unkVec3ZLabel;
        private System.Windows.Forms.NumericUpDown unkVec3YUD;
        private System.Windows.Forms.NumericUpDown unkVec3ZUD;
        private System.Windows.Forms.NumericUpDown unkFloat3UD;
        private System.Windows.Forms.Label unkFloat3Label;
        private System.Windows.Forms.Label unkFloat2Label;
        private System.Windows.Forms.NumericUpDown unkFloat2UD;
        private System.Windows.Forms.NumericUpDown unkFloat1UD;
        private System.Windows.Forms.Label unkFloat1Label;
        private System.Windows.Forms.Label unkFloat0Label;
        private System.Windows.Forms.NumericUpDown unkFloat0UD;
        private System.Windows.Forms.Label unkFloat4Label;
        private System.Windows.Forms.NumericUpDown unkFloat4UD;
        private System.Windows.Forms.NumericUpDown unkInt5UD;
        private System.Windows.Forms.Label unkInt5Label;
        private System.Windows.Forms.NumericUpDown unkInt4UD;
        private System.Windows.Forms.Label unkInt4Label;
        private System.Windows.Forms.Label unkInt3Label;
        private System.Windows.Forms.NumericUpDown unkInt3UD;
    }
}
