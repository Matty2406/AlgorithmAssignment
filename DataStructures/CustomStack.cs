namespace AlgorithmAssignment.DataStructures
{
    public class CustomStack<T>
    {
        private readonly LinkedList<T> _list = new();

        public void Push(T item)
        {
            _list.PushFront(item);
        }

        public T Pop()
        {
            return _list.PopFrontValue();
        }

        public T Peek()
        {
            return _list.First;
        }

        public bool IsEmpty()
        {
            return _list.IsEmpty();
        }
    }
}
