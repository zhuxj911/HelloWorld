using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZXY;

/// <summary>
/// 对点类Point进行功能扩展
/// </summary>
public static class PointExtension
{
    public static (double a, double d) Azimuth(this Point A, Point B)
    {
        return SurMath.Azimuth(A.X, A.Y, B.X, B.Y);
    }

    /// <summary>
    /// 将点pt平移 dx, dy 旋转 alpha 角
    /// </summary>
    /// <param name="pt">需变换坐标的点</param>
    /// <param name="dx"></param>
    /// <param name="dy"></param>
    /// <param name="alpha">旋转角，单位为弧度</param>
    public static void TransformXY(this Point pt, double dx, double dy, double alpha)
    {
        var xy = SurMath.TransformXY(pt.X, pt.Y, dx, dy, alpha);
        pt.X = xy.X; pt.Y = xy.Y;
    }

    /// <summary>
    /// 计算 p1->p2->p3 的偏转方向
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <returns>左偏：−1 或 右偏或直线：1</returns>
    public static int IsRight(this Point p1, Point p2, Point p3)
    {
        if ((p2.Y - p1.Y) * (p3.X - p2.X) <= (p3.Y - p2.Y) * (p2.X - p1.X))
            return 1;
        else  //(p2.Y-p1.Y)*(p3.X-p2.X) > (p3.Y-p2.Y)*(p2.X-p1.X)
            return -1;
    }

    /// <summary>
    /// 计算三点的偏转角α， 右+/左-
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <param name="three"></param>
    /// <returns>偏转角α， 单位弧度， 右+/左-</returns>
    public static double CalculateAlpha(this Point first, Point second, Point three)
    {
        //判断 start -> JD -> end 是偏右？ 还是 偏左？
        var flag = IsRight(first, second, three);

        //计算偏转角
        var a12 = first.Azimuth(second).a;
        var a23 = second.Azimuth(three).a;

        var alpha = 0.0;
        if (flag == 1)
        {
            alpha = a23 - a12;
        }
        else
        {
            alpha = a12 - a23;
        }

        if (alpha < 0) alpha += 2 * Math.PI;

        return alpha * flag;
    }
}