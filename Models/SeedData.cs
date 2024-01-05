using Microsoft.EntityFrameworkCore;
using RazorPagesRocket.Data;

namespace RazorPagesRocket.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesRocketContext(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesRocketContext>>()
        ))
        {
            if (context == null || context.Rocket == null)
            {
                throw new ArgumentNullException("Null RazorPagesRocketContext");
            }
            // Look for any rockets
            if (context.Rocket.Any()) {
                return;
            }
            
            context.Rocket.AddRange(
                new Rocket
                {
                    Name = "Falcon 1",
                    LaunchDate = DateTime.Parse("2011-2-12"),
                    NumberOfEngines = "1",
                    Payload = "1000T",
                    Cores = "1",
                    DesiredOrbit = "LEO"
                },
                new Rocket
                {
                    Name = "Falcon 9",
                    LaunchDate = DateTime.Parse("2015-6-20"),
                    NumberOfEngines = "9",
                    Payload = "3000T",
                    Cores = "2",
                    DesiredOrbit = "MEO"
                },
                new Rocket
                {
                    Name = "Falcon Heavy",
                    LaunchDate = DateTime.Parse("2021-12-8"),
                    NumberOfEngines = "27",
                    Payload = "12000T",
                    Cores = "3",
                    DesiredOrbit = "GEO"
                },
                new Rocket
                {
                    Name = "Starship + Super Heavy",
                    LaunchDate = DateTime.Parse("2023-10-13"),
                    NumberOfEngines = "39",
                    Payload = "36000T",
                    Cores = "2",
                    DesiredOrbit = "GTO"
                }
            );
            context.SaveChanges();
        }
    }
}