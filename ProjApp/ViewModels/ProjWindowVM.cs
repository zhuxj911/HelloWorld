using Microsoft.Win32;
using ProjApp.Library;
using SurApp.WpfLibrary;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using ZXY;

namespace ProjApp.ViewModels;

public class ProjWindowVM : NotificationObject
{
    public ICommand NewFileCommand { get; set; }
    public ICommand OpenFileCommand { get; set; }
    public ICommand SaveFileCommand { get; set; }
    public ICommand SaveAsFileCommand { get; set; }
    public ICommand ClearBLCommand { get; set; }
    public ICommand ClearXYCommand { get; set; }

    public ICommand BLtoXYCommand { get; set; }
    public ICommand XYtoBLCommand { get; set; }
    public ICommand ShowAzimuthWindowCommand { get; set; }

    public ProjWindowVM()
    {
        NewFileCommand = new RelayCommand((paramters) => NewFile(), (paramters) => true);
        OpenFileCommand = new RelayCommand((paramters) => OpenFile(), (paramters) => true);
        SaveFileCommand = new RelayCommand((paramters) => SaveFile(), (paramters) => true);
        SaveAsFileCommand = new RelayCommand((paramters) => SaveAsFile(), (paramters) => true);
        ClearBLCommand = new RelayCommand((paramters) => ClearBL(), (paramters) => true);
        ClearXYCommand = new RelayCommand((paramters) => ClearXY(), (paramters) => true);
        BLtoXYCommand = new RelayCommand((paramters) => BLtoXYAsync(), (paramters) => true);
        XYtoBLCommand = new RelayCommand((paramters) => XYtoBLAsync(), (paramters) => true);
        ShowAzimuthWindowCommand = new RelayCommand((paramters) => ShowAzimuthWindow(), (paramters) => true);
    }

    private string fileName = "untitle";

    public string FileName
    {
        get => fileName;
        set
        {
            fileName = value;
            RaisePropertyChanged(() => FileName);
            RaisePropertyChanged(() => Title);
        }
    }

    public string Title
    {
        get => $"测量螺丝刀(Ver2024.10)-{FileName}";
    }

    private List<Ellipsoid> ellipsoidList = EllipsoidFactory.EllipsoidList;

    public List<Ellipsoid> EllipsoidList
    {
        get => ellipsoidList;
    }

    public static Dictionary<string, Ellipsoid> Ellipsoids => EllipsoidFactory.Ellipsoids;


    private Ellipsoid currentEllipsoid = EllipsoidFactory.EllipsoidList[0];

    public Ellipsoid CurrentEllipsoid
    {
        get => currentEllipsoid;
        set
        {
            currentEllipsoid = value;
            RaisePropertyChanged();
        }
    }

    private double _dmsL0;

    public double dmsL0
    {
        get => _dmsL0;
        set
        {
            _dmsL0 = value;
            RaisePropertyChanged();
        }
    }

    private double _YKM;

    public double YKM
    {
        get => _YKM;
        set
        {
            _YKM = value;
            RaisePropertyChanged();
        }
    }

    private int _NY;

    public int NY
    {
        get => _NY;
        set
        {
            _NY = value;
            RaisePropertyChanged();
        }
    }

    private readonly ObservableCollection<GPoint> pointList = [];

    public ObservableCollection<GPoint> PointList
    {
        get => pointList;
    }

    public void OpenFile()
    {
        OpenFileDialog dlg = new OpenFileDialog();
        dlg.DefaultExt = ".txt";
        dlg.Filter = "高斯投影数据文件|*.txt|All File(*.*)|*.*";
        if (dlg.ShowDialog() != true) return;
        FileName = dlg.FileName;

        using (StreamReader sr = new StreamReader(FileName))
        {
            string[] items = null;
            PointList.Clear();
            while (true)
            {
                string buffer = sr.ReadLine();
                if (buffer == null) break;

                buffer = buffer.Trim();
                if (buffer == string.Empty) continue;

                if (buffer[0] == '#') continue;

                if (buffer.Contains(':'))
                {
                    items = buffer.Split(new char[] { ':' });
                    string cap = items[0].Trim();
                    switch (cap)
                    {
                        case "CS":
                            {
                                string item2 = items[1].Trim();
                                //if (item2 == "BJ54")
                                //    CurrentEllipsoid = Ellipsoids["BJ54"];
                                //else if (item2 == "XA80")
                                //    CurrentEllipsoid = Ellipsoids["XA80"];
                                //else if (item2 == "WGS84")
                                //    CurrentEllipsoid = Ellipsoids["WGS84"];
                                //else if (item2 == "CGCS2000")
                                //    CurrentEllipsoid = Ellipsoids["CGCS2000"];
                                //else
                                //{
                                //    string[] its = item2.Split(new char[1] { ',' });
                                //    if (its.Length == 3 && its[0] == "CS00")
                                //    {
                                //        CurrentEllipsoid = Ellipsoids["CS00"];
                                //        CurrentEllipsoid.a = double.Parse(its[1]);
                                //        CurrentEllipsoid.f = double.Parse(its[2]);
                                //    }
                                //}
                                if (item2 == "BJ54" || item2 == "XA80" || item2 == "WGS84" || item2 == "CGCS2000")
                                    CurrentEllipsoid = Ellipsoids[item2];
                                else
                                {
                                    string[] its = item2.Split(new char[1] { ',' });
                                    if (its.Length == 3 && its[0] == "CS00")
                                    {
                                        CurrentEllipsoid = Ellipsoids["CS00"];
                                        CurrentEllipsoid.a = double.Parse(its[1]);
                                        CurrentEllipsoid.f = double.Parse(its[2]);
                                    }
                                }
                            }
                            break;

                        case "L0":
                            dmsL0 = double.Parse(items[1]);
                            break;

                        case "YKM":
                            YKM = double.Parse(items[1]);
                            break;

                        case "N":
                            NY = int.Parse(items[1]);
                            break;

                        default:
                            break;
                    }
                    continue;
                }

                items = buffer.Split(new char[1] { ',' });
                if (items.Length < 3) continue; //少于三项数据，不是点的坐标数据，忽略
                GPoint pnt = new GPoint();
                pnt.Name = items[0].Trim();
                pnt.X = double.Parse(items[1]);
                pnt.Y = double.Parse(items[2]);

                if (items.Length >= 5)
                {
                    //默认为 D.MMSS
                    pnt.dmsB = double.Parse(items[3]);
                    pnt.dmsL = double.Parse(items[4]);
                }
                PointList.Add(pnt);
            }
        }
    }

