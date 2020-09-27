using System;

namespace ZXY
{
    public static class SurMath
    {
        /// <summary>
        /// 度分秒角度化弧度
        /// </summary>
        /// <param name="">度分秒角度:1.2030</param>
        /// <returns>弧度</returns>
        public static double DMStoRad(double dmsAngle)
        {
            int d = (int)dmsAngle;
            dmsAngle = (dmsAngle - d) * 100;
            int m = (int)dmsAngle;
            double s = (dmsAngle - m) * 100;
            return (d+m/60.0+s/3600.0)/180.0*Math.PI;
        }

        /// <summary>
        /// 弧度化度分秒角度
        /// </summary>
        /// <param name="">弧度</param>
        /// <returns>度分秒角度:1.2030</returns>
        public static double RadtoDMS(double radAngle)
        {
            return 0;
        }

        /// <summary>
        /// 计算A->两点的坐标方位角
        /// </summary>
        /// <param name="xA">A的X坐标</param>
        /// <param name="yA">A的Y坐标</param>
        /// <param name="xB">B的X坐标</param>
        /// <param name="yB">B的Y坐标</param>
        /// <returns>A->两点的坐标方位角，单位：弧度</returns>
        public static double Azimuth(double xA, double yA, double xB, double yB)
        {
            return 0;
        }
    }
}
