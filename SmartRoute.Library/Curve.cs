using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXY;

namespace SmartRoute.Library;

public interface ICurve
{
    double Radius { get; set; }

    /// <summary>
    /// 偏转角，单位为弧度
    /// </summary>
    double Alpha { get; set; }

    /// <summary>
    ///切线长
    /// </summary>
    double T { get; }

    /// <summary>
    /// 切曲差
    /// </summary>
    double Q { get; }

    double E { get; }

    /// <summary>
    /// 曲线长
    /// </summary>
    double L { get; }

    /// <summary>
    /// 缓和曲线长
    /// </summary>
    double L0 { get; set; }

    /// <summary>
    /// 根据给定公里桩号计算坐标
    /// </summary>
    /// <param name="pt">计算点</param>
    RPoint? CalculatePointOnCurveByKno(double kNo);

    /// <summary>
    /// 根据给间距批量计算坐标
    /// </summary>
    /// <param name="length">给定间距</param>
    /// <returns>批量坐标</returns>
    List<RPoint> CalculateBatchPointsOnCurve(double length);

    public string? ToString();
}

/// <summary>
/// 圆曲线与缓和曲线的曲线基类
/// </summary>
public abstract class Curve : NotificationObject, ICurve
{
    private double alpha;//参数1：单位弧度, 曲线在ZY->JD的左边为负，右边为正

    /// <summary>
    /// 偏转角，单位:弧度
    /// </summary>
    public double Alpha
    {
        get { return alpha; }
        set
        {
            alpha = value;
            RaisePropertyChanged();
        }
    }

    private double alpha0;//起始边坐标方位角，单位：弧度

    /// <summary>
    /// 起始边坐标方位角，单位:弧度
    /// </summary>
    public double Alpha0
    {
        get { return alpha0; }
        set
        {
            alpha0 = value;
            RaisePropertyChanged();
        }
    }

    protected int isRight = 1;//曲线偏向 曲线偏右 =1 还是 偏左=-1 的标识，程序内部计算出

    /// <summary>
    /// 曲线偏向 曲线偏右 =1 还是 偏左=-1 的标识，程序内部计算出
    /// </summary>
    public int IsRight
    {
        get { return isRight; }
        set
        {
            isRight = value;
            RaisePropertyChanged();
        }
    }

    protected double _radius;

    /// <summary>
    /// 圆曲线半径
    /// </summary>
    public double Radius
    {
        get { return _radius; }
        set
        {
            _radius = value;
            RaisePropertyChanged();
        }
    }

    private RPoint jd = new RPoint() { Note = "JD" }; ////参数5：交点的里程，x，y

    /// <summary>
    /// 交点
    /// </summary>
    public RPoint JD => jd;

    private double length;

    /// <summary>
    /// 批量计算时的里程间隔
    /// </summary>
    public double Length
    {
        get { return length; }
        set
        {
            length = value;
            RaisePropertyChanged();
        }
    }

    //曲中
    protected RPoint qz = new RPoint() { Note = "QZ" };

    /// <summary>
    /// 曲中点
    /// </summary>
    public RPoint QZ => qz;

    /// <summary>
    /// 切线长
    /// </summary>
    public abstract double T { get; }

    /// <summary>
    /// 曲线长
    /// </summary>
    public abstract double L { get; }

    /// <summary>
    /// 外矢距
    /// </summary>
    public abstract double E { get; }

    /// <summary>
    /// 切曲差
    /// </summary>
    public double Q => 2 * T - L;

    private double l0;

    /// <summary>
    /// 缓和曲线长
    /// </summary>
    public double L0
    {
        get { return l0; }
        set
        {
            l0 = value;
            RaisePropertyChanged();
        }
    }

    /// <summary>
    /// 根据给定公里桩号计算坐标
    /// </summary>
    /// <param name="kNo">公里桩号</param>
    /// <returns></returns>
    public abstract RPoint? CalculatePointOnCurveByKno(double kNo);

    /// <summary>
    ///  根据间距批量计算坐标
    /// </summary>
    /// <param name="length">里程间距</param>
    /// <returns>批量坐标</returns>
    public abstract List<RPoint> CalculateBatchPointsOnCurve(double length);
}