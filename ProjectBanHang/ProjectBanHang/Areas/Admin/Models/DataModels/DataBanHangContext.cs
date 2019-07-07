using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.DataModels
{
    public class DataBanHangContext : DbContext
    {
        public DataBanHangContext():base("name=DataBanHang")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBanHangContext, Migrations.Configuration>("DataBanHang"));
        }

        //tạo các thuộc tính DbSet<T>
        public DbSet<Product> Products { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }

        public System.Data.Entity.DbSet<ProjectBanHang.Areas.Admin.Models.DataModels.Category> Categories { get; set; }
    }
}