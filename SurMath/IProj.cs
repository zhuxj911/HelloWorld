namespace ZXY
{
  public interface IProj
    {
        (double X, double Y, double gamma, double m) BLtoXY(double B, double L, double L0, double YKM, int Zone);

        (double B, double L, double gamma, double m) XYtoBL(double X, double Y, double L0, double YKM, int Zone);
    }
}
