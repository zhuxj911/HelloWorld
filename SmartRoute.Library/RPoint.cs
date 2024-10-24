using ZXY;

namespace SmartRoute.Library;

public class RPoint : Point
{
    private double kNo;

    /// <summary>
    /// 里程桩号
    /// </summary>
    public double KNo
    {
        get { return kNo; }
        set
        {
            kNo = value;
            RaisePropertyChanged();
        }
    }

    private string? note;

    /// <summary>
    /// 备注
    /// </summary>
    public string? Note
    {
        get { return note; }
        set
        {
            note = value;
            RaisePropertyChanged();
        }
    }

    /// <summary>
    /// 将double类型的kno分解为K5+200.00形式的里程桩号
    /// </summary>
    /// <returns>里程桩号</returns>
    public string KNoInfo
    {
        get
        {
            int k = (int)(kNo / 1000);
            double klength = kNo - k * 1000;
            return string.Format("K{0}+{1:0.000}", k, klength);
        }
    }

    public RPoint()
    {
        KNo = 0;
        Note = "";
    }

    public RPoint(double x, double y) : base(x, y)
    {
        KNo = 0;
        Note = "";
    }

    public RPoint(double kNo, double x, double y) : base(x, y)
    {
        KNo = kNo;
        Note = "";
    }
}