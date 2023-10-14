
namespace AquaModelTool.Forms.ModelSubpanels.Material
{
    partial class MaterialVec3Editor
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
            this.matZUD = new System.Windows.Forms.NumericUpDown();
            this.matXUD = new System.Windows.Forms.NumericUpDown();
            this.matVectorLabel = new System.Windows.Forms.Label();
            this.matYUD = new System.Windows.Forms.NumericUpDown();
            this.rGBButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.matZUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matXUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matYUD)).BeginInit();
            this.SuspendLayout();
            // 
            // matZUD
            // 
            this.matZUD.DecimalPlaces = 6;
            this.matZUD.Location = new System.Drawing.Point(168, 26);
            this.matZUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.matZUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.matZUD.Name = "matZUD";
            this.matZUD.Size = new System.Drawing.Size(66, 20);
            this.matZUD.TabIndex = 52;
            this.matZUD.ValueChanged += new System.EventHandler(this.Vec3UD_Click);
            // 
            // matXUD
            // 
            this.matXUD.DecimalPlaces = 6;
            this.matXUD.Location = new System.Drawing.Point(12, 26);
            this.matXUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.matXUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.matXUD.Name = "matXUD";
            this.matXUD.Size = new System.Drawing.Size(72, 20);
            this.matXUD.TabIndex = 50;
            this.matXUD.ValueChanged += new System.EventHandler(this.Vec3UD_Click);
            // 
            // matVectorLabel
            // 
            this.matVectorLabel.AutoSize = true;
            this.matVectorLabel.Location = new System.Drawing.Point(12, 9);
            this.matVectorLabel.Name = "matVectorLabel";
            this.matVectorLabel.Size = new System.Drawing.Size(180, 13);
            this.matVectorLabel.TabIndex = 49;
            this.matVectorLabel.Text = "Mat Vector3 (RGB, when applicable)";
            // 
            // matYUD
            // 
            this.matYUD.DecimalPlaces = 6;
            this.matYUD.Location = new System.Drawing.Point(90, 26);
            this.matYUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.matYUD.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.matYUD.Name = "matYUD";
            this.matYUD.Size = new System.Drawing.Size(72, 20);
            this.matYUD.TabIndex = 51;
            this.matYUD.ValueChanged += new System.EventHandler(this.Vec3UD_Click);
            // 
            // rGBButton
            // 
            this.rGBButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rGBButton.Location = new System.Drawing.Point(12, 52);
            this.rGBButton.Name = "rGBButton";
            this.rGBButton.Size = new System.Drawing.Size(54, 45);
            this.rGBButton.TabIndex = 53;
            this.rGBButton.UseVisualStyleBackColor = false;
            this.rGBButton.Click += new System.EventHandler(this.rGBButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Color Editor Button";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "* May not give desired results for";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "materials with values greater than 1";
            // 
            // MaterialVec3Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 103);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rGBButton);
            this.Controls.Add(this.matZUD);
            this.Controls.Add(this.matXUD);
            this.Controls.Add(this.matVectorLabel);
            this.Controls.Add(this.matYUD);
            this.Name = "MaterialVec3Editor";
            this.Text = "Material Vector 3";
            ((System.ComponentModel.ISupportInitialize)(this.matZUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matXUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matYUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown matZUD;
        private System.Windows.Forms.NumericUpDown matXUD;
        private System.Windows.Forms.Label matVectorLabel;
        private System.Windows.Forms.NumericUpDown matYUD;
        private System.Windows.Forms.Button rGBButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}