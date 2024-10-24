using System;
using System.Collections.Generic;
using System.Text;

namespace ProjApp.Library
{
    public class GaussProj : IProj
    {
        private Ellipsoid ellipsoid;

        public GaussProj(Ellipsoid ellipsoid)
        {
            this.ellipsoid = ellipsoid;
        }

        public (double X, double Y, double gamma, double m) BLtoXY(double B, double L, double L0, double YKM, int Zone)
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
            double gamma = sinB * l * (
                      1
                      + (1 + 3 * g2 + 2 * g4) / 3.0 * cosB2 * l2
                      + (2 - t2) / 15.0 * cosB4 * l4
                      );
            double m = 1 + 0.5 * l2 * cosB2 * (1 + g2) + l4 * cosB4 * (5 - 4 * t2) / 24.0;

            return (x, y + YKM * 1000 + Zone * 1000000, gamma, m);
        }

        public (double B, double L, double gamma, double m) XYtoBL(double x, double y, double L0, double YKM, int Zone)
        {
            y = y - YKM * 1000 - Zone * 1000000;

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

            double gamma = tf / Nf * y * (
                     1
                     - (1 + tf2 - gf2) / 3.0 / Nf2 * y2
                     + (2 + 5 * tf2 + 3 * tf4) / 15.0 / Nf4 * y4
                     );

            double sinB = Math.Sin(B);
            double sinB2 = sinB * sinB;
            double R = ellipsoid.funR(sinB2);
            double R2 = R * R;
            double R4 = R2 * R2;
            double m = 1 + y2 / 2.0 / R2 + y4 / 24.0 / R4;

            return (B, l + L0, gamma, m);
        }
    }
}