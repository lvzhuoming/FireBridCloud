using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using FireBridCloud;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class TestFunction
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(CommonFunction.AddStockNoHead("601088"), "sh601088");
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(CommonFunction.GetUrlStockContent(new List<string>() { "601088" }).Contains("中国神华"), true);
        }
    }
}
