namespace AquaModelTool
{
    partial class KeyEditor
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
            this.timingLabel = new System.Windows.Forms.Label();
            this.timeUD = new System.Windows.Forms.NumericUpDown();
            this.data1UD = new System.Windows.Forms.NumericUpDown();
            this.data1Label = new System.Windows.Forms.Label();
            this.data0UD = new System.Windows.Forms.NumericUpDown();
            this.data0Label = new System.Windows.Forms.Label();
            this.data2UD = new System.Windows.Forms.NumericUpDown();
            this.data2Label = new System.Windows.Forms.Label();
            this.data3UD = new System.Windows.Forms.NumericUpDown();
            this.data3Label = new System.Windows.Forms.Label();
            this.internalTimeUD = new System.Windows.Forms.NumericUpDown();
            this.internalTimeLabel = new System.Windows.Forms.Label();
            this.nodeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.timeUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data1UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data0UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data2UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data3UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.internalTimeUD)).BeginInit();
            this.SuspendLayout();
            // 
            // timingLabel
            // 
            this.timingLabel.AutoSize = true;
            this.timingLabel.Location = new System.Drawing.Point(-1, 24);
            this.timingLabel.Name = "timingLabel";
            this.timingLabel.Size = new System.Drawing.Size(30, 13);
            this.timingLabel.TabIndex = 0;
            this.timingLabel.Text = "Time";
            // 
            // timeUD
            // 
            this.timeUD.Location = new System.Drawing.Point(3, 40);
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
            this.timeUD.Size = new System.Drawing.Size(74, 20);
            this.timeUD.TabIndex = 28;
            this.timeUD.ValueChanged += new System.EventHandler(this.TimeUDChanged);
            // 
            // data1UD
            // 
            this.data1UD.DecimalPlaces = 6;
            this.data1UD.Location = new System.Drawing.Point(3, 130);
            this.data1UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.data1UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.data1UD.Name = "data1UD";
            this.data1UD.Size = new System.Drawing.Size(74, 20);
            this.data1UD.TabIndex = 31;
            this.data1UD.ValueChanged += new System.EventHandler(this.Data1UDChanged);
            // 
            // data1Label
            // 
            this.data1Label.AutoSize = true;
            this.data1Label.Location = new System.Drawing.Point(3, 113);
            this.data1Label.Name = "data1Label";
            this.data1Label.Size = new System.Drawing.Size(39, 13);
            this.data1Label.TabIndex = 24;
            this.data1Label.Text = "Data 1";
            // 
            // data0UD
            // 
            this.data0UD.DecimalPlaces = 6;
            this.data0UD.Location = new System.Drawing.Point(3, 90);
            this.data0UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.data0UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.data0UD.Name = "data0UD";
            this.data0UD.Size = new System.Drawing.Size(74, 20);
            this.data0UD.TabIndex = 30;
            this.data0UD.ValueChanged += new System.EventHandler(this.Data0UDChanged);
            // 
            // data0Label
            // 
            this.data0Label.AutoSize = true;
            this.data0Label.Location = new System.Drawing.Point(3, 73);
            this.data0Label.Name = "data0Label";
            this.data0Label.Size = new System.Drawing.Size(39, 13);
            this.data0Label.TabIndex = 26;
            this.data0Label.Text = "Data 0";
            // 
            // data2UD
            // 
            this.data2UD.DecimalPlaces = 6;
            this.data2UD.Location = new System.Drawing.Point(3, 170);
            this.data2UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.data2UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.data2UD.Name = "data2UD";
            this.data2UD.Size = new System.Drawing.Size(74, 20);
            this.data2UD.TabIndex = 32;
            this.data2UD.ValueChanged += new System.EventHandler(this.Data2UDChanged);
            // 
            // data2Label
            // 
            this.data2Label.AutoSize = true;
            this.data2Label.Location = new System.Drawing.Point(3, 153);
            this.data2Label.Name = "data2Label";
            this.data2Label.Size = new System.Drawing.Size(39, 13);
            this.data2Label.TabIndex = 28;
            this.data2Label.Text = "Data 2";
            // 
            // data3UD
            // 
            this.data3UD.DecimalPlaces = 6;
            this.data3UD.Location = new System.Drawing.Point(3, 210);
            this.data3UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.data3UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.data3UD.Name = "data3UD";
            this.data3UD.Size = new System.Drawing.Size(74, 20);
            this.data3UD.TabIndex = 33;
            this.data3UD.ValueChanged += new System.EventHandler(this.Data3UDChanged);
            // 
            // data3Label
            // 
            this.data3Label.AutoSize = true;
            this.data3Label.Location = new System.Drawing.Point(3, 193);
            this.data3Label.Name = "data3Label";
            this.data3Label.Size = new System.Drawing.Size(39, 13);
            this.data3Label.TabIndex = 30;
            this.data3Label.Text = "Data 3";
            // 
            // internalTimeUD
            // 
            this.internalTimeUD.Location = new System.Drawing.Point(84, 40);
            this.internalTimeUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.internalTimeUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.internalTimeUD.Name = "internalTimeUD";
            this.internalTimeUD.Size = new System.Drawing.Size(74, 20);
            this.internalTimeUD.TabIndex = 29;
            this.internalTimeUD.ValueChanged += new System.EventHandler(this.InternalTimeUDChanged);
            // 
            // internalTimeLabel
            // 
            this.internalTimeLabel.AutoSize = true;
            this.internalTimeLabel.Location = new System.Drawing.Point(80, 24);
            this.internalTimeLabel.Name = "internalTimeLabel";
            this.internalTimeLabel.Size = new System.Drawing.Size(104, 13);
            this.internalTimeLabel.TabIndex = 32;
            this.internalTimeLabel.Text = "Time (Internal Value)";
            // 
            // nodeLabel
            // 
            this.nodeLabel.AutoSize = true;
            this.nodeLabel.Location = new System.Drawing.Point(-3, 5);
            this.nodeLabel.Name = "nodeLabel";
            this.nodeLabel.Size = new System.Drawing.Size(59, 13);
            this.nodeLabel.TabIndex = 34;
            this.nodeLabel.Text = "NodeLabel";
            // 
            // KeyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nodeLabel);
            this.Controls.Add(this.internalTimeUD);
            this.Controls.Add(this.internalTimeLabel);
            this.Controls.Add(this.data3UD);
            this.Controls.Add(this.data3Label);
            this.Controls.Add(this.data2UD);
            this.Controls.Add(this.data2Label);
            this.Controls.Add(this.data0UD);
            this.Controls.Add(this.data0Label);
            this.Controls.Add(this.data1UD);
            this.Controls.Add(this.data1Label);
            this.Controls.Add(this.timeUD);
            this.Controls.Add(this.timingLabel);
            this.Name = "KeyEditor";
            this.Size = new System.Drawing.Size(225, 253);
            ((System.ComponentModel.ISupportInitialize)(this.timeUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data1UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data0UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data2UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data3UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.internalTimeUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timingLabel;
        private System.Windows.Forms.NumericUpDown timeUD;
        private System.Windows.Forms.NumericUpDown data1UD;
        private System.Windows.Forms.Label data1Label;
        private System.Windows.Forms.NumericUpDown data0UD;
        private System.Windows.Forms.Label data0Label;
        private System.Windows.Forms.NumericUpDown data2UD;
        private System.Windows.Forms.Label data2Label;
        private System.Windows.Forms.NumericUpDown data3UD;
        private System.Windows.Forms.Label data3Label;
        private System.Windows.Forms.NumericUpDown internalTimeUD;
        private System.Windows.Forms.Label internalTimeLabel;
        private System.Windows.Forms.Label nodeLabel;
    }
}
