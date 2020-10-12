using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSurMath
{
    [TestClass]
    public class UnitTestSurMath
    {
        [TestMethod]
        public void TestDMStoRad()
        {
            double rad = ZXY.SurMath.DMStoRad(101.03201);
            Assert.AreEqual(1.763752656690170, rad, 1e-14);
            rad = ZXY.SurMath.DMStoRad(-101.03201);
            Assert.AreEqual(-1.763752656690170, rad, 1e-14);

            rad = ZXY.SurMath.DMStoRad(1.4001);
            Assert.AreEqual(0.0290936690033833000, rad, 1e-14);

            rad = ZXY.SurMath.DMStoRad(1.4000);
            Assert.AreEqual(0.0290888208665722, rad, 1e-14);
            rad = ZXY.SurMath.DMStoRad(-1.4000);
            Assert.AreEqual(-0.0290888208665722, rad, 1e-14);
        }

        [TestMethod]
        public void TestDMStoString()
        {
            var str = ZXY.SurMath.DMStoString(101.03201);
            Assert.AreEqual("101��03��20.1��", str);

            str = ZXY.SurMath.DMStoString(-101.03201);
            Assert.AreEqual("-101��03��20.1��", str);

            str = ZXY.SurMath.DMStoString(0.4001);
            Assert.AreEqual("0��40��01��", str);

            str = ZXY.SurMath.DMStoString(-0.4001);
            Assert.AreEqual("-0��40��01��", str);

            str = ZXY.SurMath.DMStoString(1.4001);
            Assert.AreEqual("1��40��01��", str);

            str = ZXY.SurMath.DMStoString(1.4000);
            Assert.AreEqual("1��40��00��", str);

            str = ZXY.SurMath.DMStoString(-1.4000);
            Assert.AreEqual("-1��40��00��", str);
        }

        [TestMethod]
        public void TestRadtoDMS()
        {
            var rad = ZXY.SurMath.DMStoRad(101.03201);
            var angle = ZXY.SurMath.Rad2DMS(rad); // 1.763752656690170 // 101.03201
            Assert.AreEqual(101, angle.d);
            Assert.AreEqual(3, angle.m);
            Assert.AreEqual(20.1, angle.s, 1e-8);

            angle = ZXY.SurMath.Rad2DMS(-1.763752656690170);
            Assert.AreEqual(-101, angle.d);
            Assert.AreEqual(-3, angle.m);
            Assert.AreEqual(-20.1, angle.s, 1e-8);

            angle = ZXY.SurMath.Rad2DMS(0.0290888208665722);
            Assert.AreEqual(1, angle.d);
            Assert.AreEqual(40, angle.m);
            Assert.AreEqual(0, angle.s, 1e-8);

            angle = ZXY.SurMath.Rad2DMS(-0.0290888208665722);
            Assert.AreEqual(-1, angle.d);
            Assert.AreEqual(-40, angle.m);
            Assert.AreEqual(0, angle.s, 1e-8);

            angle = ZXY.SurMath.Rad2DMS(-0.0290936690033833000);
            Assert.AreEqual(-1, angle.d);
            Assert.AreEqual(-40, angle.m);
            Assert.AreEqual(-1, angle.s, 1e-8);
        }

        [TestMethod]
        public void TestRadtoString()
        {
            string dms = ZXY.SurMath.RadtoString(0.0234165007975906);
            Assert.AreEqual<string>("1��20��30��", dms);

            dms = ZXY.SurMath.RadtoString(-0.0234165007975906);
            Assert.AreEqual<string>("-1��20��30��", dms);

            dms = ZXY.SurMath.RadtoString(0.02908882086657220);
            Assert.AreEqual<string>("1��40��00��", dms);

            dms = ZXY.SurMath.RadtoString(-0.02908882086657220);
            Assert.AreEqual<string>("-1��40��00��", dms);

            dms = ZXY.SurMath.RadtoString(0.02908930568025330);
            Assert.AreEqual<string>("1��40��00.1��", dms);

            dms = ZXY.SurMath.RadtoString(-0.02908930568025330);
            Assert.AreEqual<string>("-1��40��00.1��", dms);

            dms = ZXY.SurMath.RadtoString(0.69580806988502100); //39 52 0.71672
            Assert.AreEqual<string>("39��52��00.71672��", dms);

            dms = ZXY.SurMath.RadtoString(-0.69580806988502100); //-39 52 0.71672
            Assert.AreEqual<string>("-39��52��00.71672��", dms);
        }

        [TestMethod]
        public void TestAzimuth()
        {
        }
    }
}
