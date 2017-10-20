using System;

namespace Task_1
{
    public class IntegerList : IIntegerList
    {
        private const int DefaultStorageSize = 4;
        private int[] _internalStorage;
        private int _count;

        public IntegerList(int initialSize)
        {
            if (initialSize <= 0)
                throw new IndexOutOfRangeException("Size of the list must no be negative!");
            _internalStorage = new int[initialSize];
            _count = 0;
        }

        public IntegerList()
        {
            _internalStorage = new int[DefaultStorageSize];
            _count = 0;
        }

        public void Add(int item)
        {
            if (_count == _internalStorage.Length)
            {
                int[] tmpInternalStorage = new int[_count * 2];
                for (int i = 0; i < _count; i++)
                {
                    tmpInternalStorage[i] = GetElement(i);
                }
                _internalStorage = tmpInternalStorage;
            }
            _internalStorage[_count] = item;
            _count++;
        }

        public bool Remove(int item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (item.Equals(GetElement(i)))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();
            for (int i = index; i < _count - 1; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            _count--;
            return true;
        }

        public int GetElement(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();
            return _internalStorage[index];
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (item.Equals(GetElement(i)))
                    return i;
            }
            return -1;
        }

        public int Count => _count;

        public void Clear()
        {
            _internalStorage = new int[DefaultStorageSize];
            _count = 0;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (item.Equals(GetElement(i)))
                    return true;
            }
            return false;
        }
    }
}
