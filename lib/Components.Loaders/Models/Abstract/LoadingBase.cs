using Components.Loaders.Models.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Components.Loaders.Models.Abstract
{
    public abstract class LoadingBase : ComponentBase
    {
        const double _defaultInterval = 10000;
        const string _defaultMessage = "Loading...";
        const string _defaultErrorMessage = "Something may have gone wrong, please try again.";

        /// <summary>
        /// Amount of milliseconds before loader displays an error message. Default is 10000
        /// </summary>
        [Parameter] public double LoadingInterval { get; set; } = _defaultInterval;

        /// <summary>
        /// Message displayed before timer elapses. Default message is "Loading..."
        /// </summary>
        [Parameter] public string Message { get; set; } = _defaultMessage;

        /// <summary>
        /// Error message that is displayed when the timer elapses. Default message is "Something may have gone wrong, please try again."
        /// </summary>
        [Parameter] public string ErrorMessage { get; set; } = _defaultErrorMessage;

        [Inject] protected ITimerService TimerService { get; set; } = default!;

        protected bool DisplayErrorMessage { get; set; }
    }
}
