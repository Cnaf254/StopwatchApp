using System;
using System.Threading;

public class Stopwatch
{
    // Property without 'required' on the setter
    public Thread _tickThread { get; private set; }  // Make it read-only to ensure proper initialization
    public event StopwatchEventHandler OnStarted;
    public event StopwatchEventHandler OnStopped;
    public event StopwatchEventHandler OnReset;

    private TimeSpan _timeElapsed;
    private bool _isRunning;

    // Delegate for event handling
    public delegate void StopwatchEventHandler(string message);

    // Properties
    public TimeSpan TimeElapsed => _timeElapsed;
    public bool IsRunning => _isRunning;

    // Constructor to initialize the tickThread properly
    public Stopwatch()
    {
        _timeElapsed = TimeSpan.Zero;
        _isRunning = false;
    }

    // Methods
    public void Start()
    {
        if (!_isRunning)
        {
            _isRunning = true;
            OnStarted?.Invoke("Stopwatch Started!");
            _tickThread = new Thread(Tick); // Create a new thread for ticking
            _tickThread.Start();
        }
    }

    public void Stop()
    {
        if (_isRunning)
        {
            _isRunning = false;
            _tickThread?.Join(); // Wait for the thread to finish if it was running
            OnStopped?.Invoke($"Stopwatch Stopped at {_timeElapsed.TotalSeconds} seconds.");
        }
    }

    public void Reset()
    {
        _timeElapsed = TimeSpan.Zero;
        OnReset?.Invoke("Stopwatch Reset!");
    }

    // Method to increment time
    private void Tick()
    {
        while (_isRunning)
        {
            Thread.Sleep(10);  // Wait 10 milliseconds between ticks
            _timeElapsed = _timeElapsed.Add(TimeSpan.FromMilliseconds(10)); // Increment the time by 10ms
            Console.Clear();
            Console.WriteLine($"Time Elapsed: {_timeElapsed:hh\\:mm\\:ss\\.fff}");  // Format to show milliseconds
        }
    }
}
