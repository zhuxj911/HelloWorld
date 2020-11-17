using System;
using System.Collections.Generic;
using System.Text;

namespace ZXY
{
    /// <summary>
    /// 参考椭球
    /// </summary>
    public class Ellipsoid
    {
        private double a;
        private double f; //1/f = (a-b)/a
        private double b;
        private double e2;
        private double eT2;
       
        private double e4;
        private double e6;
        private double e8;

        private double A0;
        private double A2;
        private double A4;
        private double A6;
        private double A8;

        /// <summary>
        /// 初始化参考椭球
        /// </summary>
        /// <param name="a">长半轴</param>
        /// <param name="f">扁率的分母</param>
        public Ellipsoid(double a, double f)
        {
            this.a = a;
            this.f = f;
          
            this.b = a - a / f;
            this.e2 = 1 - b / a * b / a;
            this.eT2 = a / b * a / b - 1;
           
            e4 = e2 * e2;
            e6 = e4 * e2;
            e8 = e6 * e2;

            double m0 = a * (1 - e2);
            this.A0 = (1
                + 0.75 * e2
                + 45.0 / 64.0 * e4
                + 175.0 / 256.0 * e6
                + 11025.0 / 16384.0 * e8) * m0;
            this.A2 = -0.5 * (0.75 * e2
                + 15.0 / 16.0 * e4
                + 525.0 / 512.0 * e6
                + 2205.0 / 2048.0 * e8) * m0;
            this.A4 = 0.25 * (15.0 / 64.0 * e4 
                + 105.0 / 256.0 * e6 
                + 2205.0 / 4096.0 * e8) * m0;
            this.A6 = -(35.0 / 512.0 * e6 + 315.0 / 2048.0 * e8) * m0 / 6.0;
            this.A8 = 315.0 / 16384.0 * e8 * m0 / 8.0;
        }

        private double funM(double sinB)
        {
            return a * (1 - e2) / Math.Pow(1 - e2 * sinB * sinB, -1.5);
        }

        private double funN(double sinB)
        {
            return a / Math.Sqrt(1 - e2 * sinB * sinB);
        }

        private double funX(double B)
        {
            return A0 * B 
                + A2 * Math.Sin(2 * B)
                + A4 * Math.Sin(4 * B)
                + A6 * Math.Sin(6 * B)
                + A8 * Math.Sin(8 * B);
        }

        /// <summary>
        /// 高斯投影正算
        /// </summary>
        /// <param name="B">纬度， 单位：弧度</param>
        /// <param name="l">经差, 单位：弧度</param>
        /// <returns>（x, y）</returns>
        public (double x, double y) BltoXy(double B, double l)
        {
            double sinB  = Math.Sin(B);
            double cosB  = Math.Cos(B);
            double cosB2 = cosB * cosB;
            double cosB4 = cosB2 * cosB2;

            double l2 = l * l;
            double l4 = l2 * l2;

            double t = Math.Tan(B);
            double t2 = t * t;
            double t4 = t2 * t2;

            double g2 = eT2 * cosB2;
            double g4 = g2 * g2;

            double X = funX(B);
            double N = funN(sinB);

            double x = X + N * sinB * cosB * l2 * (
                0.5
                + cosB2 / 24.0 * (5 - t2 + 9 * g2 + 4 * g4) * l2
                + cosB4 / 720.0 * (61 - 58 * t2 + t4) * l4);
            double y = N * cosB * l * (
                1
                + cosB2 / 6.0 * l2 * (1 - t2 + g2)
                + cosB4 / 120.0 * l4 * (5 - 18 * t2 + t4 + 14 * g2 - 58 * g2 * t2));
            return (x, y);
        }

        /// <summary>
        /// 高斯投影反算
        /// </summary>
        /// <param name="x">X(N)</param>
        /// <param name="y">Y(E), 真实自然坐标</param>
        /// <returns>（B, l）</returns>
        public (double B, double l) XytoBl(double x, double y)
        {
            return (0, 0);
        }
    }
}
