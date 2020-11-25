using Microsoft.VisualStudio.TestTools.UnitTesting;

using ZXY;

namespace UnitTestSurMath
{
    [TestClass]
    public class UnitTestGaussProj
    {
        [TestMethod]
        public void TestBltoXy()
        {
            double B = SurMath.DMStoRad(21.58470845);
            double L = SurMath.DMStoRad(113.25314880);
            double L0 = SurMath.DMStoRad(111);

            //Ellipsoid ellipsoid = new Ellipsoid(6378245, 298.3);
            Ellipsoid ellipsoid = Ellipsoid.CreateBeijing1954();
            IProj proj = new GaussProj(ellipsoid);
            var xy = proj.BLtoXY(B, L, L0, 0, 0);
           
            Assert.AreEqual(2433586.692, xy.x, 0.001);
            Assert.AreEqual(250547.403, xy.y, 0.001);
        }

        [TestMethod]
        public void TestXytoBl()
        {
            double x = 2433586.692, y = 250547.403;
            double L0 = SurMath.DMStoRad(111);
          
            Ellipsoid ellipsoid = Ellipsoid.CreateBeijing1954();
            IProj proj = new GaussProj(ellipsoid);
            //IProj proj = new UTMProj(ellipsoid);
            var BL = proj.XYtoBL(x, y, L0, 0, 0);

            Assert.AreEqual(21.58470845, SurMath.RadtoDMS(BL.B), 1e-8);
            Assert.AreEqual(113.25314880, SurMath.RadtoDMS(BL.L), 1e-8);
        }
    }
}
