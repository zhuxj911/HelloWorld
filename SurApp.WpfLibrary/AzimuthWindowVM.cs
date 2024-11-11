using System.Windows.Input;
using ZXY;

namespace SurApp.WpfLibrary;

public class AzimuthWindowVM : NotificationObject
{
    public AzimuthWindowVM()
    {
#if DEBUG
        A = new()
        {
            Name = "GP11",
            X = 50342.464,
            Y = 3528.978
        };

        B = new()
        {
            Name = "GP12",
            X = 50289.874,
            Y = 3423.232
        };
#endif
    }


    private Point _A = new();

    public Point A
    {
        get => _A;
        set
        {
            _A = value;
            RaisePropertyChanged();
        }
    }


    private Point _B = new();

    public Point B
    {
        get => _B;
        set
        {
            _B = value;
            RaisePropertyChanged();
        }
    }

    /// <summary>
    /// 控制计算按钮是否可用
    /// </summary>
    public bool CanCalculate => Math.Abs(A.X - B.X) >= 0.0001 || Math.Abs(A.Y - B.Y) >= 0.0001;


    private string _AzName = "A -> B 坐标方位角";

    public string AzName
    {
        get { return _AzName; }
        set
        {
            _AzName = value;
            RaisePropertyChanged();
        }
    }

    private string _azValue = "";

    public string AzValue
    {
        get { return _azValue; }
        set
        {
            _azValue = value;
            RaisePropertyChanged();
        }
    }

    private double _dist;

    public double Dist
    {
        get { return Math.Round(_dist, 3); }
        set
        {
            _dist = value;
            RaisePropertyChanged();
        }
    }

    public void CalculateAzimuth()
    {
        var ad = ZXY.SurMath.Azimuth(A.X, A.Y, B.X, B.Y);
        AzValue = ZXY.SurMath.RadianToDmsString(ad.a);
        Dist = ad.d;
        AzName = $"{A.Name} -> {B.Name} 坐标方位角";
    }

    public ICommand SwitchCommand => new RelayCommand((paramters) => SwitchAB());

    private void SwitchAB()
    {
        //var t = A;
        //A = B;
        //B = t;
        (A, B) = (B, A);
    }

    public ICommand CalculateCommand => new RelayCommand((paramters) => CalculateAzimuth(), (paramters) => CanCalculate);
}