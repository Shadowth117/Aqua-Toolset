using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AquaModelTool
{
    public class AquaUICommon
    {
        public AquaModelLibrary.AquaUtil aqua = new AquaModelLibrary.AquaUtil();

        public AquaUICommon()
        {
        }


        public string confirmFile(string str = null)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select a PSO2 file",
                Filter = "All Supported Files|*.aqp;*.aqo;*.trp;*.tro;*.aqm;*.aqc;*.aqv;*.aqw;*.trm;*.trv;*.trw;*.aqe;*.bti" +
                         "|PSO2 Model Files (*.aqp, *.aqo, *.trp, *.tro)|*.aqp;*.aqo;*.trp;*.tro" +
                         "|PSO2 Motion Files (*.aqm, *.aqv, *.aqw, *.aqc, *.trm, *.trv, *.trw)|*.aqm;*.aqv;*.aqw;*.aqc;*.trm;*.trv;*.trw" +
                         "|PSO2 Motion Config BTI Files (*.bti)|*.bti" +
                         "|PSO2 Effect/Particle Files (*.aqe)|*.aqe"
            };
            if(str == null)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    str = openFileDialog.FileName;
                }
            }
            return str;
        }

        public void setAllTransparent(bool setToModels)
        {
            if (setToModels)
            {
                for (int i = 0; i < aqua.aquaModels.Count; i++)
                {
                    for (int j = 0; j < aqua.aquaModels[i].models.Count; j++)
                    {
                        for (int r = 0; r < aqua.aquaModels[i].models[j].rendList.Count; r++)
                        {
                            var rend = aqua.aquaModels[i].models[j].rendList[r];
                            
                            rend.int_0C = 1;
                            rend.unk8 = 1;
                            rend.alphaCutoff = 0;
                            aqua.aquaModels[i].models[j].rendList[r] = rend;
                        }
                        for (int m = 0; m < aqua.aquaModels[i].models[j].mateList.Count; m++)
                        {
                            var mate = aqua.aquaModels[i].models[j].mateList[m];
                            mate.alphaType.SetString("blendalpha");
                            aqua.aquaModels[i].models[j].mateList[m] = mate;
                        }
                    }
                }
            }
        }

        public void averageNormals()
        {
            for (int i = 0; i < aqua.aquaModels.Count; i++)
            {
                for(int j = 0; j < aqua.aquaModels[i].models.Count; j++)
                {
                    AquaModelLibrary.AquaObjectMethods.CalcUNRMs(aqua.aquaModels[i].models[j], true, false);
                }
            }
        }

        public void toNIFLModel(string str)
        {
            //These will be output as .**p regardless and if the user really wants the o version, they can do it in 2 seconds in a hex editor.
            str = str.Replace(".aqo", ".aqp");
            str = str.Replace(".tro", ".trp");
            
            if(aqua.aquaModels[0].models[0].objc.type > 0xC2A)
            {
                aqua.WriteNGSNIFLModel(str, str);
            } else
            {
                aqua.WriteClassicNIFLModel(str, str);
            }
        }

        public void toVTBFModel(string str)
        {
            //These will be output as .**p regardless and if the user really wants the o version, they can do it in 2 seconds in a hex editor.
            str = str.Replace(".aqo", ".aqp");
            str = str.Replace(".tro", ".trp");

            aqua.WriteVTBFModel(str, str);
        }

        public static DialogResult ShowInputDialog(ref decimal input)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 100);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Spirefier";

            System.Windows.Forms.Label label = new Label();
            label.Text = "Please specify in meters where to extend from.";
            label.Size = new System.Drawing.Size(195, 30);
            label.Location = new System.Drawing.Point(5, 5);
            inputBox.Controls.Add(label);

            System.Windows.Forms.NumericUpDown nud = new NumericUpDown();
            nud.DecimalPlaces = 6;
            nud.Maximum = decimal.MaxValue;
            nud.Minimum = decimal.MinValue;
            nud.Increment = 0.000001m;
            nud.Value = 0.5m;
            nud.Location = new System.Drawing.Point(20, 35);
            inputBox.Controls.Add(nud);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 59);
            inputBox.Controls.Add(okButton);

            inputBox.AcceptButton = okButton;

            DialogResult result = inputBox.ShowDialog();
            input = nud.Value;
            return result;
        }
    }
}
