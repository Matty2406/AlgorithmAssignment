namespace AlgorithmAssignment.DataStructures
{
    /// <summary>
    /// A priority queue wrapper around LinkedList.
    /// </summary>
    public class CustomPriorityQueue<T> where T : IComparable<T>
    {
        private readonly LinkedList<T> _list = new();

        /// <summary>
        /// Inserts the specified item into the collection in a sorted order.
        /// </summary>
        /// <remarks>The item is inserted at the appropriate position based on the collection's sorting
        /// logic.</remarks>
        /// <param name="item">The item to insert into the collection.</param>
        public void Insert(T item)
        {
            _list.PushSorted(item);
        }

        /// <summary>
        /// Removes and returns the minimum value from the collection.
        /// </summary>
        /// <returns>The minimum value from the collection.</returns>
        public T? Dequeue()
        {
            return _list.PopFrontValue();
        }

        public void Remove(T item)
        {
            _list.RemoveFirst(item);
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