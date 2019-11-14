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
            bool b = vh.v(1);
            Assert.AreEqual(false, b);
        }
    }
}
