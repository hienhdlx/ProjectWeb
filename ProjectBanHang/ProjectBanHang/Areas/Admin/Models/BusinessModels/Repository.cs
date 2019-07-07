using ProjectBanHang.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.BusinessModels
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private DataBanHangContext db;
        public DbSet<T> _tbl { get; private set; }
        public Repository()
        {
            //đối tượng context
            db = new DataBanHangContext();
            //bảng dữ liệu cần thao tác
            _tbl = db.Set<T>();
        }

        public void Add(T entity)
        {
            _tbl.Add(entity);
            db.SaveChanges();
        }

        public void Edit(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public T Get(object id)
        {
            return _tbl.Find(id);
        }

        public List<T> GetAll()
        {
            return _tbl.ToList();
        }

        public void Remove(object id)
        {
            _tbl.Remove(Get(id)); 
            db.SaveChanges();
        }
    }
}