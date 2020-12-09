using System.Collections.Generic;

namespace ZXY
{
  public static class EllipsoidFactory
  {
    private static List<Ellipsoid> ellipsoidList = new List<Ellipsoid>();
    public static List<Ellipsoid> EllipsoidList => ellipsoidList;

    //用于数据文件的读写，根据参考椭球带号查找相应椭球
    private static Dictionary<string, Ellipsoid> ellipsoids = new Dictionary<string, Ellipsoid>();
    public static Dictionary<string, Ellipsoid> Ellipsoids => ellipsoids;

    static EllipsoidFactory()
    {
      ellipsoidList.Add(Ellipsoid.CreateCGCS2000());
      ellipsoidList.Add(Ellipsoid.CreateBeijing1954());
      ellipsoidList.Add(Ellipsoid.CreateXiAn1980());
      ellipsoidList.Add(Ellipsoid.CreateWGS1984());
      ellipsoidList.Add(Ellipsoid.CreateCustom(6378137, 298.257222101));

      //用于数据文件的读写，根据参考椭球带号查找相应椭球
      foreach (var it in ellipsoidList)
      {
        Ellipsoids.Add(it.Id, it);
      }
    }
  }
}
