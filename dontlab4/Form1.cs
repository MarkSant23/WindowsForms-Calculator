using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dontlab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = new[] { "+", "-", "*", "/" };
            result1label.Text = "Result";
        }
        static double Add(double Operand1, double Operand2)
        {
            return Operand1 + Operand1;
        }        
        static double Subtract(double Operand1, double Operand2)
        {
            return Operand1 - Operand2;
        }        
        static double Multiply(double Operand1, double Operand2)
        {
            return Operand1 * Operand2;
        }        
        public static double Devide(double Operand1, double Operand2)
        {
            try
            {
                if (Operand2 != 0)
                    return Operand1 / Operand2;
            }
            catch (DivideByZeroException ex)
            {
                //Console.WriteLine("{0} Exception caught.", ex);
                MessageBox.Show(ex.Message);
            }
            throw new DivideByZeroException();
        }
        void greskaPriUnosu(object source,failedParseEventArgs e)
        {
            MessageBox.Show("Error wrong input");
            result1label.Text = e.GetInfo();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Calculator calc = new Calculator(textBox1.Text, textBox2.Text);
            calc.failedParse += new Calculator.failedParseEventHandler(greskaPriUnosu);
            string result=result1label.Text;
            switch (comboBox1.SelectedItem)
            {
                case "+":
                    result=calc.Izracun(Add).ToString();
                    break;
                case "-":
                    result=calc.Izracun(Subtract).ToString();
                    break;
                case "*":
                    result=calc.Izracun(Multiply).ToString();
                    break;
                case "/":
                    result=calc.Izracun(Devide).ToString();
                    break;
            }
            result1label.Text = result;
        }
    }
}
