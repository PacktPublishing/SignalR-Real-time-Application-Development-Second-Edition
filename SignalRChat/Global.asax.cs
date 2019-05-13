using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace SignalRChat
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if( HttpContext.Current.User != null )
            {
                if( Request.IsAuthenticated == true )
                {
                    var ticket = FormsAuthentication.Decrypt(
                        Context.Request.Cookies[FormsAuthentication.FormsCookieName].Value);
                    var roles = ticket.UserData.Split(';');
                    var id = new FormsIdentity(ticket);
                    Context.User = new GenericPrincipal(id, roles);
                }
            }
        }
    }
}