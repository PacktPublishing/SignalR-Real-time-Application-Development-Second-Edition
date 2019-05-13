using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace SignalRChat.Mobile
{

    public class Security : ISecurity
    {
        const string Site = "http://10.211.55.4:3705";

        public CookieContainer CookieContainer { get; private set; }

        public bool Authenticate(string userName, string password)
        {

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("userName", userName));
            postData.Add(new KeyValuePair<string, string>("password", password));

            var content = new FormUrlEncodedContent(postData);

            CookieContainer = new CookieContainer();

            var handler = new HttpClientHandler { CookieContainer = CookieContainer };

            var client = new HttpClient(handler);
            try
            {
                var result = client.PostAsync(Site+"/SecurityHandler.ashx", content).Result;
                result.EnsureSuccessStatusCode();
            } catch( Exception )
            {
                return false;
            }

            return true;
        }
    }
}
