using System;

public class GenericArray<T>
{
    private T[] array;

    public GenericArray(int size)
    {
        array = new T[size + 1];
    }

    public void SetItem(int index, T item)
    {
        array[index] = item;
    }

    //TODO
    // Implement GetItem(int index) method
}