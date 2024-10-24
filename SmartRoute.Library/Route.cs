using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXY;

namespace SmartRoute.Library;

public interface IRoute
{
    int ReadRouteDataFile(string fileName);

    void CalculateSingleRoutePoint(double kno);

    void CalculateBatchRoutePoints(double gap);
}

/// <summary>
/// 线路：由直线Line、圆曲线CircularCurve、缓缓和曲线SpiralCurve组成
/// </summary>
public  class Route : NotificationObject, IRoute
{
    //线路控制点
    private List<Point> controlPoints = new List<Point>();
    public List<Point> ControlPoints
    {
        get => controlPoints;
    }


    //计算后后的线路点
    private List<Point> routePoints = new List<Point>();
    public List<Point> RoutePoints
    {
        get => routePoints;
    }

    public Route()
    {
    }

    /// <summary>
    /// 读取数据文件
    /// </summary>
    /// <param name="fileName">文件名</param>
    /// <returns>读取成功的点数</returns>
    public int ReadRouteDataFile(string fileName)
    {
        //int count = 0;
        //this.controlPoints.Clear();
        //string buffer, name;
        //double kno=0, x, y, R=0, l0=0;

        //this.controlPoints.Clear();

        //using (System.IO.StreamReader sr = new System.IO.StreamReader(fileName))
        //{
        //    while (true)
        //    {
        //        buffer = sr.ReadLine();
        //        if (string.IsNullOrEmpty(buffer)) break; //文件末尾或空行退出
        //        if (buffer[0] == '#') continue;

        //        string[] its = buffer.Split(new char[1] { ',' });
        //        if (its.Length >= 3 || its.Length <= 5)
        //        {
        //            name = its[0].Trim();
        //            x = double.Parse(its[1]);
        //            y = double.Parse(its[2]);
        //            if (count == 0 && its.Length ==4) //第1行，且4个数据项，说明省略了为0的R与l0
        //            {
        //                kno = double.Parse(its[3]);
        //                R = 0; l0 = 0;
        //                this.controlPoints.Add(new Point(name, x, y, R, l0, kno));
        //            }
        //            else if (its.Length == 4) //可能圆曲线
        //            {
        //                R = double.Parse(its[3]);
        //                l0 = 0;
        //                this.controlPoints.Add(new Point(name, x, y, R, l0, kno));
        //            }
        //            else if(its.Length == 5) //可能圆曲线与缓和曲线
        //            {
        //                R = double.Parse(its[3]);
        //                l0 = double.Parse(its[4]);
        //                this.controlPoints.Add(new Point(name, x, y, R, l0, kno));
        //            }
        //            else if (its.Length == 3) //可能直线或最后一行数据
        //            {
        //                R = 0; l0 = 0;
        //                this.controlPoints.Add(new Point(name, x, y, R, l0, kno));
        //            }
        //            count++;                        
        //        }
        //    }
        //}

        //this.InitializeCurveParameters(); //读完数据立即初始化
        //return count;
        return 0;
    }

    //初始化参数
    public void InitializeCurveParameters()
    {
        //if (controlPoints.Count <= 2)
        //{
        //    throw new Exception("线路控制点不足，少于3个，无法进行线路计算");
        //}
        //else if (controlPoints.Count > 2) 
        //{
        //    //1.计算偏转角 与 坐标方位角
        //    for (int i = 1; i < controlPoints.Count - 1; i++)//去除头与尾
        //    {
        //        this.controlPoints[i].CalculateAlpha(controlPoints[i - 1], controlPoints[i + 1]);
        //    }

        //    //2. 初始化曲线参数
        //    for (int i = 1; i < controlPoints.Count; i++) 
        //    {
        //        this.controlPoints[i].InitializeCurveParameters(controlPoints[i-1].kNo);
        //    }
        //}
        ////else //两个点构成点直线段
        ////{

        ////}

        ////2.计算里程桩号(需先计算切曲差等参数)
        //for (int i = 1; i < controlPoints.Count; i++)//去除头与尾
        //{
        //    this.controlPoints[i].CalculateKNo(controlPoints[i - 1]);
        //}
    }

    public void CalculateSingleRoutePoint(double kno)
    {

    }

    public void CalculateBatchRoutePoints(double gap)
    {
    }
}
