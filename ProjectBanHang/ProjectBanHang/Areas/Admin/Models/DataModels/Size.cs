using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.DataModels
{
    public class Size
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public int ModelId { get; set; }
        //thuộc tính liên kết
        [ForeignKey("ModelId")]
        public Model Models { get; set; }
    }
}