using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DrawShape
{
    public interface IShape
    {
        double Area { get; }
        double Length { get;}
    }
}
