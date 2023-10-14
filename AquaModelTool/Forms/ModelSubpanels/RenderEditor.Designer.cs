
namespace AquaModelTool
{
    partial class RenderEditor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rendIDCB = new System.Windows.Forms.ComboBox();
            this.rendLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sourceAlphaUD = new System.Windows.Forms.NumericUpDown();
            this.sourceAlphaLabel = new System.Windows.Forms.Label();
            this.int0CUD = new System.Windows.Forms.NumericUpDown();
            this.int0CLabel = new System.Windows.Forms.Label();
            this.twoSidedUD = new System.Windows.Forms.NumericUpDown();
            this.twoSidedLabel = new System.Windows.Forms.Label();
            this.unk0UD = new System.Windows.Forms.NumericUpDown();
            this.unk0Label = new System.Windows.Forms.Label();
            this.unk5UD = new System.Windows.Forms.NumericUpDown();
            this.unk5Label = new System.Windows.Forms.Label();
            this.unk4UD = new System.Windows.Forms.NumericUpDown();
            this.unk4Label = new System.Windows.Forms.Label();
            this.unk3UD = new System.Windows.Forms.NumericUpDown();
            this.unk3Label = new System.Windows.Forms.Label();
            this.destinationAlphaUD = new System.Windows.Forms.NumericUpDown();
            this.destAlphaLabel = new System.Windows.Forms.Label();
            this.unk9UD = new System.Windows.Forms.NumericUpDown();
            this.unk9Label = new System.Windows.Forms.Label();
            this.unk8UD = new System.Windows.Forms.NumericUpDown();
            this.unk8Label = new System.Windows.Forms.Label();
            this.unk7UD = new System.Windows.Forms.NumericUpDown();
            this.unk7Label = new System.Windows.Forms.Label();
            this.unk6UD = new System.Windows.Forms.NumericUpDown();
            this.unk6Label = new System.Windows.Forms.Label();
            this.unk13UD = new System.Windows.Forms.NumericUpDown();
            this.unk13Label = new System.Windows.Forms.Label();
            this.unk12UD = new System.Windows.Forms.NumericUpDown();
            this.unk12Label = new System.Windows.Forms.Label();
            this.unk11UD = new System.Windows.Forms.NumericUpDown();
            this.unk11Label = new System.Windows.Forms.Label();
            this.alphaCutoffUD = new System.Windows.Forms.NumericUpDown();
            this.alphaCutoffLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceAlphaUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.int0CUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twoSidedUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk0UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk5UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk4UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk3UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destinationAlphaUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk9UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk8UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk7UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk6UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk13UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk12UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk11UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaCutoffUD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 230);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 0);
            this.panel1.TabIndex = 1;
            // 
            // rendIDCB
            // 
            this.rendIDCB.FormattingEnabled = true;
            this.rendIDCB.Location = new System.Drawing.Point(3, 16);
            this.rendIDCB.Name = "rendIDCB";
            this.rendIDCB.Size = new System.Drawing.Size(49, 21);
            this.rendIDCB.TabIndex = 5;
            this.rendIDCB.SelectedIndexChanged += new System.EventHandler(this.rendIDCB_SelectedIndexChanged);
            // 
            // rendLabel
            // 
            this.rendLabel.AutoSize = true;
            this.rendLabel.Location = new System.Drawing.Point(3, 0);
            this.rendLabel.Name = "rendLabel";
            this.rendLabel.Size = new System.Drawing.Size(57, 13);
            this.rendLabel.TabIndex = 4;
            this.rendLabel.Text = "REND List";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rendLabel);
            this.panel2.Controls.Add(this.rendIDCB);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(73, 51);
            this.panel2.TabIndex = 11;
            // 
            // sourceAlphaUD
            // 
            this.sourceAlphaUD.Location = new System.Drawing.Point(246, 75);
            this.sourceAlphaUD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.sourceAlphaUD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.sourceAlphaUD.Name = "sourceAlphaUD";
            this.sourceAlphaUD.Size = new System.Drawing.Size(76, 20);
            this.sourceAlphaUD.TabIndex = 31;
            this.sourceAlphaUD.ValueChanged += new System.EventHandler(this.sourceAlphaUD_ValueChanged);
            // 
            // sourceAlphaLabel
            // 
            this.sourceAlphaLabel.AutoSize = true;
            this.sourceAlphaLabel.Location = new System.Drawing.Point(243, 58);
            this.sourceAlphaLabel.Name = "sourceAlphaLabel";
            this.sourceAlphaLabel.Size = new System.Drawing.Size(71, 13);
            this.sourceAlphaLabel.TabIndex = 30;
            this.sourceAlphaLabel.Text = "Source Alpha";
            // 
            // int0CUD
            // 
            this.int0CUD.Location = new System.Drawing.Point(164, 75);
            this.int0CUD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.int0CUD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.int0CUD.Name = "int0CUD";
            this.int0CUD.Size = new System.Drawing.Size(76, 20);
            this.int0CUD.TabIndex = 29;
            this.int0CUD.ValueChanged += new System.EventHandler(this.int0CUD_ValueChanged);
            // 
            // int0CLabel
            // 
            this.int0CLabel.AutoSize = true;
            this.int0CLabel.Location = new System.Drawing.Point(161, 58);
            this.int0CLabel.Name = "int0CLabel";
            this.int0CLabel.Size = new System.Drawing.Size(37, 13);
            this.int0CLabel.TabIndex = 28;
            this.int0CLabel.Text = "int_0C";
            // 
            // twoSidedUD
            // 
            this.twoSidedUD.Location = new System.Drawing.Point(82, 75);
            this.twoSidedUD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.twoSidedUD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.twoSidedUD.Name = "twoSidedUD";
            this.twoSidedUD.Size = new System.Drawing.Size(76, 20);
            this.twoSidedUD.TabIndex = 27;
            this.twoSidedUD.ValueChanged += new System.EventHandler(this.twoSidedUD_ValueChanged);
            // 
            // twoSidedLabel
            // 
            this.twoSidedLabel.AutoSize = true;
            this.twoSidedLabel.Location = new System.Drawing.Point(79, 58);
            this.twoSidedLabel.Name = "twoSidedLabel";
            this.twoSidedLabel.Size = new System.Drawing.Size(58, 13);
            this.twoSidedLabel.TabIndex = 26;
            this.twoSidedLabel.Text = "Two-Sided";
            // 
            // unk0UD
            // 
            this.unk0UD.Location = new System.Drawing.Point(0, 75);
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
            this.unk0UD.TabIndex = 25;
            this.unk0UD.ValueChanged += new System.EventHandler(this.unk0UD_ValueChanged);
            // 
            // unk0Label
            // 
            this.unk0Label.AutoSize = true;
            this.unk0Label.Location = new System.Drawing.Point(-3, 58);
            this.unk0Label.Name = "unk0Label";
            this.unk0Label.Size = new System.Drawing.Size(33, 13);
            this.unk0Label.TabIndex = 24;
            this.unk0Label.Text = "Unk0";
            // 
            // unk5UD
            // 
            this.unk5UD.Location = new System.Drawing.Point(246, 115);
            this.unk5UD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.unk5UD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.unk5UD.Name = "unk5UD";
            this.unk5UD.Size = new System.Drawing.Size(76, 20);
            this.unk5UD.TabIndex = 39;
            this.unk5UD.ValueChanged += new System.EventHandler(this.unk5UD_ValueChanged);
            // 
            // unk5Label
            // 
            this.unk5Label.AutoSize = true;
            this.unk5Label.Location = new System.Drawing.Point(243, 98);
            this.unk5Label.Name = "unk5Label";
            this.unk5Label.Size = new System.Drawing.Size(33, 13);
            this.unk5Label.TabIndex = 38;
            this.unk5Label.Text = "Unk5";
            // 
            // unk4UD
            // 
            this.unk4UD.Location = new System.Drawing.Point(164, 115);
            this.unk4UD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.unk4UD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.unk4UD.Name = "unk4UD";
            this.unk4UD.Size = new System.Drawing.Size(76, 20);
            this.unk4UD.TabIndex = 37;
            this.unk4UD.ValueChanged += new System.EventHandler(this.unk4UD_ValueChanged);
            // 
            // unk4Label
            // 
            this.unk4Label.AutoSize = true;
            this.unk4Label.Location = new System.Drawing.Point(161, 98);
            this.unk4Label.Name = "unk4Label";
            this.unk4Label.Size = new System.Drawing.Size(33, 13);
            this.unk4Label.TabIndex = 36;
            this.unk4Label.Text = "Unk4";
            // 
            // unk3UD
            // 
            this.unk3UD.Location = new System.Drawing.Point(82, 115);
            this.unk3UD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.unk3UD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.unk3UD.Name = "unk3UD";
            this.unk3UD.Size = new System.Drawing.Size(76, 20);
            this.unk3UD.TabIndex = 35;
            this.unk3UD.ValueChanged += new System.EventHandler(this.unk3UD_ValueChanged);
            // 
            // unk3Label
            // 
            this.unk3Label.AutoSize = true;
            this.unk3Label.Location = new System.Drawing.Point(86, 98);
            this.unk3Label.Name = "unk3Label";
            this.unk3Label.Size = new System.Drawing.Size(33, 13);
            this.unk3Label.TabIndex = 34;
            this.unk3Label.Text = "Unk3";
            // 
            // destinationAlphaUD
            // 
            this.destinationAlphaUD.Location = new System.Drawing.Point(0, 115);
            this.destinationAlphaUD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.destinationAlphaUD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.destinationAlphaUD.Name = "destinationAlphaUD";
            this.destinationAlphaUD.Size = new System.Drawing.Size(76, 20);
            this.destinationAlphaUD.TabIndex = 33;
            this.destinationAlphaUD.ValueChanged += new System.EventHandler(this.destinationAlphaUD_ValueChanged);
            // 
            // destAlphaLabel
            // 
            this.destAlphaLabel.AutoSize = true;
            this.destAlphaLabel.Location = new System.Drawing.Point(-3, 98);
            this.destAlphaLabel.Name = "destAlphaLabel";
            this.destAlphaLabel.Size = new System.Drawing.Size(90, 13);
            this.destAlphaLabel.TabIndex = 32;
            this.destAlphaLabel.Text = "Destination Alpha";
            // 
            // unk9UD
            // 
            this.unk9UD.Location = new System.Drawing.Point(246, 155);
            this.unk9UD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.unk9UD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.unk9UD.Name = "unk9UD";
            this.unk9UD.Size = new System.Drawing.Size(76, 20);
            this.unk9UD.TabIndex = 47;
            this.unk9UD.ValueChanged += new System.EventHandler(this.unk9UD_ValueChanged);
            // 
            // unk9Label
            // 
            this.unk9Label.AutoSize = true;
            this.unk9Label.Location = new System.Drawing.Point(243, 138);
            this.unk9Label.Name = "unk9Label";
            this.unk9Label.Size = new System.Drawing.Size(33, 13);
            this.unk9Label.TabIndex = 46;
            this.unk9Label.Text = "Unk9";
            // 
            // unk8UD
            // 
            this.unk8UD.Location = new System.Drawing.Point(164, 155);
            this.unk8UD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.unk8UD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.unk8UD.Name = "unk8UD";
            this.unk8UD.Size = new System.Drawing.Size(76, 20);
            this.unk8UD.TabIndex = 45;
            this.unk8UD.ValueChanged += new System.EventHandler(this.unk8UD_ValueChanged);
            // 
            // unk8Label
            // 
            this.unk8Label.AutoSize = true;
            this.unk8Label.Location = new System.Drawing.Point(161, 138);
            this.unk8Label.Name = "unk8Label";
            this.unk8Label.Size = new System.Drawing.Size(33, 13);
            this.unk8Label.TabIndex = 44;
            this.unk8Label.Text = "Unk8";
            // 
            // unk7UD
            // 
            this.unk7UD.Location = new System.Drawing.Point(82, 155);
            this.unk7UD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.unk7UD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.unk7UD.Name = "unk7UD";
            this.unk7UD.Size = new System.Drawing.Size(76, 20);
            this.unk7UD.TabIndex = 43;
            this.unk7UD.ValueChanged += new System.EventHandler(this.unk7UD_ValueChanged);
            // 
            // unk7Label
            // 
            this.unk7Label.AutoSize = true;
            this.unk7Label.Location = new System.Drawing.Point(79, 138);
            this.unk7Label.Name = "unk7Label";
            this.unk7Label.Size = new System.Drawing.Size(33, 13);
            this.unk7Label.TabIndex = 42;
            this.unk7Label.Text = "Unk7";
            // 
            // unk6UD
            // 
            this.unk6UD.Location = new System.Drawing.Point(0, 155);
            this.unk6UD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.unk6UD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.unk6UD.Name = "unk6UD";
            this.unk6UD.Size = new System.Drawing.Size(76, 20);
            this.unk6UD.TabIndex = 41;
            this.unk6UD.ValueChanged += new System.EventHandler(this.unk6UD_ValueChanged);
            // 
            // unk6Label
            // 
            this.unk6Label.AutoSize = true;
            this.unk6Label.Location = new System.Drawing.Point(-3, 138);
            this.unk6Label.Name = "unk6Label";
            this.unk6Label.Size = new System.Drawing.Size(33, 13);
            this.unk6Label.TabIndex = 40;
            this.unk6Label.Text = "Unk6";
            // 
            // unk13UD
            // 
            this.unk13UD.Location = new System.Drawing.Point(249, 195);
            this.unk13UD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.unk13UD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.unk13UD.Name = "unk13UD";
            this.unk13UD.Size = new System.Drawing.Size(76, 20);
            this.unk13UD.TabIndex = 55;
            this.unk13UD.ValueChanged += new System.EventHandler(this.unk13UD_ValueChanged);
            // 
            // unk13Label
            // 
            this.unk13Label.AutoSize = true;
            this.unk13Label.Location = new System.Drawing.Point(246, 178);
            this.unk13Label.Name = "unk13Label";
            this.unk13Label.Size = new System.Drawing.Size(39, 13);
            this.unk13Label.TabIndex = 54;
            this.unk13Label.Text = "Unk13";
            // 
            // unk12UD
            // 
            this.unk12UD.Location = new System.Drawing.Point(167, 195);
            this.unk12UD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.unk12UD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.unk12UD.Name = "unk12UD";
            this.unk12UD.Size = new System.Drawing.Size(76, 20);
            this.unk12UD.TabIndex = 53;
            this.unk12UD.ValueChanged += new System.EventHandler(this.unk12UD_ValueChanged);
            // 
            // unk12Label
            // 
            this.unk12Label.AutoSize = true;
            this.unk12Label.Location = new System.Drawing.Point(164, 178);
            this.unk12Label.Name = "unk12Label";
            this.unk12Label.Size = new System.Drawing.Size(39, 13);
            this.unk12Label.TabIndex = 52;
            this.unk12Label.Text = "Unk12";
            // 
            // unk11UD
            // 
            this.unk11UD.Location = new System.Drawing.Point(85, 195);
            this.unk11UD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.unk11UD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.unk11UD.Name = "unk11UD";
            this.unk11UD.Size = new System.Drawing.Size(76, 20);
            this.unk11UD.TabIndex = 51;
            this.unk11UD.ValueChanged += new System.EventHandler(this.unk11UD_ValueChanged);
            // 
            // unk11Label
            // 
            this.unk11Label.AutoSize = true;
            this.unk11Label.Location = new System.Drawing.Point(82, 178);
            this.unk11Label.Name = "unk11Label";
            this.unk11Label.Size = new System.Drawing.Size(39, 13);
            this.unk11Label.TabIndex = 50;
            this.unk11Label.Text = "Unk11";
            // 
            // alphaCutoffUD
            // 
            this.alphaCutoffUD.Location = new System.Drawing.Point(3, 195);
            this.alphaCutoffUD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.alphaCutoffUD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.alphaCutoffUD.Name = "alphaCutoffUD";
            this.alphaCutoffUD.Size = new System.Drawing.Size(76, 20);
            this.alphaCutoffUD.TabIndex = 49;
            this.alphaCutoffUD.ValueChanged += new System.EventHandler(this.alphaCutoffUD_ValueChanged);
            // 
            // alphaCutoffLabel
            // 
            this.alphaCutoffLabel.AutoSize = true;
            this.alphaCutoffLabel.Location = new System.Drawing.Point(0, 178);
            this.alphaCutoffLabel.Name = "alphaCutoffLabel";
            this.alphaCutoffLabel.Size = new System.Drawing.Size(65, 13);
            this.alphaCutoffLabel.TabIndex = 48;
            this.alphaCutoffLabel.Text = "Alpha Cutoff";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Alpha Cutoff";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Unk11";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Unk12";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Unk13";
            // 
            // RenderEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.destAlphaLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.unk13UD);
            this.Controls.Add(this.unk13Label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.unk12UD);
            this.Controls.Add(this.unk12Label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.unk11UD);
            this.Controls.Add(this.unk11Label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.alphaCutoffUD);
            this.Controls.Add(this.alphaCutoffLabel);
            this.Controls.Add(this.unk9UD);
            this.Controls.Add(this.unk9Label);
            this.Controls.Add(this.unk8UD);
            this.Controls.Add(this.unk8Label);
            this.Controls.Add(this.unk7UD);
            this.Controls.Add(this.unk7Label);
            this.Controls.Add(this.unk6UD);
            this.Controls.Add(this.unk6Label);
            this.Controls.Add(this.unk5UD);
            this.Controls.Add(this.unk5Label);
            this.Controls.Add(this.unk4UD);
            this.Controls.Add(this.unk4Label);
            this.Controls.Add(this.unk3UD);
            this.Controls.Add(this.unk3Label);
            this.Controls.Add(this.destinationAlphaUD);
            this.Controls.Add(this.sourceAlphaUD);
            this.Controls.Add(this.sourceAlphaLabel);
            this.Controls.Add(this.int0CUD);
            this.Controls.Add(this.int0CLabel);
            this.Controls.Add(this.twoSidedUD);
            this.Controls.Add(this.twoSidedLabel);
            this.Controls.Add(this.unk0UD);
            this.Controls.Add(this.unk0Label);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RenderEditor";
            this.Size = new System.Drawing.Size(378, 230);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceAlphaUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.int0CUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twoSidedUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk0UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk5UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk4UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk3UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destinationAlphaUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk9UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk8UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk7UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk6UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk13UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk12UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unk11UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaCutoffUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox rendIDCB;
        private System.Windows.Forms.Label rendLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown sourceAlphaUD;
        private System.Windows.Forms.Label sourceAlphaLabel;
        private System.Windows.Forms.NumericUpDown int0CUD;
        private System.Windows.Forms.Label int0CLabel;
        private System.Windows.Forms.NumericUpDown twoSidedUD;
        private System.Windows.Forms.Label twoSidedLabel;
        private System.Windows.Forms.NumericUpDown unk0UD;
        private System.Windows.Forms.Label unk0Label;
        private System.Windows.Forms.NumericUpDown unk5UD;
        private System.Windows.Forms.Label unk5Label;
        private System.Windows.Forms.NumericUpDown unk4UD;
        private System.Windows.Forms.Label unk4Label;
        private System.Windows.Forms.NumericUpDown unk3UD;
        private System.Windows.Forms.Label unk3Label;
        private System.Windows.Forms.NumericUpDown destinationAlphaUD;
        private System.Windows.Forms.Label destAlphaLabel;
        private System.Windows.Forms.NumericUpDown unk9UD;
        private System.Windows.Forms.Label unk9Label;
        private System.Windows.Forms.NumericUpDown unk8UD;
        private System.Windows.Forms.Label unk8Label;
        private System.Windows.Forms.NumericUpDown unk7UD;
        private System.Windows.Forms.Label unk7Label;
        private System.Windows.Forms.NumericUpDown unk6UD;
        private System.Windows.Forms.Label unk6Label;
        private System.Windows.Forms.NumericUpDown unk13UD;
        private System.Windows.Forms.Label unk13Label;
        private System.Windows.Forms.NumericUpDown unk12UD;
        private System.Windows.Forms.Label unk12Label;
        private System.Windows.Forms.NumericUpDown unk11UD;
        private System.Windows.Forms.Label unk11Label;
        private System.Windows.Forms.NumericUpDown alphaCutoffUD;
        private System.Windows.Forms.Label alphaCutoffLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
