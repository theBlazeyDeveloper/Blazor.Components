using Components.Loaders.Models.Interfaces;
using Timer = System.Timers.Timer;

namespace Components.Loaders.Services
{
    internal sealed class TimerService : ITimerService, IDisposable
    {
        Timer _timer = default!;

        internal TimerService() { }

        public void Initialize(double interval)
        {
            _timer = new Timer(interval);

            _timer.Elapsed += (o, e) =>
            {
                OnElapsed?.Invoke();
                _timer.Dispose();
            };
            _timer.Enabled = true;           
        }

        public void Start()
        {
            if (_timer.Enabled)
                _timer?.Start();
        }

        public void Stop()
        {
            if (_timer.Enabled)
                _timer?.Stop();            
        }

        public void Dispose()
        {
            _timer.Dispose();
            GC.SuppressFinalize(this);
        }

        public event Action? OnElapsed;        
    }
}
