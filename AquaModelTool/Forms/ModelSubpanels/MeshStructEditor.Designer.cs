
namespace AquaModelTool
{
    partial class MeshStructEditor
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
            this.meshIDCB = new System.Windows.Forms.ComboBox();
            this.meshLabel = new System.Windows.Forms.Label();
            this.flagsUD = new System.Windows.Forms.NumericUpDown();
            this.flagsLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.matIDLabel = new System.Windows.Forms.Label();
            this.matIDCB = new System.Windows.Forms.ComboBox();
            this.renderIDLabel = new System.Windows.Forms.Label();
            this.renderIDCB = new System.Windows.Forms.ComboBox();
            this.shaderLabel = new System.Windows.Forms.Label();
            this.shadIDCB = new System.Windows.Forms.ComboBox();
            this.texSetIDLabel = new System.Windows.Forms.Label();
            this.tsetIDCB = new System.Windows.Forms.ComboBox();
            this.vsetIDLabel = new System.Windows.Forms.Label();
            this.vsetIDCB = new System.Windows.Forms.ComboBox();
            this.psetIDLabel = new System.Windows.Forms.Label();
            this.faceSetIDCB = new System.Windows.Forms.ComboBox();
            this.warningLabel = new System.Windows.Forms.Label();
            this.unkShort0UD = new System.Windows.Forms.NumericUpDown();
            this.unkShort0Label = new System.Windows.Forms.Label();
            this.unkByte0UD = new System.Windows.Forms.NumericUpDown();
            this.unkByte0Label = new System.Windows.Forms.Label();
            this.unkByte1UD = new System.Windows.Forms.NumericUpDown();
            this.unkByte1Label = new System.Windows.Forms.Label();
            this.unkShort1UD = new System.Windows.Forms.NumericUpDown();
            this.unkShort1Label = new System.Windows.Forms.Label();
            this.baseMeshNodeIdUD = new System.Windows.Forms.NumericUpDown();
            this.baseMeshNodeIdLabel = new System.Windows.Forms.Label();
            this.baseMeshDummyIdUD = new System.Windows.Forms.NumericUpDown();
            this.baseMeshDummyIdLabel = new System.Windows.Forms.Label();
            this.unkInt0UD = new System.Windows.Forms.NumericUpDown();
            this.unkInt0Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.flagsUD)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unkShort0UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkByte0UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkByte1UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkShort1UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseMeshNodeIdUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseMeshDummyIdUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkInt0UD)).BeginInit();
            this.SuspendLayout();
            // 
            // meshIDCB
            // 
            this.meshIDCB.FormattingEnabled = true;
            this.meshIDCB.Location = new System.Drawing.Point(4, 21);
            this.meshIDCB.Name = "meshIDCB";
            this.meshIDCB.Size = new System.Drawing.Size(49, 21);
            this.meshIDCB.TabIndex = 3;
            this.meshIDCB.SelectedIndexChanged += new System.EventHandler(this.meshIDCB_SelectedIndexChanged);
            // 
            // meshLabel
            // 
            this.meshLabel.AutoSize = true;
            this.meshLabel.Location = new System.Drawing.Point(4, 4);
            this.meshLabel.Name = "meshLabel";
            this.meshLabel.Size = new System.Drawing.Size(80, 13);
            this.meshLabel.TabIndex = 2;
            this.meshLabel.Text = "Mesh Selection";
            // 
            // flagsUD
            // 
            this.flagsUD.Location = new System.Drawing.Point(111, 22);
            this.flagsUD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.flagsUD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.flagsUD.Name = "flagsUD";
            this.flagsUD.Size = new System.Drawing.Size(76, 20);
            this.flagsUD.TabIndex = 9;
            this.flagsUD.ValueChanged += new System.EventHandler(this.flagsUD_ValueChanged);
            // 
            // flagsLabel
            // 
            this.flagsLabel.AutoSize = true;
            this.flagsLabel.Location = new System.Drawing.Point(108, 5);
            this.flagsLabel.Name = "flagsLabel";
            this.flagsLabel.Size = new System.Drawing.Size(32, 13);
            this.flagsLabel.TabIndex = 8;
            this.flagsLabel.Text = "Flags";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.meshIDCB);
            this.panel1.Controls.Add(this.meshLabel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 51);
            this.panel1.TabIndex = 10;
            // 
            // matIDLabel
            // 
            this.matIDLabel.AutoSize = true;
            this.matIDLabel.Location = new System.Drawing.Point(7, 163);
            this.matIDLabel.Name = "matIDLabel";
            this.matIDLabel.Size = new System.Drawing.Size(58, 13);
            this.matIDLabel.TabIndex = 2;
            this.matIDLabel.Text = "Material ID";
            // 
            // matIDCB
            // 
            this.matIDCB.FormattingEnabled = true;
            this.matIDCB.Location = new System.Drawing.Point(7, 180);
            this.matIDCB.Name = "matIDCB";
            this.matIDCB.Size = new System.Drawing.Size(49, 21);
            this.matIDCB.TabIndex = 3;
            this.matIDCB.SelectedIndexChanged += new System.EventHandler(this.matIDCB_SelectedIndexChanged);
            // 
            // renderIDLabel
            // 
            this.renderIDLabel.AutoSize = true;
            this.renderIDLabel.Location = new System.Drawing.Point(62, 163);
            this.renderIDLabel.Name = "renderIDLabel";
            this.renderIDLabel.Size = new System.Drawing.Size(56, 13);
            this.renderIDLabel.TabIndex = 2;
            this.renderIDLabel.Text = "Render ID";
            // 
            // renderIDCB
            // 
            this.renderIDCB.FormattingEnabled = true;
            this.renderIDCB.Location = new System.Drawing.Point(62, 180);
            this.renderIDCB.Name = "renderIDCB";
            this.renderIDCB.Size = new System.Drawing.Size(49, 21);
            this.renderIDCB.TabIndex = 3;
            this.renderIDCB.SelectedIndexChanged += new System.EventHandler(this.renderIDCB_SelectedIndexChanged);
            // 
            // shaderLabel
            // 
            this.shaderLabel.AutoSize = true;
            this.shaderLabel.Location = new System.Drawing.Point(117, 163);
            this.shaderLabel.Name = "shaderLabel";
            this.shaderLabel.Size = new System.Drawing.Size(55, 13);
            this.shaderLabel.TabIndex = 2;
            this.shaderLabel.Text = "Shader ID";
            // 
            // shadIDCB
            // 
            this.shadIDCB.FormattingEnabled = true;
            this.shadIDCB.Location = new System.Drawing.Point(117, 180);
            this.shadIDCB.Name = "shadIDCB";
            this.shadIDCB.Size = new System.Drawing.Size(49, 21);
            this.shadIDCB.TabIndex = 3;
            this.shadIDCB.SelectedIndexChanged += new System.EventHandler(this.shadIDCB_SelectedIndexChanged);
            // 
            // texSetIDLabel
            // 
            this.texSetIDLabel.AutoSize = true;
            this.texSetIDLabel.Location = new System.Drawing.Point(172, 163);
            this.texSetIDLabel.Name = "texSetIDLabel";
            this.texSetIDLabel.Size = new System.Drawing.Size(58, 13);
            this.texSetIDLabel.TabIndex = 2;
            this.texSetIDLabel.Text = "Tex Set ID";
            // 
            // tsetIDCB
            // 
            this.tsetIDCB.FormattingEnabled = true;
            this.tsetIDCB.Location = new System.Drawing.Point(172, 180);
            this.tsetIDCB.Name = "tsetIDCB";
            this.tsetIDCB.Size = new System.Drawing.Size(49, 21);
            this.tsetIDCB.TabIndex = 3;
            this.tsetIDCB.SelectedIndexChanged += new System.EventHandler(this.tsetIDCB_SelectedIndexChanged);
            // 
            // vsetIDLabel
            // 
            this.vsetIDLabel.AutoSize = true;
            this.vsetIDLabel.Location = new System.Drawing.Point(242, 163);
            this.vsetIDLabel.Name = "vsetIDLabel";
            this.vsetIDLabel.Size = new System.Drawing.Size(70, 13);
            this.vsetIDLabel.TabIndex = 2;
            this.vsetIDLabel.Text = "Vertex Set ID";
            // 
            // vsetIDCB
            // 
            this.vsetIDCB.FormattingEnabled = true;
            this.vsetIDCB.Location = new System.Drawing.Point(242, 180);
            this.vsetIDCB.Name = "vsetIDCB";
            this.vsetIDCB.Size = new System.Drawing.Size(49, 21);
            this.vsetIDCB.TabIndex = 3;
            this.vsetIDCB.SelectedIndexChanged += new System.EventHandler(this.vsetIDCB_SelectedIndexChanged);
            // 
            // psetIDLabel
            // 
            this.psetIDLabel.AutoSize = true;
            this.psetIDLabel.Location = new System.Drawing.Point(308, 163);
            this.psetIDLabel.Name = "psetIDLabel";
            this.psetIDLabel.Size = new System.Drawing.Size(64, 13);
            this.psetIDLabel.TabIndex = 2;
            this.psetIDLabel.Text = "Face Set ID";
            // 
            // faceSetIDCB
            // 
            this.faceSetIDCB.FormattingEnabled = true;
            this.faceSetIDCB.Location = new System.Drawing.Point(308, 180);
            this.faceSetIDCB.Name = "faceSetIDCB";
            this.faceSetIDCB.Size = new System.Drawing.Size(49, 21);
            this.faceSetIDCB.TabIndex = 3;
            this.faceSetIDCB.SelectedIndexChanged += new System.EventHandler(this.faceSetIDCB_SelectedIndexChanged);
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Location = new System.Drawing.Point(64, 141);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(227, 13);
            this.warningLabel.TabIndex = 11;
            this.warningLabel.Text = "Warning, high risk of issues from editing below!";
            // 
            // unkShort0UD
            // 
            this.unkShort0UD.Location = new System.Drawing.Point(193, 21);
            this.unkShort0UD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.unkShort0UD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.unkShort0UD.Name = "unkShort0UD";
            this.unkShort0UD.Size = new System.Drawing.Size(76, 20);
            this.unkShort0UD.TabIndex = 13;
            this.unkShort0UD.ValueChanged += new System.EventHandler(this.unkShort0UD_ValueChanged);
            // 
            // unkShort0Label
            // 
            this.unkShort0Label.AutoSize = true;
            this.unkShort0Label.Location = new System.Drawing.Point(190, 4);
            this.unkShort0Label.Name = "unkShort0Label";
            this.unkShort0Label.Size = new System.Drawing.Size(64, 13);
            this.unkShort0Label.TabIndex = 12;
            this.unkShort0Label.Text = "Unk Short 0";
            // 
            // unkByte0UD
            // 
            this.unkByte0UD.Location = new System.Drawing.Point(275, 21);
            this.unkByte0UD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.unkByte0UD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.unkByte0UD.Name = "unkByte0UD";
            this.unkByte0UD.Size = new System.Drawing.Size(76, 20);
            this.unkByte0UD.TabIndex = 15;
            this.unkByte0UD.ValueChanged += new System.EventHandler(this.unkByte0UD_ValueChanged);
            // 
            // unkByte0Label
            // 
            this.unkByte0Label.AutoSize = true;
            this.unkByte0Label.Location = new System.Drawing.Point(272, 4);
            this.unkByte0Label.Name = "unkByte0Label";
            this.unkByte0Label.Size = new System.Drawing.Size(60, 13);
            this.unkByte0Label.TabIndex = 14;
            this.unkByte0Label.Text = "Unk Byte 0";
            // 
            // unkByte1UD
            // 
            this.unkByte1UD.Location = new System.Drawing.Point(29, 73);
            this.unkByte1UD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.unkByte1UD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.unkByte1UD.Name = "unkByte1UD";
            this.unkByte1UD.Size = new System.Drawing.Size(76, 20);
            this.unkByte1UD.TabIndex = 17;
            this.unkByte1UD.ValueChanged += new System.EventHandler(this.unkByte1UD_ValueChanged);
            // 
            // unkByte1Label
            // 
            this.unkByte1Label.AutoSize = true;
            this.unkByte1Label.Location = new System.Drawing.Point(26, 56);
            this.unkByte1Label.Name = "unkByte1Label";
            this.unkByte1Label.Size = new System.Drawing.Size(60, 13);
            this.unkByte1Label.TabIndex = 16;
            this.unkByte1Label.Text = "Unk Byte 1";
            // 
            // unkShort1UD
            // 
            this.unkShort1UD.Location = new System.Drawing.Point(111, 73);
            this.unkShort1UD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.unkShort1UD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.unkShort1UD.Name = "unkShort1UD";
            this.unkShort1UD.Size = new System.Drawing.Size(76, 20);
            this.unkShort1UD.TabIndex = 19;
            this.unkShort1UD.ValueChanged += new System.EventHandler(this.unkShort1UD_ValueChanged);
            // 
            // unkShort1Label
            // 
            this.unkShort1Label.AutoSize = true;
            this.unkShort1Label.Location = new System.Drawing.Point(108, 56);
            this.unkShort1Label.Name = "unkShort1Label";
            this.unkShort1Label.Size = new System.Drawing.Size(64, 13);
            this.unkShort1Label.TabIndex = 18;
            this.unkShort1Label.Text = "Unk Short 1";
            // 
            // baseMeshNodeIdUD
            // 
            this.baseMeshNodeIdUD.Location = new System.Drawing.Point(193, 73);
            this.baseMeshNodeIdUD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.baseMeshNodeIdUD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.baseMeshNodeIdUD.Name = "baseMeshNodeIdUD";
            this.baseMeshNodeIdUD.Size = new System.Drawing.Size(76, 20);
            this.baseMeshNodeIdUD.TabIndex = 21;
            this.baseMeshNodeIdUD.ValueChanged += new System.EventHandler(this.baseMeshNodeIdUD_ValueChanged);
            // 
            // baseMeshNodeIdLabel
            // 
            this.baseMeshNodeIdLabel.AutoSize = true;
            this.baseMeshNodeIdLabel.Location = new System.Drawing.Point(190, 56);
            this.baseMeshNodeIdLabel.Name = "baseMeshNodeIdLabel";
            this.baseMeshNodeIdLabel.Size = new System.Drawing.Size(47, 13);
            this.baseMeshNodeIdLabel.TabIndex = 20;
            this.baseMeshNodeIdLabel.Text = "Node ID";
            // 
            // baseMeshDummyIdUD
            // 
            this.baseMeshDummyIdUD.Location = new System.Drawing.Point(275, 73);
            this.baseMeshDummyIdUD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.baseMeshDummyIdUD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.baseMeshDummyIdUD.Name = "baseMeshDummyIdUD";
            this.baseMeshDummyIdUD.Size = new System.Drawing.Size(76, 20);
            this.baseMeshDummyIdUD.TabIndex = 23;
            this.baseMeshDummyIdUD.ValueChanged += new System.EventHandler(this.baseMeshDummyIdUD_ValueChanged);
            // 
            // baseMeshDummyIdLabel
            // 
            this.baseMeshDummyIdLabel.AutoSize = true;
            this.baseMeshDummyIdLabel.Location = new System.Drawing.Point(272, 56);
            this.baseMeshDummyIdLabel.Name = "baseMeshDummyIdLabel";
            this.baseMeshDummyIdLabel.Size = new System.Drawing.Size(40, 13);
            this.baseMeshDummyIdLabel.TabIndex = 22;
            this.baseMeshDummyIdLabel.Text = "Part ID";
            // 
            // unkInt0UD
            // 
            this.unkInt0UD.Location = new System.Drawing.Point(29, 118);
            this.unkInt0UD.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.unkInt0UD.Minimum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            -2147483648});
            this.unkInt0UD.Name = "unkInt0UD";
            this.unkInt0UD.Size = new System.Drawing.Size(76, 20);
            this.unkInt0UD.TabIndex = 25;
            this.unkInt0UD.ValueChanged += new System.EventHandler(this.unkInt0UD_ValueChanged);
            // 
            // unkInt0Label
            // 
            this.unkInt0Label.AutoSize = true;
            this.unkInt0Label.Location = new System.Drawing.Point(26, 101);
            this.unkInt0Label.Name = "unkInt0Label";
            this.unkInt0Label.Size = new System.Drawing.Size(51, 13);
            this.unkInt0Label.TabIndex = 24;
            this.unkInt0Label.Text = "Unk Int 0";
            // 
            // MeshStructEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.unkInt0UD);
            this.Controls.Add(this.unkInt0Label);
            this.Controls.Add(this.baseMeshDummyIdUD);
            this.Controls.Add(this.baseMeshDummyIdLabel);
            this.Controls.Add(this.baseMeshNodeIdUD);
            this.Controls.Add(this.baseMeshNodeIdLabel);
            this.Controls.Add(this.unkShort1UD);
            this.Controls.Add(this.unkShort1Label);
            this.Controls.Add(this.unkByte1UD);
            this.Controls.Add(this.unkByte1Label);
            this.Controls.Add(this.unkByte0UD);
            this.Controls.Add(this.unkByte0Label);
            this.Controls.Add(this.unkShort0UD);
            this.Controls.Add(this.unkShort0Label);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.faceSetIDCB);
            this.Controls.Add(this.psetIDLabel);
            this.Controls.Add(this.vsetIDCB);
            this.Controls.Add(this.vsetIDLabel);
            this.Controls.Add(this.tsetIDCB);
            this.Controls.Add(this.texSetIDLabel);
            this.Controls.Add(this.shadIDCB);
            this.Controls.Add(this.shaderLabel);
            this.Controls.Add(this.renderIDCB);
            this.Controls.Add(this.renderIDLabel);
            this.Controls.Add(this.matIDCB);
            this.Controls.Add(this.matIDLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flagsUD);
            this.Controls.Add(this.flagsLabel);
            this.Name = "MeshStructEditor";
            this.Size = new System.Drawing.Size(378, 204);
            ((System.ComponentModel.ISupportInitialize)(this.flagsUD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unkShort0UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkByte0UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkByte1UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkShort1UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseMeshNodeIdUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseMeshDummyIdUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unkInt0UD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox meshIDCB;
        private System.Windows.Forms.Label meshLabel;
        private System.Windows.Forms.NumericUpDown flagsUD;
        private System.Windows.Forms.Label flagsLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label matIDLabel;
        private System.Windows.Forms.ComboBox matIDCB;
        private System.Windows.Forms.Label renderIDLabel;
        private System.Windows.Forms.ComboBox renderIDCB;
        private System.Windows.Forms.Label shaderLabel;
        private System.Windows.Forms.ComboBox shadIDCB;
        private System.Windows.Forms.Label texSetIDLabel;
        private System.Windows.Forms.ComboBox tsetIDCB;
        private System.Windows.Forms.Label vsetIDLabel;
        private System.Windows.Forms.ComboBox vsetIDCB;
        private System.Windows.Forms.Label psetIDLabel;
        private System.Windows.Forms.ComboBox faceSetIDCB;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.NumericUpDown unkShort0UD;
        private System.Windows.Forms.Label unkShort0Label;
        private System.Windows.Forms.NumericUpDown unkByte0UD;
        private System.Windows.Forms.Label unkByte0Label;
        private System.Windows.Forms.NumericUpDown unkByte1UD;
        private System.Windows.Forms.Label unkByte1Label;
        private System.Windows.Forms.NumericUpDown unkShort1UD;
        private System.Windows.Forms.Label unkShort1Label;
        private System.Windows.Forms.NumericUpDown baseMeshNodeIdUD;
        private System.Windows.Forms.Label baseMeshNodeIdLabel;
        private System.Windows.Forms.NumericUpDown baseMeshDummyIdUD;
        private System.Windows.Forms.Label baseMeshDummyIdLabel;
        private System.Windows.Forms.NumericUpDown unkInt0UD;
        private System.Windows.Forms.Label unkInt0Label;
    }
}
