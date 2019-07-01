using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBanHang.Areas.Admin.Models.BusinessModels
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(object id);
        void Add(T entity);
        void Edit(T entity);
        void Remove(object id);
    }
}
