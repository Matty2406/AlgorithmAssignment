namespace AlgorithmAssignment.DataStructures
{

    /// <summary>
    /// Implements a wrapper around LinkedList to provide stack functionality.
    /// </summary>
    public class CustomStack<T>
    {
        private readonly LinkedList<T> _list = new();

        /// <summary>
        /// Adds an item to the top of the stack.
        /// </summary>
        /// <param name="item">The item to add to the stack. Cannot be null.</param>
        public void Push(T item)
        {
            _list.PushFront(item);
        }

        /// <summary>
        /// Removes and returns the item at the front of the collection.
        /// </summary>
        /// <returns>The item at the front of the collection.</returns>
        public T Pop()
        {
            return _list.PopFrontValue();
        }

        /// <summary>
        /// Retrieves the first element in the collection without removing it.
        /// </summary>
        /// <returns>The first element of type <typeparamref name="T"/> in the collection.</returns>
        public T Peek()
        {
            return _list.First;
        }

        /// <summary>
        /// Determines whether the collection is empty.
        /// </summary>
        /// <returns><see langword="true"/> if the collection contains no elements; otherwise, <see langword="false"/>.</returns>
        public bool IsEmpty()
        {
            return _list.IsEmpty();
        }
    }
}
