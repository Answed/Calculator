using System.Net.Http.Headers;

namespace Calculator
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private CalculatorLogic calculatorLogic = new CalculatorLogic();

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button0 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.buttonDot = new System.Windows.Forms.Button();
            this.buttonEqual = new System.Windows.Forms.Button();
            this.buttonMulti = new System.Windows.Forms.Button();
            this.buttonSub = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDiv = new System.Windows.Forms.Button();
            this.buttonSqare = new System.Windows.Forms.Button();
            this.buttonLeftClip = new System.Windows.Forms.Button();
            this.buttonRightClip = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonPowerOf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button0
            // 
            this.button0.Location = new System.Drawing.Point(98, 459);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(70, 70);
            this.button0.TabIndex = 0;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.button0_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 70);
            this.button1.TabIndex = 1;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(98, 383);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 70);
            this.button2.TabIndex = 2;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 383);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 70);
            this.button3.TabIndex = 3;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(22, 307);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 70);
            this.button4.TabIndex = 4;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(98, 307);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(70, 70);
            this.button5.TabIndex = 5;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(174, 307);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(70, 70);
            this.button6.TabIndex = 6;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(22, 231);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(70, 70);
            this.button7.TabIndex = 7;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(98, 231);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(70, 70);
            this.button8.TabIndex = 8;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(174, 231);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(70, 70);
            this.button9.TabIndex = 9;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // buttonDot
            // 
            this.buttonDot.Location = new System.Drawing.Point(174, 459);
            this.buttonDot.Name = "buttonDot";
            this.buttonDot.Size = new System.Drawing.Size(70, 70);
            this.buttonDot.TabIndex = 10;
            this.buttonDot.Text = ".";
            this.buttonDot.UseVisualStyleBackColor = true;
            this.buttonDot.Click += new System.EventHandler(this.buttonDot_Click);
            // 
            // buttonEqual
            // 
            this.buttonEqual.Location = new System.Drawing.Point(250, 459);
            this.buttonEqual.Name = "buttonEqual";
            this.buttonEqual.Size = new System.Drawing.Size(70, 70);
            this.buttonEqual.TabIndex = 14;
            this.buttonEqual.Text = "=";
            this.buttonEqual.UseVisualStyleBackColor = true;
            this.buttonEqual.Click += new System.EventHandler(this.buttonEqual_Click);
            // 
            // buttonMulti
            // 
            this.buttonMulti.Location = new System.Drawing.Point(250, 231);
            this.buttonMulti.Name = "buttonMulti";
            this.buttonMulti.Size = new System.Drawing.Size(70, 70);
            this.buttonMulti.TabIndex = 13;
            this.buttonMulti.Text = "*";
            this.buttonMulti.UseVisualStyleBackColor = true;
            this.buttonMulti.Click += new System.EventHandler(this.buttonMulti_Click);
            // 
            // buttonSub
            // 
            this.buttonSub.Location = new System.Drawing.Point(250, 307);
            this.buttonSub.Name = "buttonSub";
            this.buttonSub.Size = new System.Drawing.Size(70, 70);
            this.buttonSub.TabIndex = 12;
            this.buttonSub.Text = "-";
            this.buttonSub.UseVisualStyleBackColor = true;
            this.buttonSub.Click += new System.EventHandler(this.buttonSub_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(250, 383);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(70, 70);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.Text = "+";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDiv
            // 
            this.buttonDiv.Location = new System.Drawing.Point(250, 155);
            this.buttonDiv.Name = "buttonDiv";
            this.buttonDiv.Size = new System.Drawing.Size(70, 70);
            this.buttonDiv.TabIndex = 18;
            this.buttonDiv.Text = "/";
            this.buttonDiv.UseVisualStyleBackColor = true;
            this.buttonDiv.Click += new System.EventHandler(this.buttonDiv_Click);
            // 
            // buttonSqare
            // 
            this.buttonSqare.Location = new System.Drawing.Point(22, 155);
            this.buttonSqare.Name = "buttonSqare";
            this.buttonSqare.Size = new System.Drawing.Size(70, 70);
            this.buttonSqare.TabIndex = 15;
            this.buttonSqare.Text = "x^2";
            this.buttonSqare.UseVisualStyleBackColor = true;
            this.buttonSqare.Click += new System.EventHandler(this.buttonSqare_Click);
            // 
            // buttonLeftClip
            // 
            this.buttonLeftClip.Location = new System.Drawing.Point(98, 155);
            this.buttonLeftClip.Name = "buttonLeftClip";
            this.buttonLeftClip.Size = new System.Drawing.Size(70, 70);
            this.buttonLeftClip.TabIndex = 16;
            this.buttonLeftClip.Text = "(";
            this.buttonLeftClip.UseVisualStyleBackColor = true;
            this.buttonLeftClip.Click += new System.EventHandler(this.buttonLeftClip_Click);
            // 
            // buttonRightClip
            // 
            this.buttonRightClip.Location = new System.Drawing.Point(174, 155);
            this.buttonRightClip.Name = "buttonRightClip";
            this.buttonRightClip.Size = new System.Drawing.Size(70, 70);
            this.buttonRightClip.TabIndex = 17;
            this.buttonRightClip.Text = ")";
            this.buttonRightClip.UseVisualStyleBackColor = true;
            this.buttonRightClip.Click += new System.EventHandler(this.buttonRightClip_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(22, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(298, 61);
            this.textBox1.TabIndex = 19;
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(250, 79);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(70, 70);
            this.buttonDel.TabIndex = 20;
            this.buttonDel.Text = "DEL";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(174, 79);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(70, 70);
            this.buttonClear.TabIndex = 21;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonPowerOf
            // 
            this.buttonPowerOf.Location = new System.Drawing.Point(22, 79);
            this.buttonPowerOf.Name = "buttonPowerOf";
            this.buttonPowerOf.Size = new System.Drawing.Size(70, 70);
            this.buttonPowerOf.TabIndex = 22;
            this.buttonPowerOf.Text = "x^n";
            this.buttonPowerOf.UseVisualStyleBackColor = true;
            this.buttonPowerOf.Click += new System.EventHandler(this.buttonPowerOf_Click);
            // 
            // MainWindow
            // 
            this.ClientSize = new System.Drawing.Size(348, 551);
            this.Controls.Add(this.buttonPowerOf);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonDiv);
            this.Controls.Add(this.buttonSqare);
            this.Controls.Add(this.buttonLeftClip);
            this.Controls.Add(this.buttonRightClip);
            this.Controls.Add(this.buttonEqual);
            this.Controls.Add(this.buttonMulti);
            this.Controls.Add(this.buttonSub);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonDot);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button0);
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Button button0;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button buttonDot;
        private Button buttonEqual;
        private Button buttonMulti;
        private Button buttonSub;
        private Button buttonAdd;
        private Button buttonDiv;
        private Button buttonSqare;
        private Button buttonLeftClip;
        private Button buttonRightClip;
        private TextBox textBox1;
        private Button buttonDel;
        private Button buttonClear;
        private Button buttonPowerOf;
    }
}