using SmartRoute.Library;
using ZXY;

namespace TestSmartRouteLibrary;

[TestClass]
public class UnitTestCircularCurve
{
    private RPoint start = new RPoint(6821.350, 5599.3759);
    private RPoint jd = new RPoint(3135.12, 6848.320, 5634.240);
    private RPoint end = new RPoint(6846.31, 5678.27);

    [TestMethod]
    public void TestCircleCurveWithJD_ZY_alpha()
    {
        var r = new CircularCurve(start, jd, 40.2018, 120.0);

        Assert.AreEqual(120.0, r.Radius, 1e-1);
        Assert.AreEqual(52.163128188, SurMath.RadianToDms(r.Alpha0), 1e-9);
        Assert.AreEqual(40.201800000, SurMath.RadianToDms(r.Alpha), 1e-9);
        Assert.AreEqual(1, r.IsRight);
        Assert.AreEqual(44.07820316673106, r.T, 1e-3);
        Assert.AreEqual(84.48459193269431, r.L, 1e-3);
        Assert.AreEqual(7.839305357967348, r.E, 1e-3);
        Assert.AreEqual(3.6718144007678006, r.Q, 1e-3);

        Assert.AreEqual(3135.12, r.JD.KNo, 1e-2);
        Assert.AreEqual("K3+135.120", r.JD.KNoInfo);
        Assert.AreEqual(6848.32, r.JD.X, 1e-2);
        Assert.AreEqual(5634.24, r.JD.Y, 1e-2);
        Assert.AreEqual("JD", r.JD.Note);

        Assert.AreEqual(3091.041796833269, r.ZY.KNo, 1e-2);
        Assert.AreEqual("K3+91.042", r.ZY.KNoInfo);
        Assert.AreEqual(6821.34998871721, r.ZY.X, 1e-2);
        Assert.AreEqual(5599.3758854147445, r.ZY.Y, 1e-2);
        Assert.AreEqual("ZY", r.ZY.Note);

        Assert.AreEqual(3133.2840927996162, r.QZ.KNo, 1e-2);
        Assert.AreEqual("K3+133.284", r.QZ.KNoInfo);
        Assert.AreEqual(6840.8458057929065, r.QZ.X, 1e-2);
        Assert.AreEqual(5636.604556924692, r.QZ.Y, 1e-2);
        Assert.AreEqual("QZ", r.QZ.Note);

        Assert.AreEqual(3175.5263887659635, r.YZ.KNo, 1e-2);
        Assert.AreEqual("K3+175.526", r.YZ.KNoInfo);
        Assert.AreEqual(6846.309892919199, r.YZ.X, 1e-2);
        Assert.AreEqual(5678.272345655567, r.YZ.Y, 1e-2);
        Assert.AreEqual("YZ", r.YZ.Note);

        var pt = r.CalculatePointOnCurveByKno(3091.042);
        Assert.AreEqual(3091.042, pt.KNo, 1e-3);
        Assert.AreEqual("K3+91.042", pt.KNoInfo);
        Assert.AreEqual(6821.34998871721, pt.X, 1e-2);
        Assert.AreEqual(5599.3758854147445, pt.Y, 1e-2);
        Assert.AreEqual("ZY", pt.Note);

        pt = r.CalculatePointOnCurveByKno(3100.0);
        Assert.AreEqual(3100.0, pt.KNo, 1e-4);
        Assert.AreEqual("K3+100.000", pt.KNoInfo);
        Assert.AreEqual(6826.561778079592, pt.X, 1e-2);
        Assert.AreEqual(5606.65938692256, pt.Y, 1e-2);

        pt = r.CalculatePointOnCurveByKno(3120.0);
        Assert.AreEqual(3120.0, pt.KNo, 1e-4);
        Assert.AreEqual("K3+120.000", pt.KNoInfo);
        Assert.AreEqual(6836.146806434231, pt.X, 1e-4);
        Assert.AreEqual(5624.186570450684, pt.Y, 1e-4);

        pt = r.CalculatePointOnCurveByKno(3133.284);
        Assert.AreEqual(3133.284, pt.KNo, 1e-3);
        Assert.AreEqual("K3+133.284", pt.KNoInfo);
        Assert.AreEqual(6840.8458057929065, pt.X, 1e-4);
        Assert.AreEqual(5636.604556924692, pt.Y, 1e-4);
        Assert.AreEqual("QZ", pt.Note);

        pt = r.CalculatePointOnCurveByKno(3140.0);
        Assert.AreEqual(3140.0, pt.KNo, 1e-4);
        Assert.AreEqual("K3+140.000", pt.KNoInfo);
        Assert.AreEqual(6842.691325306174, pt.X, 1e-4);
        Assert.AreEqual(5643.061002991095, pt.Y, 1e-4);

        pt = r.CalculatePointOnCurveByKno(3160.0);
        Assert.AreEqual(3160.0, pt.KNo, 1e-4);
        Assert.AreEqual("K3+160.000", pt.KNoInfo);
        Assert.AreEqual(6846.013962930339, pt.X, 1e-4);
        Assert.AreEqual(5662.759607261607, pt.Y, 1e-4);

        pt = r.CalculatePointOnCurveByKno(3175.52);
        Assert.AreEqual(3175.52, pt.KNo, 1e-3);
        Assert.AreEqual("K3+175.520", pt.KNoInfo);
        Assert.AreEqual(6846.310184097475, pt.X, 1e-3);
        Assert.AreEqual(5678.265963528513, pt.Y, 1e-3);
    }

