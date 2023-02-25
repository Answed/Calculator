using System.Diagnostics;

namespace Calculator
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            MathOperator("/");
        }

        private void buttonMulti_Click(object sender, EventArgs e)
        {
            MathOperator("*");
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            MathOperator("-");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            MathOperator("+");
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
        }

        private void buttonLeftClip_Click(object sender, EventArgs e)
        {
            textBox1.Text += "(";
            calculatorLogic.AddClampToList(textBox1.Text);
        }

        private void buttonRightClip_Click(object sender, EventArgs e)
        {
            textBox1.Text += ")";
            calculatorLogic.AddItemsToItemsList(textBox1.Text);
        }

        private void buttonSqare_Click(object sender, EventArgs e)
        {
            textBox1.Text += "^";
            calculatorLogic.AddItemsToItemsList(textBox1.Text);
            textBox1.Text += "2";
        }

        // Delets the last Input made in the Textfield.
        private void buttonDel_Click(object sender, EventArgs e)
        {
            // The If Statement ensures that the Index doesen't get out of bounds.
            if (textBox1.Text.Length >= 1)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1); // Will break the code when you remove a math operator 
            }
        }

        // Clears/Resets the string from the text box.
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calculatorLogic.ClearList();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            calculatorLogic.AddLastItemToList(textBox1.Text);
            textBox1.Text = calculatorLogic.Calculate();
        }

        private void buttonPowerOf_Click(object sender, EventArgs e)
        {
            textBox1.Text += "^";
            calculatorLogic.AddItemsToItemsList(textBox1.Text);
        }

        private void MathOperator(string mathOperator) // Just delets a lot of redundant code 
        {
            textBox1.Text += mathOperator;
            calculatorLogic.AddItemsToItemsList(textBox1.Text);
        }
    }
}