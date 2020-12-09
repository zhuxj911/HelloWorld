using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using ZXY;
using ZXY.Drawing;

namespace SurApp
{
  public class ProjWindowVM : NotificationObject
  {
    private string fileName="New Document";
    public string FileName 
    {
      get => fileName;
      set
      {
        fileName = value;
        RaisePropertyChanged("FileName");
      }
    }

    private List<Ellipsoid> ellipsoidList = EllipsoidFactory.EllipsoidList;
    public List<Ellipsoid> EllipsoidList
    {
      get => ellipsoidList;
    }

    public Dictionary<string, Ellipsoid> Ellipsoids
    {
      get => EllipsoidFactory.Ellipsoids;
    }

    private Ellipsoid currentEllipsoid = EllipsoidFactory.EllipsoidList[0];
    public Ellipsoid CurrentEllipsoid
    {
      get => currentEllipsoid;
      set
      {
        currentEllipsoid = value;
        RaisePropertyChanged("CurrentEllipsoid");
      }
    }

    private double _dmsL0;
    public double dmsL0
    {
      get => _dmsL0;
      set
      {
        _dmsL0 = value;
        RaisePropertyChanged("dmsL0");
      }
    }

    private double _YKM;
    public double YKM
    {
      get => _YKM;
      set
      {
        _YKM = value;
        RaisePropertyChanged("YKM");
      }
    }

    private double _NY;
    public double NY
    {
      get => _NY;
      set
      {
        _NY = value;
        RaisePropertyChanged("_NY");
      }
    }

    private ObservableCollection<SPoint> sPointList = new ObservableCollection<SPoint>();
    public ObservableCollection<SPoint> SPointList
    {
      get => sPointList;
    }

    public void Open()
    {
      OpenFileDialog dlg = new OpenFileDialog();
      dlg.DefaultExt = ".txt";
      dlg.Filter = "高斯投影数据文件|*.txt|All File(*.*)|*.*";
      if (dlg.ShowDialog() != true) return;
      FileName = dlg.FileName;

      using (StreamReader sr = new StreamReader(FileName))
      {
        string[] items = null;
        while (true)
        {
          string buffer = sr.ReadLine();
          if (buffer == null) break;

          buffer = buffer.Trim();
          if (buffer == string.Empty) continue;

          if (buffer[0] == '#') continue;

          if(buffer.Contains(':'))
          {
            items = buffer.Split(new char[] { ':' });
            string cap = items[0].Trim();
            switch (cap)
            {
              case "CS":
                {
                  string item2 = items[1].Trim();
                  if (item2 == "BJ54")                   
                   CurrentEllipsoid = Ellipsoids["BJ54"];
                  else if (item2 == "XA80")
                    CurrentEllipsoid = Ellipsoids["XA80"];
                  else if (item2 == "WGS84")
                    CurrentEllipsoid = Ellipsoids["WGS84"];
                  else if (item2 == "CGCS2000")
                    CurrentEllipsoid = Ellipsoids["CGCS2000"];
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
                this.dmsL0 = double.Parse(items[1]);
                break;
              case "YKM":
                this.YKM = double.Parse(items[1]);
                break;
              case "N":
                this.NY = int.Parse(items[1]);
                break;
              default:
                break;
            }
            continue;
          }

          items = buffer.Split(new char[1] { ',' });
          if (items.Length < 3) continue; //少于三项数据，不是点的坐标数据，忽略
          SPoint pnt = new SPoint();
          pnt.Name = items[0].Trim();
          pnt.X = double.Parse(items[1]);
          pnt.Y = double.Parse(items[2]);

          if (items.Length >= 5)
          {
            //默认为 D.MMSS
            pnt.dmsB = double.Parse(items[3]);
            pnt.dmsL = double.Parse(items[4]);
          }
          this.SPointList.Add(pnt);
        }
      }
    }

    public void Save()
    {
      //OpenFileDialog dlg = new OpenFileDialog();
      //dlg.DefaultExt = ".txt";
      //dlg.Filter = "高斯投影数据文件|*.txt|All File(*.*)|*.*";
      //if (dlg.ShowDialog() != true) return;
    }

    public void SaveAs()
    {
      SaveFileDialog dlg = new SaveFileDialog();
      dlg.DefaultExt = ".txt";
      dlg.Filter = "高斯投影数据文件|*.txt|All File(*.*)|*.*";
      if (dlg.ShowDialog() != true) return;
    }
  }
}
