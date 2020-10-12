using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    public class Circle
    {       
        private double r;     
        private double c;     
        private double a;

        private SPoint center;

        public double R
        {
            get => r;
            set
            {
                if (value >= 0)
                {
                    r = value;
                    c = Math.PI * r * 2;
                    a = Math.PI * r * r;
                }
            }
        }

        public Circle(double r)
        {
            this.R = r;
        }

        public double Area
        {
            get => a;
        }

        public double Length
        {
            get => c;
        }

        public override string ToString()
        {        
            return $"圆的半径{R}，面积{Area}， 周长{this.Length}";
        }
    }
}