    private void WriteFile()
    {
        using (StreamWriter sw = new StreamWriter(FileName))
        {
            sw.WriteLine("#数据文件中的 # : , 均应为英文字符");
            sw.WriteLine("#以#开头的行视为注释行");
            sw.WriteLine("#可以忽略0个空格的行");
            sw.WriteLine("#可以忽略有多个空格的行");
            sw.WriteLine();

            sw.WriteLine("#CS 指定坐标系 BJ54 XA80 CGCS2000 WGS84 CS00");
            sw.WriteLine("#CS: BJ54");
            sw.WriteLine("#CS: XA80");
            sw.WriteLine("#CS: WGS84");
            sw.WriteLine("#CS: CGCS2000");
            sw.WriteLine("#CS: CS00, 6378137, 298.257222101");
            if (CurrentEllipsoid.Id == "CS00")
            {
                sw.WriteLine($"CS: {CurrentEllipsoid.Id}, {CurrentEllipsoid.a}, {CurrentEllipsoid.f}");
            }
            else
            {
                sw.WriteLine($"CS: {CurrentEllipsoid.Id}");
            }
            sw.WriteLine();

            sw.WriteLine($"L0: {dmsL0}");
            sw.WriteLine($"YKM: {YKM}");
            sw.WriteLine($"N: {NY}");

            sw.WriteLine();
            sw.WriteLine("#点名, X, Y, B, L");
            foreach (var pnt in PointList)
            {
                sw.WriteLine(pnt);
            }
            sw.Close();
        }
    }

    public void SaveFile()
    {
        if (FileName == "untitle")
            SaveAsFile();
        else
            WriteFile();
    }

    public void SaveAsFile()
    {
        SaveFileDialog dlg = new SaveFileDialog();
        dlg.DefaultExt = ".txt";
        dlg.Filter = "高斯投影数据文件|*.txt|All File(*.*)|*.*";
        if (dlg.ShowDialog() != true) return;
        FileName = dlg.FileName;

        WriteFile();
    }

    public async Task BLtoXYAsync() //需要执行完毕后才能更新界面， 因此需使用 await
    {
        //开启线程进行计算，避免阻塞主线程
        await Task.Factory.StartNew(() =>
        {
            IProj proj = new GaussProj(CurrentEllipsoid);
            double L0 = SurMath.DmsToRadian(dmsL0);
            foreach (var pnt in PointList)
            {
                double B = SurMath.DmsToRadian(pnt.dmsB);
                double L = SurMath.DmsToRadian(pnt.dmsL);
                var xy = proj.BLtoXY(B, L, L0, YKM, NY);
                pnt.X = xy.X;
                pnt.Y = xy.Y;
                pnt.Gamma = xy.gamma;
                pnt.m = xy.m;
            }
        });
    }

    public async Task XYtoBLAsync()
    {
        await Task.Factory.StartNew(() =>
        {
            IProj proj = new GaussProj(CurrentEllipsoid);
            double L0 = SurMath.DmsToRadian(dmsL0);
            foreach (var pnt in PointList)
            {
                var BL = proj.XYtoBL(pnt.X, pnt.Y, L0, YKM, NY);
                pnt.dmsB = SurMath.RadianToDms(BL.B);
                pnt.dmsL = SurMath.RadianToDms(BL.L);
                pnt.Gamma = BL.gamma;
                pnt.m = BL.m;
            }
        }); //开启线程进行计算，避免阻塞主线程
    }

    public void ClearXY()
    {
        foreach (var pnt in PointList)
        {
            pnt.X = 0;
            pnt.Y = 0;
            pnt.Gamma = 0;
            pnt.m = 0;
        }
    }

    public void ClearBL()
    {
        foreach (var pnt in PointList)
        {
            pnt.dmsB = 0;
            pnt.dmsL = 0;
            pnt.Gamma = 0;
            pnt.m = 0;
        }
    }

    public void NewFile()
    {
        CurrentEllipsoid = Ellipsoids["CGCS2000"];
        dmsL0 = 0;
        YKM = 0;
        NY = 0;
        PointList.Clear();
    }

    /// <summary>
    /// 显示坐标方位角计算窗体
    /// </summary>
    public void ShowAzimuthWindow()
    {
        AzimuthWindow dlg = new AzimuthWindow();
        dlg.ShowDialog();
    }
}