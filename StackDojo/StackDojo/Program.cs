using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDojo
{
    class Program
    {
        static void Main(string[] args)
        {
            StackList<int> stack = new StackList<int>(10);
            stack.Push(10);
            stack.Push(20);
            try
            {
                Console.WriteLine(stack.Pop());
            }
            catch (StackUnderflow e)
            {
                Console.WriteLine("what");
            }
            

        }
    }
}
