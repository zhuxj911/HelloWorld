using SmartRoute.Library;
using ZXY;

namespace TestSmartRouteLibrary;

[TestClass]
public class UnitTestTransitionCurve
{
    [TestMethod]
    public void TestTransitionCurveWithJD_ZY_alpha()
    {
        RPoint start = new RPoint(3088256.238, 66798.566);
        RPoint jd = new RPoint(5330.198, 3088386.436, 66798.566);
        RPoint end = new RPoint(3088514.534, 66821.858);

        var r = new TransitionCurve(start, jd, alpha: 10.1820, radius: 1000.0, l0: 80.0);

        Assert.AreEqual(1000.0, r.Radius, 1e-1);
        Assert.AreEqual(80.0, r.L0, 1e-1);
        Assert.AreEqual(0.0, SurMath.RadianToDms(r.Alpha0), 1e-9);
        Assert.AreEqual(10.1820, SurMath.RadianToDms(r.Alpha), 1e-9);
        Assert.AreEqual(1, r.IsRight);
        Assert.AreEqual(130.19809566293094, r.T, 1e-3);
        Assert.AreEqual(259.8658756916379, r.L, 1e-3);
        Assert.AreEqual(0.26666666666666666, r.P, 1e-9);
        Assert.AreEqual(4.325388385369251, r.E, 1e-3);
        Assert.AreEqual(0.5303156342239959, r.Q, 1e-3);
        Assert.AreEqual(2.173059225, SurMath.RadianToDms(r.Beta0), 1e-9);
        Assert.AreEqual(39.99786666666667, r.M, 1e-9);

        Assert.AreEqual(5330.198, r.JD.KNo, 1e-3);
        Assert.AreEqual("K5+330.198", r.JD.KNoInfo);
        Assert.AreEqual(3088386.436, r.JD.X, 1e-3);
        Assert.AreEqual(66798.566, r.JD.Y, 1e-3);
        Assert.AreEqual("JD", r.JD.Note);

        Assert.AreEqual(5200.0, r.ZH.KNo, 1e-1);
        Assert.AreEqual("K5+200.000", r.ZH.KNoInfo);
        Assert.AreEqual(3088256.238, r.ZH.X, 1e-3);
        Assert.AreEqual(66798.566, r.ZH.Y, 1e-3);
        Assert.AreEqual("ZH", r.ZH.Note);

        Assert.AreEqual(5280.0, r.HY.KNo, 1e-1);
        Assert.AreEqual("K5+280.000", r.HY.KNoInfo);
        Assert.AreEqual(3088336.225, r.HY.X, 1e-3);
        Assert.AreEqual(66799.632, r.HY.Y, 1e-3);
        Assert.AreEqual("HY", r.HY.Note);

        Assert.AreEqual(5329.933, r.QZ.KNo, 1e-3);
        Assert.AreEqual("K5+329.933", r.QZ.KNoInfo);
        Assert.AreEqual(3088386.048, r.QZ.X, 1e-3);
        Assert.AreEqual(66802.874, r.QZ.Y, 1e-2);
        Assert.AreEqual("QZ", r.QZ.Note);

        Assert.AreEqual(5379.866, r.YH.KNo, 1e-3);
        Assert.AreEqual("K5+379.866", r.YH.KNoInfo);
        Assert.AreEqual(3088435.646, r.YH.X, 1e-3);
        Assert.AreEqual(66808.598, r.YH.Y, 1e-3);
        Assert.AreEqual("YH", r.YH.Note);

        Assert.AreEqual(5459.866, r.HZ.KNo, 1e-3);
        Assert.AreEqual("K5+459.866", r.HZ.KNoInfo);
        Assert.AreEqual(3088514.534, r.HZ.X, 1e-3);
        Assert.AreEqual(66821.858, r.HZ.Y, 1e-3);
        Assert.AreEqual("HZ", r.HZ.Note);

        var pt = r.CalculatePointOnCurveByKno(5240); //ZH-HY
        Assert.AreEqual(5240.0, pt.KNo, 1e-3);
        Assert.AreEqual("K5+240.000", pt.KNoInfo);
        Assert.AreEqual(3088296.238, pt.X, 1e-3);
        Assert.AreEqual(66798.699, pt.Y, 1e-3);

        pt = r.CalculatePointOnCurveByKno(5320); //HY-QZ
        Assert.AreEqual(5320.0, pt.KNo, 1e-4);
        Assert.AreEqual("K5+320.000", pt.KNoInfo);
        Assert.AreEqual(3088376.150, pt.X, 1e-3);
        Assert.AreEqual(66802.031, pt.Y, 1e-3);

        pt = r.CalculatePointOnCurveByKno(5359.866); //QZ-YH
        Assert.AreEqual(5359.866, pt.KNo, 1e-3);
        Assert.AreEqual("K5+359.866", pt.KNoInfo);
        Assert.AreEqual(3088415.815, pt.X, 1e-3);
        Assert.AreEqual(66806.008, pt.Y, 1e-3);

        pt = r.CalculatePointOnCurveByKno(5419.866); //YH-HZ
        Assert.AreEqual(5419.866, pt.KNo, 1e-3);
        Assert.AreEqual("K5+419.866", pt.KNoInfo);
        Assert.AreEqual(3088475.156, pt.X, 1e-3);
        Assert.AreEqual(66814.834, pt.Y, 1e-3);
    }
}