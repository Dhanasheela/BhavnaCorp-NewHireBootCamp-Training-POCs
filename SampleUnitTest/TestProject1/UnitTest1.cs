using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleUnitTest;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int n = 5;
            Sample factClass = new Sample();
            int res = factClass.factorial(n);
            Assert.AreEqual(res,120);

        }
        //test case2 
        [TestMethod]
        public void TestMethod2()
        {
            int n = 0;
            Sample factClass = new Sample();
            int res = factClass.factorial(n);
            Assert.AreEqual(res, 120);

        }
        [TestMethod]
        public void TestMethod3()
        {
            
            Sample factClass = new Sample();
            string str = "dhan";
            bool res = factClass.Prime(str);
            Assert.AreEqual(res,true);

        }
    }
}
