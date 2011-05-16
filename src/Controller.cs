using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Harmony
{
    public interface Controller : IHttpHandler
    {
        Controller HandleMessage(string PathSegment, HttpContextBase context);
    }
}
