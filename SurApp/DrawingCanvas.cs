using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using ZXY.Drawing;

namespace SurApp
{
  public class DrawingCanvas : System.Windows.Controls.Canvas
  {
    private VisualCollection visuals;

    public DrawingCanvas()
    {
      visuals = new VisualCollection(this);
    }

    //获取Visual的个数
    protected override int VisualChildrenCount => visuals.Count;     

    //获取Visual
    protected override Visual GetVisualChild(int index)
    {
      return visuals[index];
    }

    //添加Visual
    public void AddVisual(Visual visualObject)
    {
      visuals.Add(visualObject);
    }

    //删除Visual
    public void RemoveVisual(Visual visualObject)
    {
      base.RemoveLogicalChild(visualObject);
    }

    //命中测试
    public DrawingVisual GetVisual(System.Windows.Point point)
    {
      HitTestResult hitResult = VisualTreeHelper.HitTest(this, point);
      return hitResult.VisualHit as DrawingVisual;
    }

    public void ClearAll()
    {
      this.visuals.Clear();
    }


    //使用DrawVisual画Polyline
    public void DrawLine(double x0, double y0, double x1, double y1, Brush color, double thinkness)
    {
      DrawingVisual visualLine = new DrawingVisual();
      DrawingContext dc = visualLine.RenderOpen();
      Pen pen = new Pen(color, thinkness);
      pen.Freeze();  //冻结画笔，这样能加快绘图速度
      dc.DrawLine(pen, new Point(x0, y0), new Point(x1, y1));

      dc.Close();
      visuals.Add(visualLine);
    }

    public void DrawText(string text, double x, double y)
    {
      DrawingVisual visualText = new DrawingVisual();
      DrawingContext dc = visualText.RenderOpen();
      Typeface tp = new Typeface(new FontFamily("宋体"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
      FormattedText ft = new FormattedText(text, CultureInfo.CurrentCulture,
          FlowDirection.LeftToRight, tp, 12, Brushes.Black);
      dc.DrawText(ft, new Point(x, y));
      dc.Close();
      visuals.Add(visualText);
    }

    //使用DrawVisual画Circle，用作控制点
    public void DrawCtrPnt(double x, double y, Brush color, double thinkness)
    {
      DrawingVisual visualCircle = new DrawingVisual();
      DrawingContext dc = visualCircle.RenderOpen();
      Pen pen = new Pen(color, thinkness);
      pen.Freeze();  //冻结画笔，这样能加快绘图速度
      dc.DrawEllipse(Brushes.LemonChiffon, pen, new Point(x, y), 5, 5);
      dc.Close();
      visuals.Add(visualCircle);
    }

    //使用DrawVisual画Circle，用作控制点
    public void DrawKnCtrPnt(double x, double y, Brush color, double thinkness)
    {
      DrawingVisual visualCircle = new DrawingVisual();
      DrawingContext dc = visualCircle.RenderOpen();
      Pen pen = new Pen(color, thinkness);
      pen.Freeze();  //冻结画笔，这样能加快绘图速度
      dc.DrawEllipse(Brushes.Black, pen, new Point(x, y), 1, 1);
      dc.DrawLine(pen, new Point(x - 5, y + 2.9), new Point(x + 5, y + 2.9));
      dc.DrawLine(pen, new Point(x + 5, y + 2.9), new Point(x, y - 5.8));
      dc.DrawLine(pen, new Point(x, y - 5.8), new Point(x - 5, y + 2.9));
      dc.Close();
      visuals.Add(visualCircle);
    }


    //以下定义为绘图使用
    private double minX;  //高斯坐标X的最小值xn
    private double minY;  //高斯坐标Y的最小值yn
    private double maxX; //高斯坐标X的最大值xm
    private double maxY; //高斯坐标Y的最大值ym

    private double maxVX; //屏幕坐标X的最大值
    private double maxVY; //屏幕坐标Y的最大值

    private double k;  //变换比例

    private void OnDraw(ObservableCollection<SPoint> SPointList)
    {
      if (SPointList.Count == 0) return;

      GetGaussXySize(SPointList);

      maxVX = this.ActualWidth;
      maxVY = this.ActualHeight;

      double kx = maxVX / (maxY - minY);
      double ky = maxVY / (maxX - minX);
      k = kx <= ky ? kx : ky;

      this.ClearAll(); //先清除屏幕

      foreach (var pt in SPointList)
      {
        if (pt.X <= 0 || pt.Y <= 0) continue; //排除坐标为0的点

        GaussXyToViewXy(pt.X, pt.Y, out double x0, out double y0);
        this.DrawCtrPnt(x0, y0, Brushes.Red, 1);
        this.DrawText(pt.Name, x0 + 10, y0 - 7);
      }
    }

    private void GaussXyToViewXy(double xt, double yt, out double xp, out double yp)
    {
      //xp = x0 + kx(yt - yn);
      //yp = y1 - [y0 + ky * (xt - xn)];
      // x0 = y0 =0 且 kx = ky =k， 故以上公式简化为：

      xp = k * (yt - minY); 
      yp = maxVY - k * (xt - minX);
    }

    private void GetGaussXySize(ObservableCollection<SPoint> SPointList)
    {
      minX = SPointList[0].X; minY = SPointList[0].Y;
      maxX = SPointList[0].X; maxY = SPointList[0].Y;

      for (int i = 1; i < SPointList.Count; i++) //如果只有一个点，由循环条件知，不会执行循环体
      {
        if (SPointList[i].X <= 0 || SPointList[i].Y <= 0) continue;

        if (SPointList[i].X < minX) minX = SPointList[i].X;
        if (SPointList[i].Y < minY) minY = SPointList[i].Y;

        if (SPointList[i].X > maxX) maxX = SPointList[i].X;
        if (SPointList[i].Y > maxY) maxY = SPointList[i].Y;
      }

      //针对一个点或点范围较小的情况，进行范围扩展
      if (minX + 10 > maxX) { maxX = minX + 10; minX = maxX - 20; }
      if (minY + 10 > maxY) { maxY = minY + 10; minY = maxY - 20; }
    }

    protected override void OnRender(DrawingContext dc)
    {
      base.OnRender(dc);
      ObservableCollection<SPoint> SPointList = this.Tag as ObservableCollection<SPoint>;
      this.OnDraw(SPointList);
    }
  }
}
