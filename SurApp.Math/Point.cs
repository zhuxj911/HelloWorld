namespace ZXY;

public class Point : NotificationObject
{
    private string name = "";

    public string Name
    {
        get => name;
        set
        {
            if (name != value)
            {
                name = value;
                RaisePropertyChanged();
            }
        }
    }

    private string code = "";

    public string Code
    {
        get => code;
        set
        {
            if (code != value)
            {
                code = value;
                RaisePropertyChanged();
            }
        }
    }

    private double x = 0.0;

    public double X
    {
        get => x;
        set
        {
            if (x != value)
            {
                x = value;
                RaisePropertyChanged();
            }
        }
    }

    private double y = 0.0;

    public double Y
    {
        get => y;
        set
        {
            if (y != value)
            {
                y = value;
                RaisePropertyChanged();
            }
        }
    }

    private double z = 0.0;

    public double Z
    {
        get => z;
        set
        {
            if (z != value)
            {
                z = value;
                RaisePropertyChanged();
            }
        }
    }

    #region 构造函数

    public Point()
    {
    }

    public Point(string name, string code, double x, double y, double z)
    {
        this.name = name;
        this.code = code;
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Point(double x, double y, double z) : this("", "", x, y, z)
    {
    }

    public Point(double x, double y) : this("", "", x, y, 0)
    {   
    }

#endregion 构造函数

public override string ToString()
{
    return $"Point：{Name}, {Code}, {X}, {Y}, {Z}";
}
}