using System;

namespace ZXY;

public class Point : NotificationObject
{
    private string name;

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

    private string code;

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

    private double x;

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

    private double y;

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

    private double z;

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
        name = "";
        code = "";
        x = y = z = 0;
    }

    public Point(string name, string code, double x, double y, double z)
    {
        this.name = name;
        this.code = code;
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Point(double x, double y, double z)
    {
        name = "";
        code = "";
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Point(double x, double y)
    {
        name = "";
        code = "";
        this.x = x;
        this.y = y;
        this.z = 0;
    }

    #endregion 构造函数

    public override string ToString()
    {
        return $"Point：{Name}, {Code}, {X}, {Y}, {Z}";
    }
}