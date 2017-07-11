using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDojo
{
    public class StackList <T>
    {
        
        private T[] array;
        private Node<T> last;
        private int size;
        private int bounds;

        public StackList(int size)
        {
            bounds = size;
            array = new T[size];
        }

        public void Push(T item)
        {
            if (size == bounds) throw new StackOverflow();
            Node<T> node = new Node<T>(item);
            node.previous = last;
            last = node;
            size++;
        }

        public T Pop()
        {
            if (size==0) throw new StackUnderflow();
            Node<T> node = last;
            last = node.previous;
            size--;
            return node.value;
        }

        public T Peep()
        {
            return last.value;
        }

        public int GetSize()
        {
            return size;
        }

        public int SpacesLeft()
        {
            return bounds - size;
        }


    }
}
