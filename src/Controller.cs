using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Harmony
{
    interface Controller : IHttpHandler
    {
        Controller HandleMessage(string PathSegment, HttpContextBase context = null);
    }
}
