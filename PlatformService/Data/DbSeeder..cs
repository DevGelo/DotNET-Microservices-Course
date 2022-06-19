namespace PlatformService.Data
{
    public static class DbSeeder
    {
        public static void Populate(IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                SeedData(scope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext dbContext)
        {
            if (!dbContext.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");

                dbContext.Platforms.Add(new Models.Platform(){Name = "Asp.Net", Publisher = "Ms", Cost = "Free"});
                dbContext.Platforms.Add(new Models.Platform(){Name = "GitHub", Publisher = "Ms", Cost = "Free"});
                dbContext.Platforms.Add(new Models.Platform(){Name = "React", Publisher = "Meta", Cost = "Free"});
                dbContext.SaveChanges();

                Console.WriteLine("--> Seeded data.");
            }
            else
            {
                Console.WriteLine("--> We already have data.");
            }
        }
    }
}