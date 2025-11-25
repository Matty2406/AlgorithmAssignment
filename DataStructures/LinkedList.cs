namespace AlgorithmAssignment.DataStructures
{

    /// <summary>
    /// This is the class used for all operations. It was made during lessons and added to this project.
    /// </summary>
    public class LinkedList<T>
    {
        private class Element<U>
        {
            private U _data;
            private Element<U>? _next;

            public Element(U data)
            {
                _data = data;
            }

            public U Data { get { return _data; } }
            public Element<U>? Next { get { return _next; } set { _next = value; } }
        }

        private Element<T>? _head;
        private Element<T>? _tail;

        /// <summary>
        /// Creates an empty linked list
        /// </summary>
        public LinkedList()
        {
            _head = null;
            _tail = null;
        }

        public T First
        {
            get
            {
                if (_head == null)
                {
                    throw new InvalidOperationException("List is empty.");
                }
                return _head.Data;
            }
        }

        public T Last
        {
            get
            {
                if (_tail == null)
                {
                    throw new InvalidOperationException("List is empty.");
                }
                return _tail.Data;
            }
        }

        /// <summary>
        /// Inserts a new element at the front of the list
        /// </summary>
        /// <param name="data">The data to insert</param>
        public void PushFront(T data)
        {
            // Allocate a new element
            Element<T> newElement = new Element<T>(data);
            // Insert it at the front of the list
            newElement.Next = _head;
            // Update head to point to the new element
            _head = newElement;

            // If the list was empty, update tail as well
            if (_tail == null)
            {
                _tail = newElement;
            }
        }

        /// <summary>
        /// Inserts a new element at the back of the list
        /// </summary>
        /// <param name="data">The data to insert</param>
        public void PushBack(T data)
        {
            // Allocate a new element
            Element<T> newElement = new Element<T>(data);
            // Special case: inserting into an empty list
            if (_head == null)
            {
                _head = newElement;
                _tail = newElement;
                return;
            }

            // Use the tail to insert at the end
            _tail!.Next = newElement;
            _tail = newElement;
        }

        /// <summary>
        /// Pushes a new element into the list while maintaining sorted order.
        /// </summary>
        /// <param name="data">
        /// The data to insert into the list.
        /// </param>
        public void PushSorted(T data)
        {
            if (data is not IComparable comparable)
            {
                throw new InvalidOperationException("Data type must implement IComparable.");
            }

            // Allocate a new element
            Element<T> newElement = new Element<T>(data);

            // Special case: inserting at the front or into an empty list
            if (_head == null || comparable.CompareTo(_head.Data) < 0)
            {
                newElement.Next = _head;
                _head = newElement;

                // If the list was empty, update tail as well
                if (_tail == null)
                {
                    _tail = newElement;
                }
                return;
            }

            // General case: find the correct position to insert
            Element<T>? current = _head;
            while (current.Next != null && ((IComparable)current.Next.Data).CompareTo(data) < 0)
            {
                current = current.Next;
            }

            // Insert the new element
            newElement.Next = current.Next;
            current.Next = newElement;

            // Update tail if we inserted at the end
            if (newElement.Next == null)
            {
                _tail = newElement;
            }
        }

        /// <summary>
        /// Removes the first element from the list.
        /// </summary>
        /// <remarks>If the list is empty, this method does nothing. After the first element is removed, 
        /// the second element (if any) becomes the new head of the list.</remarks>
        public void PopFront()
        {
            // Remove the first element of the list
            Element<T>? oldHead = _head;

            if (oldHead != null) // List is not empty
            {
                _head = oldHead.Next; // Update head to point to the next element

                // Special case: if the list becomes empty, update tail as well
                if (_head == null)
                {
                    _tail = null;
                }

                // Garbage collector will take care of deallocating oldHead
            }
        }

        /// <summary>
        /// Removes and returns the first element from the list.
        /// </summary>
        /// <returns>
        /// Returns the data of the removed element. If the list is empty, returns the default value of type T.
        /// </returns>
        public T? PopFrontValue()
        {
            Element<T>? oldHead = _head;

            if (oldHead != null) // List is not empty
            {
                _head = oldHead.Next; // Update head to point to the next element

                // Special case: if the list becomes empty, update tail as well
                if (_head == null)
                {
                    _tail = null;
                }

                return oldHead.Data;
            }
            else
            {
                return default;
            }
        }

        /// <summary>
        /// Removes the last element from the collection.
        /// </summary>
        /// <remarks>If the collection is empty, this method does nothing.</remarks>
        public void PopBack()
        {
            // Special case: empty list
            if (_head == null)
            {
                return;
            }
            // Special case: only one element in the list
            if (_head.Next == null)
            {
                _head = null;
                _tail = null;
                return;
            }
            // General case: traverse to the second-to-last element
            Element<T>? current = _head;
            while (current.Next!.Next != null)
            {
                current = current.Next;
            }

            // Remove the last element
            current.Next = null;
            _tail = current;
        }

        /// <summary>
        /// Removes the first occurrence of an element with the specified data from the list.
        /// </summary>
        /// <param name="data">
        /// The data of the element to remove.
        /// </param>
        /// <returns>
        /// Returns true if an element with the specified data was found and removed; otherwise, false.
        /// </returns>
        public bool RemoveFirst(T data)
        {
            // Get the head of the list
            Element<T>? current = _head;

            // Previous element, initially null
            Element<T>? previous = null;

            // Traverse the list to find the element with the specified data
            while (current != null)
            {
                if (current.Data!.Equals(data))
                {
                    // Found the element to remove
                    if (previous == null)
                    {
                        // The element to remove is the head
                        _head = current.Next;
                        // If list becomes empty, update tail
                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }
                    else
                    {
                        // Move the previous element's next pointer to skip the current element
                        previous.Next = current.Next;
                        // If removed last element, update tail
                        if (previous.Next == null)
                        {
                            _tail = previous;
                        }
                    }

                    return true; // Element found and removed
                }

                // Move to the next element
                previous = current;
                current = current.Next;
            }

            return false; // Element not found
        }

        /// <summary>
        /// Gets the data from the first element of the list without removing it.
        /// </summary>
        /// <param name="data">
        /// Reference to a variable where the data will be stored if the list is not empty.
        /// </param>
        /// <returns>
        /// Returns true if the list is not empty and data was retrieved; false if the list is empty.
        /// </returns>
        public bool GetFront(ref T data)
        {
            if (_head != null)
            {
                data = _head.Data;
                return true;
            }
            else
            {
                Console.WriteLine("List is empty.");
            }

            return false;
        }

        public bool GetBack(ref T data)
        {
            if (_tail == null)
            {
                Console.WriteLine("List is empty.");
                return false;
            }

            data = _tail.Data;
            return true;
        }

        /// <summary>
        /// Prints the elements of the list to the console, separated by spaces.
        /// </summary>
        /// <remarks>This method iterates through the list and writes each element's data to the console.
        /// If the list is empty, no output is produced.</remarks>
        public void PrintList()
        {
            Element<T>? current = _head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
        }

        /// <summary>
        /// Checks if the list contains an element with the specified data.
        /// </summary>
        /// <param name="data">
        /// The data to search for in the list.
        /// </param>
        /// <returns>
        /// Returns true if an element with the specified data is found; otherwise, false.
        /// </returns>
        public bool Contains(T data)
        {
            // Get the head of the list
            Element<T>? current = _head;

            // Traverse the list to find the element with the specified data
            while (current != null)
            {
                if (current.Data!.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Counts the number of elements in the collection.
        /// </summary>
        /// <returns>The total number of elements in the collection.</returns>
        public int Count()
        {
            int count = 0;
            Element<T>? current = _head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        /// <summary>
        /// Checks if the linked list is empty.
        /// </summary>
        /// <returns>
        /// Returns true if the linked list is empty; otherwise, false.
        /// </returns>
        public bool IsEmpty()
        {
            return _head == null;
        }

        /// <summary>
        /// Copies the contents of this linked list into another linked list.
        /// </summary>
        /// <param name="other">
        /// A reference to the linked list where the contents will be copied.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// ArgumentNullException is thrown if the 'other' linked list is null.
        /// </exception>
        public void CopyContents(LinkedList<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), "The target linked list cannot be null.");
            }

            // Get the head of our list
            Element<T>? current = _head;

            // Go through each element in our list to copy into the other list
            while (current != null)
            {
                // Insert at the front of the other list
                other.PushFront(current.Data);
                // Move to the next element
                current = current.Next;
            }
        }
    }
}