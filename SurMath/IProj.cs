using System;
using System.Collections.Generic;
using System.Text;

namespace ZXY
{
    public interface IProj
    {
        (double x, double y) BLtoXY(double B, double L, double L0, double ykm, int Ny);

        (double B, double L) XYtoBL(double x, double y, double L0, double ykm, int Ny);
    }
}
