using System;
using System.Collections.Generic;
using System.Text;

namespace ZXY
{
    public class UTMProj : IProj
    {
        private GaussProj gaussProj;
        private double k = 0.9996;

        public UTMProj(Ellipsoid ellipsoid)
        {
            gaussProj = new GaussProj(ellipsoid);
        }

        public (double x, double y) BLtoXY(double B, double L, double L0, double ykm, int Ny)
        {
            var xy = gaussProj.BLtoXY(B, L, L0, ykm, Ny);
            return (k* xy.x, k*xy.y);
        }

        public (double B, double L) XYtoBL(double x, double y, double L0, double ykm, int Ny)
        {
            throw new NotImplementedException();
        }
    }
}
