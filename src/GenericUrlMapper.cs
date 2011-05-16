using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Harmony
{
    public abstract class UrlMappingModule<TRoot> : IHttpModule where TRoot : Controller, new()
    {
        static readonly string[] excludedFiles = new[] 
            {
                ".jpg", ".jpeg", ".png", ".gif", ".html", ".htm", ".css", ".js", ".cs"
            };

        
        public void Init(HttpApplication context)
        {
            context.PostResolveRequestCache += delegate
            {
                
                var path = context.Context.Request.Path.Split('/');

                var lastSegment = path[path.Length - 1];

                if (!excludedFiles.Any(x => lastSegment.EndsWith(x, StringComparison.OrdinalIgnoreCase)))
                {
                    Controller controller = new TRoot();
                    foreach (var segment in path)
                        controller = controller.HandleMessage(segment, new HttpContextWrapper(context.Context));

                    context.Context.RemapHandler(controller);
                }

                
            };
        }

        public void Dispose() { }
    }

    
}
