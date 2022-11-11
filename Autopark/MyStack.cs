namespace Autopark
{
    public class CustomStack<T> : AbstractCollection<T>
        where T : class
    {
        public void Push(T item) => Add(item);

        public T Pop()
        {
            T lastItem = Array[--Count];
            Array[Count] = default!;
            return lastItem;
        }
        
        //Where is the size of the garage?
    }
}