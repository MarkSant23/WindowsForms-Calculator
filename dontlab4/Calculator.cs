using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dontlab4
{
    public class failedParseEventArgs : EventArgs
    {
        private string eventInfo;
        public failedParseEventArgs(string text)
        {
            eventInfo = text;
        }
        public string GetInfo()
        {
            return eventInfo;
        }
    }
    public class Calculator
    {
        public delegate void failedParseEventHandler(object source, failedParseEventArgs e);
        
        public delegate double GetOperationCallback(double Operand1, double Operand2);
        
        public event failedParseEventHandler failedParse;
        
        public string OperandA { get; set; }
        public string OperandB { get; set; }
        
        public Calculator(string OpA, string OpB)
        {
            OperandA = OpA;
            OperandB = OpB;
        }
        public double Izracun(GetOperationCallback RacOperacija)
        {
            Boolean resultBool;
            double a, b;
            resultBool = Double.TryParse(OperandA, out a);
            resultBool = Double.TryParse(OperandB, out b);

            if (!resultBool && failedParse != null)
            {
                failedParse(this, new failedParseEventArgs("Error input!"));
            }
            double result;
            result=RacOperacija(a,b);
            return result;
        }
    }
}
