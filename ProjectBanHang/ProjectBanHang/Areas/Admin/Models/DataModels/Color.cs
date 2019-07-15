using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.DataModels
{
    public class Color
    {
        [Key]
        [Required]
        public int Id { get; set; } 
        [Required]
        [DisplayName("Tên màu")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Mã màu")]
        public string CodeColor { get; set; }
        //public int ModelId { get; set; }

        ////thuộc tính liên kết 
        //[ForeignKey("ModelId")]
        //public Model Models { get; set; }
    }
}