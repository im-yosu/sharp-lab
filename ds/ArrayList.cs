// auto resizing array
public class ArrayList<T> : System.Collections.ObjectModel.Collection<T>
{
    private static readonly int DEFAULT_CAPACITY = 10;

    // shared empty array instance 
    private static readonly Object[] EMPTY_ELEMENTDATA = { };

    // the array buffer to hold data
    private Object[] elementData;

    private int size;

    public ArrayList() : base()
    {
        this.elementData = EMPTY_ELEMENTDATA;
    }

    private void EnsureCapacityInternal(int minCapacity)
    {
        if (elementData == EMPTY_ELEMENTDATA) {
            minCapacity = Math.Max(DEFAULT_CAPACITY, minCapacity);
        }

        EnsureExplicitCapacity(minCapacity);
    }

    private void EnsureExplicitCapacity(int minCapacity)
    {
        if (minCapacity - elementData.Length > 0)
            Grow(minCapacity);
    }

    private static readonly int MAX_ARRAY_SIZE = int.MaxValue - 8;

    private void Grow(int minCapacity)
    {
        var oldCapacity = elementData.Length;
        // use right shift operator to inc the size by 50%
        var newCapacity = oldCapacity + (oldCapacity >> 1);

        if (newCapacity - minCapacity < 0)
            newCapacity = minCapacity;

        if (newCapacity - MAX_ARRAY_SIZE > 0)
            newCapacity = MAX_ARRAY_SIZE;

        Array.Copy(elementData, elementData, newCapacity);
    }

    // add - no need to return 
    // TODO provide mechanism to grow (iirc if filled halfway then double the size)
    public bool Add(T item)
    {
        EnsureCapacityInternal(size + 1);
        elementData[size++] = item;
        return true;
    }

    // get (by index)

    // set (change)

    // remove

    // clear

    // size
    public int Size()
    {
        return size;
    }
}