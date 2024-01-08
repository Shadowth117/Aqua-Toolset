namespace AquaModelTool
{
    public partial class TextBoxPopUp : Form
    {
        public TextBoxPopUp()
        {
            InitializeComponent();
        }

        public TextBoxPopUp(int limit)
        {
            InitializeComponent();
            this.textBox1.MaxLength = limit;
        }
    }
}
