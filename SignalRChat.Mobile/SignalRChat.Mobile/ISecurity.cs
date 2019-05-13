using System.Net;

namespace SignalRChat.Mobile
{
    public interface ISecurity
    {
        CookieContainer CookieContainer { get; }

        bool Authenticate(string userName, string password);
    }
}
