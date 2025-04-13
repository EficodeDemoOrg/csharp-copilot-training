namespace Backend.Services;

public class CounterService
{
    private int _counter = 0;

    public int Increment()
    {
        _counter++;
        return _counter;
    }

    public int GetCounter()
    {
        return _counter;
    }
}
