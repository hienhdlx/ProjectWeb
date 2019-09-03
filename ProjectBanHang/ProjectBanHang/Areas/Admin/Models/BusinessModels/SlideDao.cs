using ProjectBanHang.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.BusinessModels
{
    public class SlideDao
    {
        DataBanHangContext db = null;
        public SlideDao()
        {
            db = new DataBanHangContext();
        }

        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        }

    }
}