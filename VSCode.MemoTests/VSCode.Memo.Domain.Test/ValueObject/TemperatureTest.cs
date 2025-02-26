using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VSCode.Memo.Domain.ValueObjects;

namespace VSCode.Memo.Domain.Test.ValueObject
{
    [TestClass]
    public class TemperatureTest
    {
        [TestMethod]
        public void 小数点以下2桁で丸めて表示できる()
        {
            var t = new Temperature(12.345f);
            Assert.AreEqual(12.345f, t.Value);
            Assert.AreEqual("12.3℃", t.DisplayValue);
        }

        [TestMethod]
        public void 別インスタンスでも値が同じであれば同じとみなされる()
        {
            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);
            Assert.AreEqual(true, t1.Equals(t2));
            Assert.AreEqual(true, t1 == t2);
        }
    }
}