using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXY;

namespace SmartRoute.Library;

/// <summary>
/// 缓和曲线
/// </summary>
public class TransitionCurve : Curve
{
    /// <summary>
    /// 切垂距
    /// </summary>
    public double M => 0.5 * L0 - Math.Pow(L0, 3) / 240.0 / Math.Pow(Radius, 2);

    /// <summary>
    /// 内移距
    /// </summary>
    public double P => Math.Pow(L0, 2) / 24.0 / Radius;

    public override double T => M + (Radius + P) * Math.Tan(Alpha * 0.5);

    public double Beta0 => L0 / Radius * 0.5;

    public override double L => Radius * (Alpha - 2 * Beta0) + 2 * L0;

    public override double E => (Radius + P) / Math.Cos(Alpha * 0.5) - Radius;

    private RPoint zh = new() { Note = "ZH" };

    /// <summary>
    /// 直缓点
    /// </summary>
    public RPoint ZH => zh;

    private RPoint hy = new() { Note = "HY" };

    /// <summary>
    /// 缓圆点
    /// </summary>
    public RPoint HY => hy;

    private RPoint yh = new() { Note = "YH" };

    /// <summary>
    /// 圆缓点
    /// </summary>
    public RPoint YH => yh;

    private RPoint hz = new() { Note = "HZ" };

    /// <summary>
    /// 缓直点
    /// </summary>
    public RPoint HZ => hz;

    /// <summary>
    /// HZ 在 ZH坐标系中的坐标点
    /// </summary>
    private RPoint hz0 = new RPoint();

    public TransitionCurve(RPoint start, RPoint jd, Double alpha, double radius, double l0)
    {
        Radius = radius;
        L0 = l0;

        IsRight = alpha >= 0.0 ? 1 : -1; //右偏+，左偏-
        Alpha = IsRight * SurMath.DmsToRadian(alpha);

        JD.KNo = jd.KNo; JD.X = jd.X; JD.Y = jd.Y; JD.Note = "JD";
        IsRight = Alpha >= 0 ? 1 : -1;

        // 计算第一条边的坐标方位角
        var a12 = Alpha0 = start.Azimuth(jd).a;

        double a23 = a12 + Alpha * IsRight;
        if (a23 < 0) a23 += 2 * Math.PI;
        if (a23 >= 2 * Math.PI) a23 -= 2 * Math.PI;

        //ZH 为大地坐标
        ZH.KNo = jd.KNo - T;
        ZH.X = jd.X - T * Math.Cos(a12);
        ZH.Y = jd.Y - T * Math.Sin(a12);

        //HZ 为大地坐标
        HZ.KNo = ZH.KNo + L;
        HZ.X = jd.X + T * Math.Cos(a23);
        HZ.Y = jd.Y + T * Math.Sin(a23);

        //HZ在点在ZH坐标系中的坐标
        hz0.X = T * (1 + Math.Cos(Alpha));
        hz0.Y = T * Math.Sin(Alpha);

        //计算 HY 点坐标
        HY.KNo = ZH.KNo + l0;
        CalPointInCurve(ref hy);

        QZ.KNo = ZH.KNo + 0.5 * L;
        CalPointInCurve(ref qz);

        YH.KNo = HZ.KNo - l0;
        CalPointInCurve(ref yh);
    }

    private void CalPointInCurve(ref RPoint pt)
    {
        double li = pt.KNo - ZH.KNo;

        if (li <= L0)//点落在ZH段的缓和曲线上
        {
            CalHXY(li, ref pt);
        }
        else if (li <= L - L0)//点落在ZH段的圆曲线上
        {
            CalRXY(li, ref pt);
        }
        else //点落在HZ段的缓和曲线上
        {
            //此处应将li也转换到HZ坐标系中：liHZ = L - li;
            double liHZ = L - li;
            CalHXY(liHZ, ref pt);

            // 由于y轴方向不同，Y坐标需乘-1，X坐标不变
            pt.Y = -1 * pt.Y;

            //转换到ZH坐标系中 hz0为HZ点在ZH坐标系中的坐标
            pt.TransformXY(hz0.X, hz0.Y, Math.PI + Alpha);
        }

        //计算ZH->JD坐标方位角 Alpha0 即是，不需要再计算
        //double A = ZXY.SurMath.Azimuth(ZH.X, ZH.Y, JD.X, JD.Y).a;

        //利用坐标方位角转换为大地坐标
        pt.TransformXY(ZH.X, ZH.Y, Alpha0); // Alpha0 为 start -> jd 也是 ZH -> JD
    }

