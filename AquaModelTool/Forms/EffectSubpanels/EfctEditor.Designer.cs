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
            startTimeLabel = new Label();
            startFrameUD = new NumericUpDown();
            posYUD = new NumericUpDown();
            posYLabel = new Label();
            posXUD = new NumericUpDown();
            posXLabel = new Label();
            posZUD = new NumericUpDown();
            posZLabel = new Label();
            diffuseUD = new NumericUpDown();
            diffuseRGBALabel = new Label();
            diffuseRGBButton = new Button();
            soundNameBox = new TextBox();
            soundNameLabel = new Label();
            endFrameUD = new NumericUpDown();
            endFrameLabel = new Label();
            rotYLabel = new Label();
            rotYUD = new NumericUpDown();
            rotXLabel = new Label();
            rotXUD = new NumericUpDown();
            rotZLabel = new Label();
            rotZUD = new NumericUpDown();
            scaleYLabel = new Label();
            scaleYUD = new NumericUpDown();
            scaleXLabel = new Label();
            scaleXUD = new NumericUpDown();
            scaleZLabel = new Label();
            scaleZUD = new NumericUpDown();
            int48Label = new Label();
            int48UD = new NumericUpDown();
            float30label = new Label();
            float30UD = new NumericUpDown();
            label1 = new Label();
            int50UD = new NumericUpDown();
            loopEffectUD = new NumericUpDown();
            boolInt54Label = new Label();
            boolInt58Label = new Label();
            boolInt58UD = new NumericUpDown();
            boolInt5CLabel = new Label();
            boolInt5CUD = new NumericUpDown();
            float60Label = new Label();
            float60UD = new NumericUpDown();
            float64Label = new Label();
            float64UD = new NumericUpDown();
            animButton = new Button();
            ((System.ComponentModel.ISupportInitialize)startFrameUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)posYUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)posXUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)posZUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)diffuseUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)endFrameUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rotYUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rotXUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rotZUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scaleYUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scaleXUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scaleZUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)int48UD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)float30UD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)int50UD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)loopEffectUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)boolInt58UD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)boolInt5CUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)float60UD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)float64UD).BeginInit();
            SuspendLayout();
            // 
            // startTimeLabel
            // 
            startTimeLabel.AutoSize = true;
            startTimeLabel.Location = new Point(0, 0);
            startTimeLabel.Margin = new Padding(4, 0, 4, 0);
            startTimeLabel.Name = "startTimeLabel";
            startTimeLabel.Size = new Size(67, 15);
            startTimeLabel.TabIndex = 0;
            startTimeLabel.Text = "Start Frame";
            // 
            // startFrameUD
            // 
            startFrameUD.DecimalPlaces = 6;
            startFrameUD.Location = new Point(4, 20);
            startFrameUD.Margin = new Padding(4, 3, 4, 3);
            startFrameUD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            startFrameUD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            startFrameUD.Name = "startFrameUD";
            startFrameUD.Size = new Size(80, 23);
            startFrameUD.TabIndex = 28;
            startFrameUD.ValueChanged += startFrameUDValue_Changed;
            // 
            // posYUD
            // 
            posYUD.DecimalPlaces = 6;
            posYUD.Location = new Point(94, 77);
            posYUD.Margin = new Padding(4, 3, 4, 3);
            posYUD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            posYUD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            posYUD.Name = "posYUD";
            posYUD.Size = new Size(84, 23);
            posYUD.TabIndex = 31;
            posYUD.ValueChanged += posYUDValue_Changed;
            // 
            // posYLabel
            // 
            posYLabel.AutoSize = true;
            posYLabel.Location = new Point(94, 58);
            posYLabel.Margin = new Padding(4, 0, 4, 0);
            posYLabel.Name = "posYLabel";
            posYLabel.Size = new Size(74, 15);
            posYLabel.TabIndex = 24;
            posYLabel.Text = "Translation Y";
            // 
            // posXUD
            // 
            posXUD.DecimalPlaces = 6;
            posXUD.Location = new Point(4, 77);
            posXUD.Margin = new Padding(4, 3, 4, 3);
            posXUD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            posXUD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            posXUD.Name = "posXUD";
            posXUD.Size = new Size(84, 23);
            posXUD.TabIndex = 30;
            posXUD.ValueChanged += posXUDValue_Changed;
            // 
            // posXLabel
            // 
            posXLabel.AutoSize = true;
            posXLabel.Location = new Point(4, 58);
            posXLabel.Margin = new Padding(4, 0, 4, 0);
            posXLabel.Name = "posXLabel";
            posXLabel.Size = new Size(74, 15);
            posXLabel.TabIndex = 26;
            posXLabel.Text = "Translation X";
            // 
            // posZUD
            // 
            posZUD.DecimalPlaces = 6;
            posZUD.Location = new Point(186, 77);
            posZUD.Margin = new Padding(4, 3, 4, 3);
            posZUD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            posZUD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            posZUD.Name = "posZUD";
            posZUD.Size = new Size(77, 23);
            posZUD.TabIndex = 32;
            posZUD.ValueChanged += posZUDValue_Changed;
            // 
            // posZLabel
            // 
            posZLabel.AutoSize = true;
            posZLabel.Location = new Point(186, 58);
            posZLabel.Margin = new Padding(4, 0, 4, 0);
            posZLabel.Name = "posZLabel";
            posZLabel.Size = new Size(74, 15);
            posZLabel.TabIndex = 28;
            posZLabel.Text = "Translation Z";
            // 
            // diffuseUD
            // 
            diffuseUD.Location = new Point(356, 77);
            diffuseUD.Margin = new Padding(4, 3, 4, 3);
            diffuseUD.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            diffuseUD.Name = "diffuseUD";
            diffuseUD.Size = new Size(52, 23);
            diffuseUD.TabIndex = 37;
            diffuseUD.ValueChanged += diffuseUD_ValueChanged;
            // 
            // diffuseRGBALabel
            // 
            diffuseRGBALabel.AutoSize = true;
            diffuseRGBALabel.Location = new Point(309, 58);
            diffuseRGBALabel.Margin = new Padding(4, 0, 4, 0);
            diffuseRGBALabel.Name = "diffuseRGBALabel";
            diffuseRGBALabel.Size = new Size(64, 15);
            diffuseRGBALabel.TabIndex = 36;
            diffuseRGBALabel.Text = "Root Color";
            // 
            // diffuseRGBButton
            // 
            diffuseRGBButton.BackColor = Color.WhiteSmoke;
            diffuseRGBButton.Location = new Point(312, 75);
            diffuseRGBButton.Margin = new Padding(4, 3, 4, 3);
            diffuseRGBButton.Name = "diffuseRGBButton";
            diffuseRGBButton.Size = new Size(36, 27);
            diffuseRGBButton.TabIndex = 35;
            diffuseRGBButton.UseVisualStyleBackColor = false;
            diffuseRGBButton.Click += diffuseRGBButton_Click;
            // 
            // soundNameBox
            // 
            soundNameBox.Location = new Point(4, 265);
            soundNameBox.Margin = new Padding(4, 3, 4, 3);
            soundNameBox.MaxLength = 48;
            soundNameBox.Name = "soundNameBox";
            soundNameBox.Size = new Size(251, 23);
            soundNameBox.TabIndex = 38;
            soundNameBox.TextChanged += soundNameBox_TextChanged;
            // 
            // soundNameLabel
            // 
            soundNameLabel.AutoSize = true;
            soundNameLabel.Location = new Point(7, 243);
            soundNameLabel.Margin = new Padding(4, 0, 4, 0);
            soundNameLabel.Name = "soundNameLabel";
            soundNameLabel.Size = new Size(76, 15);
            soundNameLabel.TabIndex = 39;
            soundNameLabel.Text = "Sound Name";
            // 
            // endFrameUD
            // 
            endFrameUD.DecimalPlaces = 6;
            endFrameUD.Location = new Point(100, 20);
            endFrameUD.Margin = new Padding(4, 3, 4, 3);
            endFrameUD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            endFrameUD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            endFrameUD.Name = "endFrameUD";
            endFrameUD.Size = new Size(78, 23);
            endFrameUD.TabIndex = 41;
            endFrameUD.ValueChanged += endFrameUD_ValueChanged;
            // 
            // endFrameLabel
            // 
            endFrameLabel.AutoSize = true;
            endFrameLabel.Location = new Point(97, 0);
            endFrameLabel.Margin = new Padding(4, 0, 4, 0);
            endFrameLabel.Name = "endFrameLabel";
            endFrameLabel.Size = new Size(63, 15);
            endFrameLabel.TabIndex = 40;
            endFrameLabel.Text = "End Frame";
            // 
            // rotYLabel
            // 
            rotYLabel.AutoSize = true;
            rotYLabel.Location = new Point(94, 114);
            rotYLabel.Margin = new Padding(4, 0, 4, 0);
            rotYLabel.Name = "rotYLabel";
            rotYLabel.Size = new Size(62, 15);
            rotYLabel.TabIndex = 24;
            rotYLabel.Text = "Rotation Y";
            // 
            // rotYUD
            // 
            rotYUD.DecimalPlaces = 6;
            rotYUD.Location = new Point(94, 134);
            rotYUD.Margin = new Padding(4, 3, 4, 3);
            rotYUD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            rotYUD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            rotYUD.Name = "rotYUD";
            rotYUD.Size = new Size(84, 23);
            rotYUD.TabIndex = 31;
            rotYUD.ValueChanged += rotYUD_ValueChanged;
            // 
            // rotXLabel
            // 
            rotXLabel.AutoSize = true;
            rotXLabel.Location = new Point(4, 114);
            rotXLabel.Margin = new Padding(4, 0, 4, 0);
            rotXLabel.Name = "rotXLabel";
            rotXLabel.Size = new Size(62, 15);
            rotXLabel.TabIndex = 26;
            rotXLabel.Text = "Rotation X";
            // 
            // rotXUD
            // 
            rotXUD.DecimalPlaces = 6;
            rotXUD.Location = new Point(4, 134);
            rotXUD.Margin = new Padding(4, 3, 4, 3);
            rotXUD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            rotXUD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            rotXUD.Name = "rotXUD";
            rotXUD.Size = new Size(84, 23);
            rotXUD.TabIndex = 30;
            rotXUD.ValueChanged += rotXUD_ValueChanged;
            // 
            // rotZLabel
            // 
            rotZLabel.AutoSize = true;
            rotZLabel.Location = new Point(186, 114);
            rotZLabel.Margin = new Padding(4, 0, 4, 0);
            rotZLabel.Name = "rotZLabel";
            rotZLabel.Size = new Size(62, 15);
            rotZLabel.TabIndex = 28;
            rotZLabel.Text = "Rotation Z";
            // 
            // rotZUD
            // 
            rotZUD.DecimalPlaces = 6;
            rotZUD.Location = new Point(186, 134);
            rotZUD.Margin = new Padding(4, 3, 4, 3);
            rotZUD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            rotZUD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            rotZUD.Name = "rotZUD";
            rotZUD.Size = new Size(77, 23);
            rotZUD.TabIndex = 32;
            rotZUD.ValueChanged += rotZUD_ValueChanged;
            // 
            // scaleYLabel
            // 
            scaleYLabel.AutoSize = true;
            scaleYLabel.Location = new Point(94, 178);
            scaleYLabel.Margin = new Padding(4, 0, 4, 0);
            scaleYLabel.Name = "scaleYLabel";
            scaleYLabel.Size = new Size(44, 15);
            scaleYLabel.TabIndex = 24;
            scaleYLabel.Text = "Scale Y";
            // 
            // scaleYUD
            // 
            scaleYUD.DecimalPlaces = 6;
            scaleYUD.Location = new Point(94, 197);
            scaleYUD.Margin = new Padding(4, 3, 4, 3);
            scaleYUD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            scaleYUD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            scaleYUD.Name = "scaleYUD";
            scaleYUD.Size = new Size(84, 23);
            scaleYUD.TabIndex = 31;
            scaleYUD.ValueChanged += scaleYUD_ValueChanged;
            // 
            // scaleXLabel
            // 
            scaleXLabel.AutoSize = true;
            scaleXLabel.Location = new Point(4, 178);
            scaleXLabel.Margin = new Padding(4, 0, 4, 0);
            scaleXLabel.Name = "scaleXLabel";
            scaleXLabel.Size = new Size(44, 15);
            scaleXLabel.TabIndex = 26;
            scaleXLabel.Text = "Scale X";
            // 
            // scaleXUD
            // 
            scaleXUD.DecimalPlaces = 6;
            scaleXUD.Location = new Point(4, 197);
            scaleXUD.Margin = new Padding(4, 3, 4, 3);
            scaleXUD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            scaleXUD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            scaleXUD.Name = "scaleXUD";
            scaleXUD.Size = new Size(84, 23);
            scaleXUD.TabIndex = 30;
            scaleXUD.ValueChanged += scaleXUD_ValueChanged;
            // 
            // scaleZLabel
            // 
            scaleZLabel.AutoSize = true;
            scaleZLabel.Location = new Point(186, 178);
            scaleZLabel.Margin = new Padding(4, 0, 4, 0);
            scaleZLabel.Name = "scaleZLabel";
            scaleZLabel.Size = new Size(44, 15);
            scaleZLabel.TabIndex = 28;
            scaleZLabel.Text = "Scale Z";
            // 
            // scaleZUD
            // 
            scaleZUD.DecimalPlaces = 6;
            scaleZUD.Location = new Point(186, 197);
            scaleZUD.Margin = new Padding(4, 3, 4, 3);
            scaleZUD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            scaleZUD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            scaleZUD.Name = "scaleZUD";
            scaleZUD.Size = new Size(77, 23);
            scaleZUD.TabIndex = 32;
            scaleZUD.ValueChanged += scaleZUD_ValueChanged;
            // 
            // int48Label
            // 
            int48Label.AutoSize = true;
            int48Label.Location = new Point(93, 303);
            int48Label.Margin = new Padding(4, 0, 4, 0);
            int48Label.Name = "int48Label";
            int48Label.Size = new Size(38, 15);
            int48Label.TabIndex = 40;
            int48Label.Text = "int_48";
            // 
            // int48UD
            // 
            int48UD.Location = new Point(97, 323);
            int48UD.Margin = new Padding(4, 3, 4, 3);
            int48UD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            int48UD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            int48UD.Name = "int48UD";
            int48UD.Size = new Size(78, 23);
            int48UD.TabIndex = 41;
            int48UD.ValueChanged += int48UD_ValueChanged;
            // 
            // float30label
            // 
            float30label.AutoSize = true;
            float30label.Location = new Point(4, 303);
            float30label.Margin = new Padding(4, 0, 4, 0);
            float30label.Name = "float30label";
            float30label.Size = new Size(48, 15);
            float30label.TabIndex = 40;
            float30label.Text = "float_30";
            // 
            // float30UD
            // 
            float30UD.DecimalPlaces = 6;
            float30UD.Location = new Point(7, 323);
            float30UD.Margin = new Padding(4, 3, 4, 3);
            float30UD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            float30UD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            float30UD.Name = "float30UD";
            float30UD.Size = new Size(78, 23);
            float30UD.TabIndex = 41;
            float30UD.ValueChanged += float30UD_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(182, 303);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 40;
            label1.Text = "int_50";
            // 
            // int50UD
            // 
            int50UD.Location = new Point(186, 323);
            int50UD.Margin = new Padding(4, 3, 4, 3);
            int50UD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            int50UD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            int50UD.Name = "int50UD";
            int50UD.Size = new Size(78, 23);
            int50UD.TabIndex = 41;
            int50UD.ValueChanged += int50UD_ValueChanged;
            // 
            // loopEffectUD
            // 
            loopEffectUD.Location = new Point(186, 20);
            loopEffectUD.Margin = new Padding(4, 3, 4, 3);
            loopEffectUD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            loopEffectUD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            loopEffectUD.Name = "loopEffectUD";
            loopEffectUD.Size = new Size(78, 23);
            loopEffectUD.TabIndex = 43;
            loopEffectUD.ValueChanged += boolInt54UD_ValueChanged;
            // 
            // boolInt54Label
            // 
            boolInt54Label.AutoSize = true;
            boolInt54Label.Location = new Point(182, 0);
            boolInt54Label.Margin = new Padding(4, 0, 4, 0);
            boolInt54Label.Name = "boolInt54Label";
            boolInt54Label.Size = new Size(66, 15);
            boolInt54Label.TabIndex = 42;
            boolInt54Label.Text = "Loop Anim";
            // 
            // boolInt58Label
            // 
            boolInt58Label.AutoSize = true;
            boolInt58Label.Location = new Point(271, 303);
            boolInt58Label.Margin = new Padding(4, 0, 4, 0);
            boolInt58Label.Name = "boolInt58Label";
            boolInt58Label.Size = new Size(62, 15);
            boolInt58Label.TabIndex = 42;
            boolInt58Label.Text = "boolInt_58";
            // 
            // boolInt58UD
            // 
            boolInt58UD.Location = new Point(275, 323);
            boolInt58UD.Margin = new Padding(4, 3, 4, 3);
            boolInt58UD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            boolInt58UD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            boolInt58UD.Name = "boolInt58UD";
            boolInt58UD.Size = new Size(78, 23);
            boolInt58UD.TabIndex = 43;
            boolInt58UD.ValueChanged += boolInt58UD_ValueChanged;
            // 
            // boolInt5CLabel
            // 
            boolInt5CLabel.AutoSize = true;
            boolInt5CLabel.Location = new Point(267, 352);
            boolInt5CLabel.Margin = new Padding(4, 0, 4, 0);
            boolInt5CLabel.Name = "boolInt5CLabel";
            boolInt5CLabel.Size = new Size(64, 15);
            boolInt5CLabel.TabIndex = 42;
            boolInt5CLabel.Text = "boolInt_5C";
            // 
            // boolInt5CUD
            // 
            boolInt5CUD.Location = new Point(271, 372);
            boolInt5CUD.Margin = new Padding(4, 3, 4, 3);
            boolInt5CUD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            boolInt5CUD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            boolInt5CUD.Name = "boolInt5CUD";
            boolInt5CUD.Size = new Size(78, 23);
            boolInt5CUD.TabIndex = 43;
            boolInt5CUD.ValueChanged += boolInt5CUD_ValueChanged;
            // 
            // float60Label
            // 
            float60Label.AutoSize = true;
            float60Label.Location = new Point(2, 352);
            float60Label.Margin = new Padding(4, 0, 4, 0);
            float60Label.Name = "float60Label";
            float60Label.Size = new Size(48, 15);
            float60Label.TabIndex = 40;
            float60Label.Text = "float_60";
            // 
            // float60UD
            // 
            float60UD.DecimalPlaces = 6;
            float60UD.Location = new Point(6, 372);
            float60UD.Margin = new Padding(4, 3, 4, 3);
            float60UD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            float60UD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            float60UD.Name = "float60UD";
            float60UD.Size = new Size(78, 23);
            float60UD.TabIndex = 41;
            float60UD.ValueChanged += float60UD_ValueChanged;
            // 
            // float64Label
            // 
            float64Label.AutoSize = true;
            float64Label.Location = new Point(91, 352);
            float64Label.Margin = new Padding(4, 0, 4, 0);
            float64Label.Name = "float64Label";
            float64Label.Size = new Size(48, 15);
            float64Label.TabIndex = 40;
            float64Label.Text = "float_64";
            // 
            // float64UD
            // 
            float64UD.DecimalPlaces = 6;
            float64UD.Location = new Point(94, 372);
            float64UD.Margin = new Padding(4, 3, 4, 3);
            float64UD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            float64UD.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            float64UD.Name = "float64UD";
            float64UD.Size = new Size(78, 23);
            float64UD.TabIndex = 41;
            float64UD.ValueChanged += float64UD_ValueChanged;
            // 
            // animButton
            // 
            animButton.Location = new Point(321, 10);
            animButton.Margin = new Padding(4, 3, 4, 3);
            animButton.Name = "animButton";
            animButton.Size = new Size(138, 27);
            animButton.TabIndex = 51;
            animButton.Text = "Animations";
            animButton.UseVisualStyleBackColor = true;
            animButton.Click += animButton_Click;
            // 
            // EfctEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(animButton);
            Controls.Add(boolInt5CUD);
            Controls.Add(boolInt5CLabel);
            Controls.Add(boolInt58UD);
            Controls.Add(boolInt58Label);
            Controls.Add(loopEffectUD);
            Controls.Add(boolInt54Label);
            Controls.Add(int50UD);
            Controls.Add(int48UD);
            Controls.Add(label1);
            Controls.Add(int48Label);
            Controls.Add(float64UD);
            Controls.Add(float64Label);
            Controls.Add(float60UD);
            Controls.Add(float60Label);
            Controls.Add(float30UD);
            Controls.Add(float30label);
            Controls.Add(endFrameUD);
            Controls.Add(endFrameLabel);
            Controls.Add(soundNameLabel);
            Controls.Add(soundNameBox);
            Controls.Add(diffuseUD);
            Controls.Add(diffuseRGBALabel);
            Controls.Add(diffuseRGBButton);
            Controls.Add(scaleZUD);
            Controls.Add(rotZUD);
            Controls.Add(posZUD);
            Controls.Add(scaleZLabel);
            Controls.Add(rotZLabel);
            Controls.Add(posZLabel);
            Controls.Add(scaleXUD);
            Controls.Add(scaleXLabel);
            Controls.Add(rotXUD);
            Controls.Add(rotXLabel);
            Controls.Add(scaleYUD);
            Controls.Add(posXUD);
            Controls.Add(rotYUD);
            Controls.Add(scaleYLabel);
            Controls.Add(posXLabel);
            Controls.Add(rotYLabel);
            Controls.Add(posYUD);
            Controls.Add(posYLabel);
            Controls.Add(startFrameUD);
            Controls.Add(startTimeLabel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "EfctEditor";
            Size = new Size(463, 398);
            ((System.ComponentModel.ISupportInitialize)startFrameUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)posYUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)posXUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)posZUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)diffuseUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)endFrameUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)rotYUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)rotXUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)rotZUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)scaleYUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)scaleXUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)scaleZUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)int48UD).EndInit();
            ((System.ComponentModel.ISupportInitialize)float30UD).EndInit();
            ((System.ComponentModel.ISupportInitialize)int50UD).EndInit();
            ((System.ComponentModel.ISupportInitialize)loopEffectUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)boolInt58UD).EndInit();
            ((System.ComponentModel.ISupportInitialize)boolInt5CUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)float60UD).EndInit();
            ((System.ComponentModel.ISupportInitialize)float64UD).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.NumericUpDown loopEffectUD;
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
