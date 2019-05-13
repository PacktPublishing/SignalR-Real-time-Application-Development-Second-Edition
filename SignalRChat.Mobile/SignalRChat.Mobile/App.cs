using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleInjector;
using Xamarin.Forms;

namespace SignalRChat.Mobile
{
    public class App : Application
    {
        public static readonly Container Container;
        public static INavigation Navigation;

        static App()
        {
            Container = new Container();

            var security = new Security();
            var messenger = new Messenger();
            var chatHub = new ChatHub(messenger, security);
            Container.Register<ISecurity>(()=>security, Lifestyle.Singleton);
            Container.Register<IChatHub>(() => chatHub, Lifestyle.Singleton);
            Container.Register<IMessenger>(() => messenger, Lifestyle.Singleton);
            Container.Register<INavigation>(() => Navigation);
        }


        public App()
        {
            // The root page of your application
            MainPage = new Login();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
