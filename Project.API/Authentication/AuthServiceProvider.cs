using Microsoft.Owin.Security.OAuth;
using Project.BAL.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Project.API.App_Start
{
    public class AuthServiceProvider : OAuthAuthorizationServerProvider
    {
        AuthProcessor _aprocessor;
        public AuthServiceProvider()
        {
            _aprocessor = new AuthProcessor();
        }
        #pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }


        // To generate Token if valid
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        #pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (_aprocessor.IsValid(context.UserName, context.Password))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                //identity.AddClaim(new Claim("username", "admin"));
                //identity.AddClaim(new Claim(ClaimTypes.Name, "Rahul Sangwan"));
                context.Validated(identity);
            } 
            else
            {
                context.SetError("invalid_grant", "Please Provide valid email and password");
            }
        }
    }
}