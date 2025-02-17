using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VSCode.Memo.Console.L01;

namespace VSCode.Memo.Console.Test.L01
{
    [TestClass]
    public class HelloTest
    {
        [TestMethod]
        public void 正しい挨拶が返されること()
        {
            var hello = new Hello();
            var result = hello.SayHello("Taro");
            Assert.AreEqual("Taro, Hello", result);
        }
    }
}