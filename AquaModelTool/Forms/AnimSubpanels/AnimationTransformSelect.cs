using AquaModelLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AquaModelTool
{
    public partial class AnimationTransformSelect : Form
    {
        private AquaMotion motion = new AquaMotion();
        private int maxRow = 13;        //Maximum allowable row for radiobuttons in the form
        private int radioXStart = 12;   //Starting x of all radiobuttons in the form
        private int radioYStart = 3;    //Starting y of all radiobuttons in the form 
        public int currentChoice;       //Value to return on closing the form based on final selection
        public List<RadioButton> transformButtons;

        public AnimationTransformSelect(int type)
        {
            InitializeComponent();

            //Generate buttons
            int buttonTracker = 0;
            int xAddition = 0;
            int yAddition = 0;
            List<int> activeCheck;
            transformButtons = new List<RadioButton>();

            //Set the types to activate for form based on motion type
            switch (type)
            {
                case AquaMotion.stdAnim:
                case AquaMotion.stdPlayerAnim:
                    currentChoice = 0x1;
                    activeCheck = motion.standardTypes;
                    break;
                case AquaMotion.cameraAnim:
                    currentChoice = 0x1;
                    activeCheck = motion.cameraTypes;
                    break;
                case AquaMotion.materialAnim:
                    currentChoice = 0x8;
                    activeCheck = motion.materialTypes;
                    break;
                default:
                    MessageBox.Show("Unknown animation type. Please report!");
                    throw new Exception();
            }

            //Go through keys in order until the biggest key in the list
            for (int i = 0; i < motion.keyTypeNames.Keys.Max(); i++)
            {
                //Move to the next column if the row is full
                if(buttonTracker >= maxRow)
                {
                    buttonTracker = 0;
                    yAddition = 0;
                    xAddition += 200;
                }

                //Check if the key is valid
                if(motion.keyTypeNames.ContainsKey(i))
                {
                    RadioButton rButton = new RadioButton();
                    rButton.AutoSize = true;
                    rButton.Text = motion.keyTypeNames[i];
                    rButton.Tag = i;
                    rButton.Location = new Point(radioXStart + xAddition, radioYStart + yAddition);
                    rButton.CheckedChanged += changeChoice;

                    if(activeCheck.Contains(i))
                    {
                        rButton.Enabled = true;
                    } else
                    {
                        rButton.Enabled = false;
                    }
                    
                    yAddition += 16;
                    buttonTracker++;
                    this.Controls.Add(rButton);
                    transformButtons.Add(rButton);
                }
            }
        }

        private void changeChoice(object sender, EventArgs e)
        {
            currentChoice = (int)((RadioButton)sender).Tag;
        }
    }
}
