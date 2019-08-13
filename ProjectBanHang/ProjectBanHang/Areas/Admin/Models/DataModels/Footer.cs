using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.DataModels
{
    public class Footer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Nội dung")]
        public string Content { get; set; }
        [DisplayName("Thứ tự")]
        public int DisplayOder { get; set; }
        public string Link { get; set; }
        public bool Status { get; set; }
    }
}