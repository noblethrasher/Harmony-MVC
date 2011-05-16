using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Harmony
{
    abstract class UrlMappingModule<TRoot> : IHttpModule where TRoot : Controller, new()
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += delegate
            {
                Controller controller = new TRoot();
                var path = context.Context.Request.Path.Split('/');

                foreach (var segment in path)
                    controller = controller.HandleMessage(segment);

                context.Context.RemapHandler(controller);
            };
        }

        public void Dispose() { }
    }

    
}
