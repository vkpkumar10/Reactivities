using System;
using Domain;
namespace Persistence;

public class DbInitializer
{


    public static async Task SeedData(AppDbContext context)
    {


        if (context.Activities.Any())
        {
            return; // DB has been seeded
        }   

        var activities = new List<Activity>
        {
            new Activity
            {
                Title = "Past Activity 1",
                Date = DateTime.Now.AddMonths(-2),
                Description = "Activity 2 months ago",
                Category = "drinks",
                City = "London",
                Venue = "Pub",
            },
            new Activity
            {
                Title = "Past Activity 2",
                Date = DateTime.Now.AddMonths(-1),
                Description = "Activity 1 month ago",
                Category = "culture",
                City = "London",
                Venue = "British Museum",
            },
            new Activity
            {
                Title = "Future Activity 1",
                Date = DateTime.Now.AddMonths(1),
                Description = "Activity in 1 month",
                Category = "music",
                City = "London",
                Venue = "O2 Arena",
            },
            new Activity
            {
                Title = "Future Activity 2",
                Date = DateTime.Now.AddMonths(2),
                Description = "Activity in 2 months",
                Category = "travel",
                City = "Paris",
                Venue = "Eiffel Tower",
            },
            new Activity
            {
                Title = "Future Activity 3",
                Date = DateTime.Now.AddMonths(3),
                Description = "Activity in 3 months",
                Category = "food",
                City = "New York",
                Venue = "Central Park Picnic",
            },
            new Activity
            {
                Title = "Future Activity 4",
                Date = DateTime.Now.AddMonths(4),
                Description = "Activity in 4 months",
                Category = "sports",
                City = "Sydney",
                Venue = "Sydney Opera House Tour",
            },
            new Activity
            {
                Title = "Future Activity 5",
                Date = DateTime.Now.AddMonths(5),
                Description = "Activity in 5 months",
                Category = "entertainment",
                City = "Tokyo",
                Venue = "Shibuya Crossing Experience"
            },
        };
        await context.Activities.AddRangeAsync(activities);
        await context.SaveChangesAsync();
    }

    
}
