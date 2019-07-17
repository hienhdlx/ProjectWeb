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
            db.Entry(entity).State = EntityState.Added;
            db.SaveChanges();
        }

        public bool EditUser(ProfileUser puser)
        {
            try
            {
                var user = db.ProfileUsers.Find(puser.Id);
                user.Name = puser.Name;
                user.UserName = puser.UserName;
                user.Image = puser.Image;
                user.Email = puser.Email;
                user.Address = puser.Address;
                user.Phone = puser.Phone;
                user.Gender = puser.Gender;
                user.CreateDate = DateTime.Now;
                user.Role = user.Role;
                db.Entry(puser).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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

        public int Login(string userName, string passWord)
        {
            var result = db.ProfileUsers.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Password == passWord)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }

        public ProfileUser GetByName(string userName)
        {
            return db.ProfileUsers.SingleOrDefault(x => x.UserName == userName);
        }
    }
}