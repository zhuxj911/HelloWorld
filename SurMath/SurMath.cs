using System;

namespace ZXY
{
    public static class SurMath
    {
        public const double PI = Math.PI;
        public const double TWOPI = 2 * Math.PI;
        public const double TODEG = 180.0 / PI;
        public const double TORAD = PI / 180.0;
        public const double TOSECOND = 180.0 * 3600.0 / PI;

        /// <summary>
        /// 度分秒角度化弧度
        /// 此处需讲解 ref、out、元组
        /// 元组功能在 C# 7.0 及更高版本中可用，它提供了简洁的语法，用于将多个数据元素分组成一个轻型数据结构。
        /// </summary>
        /// <param name="dmsAngle">度分秒角度:1.2030</param>
        /// <returns>(度, 分, 秒)</returns>
        public static (int d, int m, double s) DMStoDMS(double dmsAngle)
        {
            //错误的算法
            //int d = (int)dmsAngle;
            //dmsAngle = (dmsAngle - d) * 100;
            //int m = (int)dmsAngle;
            //double s = (dmsAngle - m) * 100;
            //return (d + m / 60.0 + s / 3600.0) * TORAD;

            //正确的算法
            dmsAngle *= 10000;
            int angle = (int)dmsAngle;
            int d = angle / 10000;
            angle -= d * 10000;
            int m = angle / 100;
            double s = dmsAngle - d * 10000 - m * 100;
            return (d, m, s);
        }

        /// <summary>
        /// 度分秒角度值1.02305 化 度、分、秒字符串 1°02′30.5″
        /// </summary>
        /// <param name="dmsAngle">度分秒角度:1.02305</param>
        /// <returns>度、分、秒字符串 1°02′30.5″</returns>
        public static string DMStoString(double dmsAngle)
        {
            int f = Math.Sign(dmsAngle);
            var dms = DMStoDMS(dmsAngle);
            if (Math.Abs(dms.s) <= 1e-10)
                return $"{dms.d}°{f * dms.m:00}′00″";
            else
                return $"{dms.d}°{f * dms.m:00}′{f * dms.s:00.######}″";
        }

        /// <summary>
        /// 度分秒角度化弧度
        /// </summary>
        /// <param name="dmsAngle">度分秒角度:1.2030</param>
        /// <returns>弧度</returns>
        public static double DMStoRad(double dmsAngle)
        {
            var dms = DMStoDMS(dmsAngle);
            return (dms.d + dms.m / 60.0 + dms.s / 3600.0) * TORAD;
        }

        /// <summary>
        /// 弧度（radian）转化为 度、分、秒
        /// </summary>
        /// <param name="radAngle">弧度角度值</param>
        /// <returns>度分秒角度:1.2030</returns>
        public static (int d, int m, double s) Radian2DMS(double radAngle)
        {
            //radAngle *= TODEG;
            //int d = (int)radAngle;
            //radAngle = (radAngle - d) * 60;
            //int m = (int)radAngle;
            //double s = (radAngle - m) * 60;
            //return (d + m / 100.0 + s / 10000.0);

            radAngle *= TOSECOND;
            int angle = (int)radAngle;
            int d = angle / 3600;
            angle -= d * 3600;
            int m = angle / 60;
            double s = radAngle - d * 3600 - m * 60;
            return (d, m, s);
        }

        /// <summary>
        /// 弧度（radian）化度分秒角度
        /// </summary>
        /// <param name="radAngle">弧度角度值</param>
        /// <returns>度分秒角度:1.2030</returns>
        public static double RadtoDMS(double radAngle)
        {
            var dms = Radian2DMS(radAngle);
            return (dms.d + dms.m / 100.0 + dms.s / 10000.0);
        }

        /// <summary>
        /// 弧度（radian）化 度、分、秒字符串 1°02′30.5″
        /// </summary>
        /// <param name="radAngle">弧度角度值</param>
        /// <returns>度、分、秒字符串 1°02′30.5″</returns>
        public static string RadtoString(double radAngle)
        {
            int f = Math.Sign(radAngle);
            var dms = Radian2DMS(radAngle);
            if (Math.Abs(dms.s) <= 1e-10)
                return $"{dms.d}°{f * dms.m:00}′00″";
            else
                return $"{dms.d}°{f * dms.m:00}′{f * dms.s:00.######}″";
        }

        /// <summary>
        /// 计算A->两点的坐标方位角
        /// </summary>
        /// <param name="xA">A的X坐标</param>
        /// <param name="yA">A的Y坐标</param>
        /// <param name="xB">B的X坐标</param>
        /// <param name="yB">B的Y坐标</param>
        /// <returns>A->B的坐标方位角，单位：弧度</returns>
        public static double Azimuth(double xA, double yA, double xB, double yB)
        {
            double dx = xB - xA;
            double dy = yB - yA;
            return Math.Atan2(dy, dx) + (dy < 0 ? 1 : 0) * TWOPI;
        }
    }
}
