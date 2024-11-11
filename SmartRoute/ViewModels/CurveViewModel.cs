using SmartRoute.Library;
using SurApp.WpfLibrary;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using ZXY;

namespace SmartRoute.ViewModels
{
    public enum DataInputMethod
    {
        DirAngle, ThreePoint, Line
    }

    public class DataInputConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //value 绑定源中的值， 指CurveViewModel中的 DataInputMethod 属性
            //parameter 绑定时传进来的参数
            if (value == null || parameter == null)
                return false;
            else
                return value.Equals(parameter); // value == parameter
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // value 控件的值， 点击 RadioButton 时， 值为true
            // parameter 为控件RadioButton点击时的传递的参数
            // return value.Equals(true) ? parameter : Binding.DoNothing;
            return parameter;
        }
    }

    public class CurveViewModel : NotificationObject
    {
        public CurveViewModel()
        {
            calculateAlphaCommand = new RelayCommand(
                (object? parameter) => OnCalculateAzimuth(),
                (object? parameter) => CanCalculateDirAngle);

            calculatePointOnCurveByKnoCommand = new RelayCommand(
                (object? parameter) => OnCalculatePointOnCurveByKno(),
                (object? parameter) => AnyKNo > 0);

            calculateBatchPointsOnCurveCommand = new RelayCommand(
                (object? parameter) => OnCalculateBatchPointsOnCurve(),
                (object? parameter) => Length >= 5); //里程间距大于5m时可以使用

            //设置测试数据的命令
            setCurveTestDataCommand = new RelayCommand((object? parameter) => OnSetCurveTestData(parameter), (object? parameter) => true);
        }

        private RPoint jd = new RPoint();
        public RPoint JD => jd;

        private RPoint start = new RPoint();
        public RPoint Start => start;

        private RPoint end = new RPoint();
        public RPoint End => end;

        private DataInputMethod dataInput = DataInputMethod.DirAngle;

        public DataInputMethod DataInput
        {
            get => dataInput;
            set
            {
                if (dataInput != value)
                {
                    dataInput = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(() => CanCalculateDirAngle);
                }
            }
        }

        public bool CanCalculateDirAngle
        {
            get => DataInput == DataInputMethod.ThreePoint;
        }

        private double alpha = 0.0;

        public double Alpha
        {
            get => alpha;
            set
            {
                if (alpha != value)
                {
                    alpha = value;
                    RaisePropertyChanged();
                }
            }
        }

        private double radius = 0.0;

        public double Radius
        {
            get => radius;
            set
            {
                if (radius != value)
                {
                    radius = value;
                    RaisePropertyChanged();
                }
            }
        }

        private double l0 = 0.0;

        public double L0
        {
            get => l0;
            set
            {
                if (l0 != value)
                {
                    l0 = value;
                    RaisePropertyChanged();
                }
            }
        }

        private double anyKNo = 0.0;

        public double AnyKNo
        {
            get => anyKNo;
            set
            {
                if (anyKNo != value)
                {
                    anyKNo = value;
                    RaisePropertyChanged();
                }
            }
        }

        private double length = 0.0;

        public double Length
        {
            get => length;
            set
            {
                if (length != value)
                {
                    length = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string curveyKeyFeature = "";

        public string CurveyKeyFeature
        {
            get => curveyKeyFeature;
            set
            {
                if (curveyKeyFeature != value)
                {
                    curveyKeyFeature = value;
                    RaisePropertyChanged();
                }
            }
        }

        //计算线路偏转角命令
        public void OnCalculateAzimuth()
        {
            Alpha = ZXY.SurMath.RadianToDms(Start.CalculateAlpha(JD, End));
        }

        private RelayCommand calculateAlphaCommand;
        public RelayCommand CalculateAlphaCommand => calculateAlphaCommand;

        private ObservableCollection<Point> points = new ObservableCollection<Point>();
        public ObservableCollection<Point> Points => points;

        //根据里程桩号计算线路上点的坐标
        public void OnCalculatePointOnCurveByKno()
        {
            ICurve r;
            if (L0 <= 0.0)
            {
                r = new CircularCurve(start, jd, Alpha, Radius);
            }
            else
            {
                r = new TransitionCurve(start, jd, Alpha, Radius, L0);
            }
            CurveyKeyFeature = r.ToString();

            Points.Clear();
            var pt = r.CalculatePointOnCurveByKno(AnyKNo);
            if (pt != null)
            {
                points.Add(pt);
            }
        }

        private RelayCommand calculatePointOnCurveByKnoCommand;
        public RelayCommand CalculatePointOnCurveByKnoCommand => calculatePointOnCurveByKnoCommand;

        //根据里程桩号间距计算线路上所有点的坐标

        public void OnCalculateBatchPointsOnCurve()
        {
            ICurve r;
            if (L0 <= 0.0)
            {
                r = new CircularCurve(start, jd, Alpha, Radius);
            }
            else
            {
                r = new TransitionCurve(start, jd, Alpha, Radius, L0);
            }
            CurveyKeyFeature = r.ToString();

            Points.Clear();
            r.CalculateBatchPointsOnCurve(Length).ForEach(pt => Points.Add(pt));
        }

        private RelayCommand calculateBatchPointsOnCurveCommand;
        public RelayCommand CalculateBatchPointsOnCurveCommand => calculateBatchPointsOnCurveCommand;

        private RelayCommand setCurveTestDataCommand;
        public RelayCommand SetCurveTestDataCommand => setCurveTestDataCommand;

        public void OnSetCurveTestData(object? parameter)
        {
            int type = 0;
            if (parameter != null)
            {
                type = Convert.ToInt32(parameter);
            }

            switch (type)
            {
                case 0:
                    SetCircleCurve1();
                    break;

                case 1:
                    SetCircleCurve2();
                    break;

                case 2:
                    SetTransitionCurve1();
                    break;

                default:
                    SetCircleCurve1();
                    break;
            }
        }

        public void SetCircleCurve1()
        {
            Start.X = 6821.350; Start.Y = 5599.3759;
            JD.KNo = 3135.12; JD.X = 6848.320; JD.Y = 5634.240;
            End.X = 6846.31; End.Y = 5678.27;
            Radius = 120.0;
            Alpha = 40.2018;
            L0 = 0.0;
            AnyKNo = 3130.0;
            Length = 10.0;
        }

        public void SetCircleCurve2()
        {
            Start.X = 45012.735; Start.Y = 23329.725;
            JD.KNo = 3182.76; JD.X = 45040.770; JD.Y = 23433.586;
            End.X = 45021.329; End.Y = 23536.502;
            Radius = 300.0;
            Alpha = 25.4810;
            L0 = 0.0;
            AnyKNo = 3190.0;
            Length = 10.0;
        }

        public void SetTransitionCurve1()
        {
            Start.X = 3088256.238; Start.Y = 66798.566;
            JD.KNo = 5330.198; JD.X = 3088386.436; JD.Y = 66798.566;
            End.X = 3088514.534; End.Y = 66821.858;

            Radius = 1000.0;
            Alpha = 10.1820;
            L0 = 80.0;
            AnyKNo = 5400.0;
            Length = 20.0;
        }
    }
}