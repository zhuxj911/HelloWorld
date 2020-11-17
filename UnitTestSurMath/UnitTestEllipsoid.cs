using Microsoft.VisualStudio.TestTools.UnitTesting;

using ZXY;

namespace UnitTestSurMath
{
    [TestClass]
    public class UnitTestEllipsoid
    {
        [TestMethod]
        public void TestBltoXy()
        {
            double B= ZXY.SurMath.DMStoRad(21.58470845);
            double l = ZXY.SurMath.DMStoRad(2.25314880);
            
            Ellipsoid ellipsoid = new Ellipsoid(6378245, 298.3);
            var xy = ellipsoid.BltoXy(B, l);           
            
            Assert.AreEqual(2433586.692, xy.x, 0.001);
            Assert.AreEqual( 250547.403, xy.y, 0.001);
        }

        [TestMethod]
        public void TestXytoBl()
        {
            
        }      
    }
}
