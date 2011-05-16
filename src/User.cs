using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Principal;

namespace Harmony
{
    class User : IPrincipal
    {
        List<string> Roles { get; private set; }

        public User(string Name, string AuthenticationType, bool IsAuthenticated, IEnumerable<string> Roles)
        {
            _id = new _Identity(Name, AuthenticationType, IsAuthenticated);
            this.Roles = new List<string>(Roles);
        }
        
        class _Identity : IIdentity
        {

            public _Identity(string Name, string AuthenticationType, bool IsAuthenticated)
            {
                this.Name = Name;
                this.AuthenticationType = AuthenticationType;
                this.IsAuthenticated = IsAuthenticated;
            }
            
            
            public string AuthenticationType
            {
                get;
                private set;
            }

            public bool IsAuthenticated
            {
                get;
                private set;
            }

            public string Name
            {
                get;
                private set;
            }
        }

        _Identity _id;
        public IIdentity Identity
        {
            get { return this._id; }            
        }

        public bool IsInRole(string role)
        {
            return Roles != null && Roles.Contains(role);
        }
    }
}
