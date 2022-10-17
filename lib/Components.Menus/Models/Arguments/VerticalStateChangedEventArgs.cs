using Components.Menus.Models.State;

namespace Components.Menus.Models.Arguments
{
    public sealed class VerticalStateChangedEventArgs : EventArgs
    {
        public VerticalStateChangedEventArgs(VerticalMenuState currentState)
        {
            CurrentState = currentState;
        }

        public VerticalMenuState CurrentState { get; }
    }
}
