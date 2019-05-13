using System;
using System.Net;

namespace SignalRChat.WPF
{
    public class CookieAwareWebClient : WebClient
    {
        public readonly CookieContainer CookieContainer = new CookieContainer();

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
                ((HttpWebRequest)request).CookieContainer = CookieContainer;
            return request;
        }
    }
}