    /// <summary>
    /// 计算ZH坐标系中圆曲线上点的坐标
    /// </summary>
    /// <param name="li"></param>
    /// <param name="pt"></param>
    private void CalRXY(double li, ref RPoint pt)
    {
        double betai = Beta0 + (li - L0) / Radius;

        pt.X = Radius * Math.Sin(betai) + M;
        pt.Y = Radius * (1 - Math.Cos(betai)) + P;
    }

    /// <summary>
    /// 计算ZH坐标系中缓和曲线上点的坐标
    /// </summary>
    /// <param name="li"></param>
    /// <param name="pt"></param>
    private void CalHXY(double li, ref RPoint pt)
    {
        pt.X = li - Math.Pow(li, 5) / 40.0 / (Radius * L0) / (Radius * L0);
        pt.Y = Math.Pow(li, 3) / 6 / Radius / L0
            - Math.Pow(li, 7) / 336 / Math.Pow(Radius * L0, 3);
    }

    public override RPoint? CalculatePointOnCurveByKno(double kNo)
    {
        double li = kNo - ZH.KNo;
        if (li < 0 || li > L) return null;

        RPoint pt = new RPoint() { KNo = kNo };
        CalPointInCurve(ref pt);
        return pt;
    }

    public override List<RPoint> CalculateBatchPointsOnCurve(double length)
    {
        var points = new List<RPoint>();

        points.Add(zh);

        //ZH --> HY
        var kno = zh.KNo;
        while (kno + length < hy.KNo)
        {
            kno += length;
            var pt = new RPoint() { KNo = kno };
            CalPointInCurve(ref pt);
            points.Add(pt);
        }

        points.Add(hy);

        //HY --> QZ
        kno = hy.KNo;
        while (kno + length < qz.KNo)
        {
            kno += length;
            var pt = new RPoint() { KNo = kno };
            CalPointInCurve(ref pt);
            points.Add(pt);
        }

        points.Add(qz);

        //QZ --> YH
        kno = qz.KNo;
        while (kno + length < yh.KNo)
        {
            kno += length;
            var pt = new RPoint() { KNo = kno };
            CalPointInCurve(ref pt);
            points.Add(pt);
        }
        points.Add(yh);

        //YH--> HZ
        kno = yh.KNo;
        while (kno + length < hz.KNo)
        {
            kno += length;
            var pt = new RPoint() { KNo = kno };
            CalPointInCurve(ref pt);
            points.Add(pt);
        }
        points.Add(hz);

        return points;
    }

    public override string ToString()
    {
        return $"JD({JD.KNoInfo}, {JD.X}, {JD.Y} )\n" +
               $"ZH({ZH.KNoInfo}, {ZH.X}, {ZH.Y})\n" +
               $"HY({HY.KNoInfo}, {HY.X}, {HY.Y})\n" +
               $"QZ({QZ.KNoInfo}, {QZ.X}, {QZ.Y})\n" +
               $"YH({YH.KNoInfo}, {YH.X}, {YH.Y})\n" +
               $"YZ({HZ.KNoInfo}, {HZ.X}, {HZ.Y})\n" +
               $"R={Radius}\n" +
               $"α={IsRight * SurMath.RadianToDms(Alpha)}, 右偏+/左偏-\n" +
               $"T={T}\n" +
               $"L={L}\n" +
               $"E={E}\n" +
               $"q={Q}\n" +
               $"m={M}\n" +
               $"P={P}\n" +
               $"α0={SurMath.RadianToDms(Alpha0)}\n";
    }
}