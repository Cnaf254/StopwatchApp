using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new Stopwatch object
        Stopwatch stopwatch = new Stopwatch();

        // Subscribe to the events
        stopwatch.OnStarted += (message) => Console.WriteLine(message);
        stopwatch.OnStopped += (message) => Console.WriteLine(message);
        stopwatch.OnReset += (message) => Console.WriteLine(message);

        // Console UI Loop
        while (true)
        {
            // Allow input and output while stopwatch is running
            Console.WriteLine("\nPress S to Start, T to Stop, R to Reset, Q to Quit");
            var input = Console.ReadKey(true).KeyChar;

            switch (input)
            {
                case 'S':
                    stopwatch.Start();
                    break;
                case 'T':
                    stopwatch.Stop();
                    break;
                case 'R':
                    stopwatch.Reset();
                    break;
                case 'Q':
                    Console.WriteLine("Exiting Stopwatch Application.");
                    stopwatch.Stop();  // Ensure the stopwatch is stopped before quitting
                    return; // Exit the loop and program
                default:
                    Console.WriteLine("Invalid input! Press S, T, R, or Q.");
                    break;
            }
        }
    }
}
