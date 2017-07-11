using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackDojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDojo.Tests
{
    [TestClass()]
    public class StackListTests
    {
        [TestMethod()]
        public void StackListTest()
        {
            Stack<int> stack = new Stack<int>(10);
            stack.Push(10);
            Assert.AreEqual(10, stack.Pop());
        }

        [TestMethod()]
        public void PushTest()
        {
            Stack<int> stack = new Stack<int>(10);
            stack.Push(10);
            stack.Push(20);
            Assert.AreEqual(20, stack.Pop());
        }

        [TestMethod()]
        [ExpectedException(typeof(StackUnderflow))]
        public void PopTest()
        {
            Stack<int> stack = new Stack<int>(10);
            stack.Push(10);
            stack.Pop();
            stack.Pop();
        }

        [TestMethod()]
        [ExpectedException(typeof(StackUnderflow))]
        public void PeepTest()
        {
            Stack<int> stack = new Stack<int>(2);
            stack.Push(10);
            stack.Push(10);
            stack.Push(10);
        }
    }
}