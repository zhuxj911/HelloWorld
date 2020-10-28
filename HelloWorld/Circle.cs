using System;
using System.Collections.Generic;
using System.Text;

namespace DrawShape
{
    public class Circle : Shape
    {       
        private double r; 

        //private SPoint center;

        public double R
        {
            get => r;
            set
            {
                if (value >= 0)
                {
                    r = value;
                    length = Math.PI * r * 2;
                    area = Math.PI * r * r;
                }
            }
        }

        public Circle(double r)
        {
            this.R = r;
        } 

        public override string ToString()
        {        
            return $"Circle:\n半径={R}，面积={Area}， 周长={this.Length}";
        }

        public override void Drawing()
        {
            Console.WriteLine(this);
        }
    }
}
