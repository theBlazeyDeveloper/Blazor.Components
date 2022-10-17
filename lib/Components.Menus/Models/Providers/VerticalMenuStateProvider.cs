using Components.Menus.Concrete;
using Components.Menus.Models.State;
using System.Collections.Concurrent;
using System.Security.Claims;

namespace Components.Menus.Models.Providers
{
    public sealed class VerticalMenuStateProvider
    {
        static readonly ConcurrentDictionary<string, VerticalMenuState> _states = new();        

        public VerticalMenuStateProvider()
        { }

        public static void SelectPage(ClaimsPrincipal user, MenuPage page)
        {
            var currentState = new VerticalMenuState(user, page);

            _states.AddOrUpdate(user.GetUserId(), currentState, (k,v) => new(user, page));            
        }

        public static VerticalMenuState? GetCurrentState(ClaimsPrincipal user)
        {
            if (user is not null && user.Identity is not null && user.Identity.IsAuthenticated)
            {
                if (_states.TryGetValue(user.GetUserId(), out var state))
                    return state;
                else
                    return null;
            }
            else
                return null;
        }
    }
}
