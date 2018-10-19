using System;
using Microsoft.AspNetCore.Mvc;

namespace PX.API.BasicAuth
{
    namespace API.BasicAuth.Attributes
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class BasicAuthorizeAttribute : TypeFilterAttribute
        {
            public BasicAuthorizeAttribute(string realm = null) : base(typeof(BasicAuthorizeFilter))
            {
            }
        }
    }
}