using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    internal class _11
    {
        public class Calculator
    {
            private double plus;
                private double minus;
            private double multi;
            private double devide;
            public event Action<int> Oncal;
            public void SetCommand(double left, char open, double right)
            {
                
                


            }
            public double Equal()
            {
                
            }
            static void Main(string[] args) 
            {
                Calculator c = new Calculator();
                c.SetCommand(2.3, '+', 3.5);
                double result = c.Equal();
            }
    }
}


