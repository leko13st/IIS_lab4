using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab4_ExpertSystem;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            VoteHandler vh = new VoteHandler();
            bool b = vh.CreateAlternative(10, 0);
            Assert.AreEqual(true, b);
        }

        [TestMethod]
        public void TestMethod2()
        {
            VoteHandler vh = new VoteHandler();
            bool b = vh.CreateAlternative(10, 1);
            Assert.AreEqual(true, b);
        }
    }
}
