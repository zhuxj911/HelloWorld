using System;

namespace ZXY;

public static class SurMath
{
    public const double PI = Math.PI;
    public const double TWOPI = 2 * Math.PI;
    public const double HALFPI = 0.5 * Math.PI;
    public const double TORADIAN = PI / 180.0;
    public const double TODEGREE = 180.0 / PI;
    public const double TOSECOND = 180.0 * 3600.0 / PI;

    /// <summary>
    /// 度分秒角度化弧度
    /// 101 02 20.1  -> 1010220.1
    /// 1.4  -> 1.39999  140 =/= 139.9999999
    /// </summary>
    /// <param name="dmsAngle">度分秒角度:1.2030</param>
    /// <returns>(度, 分, 秒)</returns>
    public static (int d, int m, double s) DmsToDms(double dmsAngle)
    {
        dmsAngle *= 10000;
        int angle = (int)dmsAngle;
        int d = angle / 10000;
        angle -= d * 10000;
        int m = angle / 100;
        double s = dmsAngle - d * 10000 - m * 100;
        return (d, m, s);
    }

    /// <summary>
    /// 将60进制的度分秒角度转换为弧度
    /// </summary>
    /// <param name="dmsAngle">形如ddd.mmss的60进制的角度</param>
    /// <returns>弧度值</returns>
    public static double DmsToRadian(double dmsAngle)
    {
        var dms = DmsToDms(dmsAngle);
        return (dms.d + dms.m / 60.0 + dms.s / 3600.0) * TORADIAN;
    }

    /// <summary>
    /// 度分秒角度值1.02305 化 度、分、秒字符串 1°02′30.5″
    /// </summary>
    /// <param name="dmsAngle">度分秒角度:1.02305</param>
    /// <returns>度、分、秒字符串 1°02′30.5″</returns>
    public static string DmsToDmsString(double dmsAngle)
    {
        int f = dmsAngle >= 0 ? 1 : -1;
        string ff = dmsAngle >= 0 ? "" : "-";
        var dms = DmsToDms(dmsAngle);
        if (Math.Abs(dms.s) < 1e-10)
            return $"{ff}{f * dms.d}°{f * dms.m:00}′{0:00.######}″";
        else
            return $"{ff}{f * dms.d}°{f * dms.m:00}′{f * dms.s:00.######}″";
    }

    /// <summary>
    /// 弧度（radian）转化为 度、分、秒
    /// </summary>
    /// <param name="radAngle">弧度角度值</param>
    /// <returns>度分秒角度:1.2030</returns>
    public static (int d, int m, double s) Radian2Dms(double radAngle)
    {
        radAngle *= TOSECOND;
        int angle = (int)radAngle;
        int d = angle / 3600;
        angle -= d * 3600;
        int m = angle / 60;
        double s = radAngle - d * 3600 - m * 60;
        return (d, m, s);
    }

    /// <summary>
    /// 将弧度转换为60进制的度分秒角度
    /// </summary>
    /// <param name="radAngle">单位为弧度的角度</param>
    /// <returns>60进制的角度</returns>
    public static double RadianToDms(double radAngle)
    {
        var dms = Radian2Dms(radAngle);
        return dms.d + dms.m / 100.0 + dms.s / 10000.0;
    }

    /// <summary>
    /// 弧度（radian）化 度、分、秒字符串 1°02′30.5″
    /// </summary>
    /// <param name="radAngle">弧度角度值</param>
    /// <returns>度、分、秒字符串 1°02′30.5″</returns>
    public static string RadianToDmsString(double radAngle)
    {
        int f = radAngle >= 0 ? 1 : -1;
        string ff = radAngle >= 0 ? "" : "-";
        var dms = Radian2Dms(radAngle);
        if (Math.Abs(dms.s) < 1e-10)
            return $"{ff}{f * dms.d}°{f * dms.m:00}′{0:00.######}″";
        else
            return $"{ff}{f * dms.d}°{f * dms.m:00}′{f * dms.s:00.######}″";
    }

    /// <summary>
    /// 根据A、B两点坐标计算A->B的坐标方位角
    /// </summary>
    /// <param name="xA">A点x坐标</param>
    /// <param name="yA">A点y坐标</param>
    /// <param name="xB">B点x坐标</param>
    /// <param name="yB">B点y坐标</param>
    /// <returns>A->B的坐标方位角，单位弧度, 距离</returns>
    public static (double a, double d) Azimuth(double xA, double yA, double xB, double yB)
    {
        double dx = xB - xA;
        double dy = yB - yA;
        double d = Math.Sqrt(dx * dx + dy * dy);
        double a = Math.Atan2(dy, dx) + (dy >= 0 ? 0 : 1) * TWOPI;
        return (a, d);
    }

    /// <summary>
    /// 将点平移dx、dy并旋转alpha角
    /// </summary>
    /// <param name="dx">X平移量</param>
    /// <param name="dy">Y平移量</param>
    /// <param name="alpha">旋转量</param>
    public static (double X, double Y) TransformXY(double x, double y, double dx, double dy, double alpha)
    {
        double tx = dx + x * Math.Cos(alpha) - y * Math.Sin(alpha);
        double ty = dy + x * Math.Sin(alpha) + y * Math.Cos(alpha);
        return (tx, ty);
    }

    /// <summary>
    /// 规化角度值至0−2π
    /// </summary>
    /// <param name="rad">弧度制角度</param>
    /// <returns>0−2π之间的角度</returns>
    public static double To0_2PI(double rad)
    {
        int f = rad >= 0 ? 0 : 1;
        int n = (int)(rad / TWOPI);
        return rad - n * TWOPI + f * TWOPI;
    }
}