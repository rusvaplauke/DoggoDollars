﻿using Application.Profiles;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<UserService>();
        services.AddScoped<AccountService>();
        services.AddScoped<TransactionService>();

        services.AddAutoMapper(typeof(UserProfile));
        services.AddAutoMapper(typeof(AccountProfile));
        services.AddAutoMapper(typeof(TransactionProfile));
    }
}
