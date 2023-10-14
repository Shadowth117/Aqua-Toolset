namespace AquaModelTool
{
    partial class AqeAnimEditor
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
            this.endFrameUD = new System.Windows.Forms.NumericUpDown();
            this.endFrameLabel = new System.Windows.Forms.Label();
            this.curvTypeLabel = new System.Windows.Forms.Label();
            this.curvTypeUD = new System.Windows.Forms.NumericUpDown();
            this.animButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.int0CUD = new System.Windows.Forms.NumericUpDown();
            this.int14UD = new System.Windows.Forms.NumericUpDown();
            this.int0CLabel = new System.Windows.Forms.Label();
            this.int14Label = new System.Windows.Forms.Label();
            this.curvSetLabel = new System.Windows.Forms.Label();
            this.curvSetCB = new System.Windows.Forms.ComboBox();
            this.float10Label = new System.Windows.Forms.Label();
            this.float10UD = new System.Windows.Forms.NumericUpDown();
            this.keysListBox = new System.Windows.Forms.ListBox();
            this.keysTypeLabel = new System.Windows.Forms.Label();
            this.keysTypeUD = new System.Windows.Forms.NumericUpDown();
            this.field18Label = new System.Windows.Forms.Label();
            this.field18UD = new System.Windows.Forms.NumericUpDown();
            this.field1CLabel = new System.Windows.Forms.Label();
            this.field1CUD = new System.Windows.Forms.NumericUpDown();
            this.timeUD = new System.Windows.Forms.NumericUpDown();
            this.timeLabel = new System.Windows.Forms.Label();
            this.valueUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.inParamUD = new System.Windows.Forms.NumericUpDown();
            this.inParamLabel = new System.Windows.Forms.Label();
            this.outParamUD = new System.Windows.Forms.NumericUpDown();
            this.outParamLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.startFrameUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endFrameUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.curvTypeUD)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.int0CUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.int14UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.float10UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keysTypeUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.field18UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.field1CUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inParamUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outParamUD)).BeginInit();
            this.SuspendLayout();
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(124, 6);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(61, 13);
            this.startTimeLabel.TabIndex = 0;
            this.startTimeLabel.Text = "Start Frame";
            // 
            // startFrameUD
            // 
            this.startFrameUD.DecimalPlaces = 6;
            this.startFrameUD.Location = new System.Drawing.Point(127, 23);
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
            // endFrameUD
            // 
            this.endFrameUD.DecimalPlaces = 6;
            this.endFrameUD.Location = new System.Drawing.Point(202, 23);
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
            this.endFrameLabel.Location = new System.Drawing.Point(199, 6);
            this.endFrameLabel.Name = "endFrameLabel";
            this.endFrameLabel.Size = new System.Drawing.Size(58, 13);
            this.endFrameLabel.TabIndex = 40;
            this.endFrameLabel.Text = "End Frame";
            // 
            // curvTypeLabel
            // 
            this.curvTypeLabel.AutoSize = true;
            this.curvTypeLabel.Location = new System.Drawing.Point(57, 6);
            this.curvTypeLabel.Name = "curvTypeLabel";
            this.curvTypeLabel.Size = new System.Drawing.Size(53, 13);
            this.curvTypeLabel.TabIndex = 40;
            this.curvTypeLabel.Text = "CurvType";
            // 
            // curvTypeUD
            // 
            this.curvTypeUD.Location = new System.Drawing.Point(60, 23);
            this.curvTypeUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.curvTypeUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.curvTypeUD.Name = "curvTypeUD";
            this.curvTypeUD.Size = new System.Drawing.Size(53, 20);
            this.curvTypeUD.TabIndex = 41;
            this.curvTypeUD.ValueChanged += new System.EventHandler(this.curvTypeUDValue_Changed);
            // 
            // animButton
            // 
            this.animButton.Location = new System.Drawing.Point(272, 3);
            this.animButton.Name = "animButton";
            this.animButton.Size = new System.Drawing.Size(75, 23);
            this.animButton.TabIndex = 51;
            this.animButton.Text = "Parent Node";
            this.animButton.UseVisualStyleBackColor = true;
            this.animButton.Click += new System.EventHandler(this.animButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.int0CUD);
            this.panel1.Controls.Add(this.int14UD);
            this.panel1.Controls.Add(this.int0CLabel);
            this.panel1.Controls.Add(this.int14Label);
            this.panel1.Controls.Add(this.curvSetLabel);
            this.panel1.Controls.Add(this.curvTypeUD);
            this.panel1.Controls.Add(this.curvTypeLabel);
            this.panel1.Controls.Add(this.curvSetCB);
            this.panel1.Controls.Add(this.endFrameLabel);
            this.panel1.Controls.Add(this.animButton);
            this.panel1.Controls.Add(this.float10Label);
            this.panel1.Controls.Add(this.startTimeLabel);
            this.panel1.Controls.Add(this.float10UD);
            this.panel1.Controls.Add(this.startFrameUD);
            this.panel1.Controls.Add(this.endFrameUD);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 91);
            this.panel1.TabIndex = 52;
            // 
            // int0CUD
            // 
            this.int0CUD.Location = new System.Drawing.Point(3, 62);
            this.int0CUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.int0CUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.int0CUD.Name = "int0CUD";
            this.int0CUD.Size = new System.Drawing.Size(67, 20);
            this.int0CUD.TabIndex = 55;
            this.int0CUD.ValueChanged += new System.EventHandler(this.int0CUD_ValueChanged);
            // 
            // int14UD
            // 
            this.int14UD.Location = new System.Drawing.Point(151, 62);
            this.int14UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.int14UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.int14UD.Name = "int14UD";
            this.int14UD.Size = new System.Drawing.Size(67, 20);
            this.int14UD.TabIndex = 55;
            this.int14UD.ValueChanged += new System.EventHandler(this.int14UD_ValueChanged);
            // 
            // int0CLabel
            // 
            this.int0CLabel.AutoSize = true;
            this.int0CLabel.Location = new System.Drawing.Point(0, 45);
            this.int0CLabel.Name = "int0CLabel";
            this.int0CLabel.Size = new System.Drawing.Size(37, 13);
            this.int0CLabel.TabIndex = 54;
            this.int0CLabel.Text = "int_0C";
            // 
            // int14Label
            // 
            this.int14Label.AutoSize = true;
            this.int14Label.Location = new System.Drawing.Point(148, 45);
            this.int14Label.Name = "int14Label";
            this.int14Label.Size = new System.Drawing.Size(36, 13);
            this.int14Label.TabIndex = 54;
            this.int14Label.Text = "int_14";
            // 
            // curvSetLabel
            // 
            this.curvSetLabel.AutoSize = true;
            this.curvSetLabel.Location = new System.Drawing.Point(0, 6);
            this.curvSetLabel.Name = "curvSetLabel";
            this.curvSetLabel.Size = new System.Drawing.Size(56, 13);
            this.curvSetLabel.TabIndex = 53;
            this.curvSetLabel.Text = "CURV Set";
            // 
            // curvSetCB
            // 
            this.curvSetCB.FormattingEnabled = true;
            this.curvSetCB.Location = new System.Drawing.Point(3, 23);
            this.curvSetCB.Name = "curvSetCB";
            this.curvSetCB.Size = new System.Drawing.Size(43, 21);
            this.curvSetCB.TabIndex = 52;
            this.curvSetCB.SelectedIndexChanged += new System.EventHandler(this.curvSetCB_SelectedIndexChanged);
            // 
            // float10Label
            // 
            this.float10Label.AutoSize = true;
            this.float10Label.Location = new System.Drawing.Point(73, 45);
            this.float10Label.Name = "float10Label";
            this.float10Label.Size = new System.Drawing.Size(45, 13);
            this.float10Label.TabIndex = 0;
            this.float10Label.Text = "float_10";
            // 
            // float10UD
            // 
            this.float10UD.DecimalPlaces = 6;
            this.float10UD.Location = new System.Drawing.Point(76, 62);
            this.float10UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.float10UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.float10UD.Name = "float10UD";
            this.float10UD.Size = new System.Drawing.Size(69, 20);
            this.float10UD.TabIndex = 28;
            this.float10UD.ValueChanged += new System.EventHandler(this.float10UD_ValueChanged);
            // 
            // keysListBox
            // 
            this.keysListBox.FormattingEnabled = true;
            this.keysListBox.Location = new System.Drawing.Point(0, 90);
            this.keysListBox.Name = "keysListBox";
            this.keysListBox.Size = new System.Drawing.Size(129, 251);
            this.keysListBox.TabIndex = 53;
            this.keysListBox.SelectedIndexChanged += new System.EventHandler(this.keysListBox_SelectedIndexChanged);
            // 
            // keysTypeLabel
            // 
            this.keysTypeLabel.AutoSize = true;
            this.keysTypeLabel.Location = new System.Drawing.Point(140, 143);
            this.keysTypeLabel.Name = "keysTypeLabel";
            this.keysTypeLabel.Size = new System.Drawing.Size(52, 13);
            this.keysTypeLabel.TabIndex = 40;
            this.keysTypeLabel.Text = "Key Type";
            // 
            // keysTypeUD
            // 
            this.keysTypeUD.Location = new System.Drawing.Point(143, 160);
            this.keysTypeUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.keysTypeUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.keysTypeUD.Name = "keysTypeUD";
            this.keysTypeUD.Size = new System.Drawing.Size(53, 20);
            this.keysTypeUD.TabIndex = 41;
            this.keysTypeUD.ValueChanged += new System.EventHandler(this.keysTypeUD_ValueChanged);
            // 
            // field18Label
            // 
            this.field18Label.AutoSize = true;
            this.field18Label.Location = new System.Drawing.Point(135, 249);
            this.field18Label.Name = "field18Label";
            this.field18Label.Size = new System.Drawing.Size(44, 13);
            this.field18Label.TabIndex = 40;
            this.field18Label.Text = "field_18";
            // 
            // field18UD
            // 
            this.field18UD.Location = new System.Drawing.Point(138, 266);
            this.field18UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.field18UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.field18UD.Name = "field18UD";
            this.field18UD.Size = new System.Drawing.Size(53, 20);
            this.field18UD.TabIndex = 41;
            this.field18UD.ValueChanged += new System.EventHandler(this.field18UD_ValueChanged);
            // 
            // field1CLabel
            // 
            this.field1CLabel.AutoSize = true;
            this.field1CLabel.Location = new System.Drawing.Point(193, 249);
            this.field1CLabel.Name = "field1CLabel";
            this.field1CLabel.Size = new System.Drawing.Size(45, 13);
            this.field1CLabel.TabIndex = 40;
            this.field1CLabel.Text = "field_1C";
            // 
            // field1CUD
            // 
            this.field1CUD.Location = new System.Drawing.Point(196, 266);
            this.field1CUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.field1CUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.field1CUD.Name = "field1CUD";
            this.field1CUD.Size = new System.Drawing.Size(53, 20);
            this.field1CUD.TabIndex = 41;
            this.field1CUD.ValueChanged += new System.EventHandler(this.field1CUD_ValueChanged);
            // 
            // timeUD
            // 
            this.timeUD.DecimalPlaces = 6;
            this.timeUD.Location = new System.Drawing.Point(143, 120);
            this.timeUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.timeUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.timeUD.Name = "timeUD";
            this.timeUD.Size = new System.Drawing.Size(69, 20);
            this.timeUD.TabIndex = 28;
            this.timeUD.ValueChanged += new System.EventHandler(this.timeUD_ValueChanged);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(140, 103);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(30, 13);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "Time";
            // 
            // valueUD
            // 
            this.valueUD.DecimalPlaces = 6;
            this.valueUD.Location = new System.Drawing.Point(218, 120);
            this.valueUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.valueUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.valueUD.Name = "valueUD";
            this.valueUD.Size = new System.Drawing.Size(69, 20);
            this.valueUD.TabIndex = 28;
            this.valueUD.ValueChanged += new System.EventHandler(this.valueUD_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Value";
            // 
            // inParamUD
            // 
            this.inParamUD.DecimalPlaces = 6;
            this.inParamUD.Location = new System.Drawing.Point(218, 160);
            this.inParamUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.inParamUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.inParamUD.Name = "inParamUD";
            this.inParamUD.Size = new System.Drawing.Size(69, 20);
            this.inParamUD.TabIndex = 28;
            this.inParamUD.ValueChanged += new System.EventHandler(this.inParamUD_ValueChanged);
            // 
            // inParamLabel
            // 
            this.inParamLabel.AutoSize = true;
            this.inParamLabel.Location = new System.Drawing.Point(215, 143);
            this.inParamLabel.Name = "inParamLabel";
            this.inParamLabel.Size = new System.Drawing.Size(49, 13);
            this.inParamLabel.TabIndex = 0;
            this.inParamLabel.Text = "In Param";
            // 
            // outParamUD
            // 
            this.outParamUD.DecimalPlaces = 6;
            this.outParamUD.Location = new System.Drawing.Point(219, 200);
            this.outParamUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.outParamUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.outParamUD.Name = "outParamUD";
            this.outParamUD.Size = new System.Drawing.Size(69, 20);
            this.outParamUD.TabIndex = 28;
            this.outParamUD.ValueChanged += new System.EventHandler(this.outParamUD_ValueChanged);
            // 
            // outParamLabel
            // 
            this.outParamLabel.AutoSize = true;
            this.outParamLabel.Location = new System.Drawing.Point(216, 183);
            this.outParamLabel.Name = "outParamLabel";
            this.outParamLabel.Size = new System.Drawing.Size(57, 13);
            this.outParamLabel.TabIndex = 0;
            this.outParamLabel.Text = "Out Param";
            // 
            // AqeAnimEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.keysListBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.field1CUD);
            this.Controls.Add(this.field1CLabel);
            this.Controls.Add(this.field18UD);
            this.Controls.Add(this.field18Label);
            this.Controls.Add(this.keysTypeUD);
            this.Controls.Add(this.keysTypeLabel);
            this.Controls.Add(this.outParamLabel);
            this.Controls.Add(this.inParamLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.outParamUD);
            this.Controls.Add(this.inParamUD);
            this.Controls.Add(this.valueUD);
            this.Controls.Add(this.timeUD);
            this.Name = "AqeAnimEditor";
            this.Size = new System.Drawing.Size(353, 344);
            ((System.ComponentModel.ISupportInitialize)(this.startFrameUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endFrameUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.curvTypeUD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.int0CUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.int14UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.float10UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keysTypeUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.field18UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.field1CUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inParamUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outParamUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.NumericUpDown startFrameUD;
        private System.Windows.Forms.NumericUpDown endFrameUD;
        private System.Windows.Forms.Label endFrameLabel;
        private System.Windows.Forms.Label curvTypeLabel;
        private System.Windows.Forms.NumericUpDown curvTypeUD;
        private System.Windows.Forms.Button animButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label curvSetLabel;
        private System.Windows.Forms.ComboBox curvSetCB;
        private System.Windows.Forms.NumericUpDown int0CUD;
        private System.Windows.Forms.NumericUpDown int14UD;
        private System.Windows.Forms.Label int0CLabel;
        private System.Windows.Forms.Label int14Label;
        private System.Windows.Forms.Label float10Label;
        private System.Windows.Forms.NumericUpDown float10UD;
        private System.Windows.Forms.ListBox keysListBox;
        private System.Windows.Forms.Label keysTypeLabel;
        private System.Windows.Forms.NumericUpDown keysTypeUD;
        private System.Windows.Forms.Label field18Label;
        private System.Windows.Forms.NumericUpDown field18UD;
        private System.Windows.Forms.Label field1CLabel;
        private System.Windows.Forms.NumericUpDown field1CUD;
        private System.Windows.Forms.NumericUpDown timeUD;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.NumericUpDown valueUD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown inParamUD;
        private System.Windows.Forms.Label inParamLabel;
        private System.Windows.Forms.NumericUpDown outParamUD;
        private System.Windows.Forms.Label outParamLabel;
    }
}
