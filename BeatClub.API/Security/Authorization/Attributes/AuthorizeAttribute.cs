﻿using System;
using System.Linq;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.Security.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BeatClub.API.Security.Authorization.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // If action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor
                .EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

            if (allowAnonymous)

                //Then skip authorization process

                return;

            //Otherwise, perform Authorization process

            var user = (User) context.HttpContext.Items["User"];

            if (user == null)

                context.Result = new JsonResult(new {message = "Unauthorized"})
                    {StatusCode = StatusCodes.Status401Unauthorized};

        }
    }
}