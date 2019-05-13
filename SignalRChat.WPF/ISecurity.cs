using System.Net;

namespace SignalRChat.WPF
{
    public interface ISecurity
    {
        CookieContainer CookieContainer { get; }

        bool Authenticate(string userName, string password);
    }
}
