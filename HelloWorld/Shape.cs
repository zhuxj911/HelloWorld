using System;
using System.Collections.Generic;
using System.Text;

namespace DrawShape
{
    public abstract class Shape : IShape, IDrawing
    {
        protected double length;
        protected double area;

        public double Area { get => area; }
        public double Length { get => length; }

        public abstract void Drawing();
    }
}
