using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.DataModels
{
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DisplayName("Tiêu đề")]
        public string Text { get; set; }
        public string Link { get; set; }
        [DisplayName("Thứ tự")]
        public int DisplayOrder { get; set; }
        public string Tardet { get; set; }
        public bool Status { get; set; }
        [ForeignKey("TypeId")]
        public virtual MenuType MenuTypes { get; set; }
    }
}