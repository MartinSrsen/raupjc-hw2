using System;
using System.Collections;
using System.Collections.Generic;


namespace GenericList
{
    class GenericList<X> : IGenericList<X>
    {

        private X[] _internalStorage;
        private X[] _helper;
        private int _numberOfItems = 0;

        

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        private void SetDefault()
        {
            _internalStorage = new X[4];
        }

        public GenericList()
        {
            SetDefault();
        }

        public GenericList(int initialSize)
        {
            if (initialSize <= 0)
            {

                Console.WriteLine("Storage size must be greater than 0\nSet to default value.");
                Console.ReadLine();
                SetDefault();

            }
            else
            {
                _internalStorage = new X[initialSize];
            }
        }



        public int Count
        {
            get { return _numberOfItems; }
        }

        public void Add(X item)
        {
            if (_numberOfItems == _internalStorage.Length)
            {
                _helper = new X[_internalStorage.Length];
                for (int i = 0; i < _internalStorage.Length; ++i)
                {
                    _helper[i] = _internalStorage[i];
                }

                _internalStorage = new X[_internalStorage.Length * 2];
                for (int i = 0; i < _helper.Length; ++i)
                {
                    _internalStorage[i] = _helper[i];

                }
                _helper = null;
            }

            _internalStorage[_numberOfItems] = item;
            _numberOfItems++;
        }

        public void Clear()
        {
            for (int i = 0; i < _numberOfItems; ++i)
            {
                _internalStorage[i] = default(X);
            }
            _numberOfItems = 0;
        }

        public bool Contains(X item)
        {
            if (IndexOf(item) != -1)
            {
                return true;
            }

            return false;
        }

        public X GetElement(int index)
        {
            if (index >= _numberOfItems)
            {
                throw new IndexOutOfRangeException();
            }

            return _internalStorage[index];
        }

        public int IndexOf(X item)
        {

            for (int i = 0; i < _numberOfItems; ++i)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Remove(X item)
        {
            int index = IndexOf(item);

            if (index != -1)
            {
                return RemoveAt(index);
            }

            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= _numberOfItems)
            {
                throw new IndexOutOfRangeException();

            }
            _internalStorage[index] = default(X);
            for (int i = index; i < _numberOfItems - 1; ++i)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }

            _numberOfItems--;
            return true;
        }
    }
}
