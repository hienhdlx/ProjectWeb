namespace ProjectBanHang.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectBanHang.Areas.Admin.Models.DataModels.DataBanHangContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ProjectBanHang.Areas.Admin.Models.DataModels.DataBanHangContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ProjectBanHang.Areas.Admin.Models.DataModels.DataBanHangContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
