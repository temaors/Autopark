namespace Autopark
{
    public class CustomQueue<T> : AbstractCollection<T>
        where T : class
    {
        public CustomQueue()
        {
        }

        public void Enqueue(T item) => Add(item);

        public T Dequeue()
        {
            T firstItem = Array[0];
            for (int i = 1; i < Count; i++)
            {
                Array[i - 1] = Array[i];
            }
            Array[--Count] = default!;
            return firstItem;
        }
    }
}