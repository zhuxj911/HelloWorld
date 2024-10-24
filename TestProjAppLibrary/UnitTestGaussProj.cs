using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjApp.Library;
using ZXY;

namespace TestProjAppLibrary
{
    [TestClass]
    public class UnitTestGaussProj
    {
        [TestMethod]
        public void TestBLtoXY()
        {
            {
                double B = SurMath.DmsToRadian(21.58470845);
                double L = SurMath.DmsToRadian(113.25314880);
                double L0 = SurMath.DmsToRadian(111);

                //Ellipsoid ellipsoid = new Ellipsoid(6378245, 298.3);
                Ellipsoid ellipsoid = Ellipsoid.CreateBeijing1954();
                IProj proj = new GaussProj(ellipsoid);
                var xy = proj.BLtoXY(B, L, L0, 0, 0);

                Assert.AreEqual(2433586.692, xy.X, 0.001);
                Assert.AreEqual(250547.403, xy.Y, 0.001);
            }

            //�������ԡ���ز���ѧ������2��P193
            {
                double B = SurMath.DmsToRadian(17.33557339);
                double L = SurMath.DmsToRadian(119.15521159);
                double L0 = SurMath.DmsToRadian(117);

                Ellipsoid ellipsoid = Ellipsoid.CreateBeijing1954();
                IProj proj = new GaussProj(ellipsoid);
                var xy = proj.BLtoXY(B, L, L0, 0, 0);

                Assert.AreEqual(1944359.6070, xy.X, 0.003);
                Assert.AreEqual(240455.4563, xy.Y, 0.001);
            }

            //�������ԡ���ز���ѧ������2��P193
            {
                double B = SurMath.DmsToRadian(17.33557339);
                double L = SurMath.DmsToRadian(119.15521159);
                double L0 = SurMath.DmsToRadian(117);

                Ellipsoid ellipsoid = Ellipsoid.CreateXiAn1980();
                IProj proj = new GaussProj(ellipsoid);
                var xy = proj.BLtoXY(B, L, L0, 0, 0);

                Assert.AreEqual(1944325.8030, xy.X, 0.001);
                Assert.AreEqual(240451.5085, xy.Y, 0.001);
            }
        }

        [TestMethod]
        public void TestXYtoBL()
        {
            {
                double x = 2433586.692, y = 250547.403;
                double L0 = SurMath.DmsToRadian(111);

                Ellipsoid ellipsoid = Ellipsoid.CreateBeijing1954();
                IProj proj = new GaussProj(ellipsoid);
                //IProj proj = new UTMProj(ellipsoid);
                var BL = proj.XYtoBL(x, y, L0, 0, 0);

                Assert.AreEqual(21.58470845, SurMath.DmsToRadian(BL.B), 1e-8);
                Assert.AreEqual(113.25314880, SurMath.DmsToRadian(BL.L), 1e-8);

                x = 3380330.773; y = 320089.9761;
                BL = proj.XYtoBL(x, y, L0, 0, 0);

                //�˴����밴���洦������59.999996�������
                Assert.AreEqual(30.30, SurMath.DmsToRadian(BL.B), 1e-7);
                Assert.AreEqual(114.20, SurMath.DmsToRadian(BL.L), 1e-7);
            }

            //�������ԡ���ز���ѧ������2��P194
            {
                double x = 1944359.6070, y = 240455.4563;
                double L0 = SurMath.DmsToRadian(117);

                Ellipsoid ellipsoid = Ellipsoid.CreateBeijing1954();
                IProj proj = new GaussProj(ellipsoid);
                //IProj proj = new UTMProj(ellipsoid);
                var BL = proj.XYtoBL(x, y, L0, 0, 0);

                Assert.AreEqual(17.33557338, SurMath.DmsToRadian(BL.B), 1e-8);
                Assert.AreEqual(119.15521150, SurMath.DmsToRadian(BL.L), 1e-8);
            }
        }
    }
}