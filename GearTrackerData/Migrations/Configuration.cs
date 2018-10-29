namespace GearTrackerData.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GearTrackerData.Implementations.GearTrackingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "GearTrackerData.Implementations.GearTrackingContext";
        }

        protected override void Seed(GearTrackerData.Implementations.GearTrackingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Actions.AddOrUpdate(new Models.Action { Id = 1, Name = "Check In" }, new Models.Action { Id = 2, Name = "Check Out" });
            context.Locations.AddOrUpdate(new Models.Location { Id = 1, Name = "Home", Rfid = "111111" }, new Models.Location { Id = 2, Name = "Trailer", Rfid = "222222" });
            context.Items.AddOrUpdate(new Models.Item { Id = 1, Name = "SM57", Rfid = "123456" }, new Models.Item { Id = 2, Name = "SM58", Rfid = "234567" });
            context.TrackingHistories.AddOrUpdate(new Models.TrackingHistory { Id = 1, ActionId = 2, Date = DateTime.Now, ItemId = 1, LocationId = 2 }, new Models.TrackingHistory { Id = 2, ActionId = 1, Date = DateTime.Now, ItemId = 1, LocationId = 1 });
        }
    }
}
