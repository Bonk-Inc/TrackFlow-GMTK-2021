using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BinairyHeap<Value>
{
    private readonly List<Value> queue = new List<Value>();
    private readonly Comparer<Value> comparer;

    public int Capacity => queue.Capacity;
    public int Count => queue.Count;

    public BinairyHeap(): this(Comparer<Value>.Default){}
    public BinairyHeap(Comparer<Value> comparer)
    {
        this.comparer = comparer;
    }

    public Value Peek()
    {
        return queue[0];
    }

    public Value Dequeue()
    {
        if(queue.Count == 0)
            throw new InvalidOperationException("No elements left in the queue");

        Value result = queue[0];

        queue[0] = queue[Count - 1];
        queue.RemoveAt(Count - 1);

        int currentPos = 1;
        var (left, right)= GetChildrenPos(currentPos);
        int largestChildPosition = right <= Count && !Compare(left, right) ? right : left;
        while (currentPos <= Count && largestChildPosition <= Count && Compare(largestChildPosition, currentPos))
        {
            Switch(currentPos-1, largestChildPosition-1);
            currentPos = largestChildPosition;
            (left, right) = GetChildrenPos(currentPos);
            largestChildPosition = right <= Count && !Compare(left, right) ? right : left;
        }

        return result;
    }

    private (int left, int right) GetChildrenPos(int position)
    {
        return (left: position*2, right: position * 2 + 1);
    }

    public void Enqueue(Value value)
    {
        queue.Add(value);
        int currentPos = Count;
        int parentPos = GetParentIndex(currentPos);

        while (currentPos != 1 && Compare(currentPos, parentPos))
        {
            Switch(currentPos-1, parentPos-1);
            currentPos = parentPos;
            parentPos = GetParentIndex(currentPos);
        }
    }

    private int GetParentIndex(int idx)
    {
        return Mathf.FloorToInt(((float)idx) / 2);
    }

    private bool Compare(int lhs, int rhs)
    {
        Value val = queue[lhs-1];
        Value parent = queue[rhs-1];
        return comparer.Compare(val, parent) > 0;
    }

    private void Switch(int i, int j)
    {
        Value temp = queue[i];
        queue[i] = queue[j];
        queue[j] = temp;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder("BinairyHeap { ");
        for (int i = 0; i < queue.Count; i++)
        {
            if(i != 0)
                sb.Append(", ");

            sb.Append(queue[i]);
        }
        sb.Append(" }");
        return sb.ToString();
    }
}
