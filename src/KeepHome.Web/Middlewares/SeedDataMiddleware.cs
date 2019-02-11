﻿namespace KeepHome.Web.Middlewares
{
    using KeepHome.Common;
    using KeepHome.Data;
    using KeepHome.Models;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDataMiddleware
    {
        private readonly RequestDelegate next;

        public SeedDataMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, KeepHomeContext dbContext,
           UserManager<KeepHomeUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!dbContext.Roles.Any())
            {
                await this.SeedRoles(userManager, roleManager);
            }

            await this.next(context);
        }

        private async Task SeedRoles(UserManager<KeepHomeUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminRoleExists = await roleManager.RoleExistsAsync(GlobalConstants.AdminRoleName);
            var userRoleExist = await roleManager.RoleExistsAsync(GlobalConstants.UserRoleName);

            if (!adminRoleExists || !userRoleExist)
            {
                var adminRoleResult = await roleManager.CreateAsync(new IdentityRole(GlobalConstants.AdminRoleName));
                var userRoleResult = await roleManager.CreateAsync(new IdentityRole(GlobalConstants.UserRoleName));
            }
        }
    }
}