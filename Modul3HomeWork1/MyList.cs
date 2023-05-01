using System.Collections;

namespace Modul3HomeWork1
{
    public class MyList<T> : IEnumerable<T>
        where T : IComparable
    {
        private T[] _array = new T[12];

        public int Length { get; private set; } = 0;

        public void Add(T item)
        {
            if (Length >= _array.Length)
            {
                DoublingArrayLength();
            }

            _array[Length] = item;
            Length++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < Length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            _array[Length - 1] = default;
            Length--;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public void Sort()
        {
            Array.Sort(_array, 0, Length);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyListEnumerator<T>(_array, Length);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void DoublingArrayLength()
        {
            var result = new T[_array.Length * 2];

            for (int i = 0; i < _array.Length; i++)
            {
                result[i] = _array[i];
            }

            _array = result;
        }

        private class MyListEnumerator<T> : IEnumerator<T>
        {
            private readonly T[] _array;
            private readonly int _length;
            private int _position = -1;
            public MyListEnumerator(T[] array, int length)
            {
                _array = array;
                _length = length;
            }

            public T Current
            {
                get
                {
                    if (_position == -1 || _position >= _length)
                    {
                        throw new ArgumentException();
                    }

                    return _array[_position];
                }
            }

            object IEnumerator.Current => Current;
            public bool MoveNext()
            {
                if (_position < _length - 1)
                {
                    _position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset() => _position = -1;
            public void Dispose()
            {
            }
        }
    }
}
