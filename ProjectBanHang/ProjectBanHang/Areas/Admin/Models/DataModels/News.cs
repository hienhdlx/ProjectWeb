using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.DataModels
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DisplayName("Tiêu đề")]
        public string Title { get; set; }
        [DisplayName("Nội dung")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        [DisplayName("Trạng thái")]
        public bool Status { get; set; }
    }
}