namespace Backend;

   public class DoublyLinkedList<T>
    {
        private DoubleNode<T>? _head;
        private DoubleNode<T>? _tail;

        public DoublyLinkedList()
        {
            _head = null;
            _tail = null;
        }



    public void InsertAtBeginning(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null) 
        {
        _head = newNode;
        _tail = newNode;
            return;
        }
         newNode.Next = _head;
         _head.Prev = newNode.Next;
         _head= newNode;
        }
    public void InsertAtEnd(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }
        _tail.Next = newNode;
        newNode.Prev = _tail;
        _tail = newNode;
    }

    public bool Contains(T data)
    {
        var current = _head;
        while(current != null) 
        {
            if (current.Data!.Equals(data))
            { 
                return true; 
            }
            current = current.Next;
        }

        return false;
    }
    public void Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
               if (current.Prev == null)
                {
                    current.Next!.Prev = null;
                    _head = _head!.Next;
                    return;
                }
                if (current.Next == null)
                {
                    current.Prev!.Next = null;
                    _tail = _tail!.Prev;
                    return;
                }
                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
                return;
            }
          current= current.Next;  
        }
    }


    public override string ToString()
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data}->";
            current = current.Next;
        }
        return $"{output} null";
    }

    public string ToStringReverse()
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data}<->";
            current = current.Prev;
        }
        return $"{output} null";
    }

}

