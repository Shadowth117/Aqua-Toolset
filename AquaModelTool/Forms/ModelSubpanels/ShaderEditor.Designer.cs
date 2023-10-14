
namespace AquaModelTool
{
    partial class ShaderEditor
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
            this.shadIDCB = new System.Windows.Forms.ComboBox();
            this.shadLabel = new System.Windows.Forms.Label();
            this.pixelShaderTB = new System.Windows.Forms.TextBox();
            this.pixelShaderLabel = new System.Windows.Forms.Label();
            this.vShaderTB = new System.Windows.Forms.TextBox();
            this.vShaderLabel = new System.Windows.Forms.Label();
            this.unk0Label = new System.Windows.Forms.Label();
            this.unk0UD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.shaderExtraLB = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.valueZUD = new System.Windows.Forms.NumericUpDown();
            this.valueZLabel = new System.Windows.Forms.Label();
            this.valueXUD = new System.Windows.Forms.NumericUpDown();
            this.valueXLabel = new System.Windows.Forms.Label();
            this.valueYUD = new System.Windows.Forms.NumericUpDown();
            this.valueYLabel = new System.Windows.Forms.Label();
            this.valueWLabel = new System.Windows.Forms.Label();
            this.valueWUD = new System.Windows.Forms.NumericUpDown();
            this.flags0Label = new System.Windows.Forms.Label();
            this.flags0UD = new System.Windows.Forms.NumericUpDown();
            this.flags1Label = new System.Windows.Forms.Label();
            this.flags2Label = new System.Windows.Forms.Label();
            this.flags1UD = new System.Windows.Forms.NumericUpDown();
            this.flags2UD = new System.Windows.Forms.NumericUpDown();
            this.diffuseRGBButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.unk0UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueZUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueXUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueYUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueWUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flags0UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flags1UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flags2UD)).BeginInit();
            this.SuspendLayout();
            // 
            // shadIDCB
            // 
            this.shadIDCB.FormattingEnabled = true;
            this.shadIDCB.Location = new System.Drawing.Point(4, 21);
            this.shadIDCB.Name = "shadIDCB";
            this.shadIDCB.Size = new System.Drawing.Size(49, 21);
            this.shadIDCB.TabIndex = 3;
            this.shadIDCB.SelectedIndexChanged += new System.EventHandler(this.shadIDCB_SelectedIndexChanged);
            // 
            // shadLabel
            // 
            this.shadLabel.AutoSize = true;
            this.shadLabel.Location = new System.Drawing.Point(4, 4);
            this.shadLabel.Name = "shadLabel";
            this.shadLabel.Size = new System.Drawing.Size(46, 13);
            this.shadLabel.TabIndex = 2;
            this.shadLabel.Text = "Shaders";
            // 
            // pixelShaderTB
            // 
            this.pixelShaderTB.Location = new System.Drawing.Point(60, 21);
            this.pixelShaderTB.Name = "pixelShaderTB";
            this.pixelShaderTB.Size = new System.Drawing.Size(92, 20);
            this.pixelShaderTB.TabIndex = 4;
            this.pixelShaderTB.TextChanged += new System.EventHandler(this.pixelShaderTB_TextChanged);
            // 
            // pixelShaderLabel
            // 
            this.pixelShaderLabel.AutoSize = true;
            this.pixelShaderLabel.Location = new System.Drawing.Point(60, 4);
            this.pixelShaderLabel.Name = "pixelShaderLabel";
            this.pixelShaderLabel.Size = new System.Drawing.Size(66, 13);
            this.pixelShaderLabel.TabIndex = 5;
            this.pixelShaderLabel.Text = "Pixel Shader";
            // 
            // vShaderTB
            // 
            this.vShaderTB.Location = new System.Drawing.Point(158, 21);
            this.vShaderTB.Name = "vShaderTB";
            this.vShaderTB.Size = new System.Drawing.Size(92, 20);
            this.vShaderTB.TabIndex = 4;
            this.vShaderTB.TextChanged += new System.EventHandler(this.vShaderTB_TextChanged);
            // 
            // vShaderLabel
            // 
            this.vShaderLabel.AutoSize = true;
            this.vShaderLabel.Location = new System.Drawing.Point(158, 4);
            this.vShaderLabel.Name = "vShaderLabel";
            this.vShaderLabel.Size = new System.Drawing.Size(74, 13);
            this.vShaderLabel.TabIndex = 5;
            this.vShaderLabel.Text = "Vertex Shader";
            // 
            // unk0Label
            // 
            this.unk0Label.AutoSize = true;
            this.unk0Label.Location = new System.Drawing.Point(256, 4);
            this.unk0Label.Name = "unk0Label";
            this.unk0Label.Size = new System.Drawing.Size(31, 13);
            this.unk0Label.TabIndex = 6;
            this.unk0Label.Text = "unk0";
            // 
            // unk0UD
            // 
            this.unk0UD.Location = new System.Drawing.Point(259, 21);
            this.unk0UD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.unk0UD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.unk0UD.Name = "unk0UD";
            this.unk0UD.Size = new System.Drawing.Size(76, 20);
            this.unk0UD.TabIndex = 7;
            this.unk0UD.ValueChanged += new System.EventHandler(this.unk0UD_ValueChanged);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(0, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 2);
            this.label1.TabIndex = 8;
            // 
            // shaderExtraLB
            // 
            this.shaderExtraLB.FormattingEnabled = true;
            this.shaderExtraLB.Location = new System.Drawing.Point(6, 69);
            this.shaderExtraLB.Name = "shaderExtraLB";
            this.shaderExtraLB.Size = new System.Drawing.Size(119, 134);
            this.shaderExtraLB.TabIndex = 9;
            this.shaderExtraLB.SelectedIndexChanged += new System.EventHandler(this.shaderExtraLB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Extra Paramaters (NGS Only)";
            // 
            // valueZUD
            // 
            this.valueZUD.DecimalPlaces = 6;
            this.valueZUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            458752});
            this.valueZUD.Location = new System.Drawing.Point(291, 132);
            this.valueZUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.valueZUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.valueZUD.Name = "valueZUD";
            this.valueZUD.Size = new System.Drawing.Size(66, 20);
            this.valueZUD.TabIndex = 38;
            this.valueZUD.ValueChanged += new System.EventHandler(this.valueZUD_ValueChanged);
            // 
            // valueZLabel
            // 
            this.valueZLabel.AutoSize = true;
            this.valueZLabel.Location = new System.Drawing.Point(291, 115);
            this.valueZLabel.Name = "valueZLabel";
            this.valueZLabel.Size = new System.Drawing.Size(44, 13);
            this.valueZLabel.TabIndex = 35;
            this.valueZLabel.Text = "Value Z";
            // 
            // valueXUD
            // 
            this.valueXUD.DecimalPlaces = 6;
            this.valueXUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            458752});
            this.valueXUD.Location = new System.Drawing.Point(135, 132);
            this.valueXUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.valueXUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.valueXUD.Name = "valueXUD";
            this.valueXUD.Size = new System.Drawing.Size(72, 20);
            this.valueXUD.TabIndex = 36;
            this.valueXUD.ValueChanged += new System.EventHandler(this.valueXUD_ValueChanged);
            // 
            // valueXLabel
            // 
            this.valueXLabel.AutoSize = true;
            this.valueXLabel.Location = new System.Drawing.Point(135, 115);
            this.valueXLabel.Name = "valueXLabel";
            this.valueXLabel.Size = new System.Drawing.Size(44, 13);
            this.valueXLabel.TabIndex = 34;
            this.valueXLabel.Text = "Value X";
            // 
            // valueYUD
            // 
            this.valueYUD.DecimalPlaces = 6;
            this.valueYUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            458752});
            this.valueYUD.Location = new System.Drawing.Point(213, 132);
            this.valueYUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.valueYUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.valueYUD.Name = "valueYUD";
            this.valueYUD.Size = new System.Drawing.Size(72, 20);
            this.valueYUD.TabIndex = 37;
            this.valueYUD.ValueChanged += new System.EventHandler(this.valueYUD_ValueChanged);
            // 
            // valueYLabel
            // 
            this.valueYLabel.AutoSize = true;
            this.valueYLabel.Location = new System.Drawing.Point(213, 115);
            this.valueYLabel.Name = "valueYLabel";
            this.valueYLabel.Size = new System.Drawing.Size(44, 13);
            this.valueYLabel.TabIndex = 33;
            this.valueYLabel.Text = "Value Y";
            // 
            // valueWLabel
            // 
            this.valueWLabel.AutoSize = true;
            this.valueWLabel.Location = new System.Drawing.Point(135, 154);
            this.valueWLabel.Name = "valueWLabel";
            this.valueWLabel.Size = new System.Drawing.Size(48, 13);
            this.valueWLabel.TabIndex = 34;
            this.valueWLabel.Text = "Value W";
            // 
            // valueWUD
            // 
            this.valueWUD.DecimalPlaces = 6;
            this.valueWUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            458752});
            this.valueWUD.Location = new System.Drawing.Point(135, 171);
            this.valueWUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.valueWUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.valueWUD.Name = "valueWUD";
            this.valueWUD.Size = new System.Drawing.Size(72, 20);
            this.valueWUD.TabIndex = 36;
            this.valueWUD.ValueChanged += new System.EventHandler(this.valueWUD_ValueChanged);
            // 
            // flags0Label
            // 
            this.flags0Label.AutoSize = true;
            this.flags0Label.Location = new System.Drawing.Point(132, 66);
            this.flags0Label.Name = "flags0Label";
            this.flags0Label.Size = new System.Drawing.Size(41, 13);
            this.flags0Label.TabIndex = 6;
            this.flags0Label.Text = "Flags 0";
            // 
            // flags0UD
            // 
            this.flags0UD.Location = new System.Drawing.Point(135, 83);
            this.flags0UD.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.flags0UD.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.flags0UD.Name = "flags0UD";
            this.flags0UD.Size = new System.Drawing.Size(72, 20);
            this.flags0UD.TabIndex = 7;
            this.flags0UD.ValueChanged += new System.EventHandler(this.flags0UD_ValueChanged);
            // 
            // flags1Label
            // 
            this.flags1Label.AutoSize = true;
            this.flags1Label.Location = new System.Drawing.Point(213, 66);
            this.flags1Label.Name = "flags1Label";
            this.flags1Label.Size = new System.Drawing.Size(41, 13);
            this.flags1Label.TabIndex = 6;
            this.flags1Label.Text = "Flags 1";
            // 
            // flags2Label
            // 
            this.flags2Label.AutoSize = true;
            this.flags2Label.Location = new System.Drawing.Point(291, 66);
            this.flags2Label.Name = "flags2Label";
            this.flags2Label.Size = new System.Drawing.Size(41, 13);
            this.flags2Label.TabIndex = 6;
            this.flags2Label.Text = "Flags 2";
            // 
            // flags1UD
            // 
            this.flags1UD.Location = new System.Drawing.Point(213, 82);
            this.flags1UD.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.flags1UD.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.flags1UD.Name = "flags1UD";
            this.flags1UD.Size = new System.Drawing.Size(72, 20);
            this.flags1UD.TabIndex = 7;
            this.flags1UD.ValueChanged += new System.EventHandler(this.flags1UD_ValueChanged);
            // 
            // flags2UD
            // 
            this.flags2UD.Location = new System.Drawing.Point(291, 82);
            this.flags2UD.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.flags2UD.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.flags2UD.Name = "flags2UD";
            this.flags2UD.Size = new System.Drawing.Size(72, 20);
            this.flags2UD.TabIndex = 7;
            this.flags2UD.ValueChanged += new System.EventHandler(this.flags2UD_ValueChanged);
            // 
            // diffuseRGBButton
            // 
            this.diffuseRGBButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.diffuseRGBButton.Location = new System.Drawing.Point(219, 168);
            this.diffuseRGBButton.Name = "diffuseRGBButton";
            this.diffuseRGBButton.Size = new System.Drawing.Size(144, 23);
            this.diffuseRGBButton.TabIndex = 39;
            this.diffuseRGBButton.Text = "Edit XYZ as Color";
            this.diffuseRGBButton.UseVisualStyleBackColor = false;
            this.diffuseRGBButton.Click += new System.EventHandler(this.diffuseRGBButton_Click);
            // 
            // ShaderEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.diffuseRGBButton);
            this.Controls.Add(this.valueZUD);
            this.Controls.Add(this.valueZLabel);
            this.Controls.Add(this.valueWUD);
            this.Controls.Add(this.valueWLabel);
            this.Controls.Add(this.valueXUD);
            this.Controls.Add(this.valueXLabel);
            this.Controls.Add(this.valueYUD);
            this.Controls.Add(this.valueYLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shaderExtraLB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flags2Label);
            this.Controls.Add(this.flags1Label);
            this.Controls.Add(this.flags2UD);
            this.Controls.Add(this.flags1UD);
            this.Controls.Add(this.flags0UD);
            this.Controls.Add(this.flags0Label);
            this.Controls.Add(this.unk0UD);
            this.Controls.Add(this.unk0Label);
            this.Controls.Add(this.vShaderLabel);
            this.Controls.Add(this.pixelShaderLabel);
            this.Controls.Add(this.vShaderTB);
            this.Controls.Add(this.pixelShaderTB);
            this.Controls.Add(this.shadIDCB);
            this.Controls.Add(this.shadLabel);
            this.Name = "ShaderEditor";
            this.Size = new System.Drawing.Size(378, 204);
            ((System.ComponentModel.ISupportInitialize)(this.unk0UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueZUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueXUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueYUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueWUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flags0UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flags1UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flags2UD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox shadIDCB;
        private System.Windows.Forms.Label shadLabel;
        private System.Windows.Forms.TextBox pixelShaderTB;
        private System.Windows.Forms.Label pixelShaderLabel;
        private System.Windows.Forms.TextBox vShaderTB;
        private System.Windows.Forms.Label vShaderLabel;
        private System.Windows.Forms.Label unk0Label;
        private System.Windows.Forms.NumericUpDown unk0UD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox shaderExtraLB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown valueZUD;
        private System.Windows.Forms.Label valueZLabel;
        private System.Windows.Forms.NumericUpDown valueXUD;
        private System.Windows.Forms.Label valueXLabel;
        private System.Windows.Forms.NumericUpDown valueYUD;
        private System.Windows.Forms.Label valueYLabel;
        private System.Windows.Forms.Label valueWLabel;
        private System.Windows.Forms.NumericUpDown valueWUD;
        private System.Windows.Forms.Label flags0Label;
        private System.Windows.Forms.NumericUpDown flags0UD;
        private System.Windows.Forms.Label flags1Label;
        private System.Windows.Forms.Label flags2Label;
        private System.Windows.Forms.NumericUpDown flags1UD;
        private System.Windows.Forms.NumericUpDown flags2UD;
        private System.Windows.Forms.Button diffuseRGBButton;
    }
}
