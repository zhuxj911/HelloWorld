using System;
using System.Collections.Generic;
using System.Text;

namespace ZXY
{
    /// <summary>
    /// 参考椭球类
    /// </summary>
    public class Ellipsoid
    {
        private double a;
        private double f; //扁率的分母 1/f = (a-b)/a

        private double b;
        private double e2;
        private double eT2;

        private double m0;
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
        private Ellipsoid(double a, double f)
        {
            this.a = a;
            this.f = f;
           
            this.b = a - a / f;
            this.e2 = 1 - b / a * b / a;
            this.eT2 = a / b * a / b -1;

            m0 = a * (1 - e2);
            e4 = e2 * e2;
            e6 = e4 * e2;
            e8 = e6 * e2;

            A0 = (1 
                + 0.75 * e2 
                + 45.0 / 64.0 * e4
                + 175.0 / 256.0 * e6 
                + 11025.0 / 16384.0 * e8) * m0;
            A2 = -0.5 * (0.75 * e2 
                + 15.0 / 16.0 * e4
                + 525.0 / 512.0 * e6 
                + 2205.0 / 2048.0 * e8) * m0;
            A4 = 0.25 * (15.0 / 64.0 * e4 
                + 105.0 / 256.0 * e6
                + 2205.0 / 4096.0 * e8) * m0; ;
            A6 = -(35.0 / 512.0 * e6 
                + 315.0 / 2048.0 * e8) * m0 / 6.0;
            A8 = 315.0 / 16384.0 * e8 * m0 / 8.0;
        }
        
        //1 构造函数定义为private，防止外部类直接new生成对象
        //2 在本类中定义静态的工厂方法来生成相应的对象
        public static Ellipsoid CreateBeijing1954()
        {
            return  new Ellipsoid(6378245, 298.3);
        }

        public static Ellipsoid CreateXiAn1980()
        {
            return new Ellipsoid(6378140, 298.257);
        }
        public static Ellipsoid CreateCGCS2000()
        {
            return new Ellipsoid(6378137, 298.257222101);
        }

        public static Ellipsoid CreateWGS1984()
        {
            return new Ellipsoid(6378137, 298.257223563);
        }

        public static Ellipsoid CreateCustom(double a , double f)
        {
            return new Ellipsoid(a, f);
        }

        public double funX(double B)
        {
            return A0 * B
                + A2 * Math.Sin(2 * B)
                + A4 * Math.Sin(4 * B)
                + A6 * Math.Sin(6 * B)
                + A8 * Math.Sin(8 * B);
        }

        public double funBf(double x)
        {
            double B0 = x / A0, Bi = 0;

            int i = 0;
            while (i < 1000)
            {
                i++;
                Bi = (x - (
                   +A2 * Math.Sin(2 * B0)
                   + A4 * Math.Sin(4 * B0)
                   + A6 * Math.Sin(6 * B0)
                   + A8 * Math.Sin(8 * B0))) / A0;

                if (Math.Abs(Bi - B0) < 1e-10) break;
                 
                B0 = Bi;
            };

            return Bi;
        }

        public double funM(double sinB2)
        {
            return a * (1 - e2) / Math.Pow(1 - e2 * sinB2, 1.5);
        }

        public double funN(double sinB2)
        {
            return a / Math.Sqrt(1 - e2 * sinB2);
        }

        public double funR(double sinB2)
        {
            return Math.Sqrt(funM(sinB2) * funN(sinB2));
        }

        public double funG2(double cosB2)
        {
            return eT2 * cosB2;
        }
    }
}
