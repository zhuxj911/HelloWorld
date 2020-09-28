using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSurMath
{
    [TestClass]
    public class UnitTestSurMath
    {
        [TestMethod]
        public void TestDMStoRad()
        {
            {
                double rad = ZXY.SurMath.DMStoRad(1.2030);
                Assert.AreEqual(0.0234165007975906, rad, 1e-15);

                rad = ZXY.SurMath.DMStoRad(-1.2030);
                Assert.AreEqual(-0.0234165007975906, rad, 1e-15);
            }

            {
                double rad = ZXY.SurMath.DMStoRad(1.4); //error 0.029282746339015973
                Assert.AreEqual(0.02908882086657220, rad, 1e-15);

                rad = ZXY.SurMath.DMStoRad(-1.4); //error 0.029282746339015973
                Assert.AreEqual(-0.02908882086657220, rad, 1e-15);
            }

            {
                double rad = ZXY.SurMath.DMStoRad(1.40001);
                Assert.AreEqual(0.02908930568025330, rad, 1e-15);
            
                rad = ZXY.SurMath.DMStoRad(-1.40001);
                Assert.AreEqual(-0.02908930568025330, rad, 1e-15);
            }

            {
                double rad = ZXY.SurMath.DMStoRad(39.520071672); //39 52 0.71672
                Assert.AreEqual(0.69580806988502100, rad, 1e-15);

                rad = ZXY.SurMath.DMStoRad(-39.520071672); //39 52 0.71672
                Assert.AreEqual(-0.69580806988502100, rad, 1e-15);
            }
        }

        [TestMethod]
        public void TestDMStoString()
        {
            {               
                string dms = ZXY.SurMath.DMStoString(1.2030);
                Assert.AreEqual<string>("1��20��30��", dms);                
                
                dms = ZXY.SurMath.DMStoString(-1.2030);
                Assert.AreEqual<string>("-1��20��30��", dms);
            }

            {
                string dms = ZXY.SurMath.DMStoString(1.4);
                Assert.AreEqual<string>("1��40��00��", dms);

                dms = ZXY.SurMath.DMStoString(-1.4);
                Assert.AreEqual<string>("-1��40��00��", dms);
            }

            {
                string dms = ZXY.SurMath.DMStoString(1.40001);
                Assert.AreEqual<string>("1��40��00.1��", dms);

                dms = ZXY.SurMath.DMStoString(-1.40001);
                Assert.AreEqual<string>("-1��40��00.1��", dms);
            }

            {
                string dms = ZXY.SurMath.DMStoString(39.520071672);
                Assert.AreEqual<string>("39��52��00.71672��", dms);

                dms = ZXY.SurMath.DMStoString(-39.520071672);
                Assert.AreEqual<string>("-39��52��00.71672��", dms);
            }
        }

        [TestMethod]
        public void TestRadtoDMS()
        {
            {
                double rad = ZXY.SurMath.RadtoDMS(0.0234165007975906);
                Assert.AreEqual(1.2030, rad, 1e-10);               

                rad = ZXY.SurMath.RadtoDMS(-0.0234165007975906);
                Assert.AreEqual(-1.2030, rad, 1e-10);
            }
            {
                double rad = ZXY.SurMath.RadtoDMS(0.02908882086657220); 
                Assert.AreEqual(1.4, rad, 1e-10);
               
                rad = ZXY.SurMath.RadtoDMS(-0.02908882086657220 );
                Assert.AreEqual(-1.4, rad, 1e-10);
            }

            {
                double rad = ZXY.SurMath.RadtoDMS(-0.02908930568025330);
                Assert.AreEqual(-1.40001 , rad, 1e-10);               

                rad = ZXY.SurMath.RadtoDMS(0.02908930568025330);
                Assert.AreEqual(1.40001, rad, 1e-10);
            }

            {
                double rad = ZXY.SurMath.RadtoDMS(0.69580806988502100); //39 52 0.71672
                Assert.AreEqual(39.520071672, rad, 1e-10);

                rad = ZXY.SurMath.RadtoDMS(-0.69580806988502100); //39 52 0.71672
                Assert.AreEqual(-39.520071672 , rad, 1e-10);
            }
        }

        [TestMethod]
        public void TestRadtoString()
        {
            {                
                string dms = ZXY.SurMath.RadtoString(0.0234165007975906);
                Assert.AreEqual<string>("1��20��30��", dms);               

                dms = ZXY.SurMath.RadtoString(-0.0234165007975906);
                Assert.AreEqual<string>("-1��20��30��", dms);
            }
            {                
                string dms = ZXY.SurMath.RadtoString(0.02908882086657220);
                Assert.AreEqual<string>("1��40��00��", dms);
               
                dms = ZXY.SurMath.RadtoString(-0.02908882086657220);
                Assert.AreEqual<string>("-1��40��00��", dms);
            }

            {
                string dms = ZXY.SurMath.RadtoString(0.02908930568025330);
                Assert.AreEqual<string>("1��40��00.1��", dms);

                dms = ZXY.SurMath.RadtoString(-0.02908930568025330);
                Assert.AreEqual<string>("-1��40��00.1��", dms);
            }

            {                
                string dms = ZXY.SurMath.RadtoString(0.69580806988502100); //39 52 0.71672
                Assert.AreEqual<string>("39��52��00.71672��", dms);

                dms = ZXY.SurMath.RadtoString(-0.69580806988502100); //-39 52 0.71672
                Assert.AreEqual<string>("-39��52��00.71672��", dms);
            }
        }

        [TestMethod]
        public void TestAzimuth()
        {
        }
    }
}
