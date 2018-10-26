using GearTrackerData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace GearTrackerData.Implementations
{
    public partial class GearTrackingContext : DbContext
    {

        public GearTrackingContext() : base("name=GearTrackingContext")
        {
            //necessary to avoid EF reference in UI project
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<TrackingHistory> TrackingHistory { get; set; }
    }
}
