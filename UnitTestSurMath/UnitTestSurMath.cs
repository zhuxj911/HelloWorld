using Microsoft.VisualStudio.TestTools.UnitTesting;

using ZXY;

namespace UnitTestSurMath
{
    [TestClass]
    public class UnitTestSurMath
    {
        [TestMethod]
        public void TestDmsToRadian()
        {
            double rad = SurMath.DmsToRadian(101.03201);
            Assert.AreEqual(1.763752656690170, rad, 1e-14);
            rad = SurMath.DmsToRadian(-101.03201);
            Assert.AreEqual(-1.763752656690170, rad, 1e-14);

            rad = SurMath.DmsToRadian(1.4001);
            Assert.AreEqual(0.0290936690033833000, rad, 1e-14);

            rad = SurMath.DmsToRadian(1.4000);
            Assert.AreEqual(0.0290888208665722, rad, 1e-14);
            rad = SurMath.DmsToRadian(-1.4000);
            Assert.AreEqual(-0.0290888208665722, rad, 1e-14);
        }

        [TestMethod]
        public void TestDMStoString()
        {
            var str = SurMath.DmsToDmsString(101.03201);
            Assert.AreEqual("101��03��20.1��", str);

            str = SurMath.DmsToDmsString(-101.03201);
            Assert.AreEqual("-101��03��20.1��", str);

            str = SurMath.DmsToDmsString(0.4001);
            Assert.AreEqual("0��40��01��", str);

            str = SurMath.DmsToDmsString(-0.4001);
            Assert.AreEqual("-0��40��01��", str);

            str = SurMath.DmsToDmsString(1.4001);
            Assert.AreEqual("1��40��01��", str);

            str = SurMath.DmsToDmsString(1.4000);
            Assert.AreEqual("1��40��00��", str);

            str = SurMath.DmsToDmsString(-1.4000);
            Assert.AreEqual("-1��40��00��", str);
        }

        [TestMethod]
        public void TestRadtoDMS()
        {
            var rad = SurMath.DmsToRadian(101.03201);
            var angle = SurMath.Radian2Dms(rad); // 1.763752656690170 // 101.03201
            Assert.AreEqual(101, angle.d);
            Assert.AreEqual(3, angle.m);
            Assert.AreEqual(20.1, angle.s, 1e-8);

            angle = SurMath.Radian2Dms(-1.763752656690170);
            Assert.AreEqual(-101, angle.d);
            Assert.AreEqual(-3, angle.m);
            Assert.AreEqual(-20.1, angle.s, 1e-8);

            angle = SurMath.Radian2Dms(0.0290888208665722);
            Assert.AreEqual(1, angle.d);
            Assert.AreEqual(40, angle.m);
            Assert.AreEqual(0, angle.s, 1e-8);

            angle = SurMath.Radian2Dms(-0.0290888208665722);
            Assert.AreEqual(-1, angle.d);
            Assert.AreEqual(-40, angle.m);
            Assert.AreEqual(0, angle.s, 1e-8);

            angle = SurMath.Radian2Dms(-0.0290936690033833000);
            Assert.AreEqual(-1, angle.d);
            Assert.AreEqual(-40, angle.m);
            Assert.AreEqual(-1, angle.s, 1e-8);
        }

        [TestMethod]
        public void TestRadtoString()
        {
            string dms = SurMath.RadianToDmsString(0.0234165007975906);
            Assert.AreEqual<string>("1��20��30��", dms);

            dms = SurMath.RadianToDmsString(-0.0234165007975906);
            Assert.AreEqual<string>("-1��20��30��", dms);

            dms = SurMath.RadianToDmsString(0.02908882086657220);
            Assert.AreEqual<string>("1��40��00��", dms);

            dms = SurMath.RadianToDmsString(-0.02908882086657220);
            Assert.AreEqual<string>("-1��40��00��", dms);

            dms = SurMath.RadianToDmsString(0.02908930568025330);
            Assert.AreEqual<string>("1��40��00.1��", dms);

            dms = SurMath.RadianToDmsString(-0.02908930568025330);
            Assert.AreEqual<string>("-1��40��00.1��", dms);

            dms = SurMath.RadianToDmsString(0.69580806988502100); //39 52 0.71672
            Assert.AreEqual<string>("39��52��00.71672��", dms);

            dms = SurMath.RadianToDmsString(-0.69580806988502100); //-39 52 0.71672
            Assert.AreEqual<string>("-39��52��00.71672��", dms);
        }

        [TestMethod]
        public void TestAzimuth()
        {
            double xA = 50342.464;
            double yA = 3423.232;
            double xB = 50289.874;
            double yB = 3528.978;
            var az = SurMath.Azimuth(xA, yA, xB, yB);
            Assert.AreEqual<string>("116��26��32.102984��", SurMath.RadianToDmsString(az.a));

            xA = 50289.874;
            yA = 3528.978;
            xB = 50342.464;
            yB = 3423.232;
            az = SurMath.Azimuth(xA, yA, xB, yB);
            Assert.AreEqual<string>("296��26��32.102984��", SurMath.RadianToDmsString(az.a));

            xA = 50342.464;
            yA = 3423.232;
            xB = 50389.874;
            yB = 3528.978;
            az = SurMath.Azimuth(xA, yA, xB, yB);
            Assert.AreEqual<string>("65��51��05.295961��", SurMath.RadianToDmsString(az.a));

            xA = 50389.874;
            yA = 3528.978;
            xB = 50342.464;
            yB = 3423.232;
            az = SurMath.Azimuth(xA, yA, xB, yB);
            Assert.AreEqual<string>("245��51��05.295961��", SurMath.RadianToDmsString(az.a));
        }
    }
}