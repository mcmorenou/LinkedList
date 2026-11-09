namespace Backend;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;
    private bool _ascending = true;

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
        _head.Prev = newNode;
        _head = newNode;
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
    public bool Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current.Prev == null)
                {
                    _head = current.Next;
                    if (_head == null)
                    {
                        _tail = null;
                    }
                    else
                    {
                        _head.Prev = null;

                    }
                    return true;

                }
                if (current.Next == null)
                {
                    current.Prev!.Next = null;
                    _tail = current.Prev;
                    return true;
                }
                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
                return true;
            }
            current = current.Next;
        }
        return false;
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

    public void Insert(T data)
    {
        var current = _head;
        while (current != null && !GoesAfter(current.Data!, data))
        {
            current = current!.Next;

        }
        if (current == null)
        {
            InsertAtEnd(data);
            return;
        }
        if (current == _head)
        {
            InsertAtBeginning(data);
            return;
        }


        var newNode = new DoubleNode<T>(data);
        newNode.Prev = current.Prev;
        newNode.Next = current;
        current.Prev!.Next = newNode;
        current.Prev = newNode;
    }

    private bool GoesAfter(T existing, T incoming)       
    {
        return _ascending
            ? existing.CompareTo(incoming) > 0
            : existing.CompareTo(incoming) < 0;
    }

    public void SortDescending()
    {
        if (!_ascending) return;

        var current = _head;
        while (current != null)
        {
            var oldNext = current.Next;
            current.Next = current.Prev;
            current.Prev = oldNext;
            current = oldNext;
        }
        (_head, _tail) = (_tail, _head);
        _ascending = false;
    }


    public List<(T Value, int Count)> Occurrences()
    {
        var result = new List<(T Value, int Count)>();
        var current = _head;

        while (current != null)
        {
            T value = current.Data!;
            int count = 0;
            while (current != null && current.Data!.Equals(value))
            {
                count++;
                current = current.Next;
            }
            result.Add((value, count));
        }
        return result;
    }

    public (List<T> Modes, int Frequency) Modes()
    {
        var modes = new List<T>();
        int max = 0;

        foreach (var (value, count) in Occurrences())
        {
            if (count > max)
            {
                max = count;
                modes.Clear();
                modes.Add(value);
            }
            else if (count == max)
            {
                modes.Add(value);
            }
        }
        return (modes, max);
    }

    public int RemoveAll(T data)
    {
        int removed = 0;
        while (Remove(data))
        {
            removed++;
        }
        return removed;
    }

}






