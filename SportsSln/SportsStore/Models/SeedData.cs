using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.famMembers.Any())
            {
                context.famMembers.AddRange(
                    new FamMember
                    {
                        FirstName = "Corey",
                        LastName = "Lesko",
                        Relation = "Myself",
                        Age = 23,
                        Hobbies = "Exercising"
                    },
                      new FamMember
                      {
                          FirstName = "Nikki",
                          LastName = "Lesko",
                          Relation = "Spouse",
                          Age = 20,
                          Hobbies = ""
                      },
                      new FamMember
                      {
                          FirstName = "Moose",
                          LastName = "Lesko",
                          Relation = "Dog",
                          Age = 2,
                          Hobbies = "Running"
                      },
                      new FamMember
                      {
                          FirstName = "Winnie",
                          LastName = "Lesko",
                          Relation = "Dog",
                          Age = 1,
                          Hobbies = "Barking"
                      });
                context.SaveChanges();
            }
        }
        
    }
}

