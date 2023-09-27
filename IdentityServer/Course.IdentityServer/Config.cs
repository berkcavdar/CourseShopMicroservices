﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace Course.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog")
            {
                Scopes = { "catalog_fullpermission" }
            },
            new ApiResource("resource_photo_stock")
            {
                Scopes = {"photo_stock_fullpermission"}
            },
            new ApiResource("resource_basket")
            {
                Scopes = {"basket_fullpermission"}
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };


        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                       new IdentityResources.OpenId(),
                       new IdentityResources.Profile(),
                       new IdentityResource(){ Name = "roles", DisplayName = "Roles", Description = "User Roles", UserClaims = new[] { "role" } },
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission","CatalogAPI Tam Erişim"),
                new ApiScope("photo_stock_fullpermission","PhotoStockAPI Tam Erişim"),
                new ApiScope("basket_fullpermission","BasketAPI Tam Erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName = "Asp.Net Core MVC",
                    ClientId = "WebMvcClient",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes =
                    {
                        "catalog_fullpermission",
                        "photo_stock_fullpermission",
                        IdentityServerConstants.LocalApi.ScopeName
                    }

                },

                new Client
                {
                    AllowOfflineAccess = true,
                    ClientName = "Asp.Net Core MVC",
                    ClientId = "WebMvcClientForUser",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes =
                    {
                        "basket_fullpermission",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.LocalApi.ScopeName,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "roles"
                    },
                    AccessTokenLifetime = 1 * 60 * 60,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime = (int) (DateTime.Now.AddDays(60) - DateTime.Now).TotalSeconds,
                    RefreshTokenUsage = TokenUsage.ReUse
                }
            };
    }
}