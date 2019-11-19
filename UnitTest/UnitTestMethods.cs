using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab4_ExpertSystem;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTestMethods
    {
        [TestMethod]
        public void TestMethodAlter()
        {
            VoteHandler vh = new VoteHandler();
            bool b = vh.CreateAlternative(10, 0);
            Assert.AreEqual(true, b);
        }

        [TestMethod]
        public void TestMethodKondorse()
        {
            List<string> la = new List<string>();
            la.Add("A > B > C");
            List<int> lv = new List<int>();
            lv.Add(5);

            Answer ans = new AnswerByKondorse(la, lv, 3);
            string s = ans.GetAnswer();
            Assert.IsNotNull(s);
        }

        [TestMethod]
        public void TestMethodCopeland()
        {
            List<string> la = new List<string>();
            la.Add("A > B > C");
            List<int> lv = new List<int>();
            lv.Add(5);

            Answer ans = new AnswerByCopeland(la, lv, 3);
            string s = ans.GetAnswer();
            Assert.IsNotNull(s);
        }

        [TestMethod]
        public void TestMethodSimpson()
        {
            List<string> la = new List<string>();
            la.Add("A > B > C");
            List<int> lv = new List<int>();
            lv.Add(5);

            Answer ans = new AnswerBySimpson(la, lv, 3);
            string s = ans.GetAnswer();
            Assert.IsNotNull(s);
        }

        [TestMethod]
        public void TestMethodBord()
        {
            List<string> la = new List<string>();
            la.Add("A > B > C");
            List<int> lv = new List<int>();
            lv.Add(5);

            Answer ans = new AnswerByBord(la, lv, 3);
            string s = ans.GetAnswer();
            Assert.IsNotNull(s);
        }
    }
}
