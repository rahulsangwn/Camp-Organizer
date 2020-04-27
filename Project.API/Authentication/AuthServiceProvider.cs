﻿using Microsoft.Owin.Security.OAuth;
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
            if (context.UserName == "admin" && context.Password == "admin")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Rahul Sangwan"));
                context.Validated(identity);
            } 
            else
            {
                context.SetError("invalid_grant", "Please Provide valid username and password");
            }
        }
    }
}