namespace AquaModelTool
{
    partial class EfctEditor
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
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.startFrameUD = new System.Windows.Forms.NumericUpDown();
            this.posYUD = new System.Windows.Forms.NumericUpDown();
            this.posYLabel = new System.Windows.Forms.Label();
            this.posXUD = new System.Windows.Forms.NumericUpDown();
            this.posXLabel = new System.Windows.Forms.Label();
            this.posZUD = new System.Windows.Forms.NumericUpDown();
            this.posZLabel = new System.Windows.Forms.Label();
            this.diffuseUD = new System.Windows.Forms.NumericUpDown();
            this.diffuseRGBALabel = new System.Windows.Forms.Label();
            this.diffuseRGBButton = new System.Windows.Forms.Button();
            this.soundNameBox = new System.Windows.Forms.TextBox();
            this.soundNameLabel = new System.Windows.Forms.Label();
            this.endFrameUD = new System.Windows.Forms.NumericUpDown();
            this.endFrameLabel = new System.Windows.Forms.Label();
            this.rotYLabel = new System.Windows.Forms.Label();
            this.rotYUD = new System.Windows.Forms.NumericUpDown();
            this.rotXLabel = new System.Windows.Forms.Label();
            this.rotXUD = new System.Windows.Forms.NumericUpDown();
            this.rotZLabel = new System.Windows.Forms.Label();
            this.rotZUD = new System.Windows.Forms.NumericUpDown();
            this.scaleYLabel = new System.Windows.Forms.Label();
            this.scaleYUD = new System.Windows.Forms.NumericUpDown();
            this.scaleXLabel = new System.Windows.Forms.Label();
            this.scaleXUD = new System.Windows.Forms.NumericUpDown();
            this.scaleZLabel = new System.Windows.Forms.Label();
            this.scaleZUD = new System.Windows.Forms.NumericUpDown();
            this.int48Label = new System.Windows.Forms.Label();
            this.int48UD = new System.Windows.Forms.NumericUpDown();
            this.float30label = new System.Windows.Forms.Label();
            this.float30UD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.int50UD = new System.Windows.Forms.NumericUpDown();
            this.boolInt54UD = new System.Windows.Forms.NumericUpDown();
            this.boolInt54Label = new System.Windows.Forms.Label();
            this.boolInt58Label = new System.Windows.Forms.Label();
            this.boolInt58UD = new System.Windows.Forms.NumericUpDown();
            this.boolInt5CLabel = new System.Windows.Forms.Label();
            this.boolInt5CUD = new System.Windows.Forms.NumericUpDown();
            this.float60Label = new System.Windows.Forms.Label();
            this.float60UD = new System.Windows.Forms.NumericUpDown();
            this.float64Label = new System.Windows.Forms.Label();
            this.float64UD = new System.Windows.Forms.NumericUpDown();
            this.animButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.startFrameUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posYUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posXUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posZUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diffuseUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endFrameUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotYUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotXUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotZUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleYUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleXUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleZUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.int48UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.float30UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.int50UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boolInt54UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boolInt58UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boolInt5CUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.float60UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.float64UD)).BeginInit();
            this.SuspendLayout();
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(0, 0);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(61, 13);
            this.startTimeLabel.TabIndex = 0;
            this.startTimeLabel.Text = "Start Frame";
            // 
            // startFrameUD
            // 
            this.startFrameUD.DecimalPlaces = 6;
            this.startFrameUD.Location = new System.Drawing.Point(3, 17);
            this.startFrameUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.startFrameUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.startFrameUD.Name = "startFrameUD";
            this.startFrameUD.Size = new System.Drawing.Size(69, 20);
            this.startFrameUD.TabIndex = 28;
            this.startFrameUD.ValueChanged += new System.EventHandler(this.startFrameUDValue_Changed);
            // 
            // posYUD
            // 
            this.posYUD.DecimalPlaces = 6;
            this.posYUD.Location = new System.Drawing.Point(81, 67);
            this.posYUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.posYUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.posYUD.Name = "posYUD";
            this.posYUD.Size = new System.Drawing.Size(72, 20);
            this.posYUD.TabIndex = 31;
            this.posYUD.ValueChanged += new System.EventHandler(this.posYUDValue_Changed);
            // 
            // posYLabel
            // 
            this.posYLabel.AutoSize = true;
            this.posYLabel.Location = new System.Drawing.Point(81, 50);
            this.posYLabel.Name = "posYLabel";
            this.posYLabel.Size = new System.Drawing.Size(69, 13);
            this.posYLabel.TabIndex = 24;
            this.posYLabel.Text = "Translation Y";
            // 
            // posXUD
            // 
            this.posXUD.DecimalPlaces = 6;
            this.posXUD.Location = new System.Drawing.Point(3, 67);
            this.posXUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.posXUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.posXUD.Name = "posXUD";
            this.posXUD.Size = new System.Drawing.Size(72, 20);
            this.posXUD.TabIndex = 30;
            this.posXUD.ValueChanged += new System.EventHandler(this.posXUDValue_Changed);
            // 
            // posXLabel
            // 
            this.posXLabel.AutoSize = true;
            this.posXLabel.Location = new System.Drawing.Point(3, 50);
            this.posXLabel.Name = "posXLabel";
            this.posXLabel.Size = new System.Drawing.Size(69, 13);
            this.posXLabel.TabIndex = 26;
            this.posXLabel.Text = "Translation X";
            // 
            // posZUD
            // 
            this.posZUD.DecimalPlaces = 6;
            this.posZUD.Location = new System.Drawing.Point(159, 67);
            this.posZUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.posZUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.posZUD.Name = "posZUD";
            this.posZUD.Size = new System.Drawing.Size(66, 20);
            this.posZUD.TabIndex = 32;
            this.posZUD.ValueChanged += new System.EventHandler(this.posZUDValue_Changed);
            // 
            // posZLabel
            // 
            this.posZLabel.AutoSize = true;
            this.posZLabel.Location = new System.Drawing.Point(159, 50);
            this.posZLabel.Name = "posZLabel";
            this.posZLabel.Size = new System.Drawing.Size(69, 13);
            this.posZLabel.TabIndex = 28;
            this.posZLabel.Text = "Translation Z";
            // 
            // diffuseUD
            // 
            this.diffuseUD.Location = new System.Drawing.Point(305, 67);
            this.diffuseUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.diffuseUD.Name = "diffuseUD";
            this.diffuseUD.Size = new System.Drawing.Size(45, 20);
            this.diffuseUD.TabIndex = 37;
            this.diffuseUD.ValueChanged += new System.EventHandler(this.diffuseUD_ValueChanged);
            // 
            // diffuseRGBALabel
            // 
            this.diffuseRGBALabel.AutoSize = true;
            this.diffuseRGBALabel.Location = new System.Drawing.Point(265, 50);
            this.diffuseRGBALabel.Name = "diffuseRGBALabel";
            this.diffuseRGBALabel.Size = new System.Drawing.Size(57, 13);
            this.diffuseRGBALabel.TabIndex = 36;
            this.diffuseRGBALabel.Text = "Root Color";
            // 
            // diffuseRGBButton
            // 
            this.diffuseRGBButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.diffuseRGBButton.Location = new System.Drawing.Point(267, 65);
            this.diffuseRGBButton.Name = "diffuseRGBButton";
            this.diffuseRGBButton.Size = new System.Drawing.Size(31, 23);
            this.diffuseRGBButton.TabIndex = 35;
            this.diffuseRGBButton.UseVisualStyleBackColor = false;
            this.diffuseRGBButton.Click += new System.EventHandler(this.diffuseRGBButton_Click);
            // 
            // soundNameBox
            // 
            this.soundNameBox.Location = new System.Drawing.Point(3, 230);
            this.soundNameBox.MaxLength = 48;
            this.soundNameBox.Name = "soundNameBox";
            this.soundNameBox.Size = new System.Drawing.Size(216, 20);
            this.soundNameBox.TabIndex = 38;
            this.soundNameBox.TextChanged += new System.EventHandler(this.soundNameBox_TextChanged);
            // 
            // soundNameLabel
            // 
            this.soundNameLabel.AutoSize = true;
            this.soundNameLabel.Location = new System.Drawing.Point(6, 211);
            this.soundNameLabel.Name = "soundNameLabel";
            this.soundNameLabel.Size = new System.Drawing.Size(69, 13);
            this.soundNameLabel.TabIndex = 39;
            this.soundNameLabel.Text = "Sound Name";
            // 
            // endFrameUD
            // 
            this.endFrameUD.DecimalPlaces = 6;
            this.endFrameUD.Location = new System.Drawing.Point(86, 17);
            this.endFrameUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.endFrameUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.endFrameUD.Name = "endFrameUD";
            this.endFrameUD.Size = new System.Drawing.Size(67, 20);
            this.endFrameUD.TabIndex = 41;
            this.endFrameUD.ValueChanged += new System.EventHandler(this.endFrameUD_ValueChanged);
            // 
            // endFrameLabel
            // 
            this.endFrameLabel.AutoSize = true;
            this.endFrameLabel.Location = new System.Drawing.Point(83, 0);
            this.endFrameLabel.Name = "endFrameLabel";
            this.endFrameLabel.Size = new System.Drawing.Size(58, 13);
            this.endFrameLabel.TabIndex = 40;
            this.endFrameLabel.Text = "End Frame";
            // 
            // rotYLabel
            // 
            this.rotYLabel.AutoSize = true;
            this.rotYLabel.Location = new System.Drawing.Point(81, 99);
            this.rotYLabel.Name = "rotYLabel";
            this.rotYLabel.Size = new System.Drawing.Size(57, 13);
            this.rotYLabel.TabIndex = 24;
            this.rotYLabel.Text = "Rotation Y";
            // 
            // rotYUD
            // 
            this.rotYUD.DecimalPlaces = 6;
            this.rotYUD.Location = new System.Drawing.Point(81, 116);
            this.rotYUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.rotYUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.rotYUD.Name = "rotYUD";
            this.rotYUD.Size = new System.Drawing.Size(72, 20);
            this.rotYUD.TabIndex = 31;
            this.rotYUD.ValueChanged += new System.EventHandler(this.rotYUD_ValueChanged);
            // 
            // rotXLabel
            // 
            this.rotXLabel.AutoSize = true;
            this.rotXLabel.Location = new System.Drawing.Point(3, 99);
            this.rotXLabel.Name = "rotXLabel";
            this.rotXLabel.Size = new System.Drawing.Size(57, 13);
            this.rotXLabel.TabIndex = 26;
            this.rotXLabel.Text = "Rotation X";
            // 
            // rotXUD
            // 
            this.rotXUD.DecimalPlaces = 6;
            this.rotXUD.Location = new System.Drawing.Point(3, 116);
            this.rotXUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.rotXUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.rotXUD.Name = "rotXUD";
            this.rotXUD.Size = new System.Drawing.Size(72, 20);
            this.rotXUD.TabIndex = 30;
            this.rotXUD.ValueChanged += new System.EventHandler(this.rotXUD_ValueChanged);
            // 
            // rotZLabel
            // 
            this.rotZLabel.AutoSize = true;
            this.rotZLabel.Location = new System.Drawing.Point(159, 99);
            this.rotZLabel.Name = "rotZLabel";
            this.rotZLabel.Size = new System.Drawing.Size(57, 13);
            this.rotZLabel.TabIndex = 28;
            this.rotZLabel.Text = "Rotation Z";
            // 
            // rotZUD
            // 
            this.rotZUD.DecimalPlaces = 6;
            this.rotZUD.Location = new System.Drawing.Point(159, 116);
            this.rotZUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.rotZUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.rotZUD.Name = "rotZUD";
            this.rotZUD.Size = new System.Drawing.Size(66, 20);
            this.rotZUD.TabIndex = 32;
            this.rotZUD.ValueChanged += new System.EventHandler(this.rotZUD_ValueChanged);
            // 
            // scaleYLabel
            // 
            this.scaleYLabel.AutoSize = true;
            this.scaleYLabel.Location = new System.Drawing.Point(81, 154);
            this.scaleYLabel.Name = "scaleYLabel";
            this.scaleYLabel.Size = new System.Drawing.Size(44, 13);
            this.scaleYLabel.TabIndex = 24;
            this.scaleYLabel.Text = "Scale Y";
            // 
            // scaleYUD
            // 
            this.scaleYUD.DecimalPlaces = 6;
            this.scaleYUD.Location = new System.Drawing.Point(81, 171);
            this.scaleYUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.scaleYUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.scaleYUD.Name = "scaleYUD";
            this.scaleYUD.Size = new System.Drawing.Size(72, 20);
            this.scaleYUD.TabIndex = 31;
            this.scaleYUD.ValueChanged += new System.EventHandler(this.scaleYUD_ValueChanged);
            // 
            // scaleXLabel
            // 
            this.scaleXLabel.AutoSize = true;
            this.scaleXLabel.Location = new System.Drawing.Point(3, 154);
            this.scaleXLabel.Name = "scaleXLabel";
            this.scaleXLabel.Size = new System.Drawing.Size(44, 13);
            this.scaleXLabel.TabIndex = 26;
            this.scaleXLabel.Text = "Scale X";
            // 
            // scaleXUD
            // 
            this.scaleXUD.DecimalPlaces = 6;
            this.scaleXUD.Location = new System.Drawing.Point(3, 171);
            this.scaleXUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.scaleXUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.scaleXUD.Name = "scaleXUD";
            this.scaleXUD.Size = new System.Drawing.Size(72, 20);
            this.scaleXUD.TabIndex = 30;
            this.scaleXUD.ValueChanged += new System.EventHandler(this.scaleXUD_ValueChanged);
            // 
            // scaleZLabel
            // 
            this.scaleZLabel.AutoSize = true;
            this.scaleZLabel.Location = new System.Drawing.Point(159, 154);
            this.scaleZLabel.Name = "scaleZLabel";
            this.scaleZLabel.Size = new System.Drawing.Size(44, 13);
            this.scaleZLabel.TabIndex = 28;
            this.scaleZLabel.Text = "Scale Z";
            // 
            // scaleZUD
            // 
            this.scaleZUD.DecimalPlaces = 6;
            this.scaleZUD.Location = new System.Drawing.Point(159, 171);
            this.scaleZUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.scaleZUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.scaleZUD.Name = "scaleZUD";
            this.scaleZUD.Size = new System.Drawing.Size(66, 20);
            this.scaleZUD.TabIndex = 32;
            this.scaleZUD.ValueChanged += new System.EventHandler(this.scaleZUD_ValueChanged);
            // 
            // int48Label
            // 
            this.int48Label.AutoSize = true;
            this.int48Label.Location = new System.Drawing.Point(80, 263);
            this.int48Label.Name = "int48Label";
            this.int48Label.Size = new System.Drawing.Size(36, 13);
            this.int48Label.TabIndex = 40;
            this.int48Label.Text = "int_48";
            // 
            // int48UD
            // 
            this.int48UD.Location = new System.Drawing.Point(83, 280);
            this.int48UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.int48UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.int48UD.Name = "int48UD";
            this.int48UD.Size = new System.Drawing.Size(67, 20);
            this.int48UD.TabIndex = 41;
            this.int48UD.ValueChanged += new System.EventHandler(this.int48UD_ValueChanged);
            // 
            // float30label
            // 
            this.float30label.AutoSize = true;
            this.float30label.Location = new System.Drawing.Point(3, 263);
            this.float30label.Name = "float30label";
            this.float30label.Size = new System.Drawing.Size(45, 13);
            this.float30label.TabIndex = 40;
            this.float30label.Text = "float_30";
            // 
            // float30UD
            // 
            this.float30UD.DecimalPlaces = 6;
            this.float30UD.Location = new System.Drawing.Point(6, 280);
            this.float30UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.float30UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.float30UD.Name = "float30UD";
            this.float30UD.Size = new System.Drawing.Size(67, 20);
            this.float30UD.TabIndex = 41;
            this.float30UD.ValueChanged += new System.EventHandler(this.float30UD_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "int_50";
            // 
            // int50UD
            // 
            this.int50UD.Location = new System.Drawing.Point(159, 280);
            this.int50UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.int50UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.int50UD.Name = "int50UD";
            this.int50UD.Size = new System.Drawing.Size(67, 20);
            this.int50UD.TabIndex = 41;
            this.int50UD.ValueChanged += new System.EventHandler(this.int50UD_ValueChanged);
            // 
            // boolInt54UD
            // 
            this.boolInt54UD.Location = new System.Drawing.Point(232, 280);
            this.boolInt54UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.boolInt54UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.boolInt54UD.Name = "boolInt54UD";
            this.boolInt54UD.Size = new System.Drawing.Size(67, 20);
            this.boolInt54UD.TabIndex = 43;
            this.boolInt54UD.ValueChanged += new System.EventHandler(this.boolInt54UD_ValueChanged);
            // 
            // boolInt54Label
            // 
            this.boolInt54Label.AutoSize = true;
            this.boolInt54Label.Location = new System.Drawing.Point(229, 263);
            this.boolInt54Label.Name = "boolInt54Label";
            this.boolInt54Label.Size = new System.Drawing.Size(57, 13);
            this.boolInt54Label.TabIndex = 42;
            this.boolInt54Label.Text = "boolInt_54";
            // 
            // boolInt58Label
            // 
            this.boolInt58Label.AutoSize = true;
            this.boolInt58Label.Location = new System.Drawing.Point(302, 263);
            this.boolInt58Label.Name = "boolInt58Label";
            this.boolInt58Label.Size = new System.Drawing.Size(57, 13);
            this.boolInt58Label.TabIndex = 42;
            this.boolInt58Label.Text = "boolInt_58";
            // 
            // boolInt58UD
            // 
            this.boolInt58UD.Location = new System.Drawing.Point(305, 280);
            this.boolInt58UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.boolInt58UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.boolInt58UD.Name = "boolInt58UD";
            this.boolInt58UD.Size = new System.Drawing.Size(67, 20);
            this.boolInt58UD.TabIndex = 43;
            this.boolInt58UD.ValueChanged += new System.EventHandler(this.boolInt58UD_ValueChanged);
            // 
            // boolInt5CLabel
            // 
            this.boolInt5CLabel.AutoSize = true;
            this.boolInt5CLabel.Location = new System.Drawing.Point(229, 305);
            this.boolInt5CLabel.Name = "boolInt5CLabel";
            this.boolInt5CLabel.Size = new System.Drawing.Size(58, 13);
            this.boolInt5CLabel.TabIndex = 42;
            this.boolInt5CLabel.Text = "boolInt_5C";
            // 
            // boolInt5CUD
            // 
            this.boolInt5CUD.Location = new System.Drawing.Point(232, 322);
            this.boolInt5CUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.boolInt5CUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.boolInt5CUD.Name = "boolInt5CUD";
            this.boolInt5CUD.Size = new System.Drawing.Size(67, 20);
            this.boolInt5CUD.TabIndex = 43;
            this.boolInt5CUD.ValueChanged += new System.EventHandler(this.boolInt5CUD_ValueChanged);
            // 
            // float60Label
            // 
            this.float60Label.AutoSize = true;
            this.float60Label.Location = new System.Drawing.Point(2, 305);
            this.float60Label.Name = "float60Label";
            this.float60Label.Size = new System.Drawing.Size(45, 13);
            this.float60Label.TabIndex = 40;
            this.float60Label.Text = "float_60";
            // 
            // float60UD
            // 
            this.float60UD.DecimalPlaces = 6;
            this.float60UD.Location = new System.Drawing.Point(5, 322);
            this.float60UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.float60UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.float60UD.Name = "float60UD";
            this.float60UD.Size = new System.Drawing.Size(67, 20);
            this.float60UD.TabIndex = 41;
            this.float60UD.ValueChanged += new System.EventHandler(this.float60UD_ValueChanged);
            // 
            // float64Label
            // 
            this.float64Label.AutoSize = true;
            this.float64Label.Location = new System.Drawing.Point(78, 305);
            this.float64Label.Name = "float64Label";
            this.float64Label.Size = new System.Drawing.Size(45, 13);
            this.float64Label.TabIndex = 40;
            this.float64Label.Text = "float_64";
            // 
            // float64UD
            // 
            this.float64UD.DecimalPlaces = 6;
            this.float64UD.Location = new System.Drawing.Point(81, 322);
            this.float64UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.float64UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.float64UD.Name = "float64UD";
            this.float64UD.Size = new System.Drawing.Size(67, 20);
            this.float64UD.TabIndex = 41;
            this.float64UD.ValueChanged += new System.EventHandler(this.float64UD_ValueChanged);
            // 
            // animButton
            // 
            this.animButton.Location = new System.Drawing.Point(275, 9);
            this.animButton.Name = "animButton";
            this.animButton.Size = new System.Drawing.Size(118, 23);
            this.animButton.TabIndex = 51;
            this.animButton.Text = "Animations";
            this.animButton.UseVisualStyleBackColor = true;
            this.animButton.Click += new System.EventHandler(this.animButton_Click);
            // 
            // EfctEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.animButton);
            this.Controls.Add(this.boolInt5CUD);
            this.Controls.Add(this.boolInt5CLabel);
            this.Controls.Add(this.boolInt58UD);
            this.Controls.Add(this.boolInt58Label);
            this.Controls.Add(this.boolInt54UD);
            this.Controls.Add(this.boolInt54Label);
            this.Controls.Add(this.int50UD);
            this.Controls.Add(this.int48UD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.int48Label);
            this.Controls.Add(this.float64UD);
            this.Controls.Add(this.float64Label);
            this.Controls.Add(this.float60UD);
            this.Controls.Add(this.float60Label);
            this.Controls.Add(this.float30UD);
            this.Controls.Add(this.float30label);
            this.Controls.Add(this.endFrameUD);
            this.Controls.Add(this.endFrameLabel);
            this.Controls.Add(this.soundNameLabel);
            this.Controls.Add(this.soundNameBox);
            this.Controls.Add(this.diffuseUD);
            this.Controls.Add(this.diffuseRGBALabel);
            this.Controls.Add(this.diffuseRGBButton);
            this.Controls.Add(this.scaleZUD);
            this.Controls.Add(this.rotZUD);
            this.Controls.Add(this.posZUD);
            this.Controls.Add(this.scaleZLabel);
            this.Controls.Add(this.rotZLabel);
            this.Controls.Add(this.posZLabel);
            this.Controls.Add(this.scaleXUD);
            this.Controls.Add(this.scaleXLabel);
            this.Controls.Add(this.rotXUD);
            this.Controls.Add(this.rotXLabel);
            this.Controls.Add(this.scaleYUD);
            this.Controls.Add(this.posXUD);
            this.Controls.Add(this.rotYUD);
            this.Controls.Add(this.scaleYLabel);
            this.Controls.Add(this.posXLabel);
            this.Controls.Add(this.rotYLabel);
            this.Controls.Add(this.posYUD);
            this.Controls.Add(this.posYLabel);
            this.Controls.Add(this.startFrameUD);
            this.Controls.Add(this.startTimeLabel);
            this.Name = "EfctEditor";
            this.Size = new System.Drawing.Size(396, 345);
            ((System.ComponentModel.ISupportInitialize)(this.startFrameUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posYUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posXUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posZUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diffuseUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endFrameUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotYUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotXUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotZUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleYUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleXUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleZUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.int48UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.float30UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.int50UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boolInt54UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boolInt58UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boolInt5CUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.float60UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.float64UD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.NumericUpDown startFrameUD;
        private System.Windows.Forms.NumericUpDown posYUD;
        private System.Windows.Forms.Label posYLabel;
        private System.Windows.Forms.NumericUpDown posXUD;
        private System.Windows.Forms.Label posXLabel;
        private System.Windows.Forms.NumericUpDown posZUD;
        private System.Windows.Forms.Label posZLabel;
        private System.Windows.Forms.NumericUpDown diffuseUD;
        private System.Windows.Forms.Label diffuseRGBALabel;
        private System.Windows.Forms.Button diffuseRGBButton;
        private System.Windows.Forms.TextBox soundNameBox;
        private System.Windows.Forms.Label soundNameLabel;
        private System.Windows.Forms.NumericUpDown endFrameUD;
        private System.Windows.Forms.Label endFrameLabel;
        private System.Windows.Forms.Label rotYLabel;
        private System.Windows.Forms.NumericUpDown rotYUD;
        private System.Windows.Forms.Label rotXLabel;
        private System.Windows.Forms.NumericUpDown rotXUD;
        private System.Windows.Forms.Label rotZLabel;
        private System.Windows.Forms.NumericUpDown rotZUD;
        private System.Windows.Forms.Label scaleYLabel;
        private System.Windows.Forms.NumericUpDown scaleYUD;
        private System.Windows.Forms.Label scaleXLabel;
        private System.Windows.Forms.NumericUpDown scaleXUD;
        private System.Windows.Forms.Label scaleZLabel;
        private System.Windows.Forms.NumericUpDown scaleZUD;
        private System.Windows.Forms.Label int48Label;
        private System.Windows.Forms.NumericUpDown int48UD;
        private System.Windows.Forms.Label float30label;
        private System.Windows.Forms.NumericUpDown float30UD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown int50UD;
        private System.Windows.Forms.NumericUpDown boolInt54UD;
        private System.Windows.Forms.Label boolInt54Label;
        private System.Windows.Forms.Label boolInt58Label;
        private System.Windows.Forms.NumericUpDown boolInt58UD;
        private System.Windows.Forms.Label boolInt5CLabel;
        private System.Windows.Forms.NumericUpDown boolInt5CUD;
        private System.Windows.Forms.Label float60Label;
        private System.Windows.Forms.NumericUpDown float60UD;
        private System.Windows.Forms.Label float64Label;
        private System.Windows.Forms.NumericUpDown float64UD;
        private System.Windows.Forms.Button animButton;
    }
}
