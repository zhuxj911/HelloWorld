using System;
using System.Collections.Generic;
using System.Text;
using ZXY;

namespace ZXY.Drawing
{
  public class SPoint : NotificationObject
  {
    private static int count;

    private int id;
    public int Id
    {
      get => id;
    }

    //private string name;
    public String Name
    {
      get;
      set;
    }

    
    #region 构造函数

    /// <summary>
    /// 静态构造函数
    /// </summary>
    static SPoint()
    {
      count = 0;
    }

    public SPoint()
    {
      this.id = ++count;
      Name = "";
      x = y = 0;
    }


    public SPoint(double x, double y)
    {
      this.id = ++count;
      this.x = x;
      this.y = y;
    }

    public override string ToString()
    {
      return $"{Name}, {x}, {y}, {dmsB}, {dmsL}";
    }
    #endregion

    private double x;
    public double X
    {
      get => x;
      set
      {
        if (value >= 0)
        {
          x = value;
          RaisePropertyChanged("X");
        }
      }
    }

    private double y;
    public double Y
    {
      get
      {
        return y;
      }
      set
      {
        if (value >= 0)
        {
          y = value;
          RaisePropertyChanged("Y");
        }
      }
    }

    private double _dmsB;
    public double dmsB
    {
      get
      {
        return _dmsB;
      }
      set
      {
        _dmsB = value;
        RaisePropertyChanged("dmsB");
      }
    }

    private double _dmsL;
    public double dmsL
    {
      get
      {
        return _dmsL;
      }
      set
      {
        _dmsL = value;
        RaisePropertyChanged("dmsL");
      }
    }

    private double _Gamma;
    public double Gamma
    {
      get => _Gamma;
      set
      {
        _Gamma = value;
        RaisePropertyChanged("Gamma");
        RaisePropertyChanged("GammaDMSString");
      }
    }

    public string GammaDMSString
    {
      get => ZXY.SurMath.RadtoString(Gamma);
    }


    private double _m;
    public double m
    {
      get => _m;
      set
      {
        _m = value;
        RaisePropertyChanged("m");
      }
    }
  }
}
