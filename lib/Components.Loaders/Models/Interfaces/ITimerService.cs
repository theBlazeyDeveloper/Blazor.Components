namespace Components.Loaders.Models.Interfaces
{
    public interface ITimerService
    {
        /// <summary>
        /// Starts the timer
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the timer
        /// </summary>
        void Stop();

        /// <summary>
        /// Handler for when the timer elapses
        /// </summary>
        event Action? OnElapsed;

        /// <summary>
        /// Initializes the timer
        /// </summary>
        /// <param name="interval">Amount of time in milliseconds till timer elapses</param>
        void Initialize(double interval);

        /// <summary>
        /// Disposes of the timer object
        /// </summary>
        void Dispose();
    }
}
