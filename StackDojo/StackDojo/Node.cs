using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDojo
{
    public class Node <T>
    {
        public Node<T> previous { get; set; }
        public T value;

        public Node(T item)
        {
            this.value = item;
        }

    }
}
