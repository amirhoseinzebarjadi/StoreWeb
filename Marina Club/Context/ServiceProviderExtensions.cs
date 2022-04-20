using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Marina_Club.Context
{
    public static class ServiceProviderExtensions
    {
        public static void MigrateDatabases(this IServiceProvider provider)
        {
            using (provider.CreateScope())
            using (var context = provider.GetRequiredService<MarinaClubContext>())
            {
                context.Database.Migrate();
            }
        }
    }
}
