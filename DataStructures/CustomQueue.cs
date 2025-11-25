namespace AlgorithmAssignment.DataStructures
{
    /// <summary>
    /// A queue wrapper around LinkedList.
    /// </summary>
    public class CustomQueue<T>
    {
        private readonly LinkedList<T> _list = new();

        /// <summary>
        /// Adds an item to the end of the queue.
        /// </summary>
        /// <remarks>The item is added to the back of the queue, maintaining the FIFO (first-in,
        /// first-out) order.</remarks>
        /// <param name="item">The item to add to the queue.</param>
        public void Enqueue(T item)
        {
            _list.PushBack(item);
        }

        /// <summary>
        /// Removes and returns the item at the front of the queue.
        /// </summary>
        /// <remarks>This method retrieves the first item in the queue and removes it from the collection.
        /// If the queue is empty, the behavior depends on the implementation of the underlying data
        /// structure.</remarks>
        /// <returns>The item at the front of the queue.</returns>
        public T Dequeue()
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