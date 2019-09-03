using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.DataModels
{
    public class Slide
    {
        private DateTime _date = DateTime.Now;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Image")]
        public string Image { get; set; }
        [DisplayName("Thứ tự")]
        public int DisplayOrder { get; set; }
        public string Link { get; set; }
        [DisplayName("Mô tả")]
        public string Discription { get; set; }
        public DateTime CreateDate { get { return _date; } set { _date = value; } }
        public bool Status { get; set; }
    }
}