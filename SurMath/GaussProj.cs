using System;
using System.Collections.Generic;
using System.Text;

namespace ZXY
{
    public class GaussProj : IProj
    {
        private Ellipsoid ellipsoid;

        public GaussProj(Ellipsoid ellipsoid)
        {
            this.ellipsoid = ellipsoid;
        }

        public (double x, double y) BLtoXY(double B, double L, double L0, double ykm, int Ny)
        {
            double l = L - L0;

            double sinB = Math.Sin(B);
            double cosB = Math.Cos(B);
            double cosB2 = cosB * cosB;
            double cosB4 = cosB2 * cosB2;

            double t = Math.Tan(B);
            double t2 = t * t;
            double t4 = t2 * t2;

            double g2 = ellipsoid.funG2(cosB2);
            double g4 = g2 * g2;

            double l2 = l * l;
            double l4 = l2 * l2;

            double N = ellipsoid.funN(sinB * sinB);

            double x = ellipsoid.funX(B) + N * sinB * cosB * l2 * (
                0.5
                + cosB2 / 24.0 * (5 - t2 + 9 * g2 + 4 * g4) * l2
                + cosB4 / 720.0 * (61 - 58 * t2 + t4) * l4);
            double y = N * cosB * l * (
               1
               + cosB2 / 6.0 * (1 - t2 + g2) * l2
               + cosB4 / 120.0 * (5 - 18 * t2 + t4 + 14 * g2 - 58 * g2 * t2) * l4);
            return (x, y + ykm * 1000 + Ny * 1000000);
        }

        public (double B, double L) XYtoBL(double x, double y, double L0, double ykm, int Ny)
        {
            y = y - ykm * 1000 - Ny * 1000000;

            double Bf = ellipsoid.funBf(x);
            double tf = Math.Tan(Bf);
            double tf2 = tf * tf;
            double tf4 = tf2 * tf2;

            double sinBf = Math.Sin(Bf);
            double sinBf2 = sinBf * sinBf;

            double Mf = ellipsoid.funM(sinBf2);
            double Nf = ellipsoid.funN(sinBf2);
            double Nf2 = Nf * Nf;
            double Nf4 = Nf2 * Nf2;

            double cosBf = Math.Cos(Bf);
            double gf2 = ellipsoid.funG2(cosBf * cosBf);

            double y2 = y * y;
            double y4 = y2 * y2;

            double B = Bf + tf / Mf / Nf * y2 * (
                -0.5
                + y2 / 24.0 / Nf2 * (5 + 3 * tf2 + gf2 - 9 * gf2 * tf2)
                - y4 / 720.0 / Nf4 * (61 + 90 * tf2 + 45 * tf4)
                );
            double l = y / Nf / cosBf * (
                1
                - y2 / 6.0 / Nf2 * (1 + 2 * tf2 + gf2)
                + y4 / 120.0 / Nf4 * (5 + 28 * tf2 + 24 * tf4 + 6 * gf2 + 8 * gf2 * tf2)
                );

            return (B, l + L0);
        }
    }
}
