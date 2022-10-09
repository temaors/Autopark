using System.Collections;

namespace Autopark;

public abstract class AbstractCollection<T> : IEnumerable<T>
{
    public T[] Array;
    public int Count { get; set; }

    protected AbstractCollection()
    {
        Array = new T[8];
        Count = 0;
    }

    protected void Add(T item)
    {
        if (Count == Array.Length)
        {
            var newArray = new T[Array.Length * 2];
            Array.CopyTo(newArray, 0);
            Array = newArray;
        }
        Array[Count++] = item;
    }

    public void Clear()
    {
        Array = new T[8];
        Count = 0;
    }

    public bool Contains(T item)
    {
        foreach (var elem in Array)
        {
            if (elem != null && elem.Equals(item))
            {
                return true;
            }
        }
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return Array[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    } 
}