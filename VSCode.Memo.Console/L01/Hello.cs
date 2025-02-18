using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSCode.Memo.Classlib.L01;

namespace VSCode.Memo.Console.L01
{
    public class Hello
    {
        public string SayHello(string name)
        {
            var add = new Add();
            var sum = add.AddTwoNumbers(1, 2);
            return name + ", Hello";
        }
    }
}