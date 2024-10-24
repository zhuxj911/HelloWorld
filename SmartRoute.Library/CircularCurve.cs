using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXY;

namespace SmartRoute.Library;

//圆曲线
public class CircularCurve : Curve
{
    //直圆点
    private RPoint zy = new() { Note = "ZY" };

    public RPoint ZY => zy;

    //圆直点
    private RPoint yz = new() { Note = "YZ" };

    public RPoint YZ => yz;

    public override double T => Radius * Math.Tan(Alpha * 0.5);

    public override double L => Radius * Alpha;

    public override double E => Radius * (1 / Math.Cos(Alpha * 0.5) - 1);

    /// <summary>
    ///
    /// </summary>
    /// <param name="start"></param>
    /// <param name="jd"></param>
    /// <param name="alpha">带正负号的以度分秒为单位的偏转角</param>
    /// <param name="radius"></param>
    public CircularCurve(RPoint start, RPoint jd, double alpha, double radius)
    {
        //判断 偏右？ 还是 偏左？
        IsRight = alpha >= 0.0 ? 1 : -1; ////右偏+，左偏-
        this.Alpha = IsRight * SurMath.DmsToRadian(alpha); //将带正负号的以度分秒为单位的偏转角解耦，并以弧度为单位
        this.Radius = radius;

        this.JD.KNo = jd.KNo; this.JD.X = jd.X; this.JD.Y = jd.Y;

        //计算第一条边的坐标方位角
        double a12 = this.Alpha0 = start.Azimuth(jd).a;

        double a23 = a12 + this.Alpha * IsRight;
        if (a23 < 0) a23 += 2 * Math.PI;
        if (a23 >= 2 * Math.PI) a23 -= 2 * Math.PI;

        ZY.KNo = jd.KNo - T;
        ZY.X = jd.X - T * Math.Cos(a12);
        ZY.Y = jd.Y - T * Math.Sin(a12);

        QZ.KNo = ZY.KNo + L * 0.5;
        CalculatePointInCurve(ref qz);

        YZ.KNo = ZY.KNo + L;
        YZ.X = jd.X + T * Math.Cos(a23);
        YZ.Y = jd.Y + T * Math.Sin(a23);
    }

    /// <summary>
    /// 根据给定公里桩号计算坐标
    /// </summary>
    /// <param name="pt">给定了公里桩号的计算点</param>
    private void CalculatePointInCurve(ref RPoint pt)
    {
        double li = pt.KNo - ZY.KNo;
        double alphai = li / Radius;

        pt.X = Radius * Math.Sin(alphai);
        pt.Y = IsRight * Radius * (1 - Math.Cos(alphai));

        pt.TransformXY(ZY.X, ZY.Y, Alpha0);
    }

    /// <summary>
    /// 根据里程桩号计算圆曲线上的坐标
    /// </summary>
    /// <param name="kNo">里程桩号</param>
    /// <returns>点坐标</returns>
    public override RPoint? CalculatePointOnCurveByKno(double kNo)
    {
        if (kNo < ZY.KNo || kNo > YZ.KNo) return null; //不是圆曲线上有效范围

        if (Math.Abs(kNo - ZY.KNo) <= 0.001) return ZY;
        if (Math.Abs(kNo - QZ.KNo) <= 0.001) return QZ;
        if (Math.Abs(kNo - YZ.KNo) <= 0.001) return YZ;

        RPoint pt = new RPoint() { KNo = kNo };
        CalculatePointInCurve(ref pt);

        return pt;
    }

    public override List<RPoint> CalculateBatchPointsOnCurve(double length)
    {
        var points = new List<RPoint> { ZY };

        //ZY --> QZ
        var kNo = ZY.KNo;
        while (kNo + length < QZ.KNo)
        {
            kNo += length;
            RPoint pt = new RPoint() { KNo = kNo };
            CalculatePointInCurve(ref pt);
            points.Add(pt);
        }

        points.Add(QZ);

        //QZ --> YZ
        kNo = QZ.KNo;
        while (kNo + length < YZ.KNo)
        {
            kNo += length;
            RPoint pt = new RPoint() { KNo = kNo };
            CalculatePointInCurve(ref pt);
            points.Add(pt);
        }

        points.Add(YZ);

        return points;
    }

    public override string ToString()
    {
        return $"JD({JD.KNoInfo}, {JD.X}, {JD.Y} )\n" +
               $"ZY({ZY.KNoInfo}, {ZY.X}, {ZY.Y})\n" +
               $"QZ({QZ.KNoInfo}, {QZ.X}, {QZ.Y})\n" +
               $"YZ({YZ.KNoInfo}, {YZ.X}, {YZ.Y})\n" +
               $"R={Radius}\n" +
               $"α={IsRight * SurMath.RadianToDms(Alpha)}, 右偏+/左偏-\n" +
               $"T={T}\n" +
               $"L={L}\n" +
               $"E={E}\n" +
               $"q={Q}\n" +
               $"α0={SurMath.RadianToDms(Alpha0)}\n";
    }
}