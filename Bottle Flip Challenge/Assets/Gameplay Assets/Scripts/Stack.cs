using UnityEngine;
using System.Collections;

public class Stack<T>
{
    private T[] objects;
    private int count;
    private int Size;


    public Stack(int Size)
    {
        this.Size = Size;
        this.objects = new T[Size];
        this.count = 0;
    }

    public void Push(T obj)
    {
        if (!this.IsFull())
        {
            this.objects[count++] = obj;
        }
    }

    public bool IsEmpty()
    {
        return this.count <= 0;
    }

    public int PoolSize()
    {
        return this.count;
    }

    public T Pop()
    {
        if (!this.IsEmpty())
        {
            return this.objects[--count];
        }
        return default(T);
    }

    public bool IsFull()
    {
        return this.count >= this.Size;
    }
}
