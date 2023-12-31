using System.Collections.Generic;

public class Pool<T>
{
    private readonly Stack<T> stack = new Stack<T>();

    public void Return(T item)
    {
        stack.Push(item);
    }

    public bool TryRent(out T item)
    {
        return stack.TryPop(out item);
    }
}
