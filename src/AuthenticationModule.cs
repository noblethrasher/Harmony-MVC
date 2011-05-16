using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Harmony
{
    public class AuthenticationModule : IHttpModule
    {

        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += delegate
            {
                if (DateTime.Now == DateTime.Now)
                {

                }
                else
                {
                    var username = context.Request.Form["username"];
                    var password = context.Request.Form["password"];


                    //TODO: Add check for secure connection...
                    if (username != null && password != null)
                    {

                    }
                }
            };
        }
    }
}
