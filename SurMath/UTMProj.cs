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

        public (double X, double Y, double gamma, double m) BLtoXY(double B, double L, double L0, double YKM, int Zone)
        {
            var xy = gaussProj.BLtoXY(B, L, L0, YKM, Zone);
            return (k* xy.X, k*xy.Y, xy.gamma, xy.m);
        }

        public (double B, double L, double gamma, double m) XYtoBL(double X, double Y, double L0, double YKM, int Zone)
        {
            throw new NotImplementedException();
        }
    }
}
