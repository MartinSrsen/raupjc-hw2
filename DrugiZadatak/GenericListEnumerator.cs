using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class GenericListEnumerator<T> : IEnumerator<T>
    {
        
       private GenericList<T> list;
        private int position = -1;

        public GenericListEnumerator(GenericList<T> list)
        {
            this.list = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < list.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public T Current
        {
            get { return list.GetElement(position); }
        }

        public void Dispose()
        {
            position = -1;
        }
    }
}
