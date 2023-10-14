
namespace AquaModelTool.Forms.ModelSubpanels
{
    partial class BoundingEditor
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
            this.boundingLabel = new System.Windows.Forms.Label();
            this.halfZUD = new System.Windows.Forms.NumericUpDown();
            this.center2ZUD = new System.Windows.Forms.NumericUpDown();
            this.centerZUD = new System.Windows.Forms.NumericUpDown();
            this.halfXUD = new System.Windows.Forms.NumericUpDown();
            this.halfExtentLabel = new System.Windows.Forms.Label();
            this.center2XUD = new System.Windows.Forms.NumericUpDown();
            this.center2Label = new System.Windows.Forms.Label();
            this.halfYUD = new System.Windows.Forms.NumericUpDown();
            this.centerXUD = new System.Windows.Forms.NumericUpDown();
            this.center2YUD = new System.Windows.Forms.NumericUpDown();
            this.centerLabel = new System.Windows.Forms.Label();
            this.centerYUD = new System.Windows.Forms.NumericUpDown();
            this.boundRadiusLabel = new System.Windows.Forms.Label();
            this.boundingUD = new System.Windows.Forms.NumericUpDown();
            this.reserve0UD = new System.Windows.Forms.NumericUpDown();
            this.reserve0Label = new System.Windows.Forms.Label();
            this.reserve1UD = new System.Windows.Forms.NumericUpDown();
            this.reserve1Label = new System.Windows.Forms.Label();
            this.unkCount0UD = new System.Windows.Forms.NumericUpDown();
            this.unkCount0Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.halfZUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.center2ZUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerZUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.halfXUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.center2XUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.halfYUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerXUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.center2YUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerYUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boundingUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reserve0UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reserve1UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkCount0UD)).BeginInit();
            this.SuspendLayout();
            // 
            // boundingLabel
            // 
            this.boundingLabel.AutoSize = true;
            this.boundingLabel.Location = new System.Drawing.Point(4, 4);
            this.boundingLabel.Name = "boundingLabel";
            this.boundingLabel.Size = new System.Drawing.Size(95, 13);
            this.boundingLabel.TabIndex = 0;
            this.boundingLabel.Text = "Bounding Volumes";
            // 
            // halfZUD
            // 
            this.halfZUD.DecimalPlaces = 6;
            this.halfZUD.Location = new System.Drawing.Point(160, 123);
            this.halfZUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.halfZUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.halfZUD.Name = "halfZUD";
            this.halfZUD.Size = new System.Drawing.Size(66, 20);
            this.halfZUD.TabIndex = 50;
            this.halfZUD.ValueChanged += new System.EventHandler(this.halfZUD_ValueChanged);
            // 
            // center2ZUD
            // 
            this.center2ZUD.DecimalPlaces = 6;
            this.center2ZUD.Location = new System.Drawing.Point(160, 84);
            this.center2ZUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.center2ZUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.center2ZUD.Name = "center2ZUD";
            this.center2ZUD.Size = new System.Drawing.Size(66, 20);
            this.center2ZUD.TabIndex = 49;
            this.center2ZUD.ValueChanged += new System.EventHandler(this.center2ZUD_ValueChanged);
            // 
            // centerZUD
            // 
            this.centerZUD.DecimalPlaces = 6;
            this.centerZUD.Location = new System.Drawing.Point(160, 44);
            this.centerZUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.centerZUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.centerZUD.Name = "centerZUD";
            this.centerZUD.Size = new System.Drawing.Size(66, 20);
            this.centerZUD.TabIndex = 48;
            this.centerZUD.ValueChanged += new System.EventHandler(this.centerZUD_ValueChanged);
            // 
            // halfXUD
            // 
            this.halfXUD.DecimalPlaces = 6;
            this.halfXUD.Location = new System.Drawing.Point(4, 123);
            this.halfXUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.halfXUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.halfXUD.Name = "halfXUD";
            this.halfXUD.Size = new System.Drawing.Size(72, 20);
            this.halfXUD.TabIndex = 44;
            this.halfXUD.ValueChanged += new System.EventHandler(this.halfXUD_ValueChanged);
            // 
            // halfExtentLabel
            // 
            this.halfExtentLabel.AutoSize = true;
            this.halfExtentLabel.Location = new System.Drawing.Point(4, 106);
            this.halfExtentLabel.Name = "halfExtentLabel";
            this.halfExtentLabel.Size = new System.Drawing.Size(106, 13);
            this.halfExtentLabel.TabIndex = 37;
            this.halfExtentLabel.Text = "Half Extents (X, Y, Z)";
            // 
            // center2XUD
            // 
            this.center2XUD.DecimalPlaces = 6;
            this.center2XUD.Location = new System.Drawing.Point(4, 84);
            this.center2XUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.center2XUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.center2XUD.Name = "center2XUD";
            this.center2XUD.Size = new System.Drawing.Size(72, 20);
            this.center2XUD.TabIndex = 43;
            this.center2XUD.ValueChanged += new System.EventHandler(this.center2XUD_ValueChanged);
            // 
            // center2Label
            // 
            this.center2Label.AutoSize = true;
            this.center2Label.Location = new System.Drawing.Point(4, 67);
            this.center2Label.Name = "center2Label";
            this.center2Label.Size = new System.Drawing.Size(121, 13);
            this.center2Label.TabIndex = 38;
            this.center2Label.Text = "Model Center 2 (X, Y, Z)";
            // 
            // halfYUD
            // 
            this.halfYUD.DecimalPlaces = 6;
            this.halfYUD.Location = new System.Drawing.Point(82, 123);
            this.halfYUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.halfYUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.halfYUD.Name = "halfYUD";
            this.halfYUD.Size = new System.Drawing.Size(72, 20);
            this.halfYUD.TabIndex = 47;
            this.halfYUD.ValueChanged += new System.EventHandler(this.halfYUD_ValueChanged);
            // 
            // centerXUD
            // 
            this.centerXUD.DecimalPlaces = 6;
            this.centerXUD.Location = new System.Drawing.Point(4, 44);
            this.centerXUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.centerXUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.centerXUD.Name = "centerXUD";
            this.centerXUD.Size = new System.Drawing.Size(72, 20);
            this.centerXUD.TabIndex = 42;
            this.centerXUD.ValueChanged += new System.EventHandler(this.centerXUD_ValueChanged);
            // 
            // center2YUD
            // 
            this.center2YUD.DecimalPlaces = 6;
            this.center2YUD.Location = new System.Drawing.Point(82, 84);
            this.center2YUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.center2YUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.center2YUD.Name = "center2YUD";
            this.center2YUD.Size = new System.Drawing.Size(72, 20);
            this.center2YUD.TabIndex = 46;
            this.center2YUD.ValueChanged += new System.EventHandler(this.center2YUD_ValueChanged);
            // 
            // centerLabel
            // 
            this.centerLabel.AutoSize = true;
            this.centerLabel.Location = new System.Drawing.Point(4, 27);
            this.centerLabel.Name = "centerLabel";
            this.centerLabel.Size = new System.Drawing.Size(112, 13);
            this.centerLabel.TabIndex = 36;
            this.centerLabel.Text = "Model Center (X, Y, Z)";
            // 
            // centerYUD
            // 
            this.centerYUD.DecimalPlaces = 6;
            this.centerYUD.Location = new System.Drawing.Point(82, 44);
            this.centerYUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.centerYUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.centerYUD.Name = "centerYUD";
            this.centerYUD.Size = new System.Drawing.Size(72, 20);
            this.centerYUD.TabIndex = 45;
            this.centerYUD.ValueChanged += new System.EventHandler(this.centerYUD_ValueChanged);
            // 
            // boundRadiusLabel
            // 
            this.boundRadiusLabel.AutoSize = true;
            this.boundRadiusLabel.Location = new System.Drawing.Point(7, 161);
            this.boundRadiusLabel.Name = "boundRadiusLabel";
            this.boundRadiusLabel.Size = new System.Drawing.Size(88, 13);
            this.boundRadiusLabel.TabIndex = 51;
            this.boundRadiusLabel.Text = "Bounding Radius";
            // 
            // boundingUD
            // 
            this.boundingUD.DecimalPlaces = 6;
            this.boundingUD.Location = new System.Drawing.Point(10, 177);
            this.boundingUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.boundingUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.boundingUD.Name = "boundingUD";
            this.boundingUD.Size = new System.Drawing.Size(72, 20);
            this.boundingUD.TabIndex = 52;
            this.boundingUD.ValueChanged += new System.EventHandler(this.boundingUD_ValueChanged);
            // 
            // reserve0UD
            // 
            this.reserve0UD.DecimalPlaces = 6;
            this.reserve0UD.Location = new System.Drawing.Point(243, 43);
            this.reserve0UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.reserve0UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.reserve0UD.Name = "reserve0UD";
            this.reserve0UD.Size = new System.Drawing.Size(72, 20);
            this.reserve0UD.TabIndex = 54;
            this.reserve0UD.ValueChanged += new System.EventHandler(this.reserve0UD_ValueChanged);
            // 
            // reserve0Label
            // 
            this.reserve0Label.AutoSize = true;
            this.reserve0Label.Location = new System.Drawing.Point(240, 27);
            this.reserve0Label.Name = "reserve0Label";
            this.reserve0Label.Size = new System.Drawing.Size(53, 13);
            this.reserve0Label.TabIndex = 53;
            this.reserve0Label.Text = "Reserve0";
            // 
            // reserve1UD
            // 
            this.reserve1UD.DecimalPlaces = 6;
            this.reserve1UD.Location = new System.Drawing.Point(243, 84);
            this.reserve1UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.reserve1UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.reserve1UD.Name = "reserve1UD";
            this.reserve1UD.Size = new System.Drawing.Size(72, 20);
            this.reserve1UD.TabIndex = 56;
            this.reserve1UD.ValueChanged += new System.EventHandler(this.reserve1UD_ValueChanged);
            // 
            // reserve1Label
            // 
            this.reserve1Label.AutoSize = true;
            this.reserve1Label.Location = new System.Drawing.Point(240, 68);
            this.reserve1Label.Name = "reserve1Label";
            this.reserve1Label.Size = new System.Drawing.Size(53, 13);
            this.reserve1Label.TabIndex = 55;
            this.reserve1Label.Text = "Reserve1";
            // 
            // unkCount0UD
            // 
            this.unkCount0UD.DecimalPlaces = 6;
            this.unkCount0UD.Location = new System.Drawing.Point(104, 177);
            this.unkCount0UD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.unkCount0UD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.unkCount0UD.Name = "unkCount0UD";
            this.unkCount0UD.Size = new System.Drawing.Size(72, 20);
            this.unkCount0UD.TabIndex = 58;
            this.unkCount0UD.ValueChanged += new System.EventHandler(this.unkCount0UD_ValueChanged);
            // 
            // unkCount0Label
            // 
            this.unkCount0Label.AutoSize = true;
            this.unkCount0Label.Location = new System.Drawing.Point(101, 161);
            this.unkCount0Label.Name = "unkCount0Label";
            this.unkCount0Label.Size = new System.Drawing.Size(53, 13);
            this.unkCount0Label.TabIndex = 57;
            this.unkCount0Label.Text = "Unknown";
            // 
            // BoundingEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.unkCount0UD);
            this.Controls.Add(this.unkCount0Label);
            this.Controls.Add(this.reserve1UD);
            this.Controls.Add(this.reserve1Label);
            this.Controls.Add(this.reserve0UD);
            this.Controls.Add(this.reserve0Label);
            this.Controls.Add(this.boundingUD);
            this.Controls.Add(this.boundRadiusLabel);
            this.Controls.Add(this.halfZUD);
            this.Controls.Add(this.center2ZUD);
            this.Controls.Add(this.centerZUD);
            this.Controls.Add(this.halfXUD);
            this.Controls.Add(this.halfExtentLabel);
            this.Controls.Add(this.center2XUD);
            this.Controls.Add(this.center2Label);
            this.Controls.Add(this.halfYUD);
            this.Controls.Add(this.centerXUD);
            this.Controls.Add(this.center2YUD);
            this.Controls.Add(this.centerLabel);
            this.Controls.Add(this.centerYUD);
            this.Controls.Add(this.boundingLabel);
            this.Name = "BoundingEditor";
            this.Size = new System.Drawing.Size(378, 204);
            ((System.ComponentModel.ISupportInitialize)(this.halfZUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.center2ZUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerZUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.halfXUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.center2XUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.halfYUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerXUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.center2YUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerYUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boundingUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reserve0UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reserve1UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkCount0UD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label boundingLabel;
        private System.Windows.Forms.NumericUpDown halfZUD;
        private System.Windows.Forms.NumericUpDown center2ZUD;
        private System.Windows.Forms.NumericUpDown centerZUD;
        private System.Windows.Forms.NumericUpDown halfXUD;
        private System.Windows.Forms.Label halfExtentLabel;
        private System.Windows.Forms.NumericUpDown center2XUD;
        private System.Windows.Forms.Label center2Label;
        private System.Windows.Forms.NumericUpDown halfYUD;
        private System.Windows.Forms.NumericUpDown centerXUD;
        private System.Windows.Forms.NumericUpDown center2YUD;
        private System.Windows.Forms.Label centerLabel;
        private System.Windows.Forms.NumericUpDown centerYUD;
        private System.Windows.Forms.Label boundRadiusLabel;
        private System.Windows.Forms.NumericUpDown boundingUD;
        private System.Windows.Forms.NumericUpDown reserve0UD;
        private System.Windows.Forms.Label reserve0Label;
        private System.Windows.Forms.NumericUpDown reserve1UD;
        private System.Windows.Forms.Label reserve1Label;
        private System.Windows.Forms.NumericUpDown unkCount0UD;
        private System.Windows.Forms.Label unkCount0Label;
    }
}
