using System.Collections.Specialized;
using System.Net;
using Bifrost.Execution;

namespace SignalRChat.WPF
{
    [Singleton]
    public class Security : ISecurity
    {
        const string Site = "http://localhost:3705";

        public CookieContainer CookieContainer { get; private set; }

        public bool Authenticate(string userName, string password)
        {
            var postData = new NameValueCollection();
            postData.Add("userName", userName);
            postData.Add("password", password);

            var url = string.Format("{0}/SecurityHandler.ashx", Site);
            var webClient = new CookieAwareWebClient();
            try
            {
                webClient.UploadValues(url, postData);
            }
            catch (WebException)
            {
                return false;
            }
            CookieContainer = webClient.CookieContainer;
            return true;
        }
    }
}
