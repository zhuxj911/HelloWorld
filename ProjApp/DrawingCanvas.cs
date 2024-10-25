
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace ProjApp;

public class DrawingCanvas : System.Windows.Controls.Canvas
{
    //定义依赖属性，绑定绘图数据源
    public ObservableCollection<GPoint> DrawPoints
    {
        get => (ObservableCollection<GPoint>)GetValue(DrawPointsProperty);
        set => SetValue(DrawPointsProperty, value);
    }

    public static readonly DependencyProperty DrawPointsProperty =
        DependencyProperty.Register("DrawPoints", typeof(ObservableCollection<GPoint>), typeof(DrawingCanvas),
            new PropertyMetadata(DrawPointsValueChanged));

    public static void DrawPointsValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        DrawingCanvas drawingCanvas = (DrawingCanvas)d;
        drawingCanvas.DrawPoints.CollectionChanged += drawingCanvas.DrawPoints_CollectionChanged;
    }

    private void DrawPoints_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        this.InvalidateVisual();
    }
    //定义依赖属性，绑定绘图数据源



    //使用DrawVisual画Polyline
    public void DrawLine(DrawingContext dc,  double x0, double y0, double x1, double y1, Brush color, double thinkness)
    { 
        Pen pen = new Pen(color, thinkness);
        pen.Freeze();  //冻结画笔，这样能加快绘图速度
        dc.DrawLine(pen, new Point(x0, y0), new Point(x1, y1));
    }

    public void DrawText(DrawingContext dc, string text, double x, double y)
    {
        Typeface tp = new Typeface(new FontFamily("宋体"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
        FormattedText ft = new FormattedText(text, new CultureInfo("zh-cn"), FlowDirection.LeftToRight, tp, 12, Brushes.Black);
        //PixelsPerDip

        dc.DrawText(ft, new Point(x, y));
    }

    //使用DrawVisual画Circle，用作控制点
    public void DrawCtrPnt(DrawingContext dc, double x, double y, Brush color, double thinkness)
    {     
        Pen pen = new Pen(color, thinkness);
        pen.Freeze();  //冻结画笔，这样能加快绘图速度
        dc.DrawEllipse(Brushes.LemonChiffon, pen, new Point(x, y), 5, 5);
    }

    //使用DrawVisual画Circle，用作控制点
    public void DrawKnCtrPnt(DrawingContext dc, double x, double y, Brush color, double thinkness)
    {
        Pen pen = new Pen(color, thinkness);
        pen.Freeze();  //冻结画笔，这样能加快绘图速度
        dc.DrawEllipse(Brushes.Black, pen, new Point(x, y), 1, 1);
        dc.DrawLine(pen, new Point(x - 5, y + 2.9), new Point(x + 5, y + 2.9));
        dc.DrawLine(pen, new Point(x + 5, y + 2.9), new Point(x, y - 5.8));
        dc.DrawLine(pen, new Point(x, y - 5.8), new Point(x - 5, y + 2.9));
    }

    //以下定义为绘图使用
    private double minX;  //高斯坐标X的最小值xn
    private double minY;  //高斯坐标Y的最小值yn
    private double maxX; //高斯坐标X的最大值xm
    private double maxY; //高斯坐标Y的最大值ym

    private double maxVX; //屏幕坐标X的最大值
    private double maxVY; //屏幕坐标Y的最大值

    private double k;  //变换比例

    private void OnDraw(DrawingContext dc)
    {        
        if (DrawPoints.Count == 0) return;

        GetGaussXySize();

        maxVX = this.ActualWidth;
        maxVY = this.ActualHeight;

        double kx = maxVX / (maxY - minY);
        double ky = maxVY / (maxX - minX);
        k = kx <= ky ? kx : ky;

  
        foreach (var pt in DrawPoints)
        {
            if (pt.X <= 0 || pt.Y <= 0) continue; //排除坐标为0的点

            GaussXyToViewXy(pt.X, pt.Y, out double x0, out double y0);
            this.DrawCtrPnt(dc, x0, y0, Brushes.Red, 1);
            this.DrawText(dc, pt.Name, x0 + 10, y0 - 7);
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

    private void GetGaussXySize()
    {
        minX = DrawPoints[0].X; minY = DrawPoints[0].Y;
        maxX = DrawPoints[0].X; maxY = DrawPoints[0].Y;

        for (int i = 1; i < DrawPoints.Count; i++) //如果只有一个点，由循环条件知，不会执行循环体
        {
            if (DrawPoints[i].X <= 0 || DrawPoints[i].Y <= 0) continue;

            if (DrawPoints[i].X < minX) minX = DrawPoints[i].X;
            if (DrawPoints[i].Y < minY) minY = DrawPoints[i].Y;

            if (DrawPoints[i].X > maxX) maxX = DrawPoints[i].X;
            if (DrawPoints[i].Y > maxY) maxY = DrawPoints[i].Y;
        }

        //针对一个点或点范围较小的情况，进行范围扩展
        if (minX + 10 > maxX) { maxX = minX + 10; minX = maxX - 20; }
        if (minY + 10 > maxY) { maxY = minY + 10; minY = maxY - 20; }
    }

    protected override void OnRender(DrawingContext dc)
    {
        base.OnRender(dc);
        if (DrawPoints != null) this.OnDraw(dc);
    }

    public void OutToBmp(string bmpFileName)
    {
        //RenderTargetBitmap rtb = new RenderTargetBitmap((int)this.ActualWidth, (int)this.ActualHeight, this.ActualWidth, this.ActualHeight, PixelFormats.Default);
        //foreach (var it in this.visuals)
        //{
        //	rtb.Render(it);
        //}
        //rtb.Render(this.visuals[0]);

        ////FileStream stream = new FileStream(bmpFileName, FileMode.Create);
        ////BitmapEncoder encoder = new BmpBitmapEncoder();
        ////encoder.Frames.Add(BitmapFrame.Create(rtb));
        ////encoder.Save(stream);
    }
}