    [TestMethod]
    public void TestCircleCurveWithJD_ZY_alpha2()
    {
        RPoint ZD1 = new RPoint(45012.735, 23329.725);
        RPoint jd = new RPoint(3182.76, 45040.770, 23433.586);
        RPoint ZD2 = new RPoint(45021.329, 23536.502);

        var r = new CircularCurve(ZD1, jd, alpha: 25.4810, radius: 300);

        Assert.AreEqual(300, r.Radius, 1e-1);
        Assert.AreEqual(25.4810, SurMath.RadianToDms(r.Alpha), 1e-9);
        Assert.AreEqual(74.5339357, SurMath.RadianToDms(r.Alpha0), 1e-9);
        Assert.AreEqual(1, r.IsRight);
        Assert.AreEqual(68.72, r.T, 1e-2);
        Assert.AreEqual(135.103, r.L, 1e-3);
        Assert.AreEqual(7.769, r.E, 1e-3);
        Assert.AreEqual(2.331, r.Q, 1e-3);

        Assert.AreEqual(3114.04, r.ZY.KNo, 1e-2);
        Assert.AreEqual("K3+114.043", r.ZY.KNoInfo);
        Assert.AreEqual(45022.862, r.ZY.X, 1e-2);
        Assert.AreEqual(23367.244, r.ZY.Y, 1e-2);
        Assert.AreEqual("ZY", r.ZY.Note);

        Assert.AreEqual(3181.59, r.QZ.KNo, 1e-2);
        Assert.AreEqual("K3+181.595", r.QZ.KNoInfo);
        Assert.AreEqual(45033.006, r.QZ.X, 1e-2);
        Assert.AreEqual(23433.885, r.QZ.Y, 1e-2);
        Assert.AreEqual("QZ", r.QZ.Note);

        Assert.AreEqual(3249.14, r.YZ.KNo, 1e-2);
        Assert.AreEqual("K3+249.146", r.YZ.KNoInfo);
        Assert.AreEqual(45028.015, r.YZ.X, 1e-2);
        Assert.AreEqual(23501.109, r.YZ.Y, 1e-2);
        Assert.AreEqual("YZ", r.YZ.Note);
    }

    [TestMethod]
    public void TestCircleCurveWithJD_ZY_alpha3()
    {
        RPoint ZD1 = new RPoint(45012.735, 23329.725);
        RPoint jd = new RPoint(3182.76, 45040.770, 23433.586);
        RPoint ZD2 = new RPoint(45021.329, 23536.502);

        //¼ÆËãÆ«×ª½Ç
        double a = SurMath.RadianToDms(ZD1.CalculateAlpha(jd, ZD2));
        Assert.AreEqual(25.4810, a, 1e-4);

        var r = new CircularCurve(ZD1, jd, alpha: a, radius: 300);

        Assert.AreEqual(300, r.Radius, 1e-1);
        Assert.AreEqual(25.4810, SurMath.RadianToDms(r.Alpha), 1e-4);
        Assert.AreEqual(74.5339357, SurMath.RadianToDms(r.Alpha0), 1e-4);
        Assert.AreEqual(1, r.IsRight);
        Assert.AreEqual(68.72, r.T, 1e-2);
        Assert.AreEqual(135.103, r.L, 1e-3);
        Assert.AreEqual(7.769, r.E, 1e-3);
        Assert.AreEqual(2.331, r.Q, 1e-3);

        Assert.AreEqual(3114.04, r.ZY.KNo, 1e-2);
        Assert.AreEqual("K3+114.043", r.ZY.KNoInfo);
        Assert.AreEqual(45022.862, r.ZY.X, 1e-2);
        Assert.AreEqual(23367.244, r.ZY.Y, 1e-2);
        Assert.AreEqual("ZY", r.ZY.Note);

        Assert.AreEqual(3181.59, r.QZ.KNo, 1e-2);
        Assert.AreEqual("K3+181.595", r.QZ.KNoInfo);
        Assert.AreEqual(45033.006, r.QZ.X, 1e-2);
        Assert.AreEqual(23433.885, r.QZ.Y, 1e-2);
        Assert.AreEqual("QZ", r.QZ.Note);

        Assert.AreEqual(3249.14, r.YZ.KNo, 1e-2);
        Assert.AreEqual("K3+249.147", r.YZ.KNoInfo);
        Assert.AreEqual(45028.015, r.YZ.X, 1e-2);
        Assert.AreEqual(23501.109, r.YZ.Y, 1e-2);
        Assert.AreEqual("YZ", r.YZ.Note);
    }
}