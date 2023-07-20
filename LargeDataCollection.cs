
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConAppAssignment11
{
    public class LargeDataCollection : IDisposable
    {

        public int[] data;
        public int Length;
        public bool disposed = false;

        public LargeDataCollection( int[] initialData)
        {
            data = initialData;
        }

        public void AddElement(int item)
        {
            int currentIndex = data.Length;
            Array.Resize(ref data, currentIndex + 1);
            data[currentIndex] = item;
        }

        public void RemoveElement(int item)
        {
            int index = Array.IndexOf(data, item);
            if (index >= 0)
            {
                for (int i = index; i < data.Length - 1; i++)
                {
                    data[i] = data[i + 1];
                }
                Array.Resize(ref data, data.Length - 1);
            }
        }

        public int GetElement(int index)
        {
            if (index >= 0 && index < data.Length)
            {
                return data[index];
            }
            throw new IndexOutOfRangeException("Index is out of Range");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }
                data = null;
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~LargeDataCollection()
        {
            Dispose(false);
        }

        public void DisplayCllections()
        {
            Console.WriteLine("LargeDataCollction:");
            foreach (int item in data)
            {
                Console.WriteLine(item + "");
            }
            Console.WriteLine();
        }
    }
}


/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConAppAssignment11
{
    public class LargeDataCollection : IDisposable
    {
        private int[] Arr;
        bool disposed = false;
        public LargeDataCollection(int InitialValue)
        {
            Arr = new int[InitialValue];
        }
        public void Add(int element)
        {
            int[] newData = new int[Arr.Length + 1];
            Array.Copy(Arr, newData, Arr.Length);
            newData[Arr.Length] = element;
            Arr = newData;

        }
        public void Remove(int index, int[] Data)
        {
            if (index < 0 || index >= Arr.Length)
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");
            int[] newData = new int[Arr.Length - 1];
            Array.Copy(Arr, 0, newData, 0, index);
            Array.Copy(Arr, index + 1, newData, index, Arr.Length - index - 1);
            Arr = newData;
        }
        public int AccessingElement(int index)
        {
            if (index < 0 || index >= Arr.Length)
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");

            return Arr[index];
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    
                }

               
                Arr = null;

                disposed = true;
            }
        }

      

        ~LargeDataCollection()
        {

        }
    }
}
*/


