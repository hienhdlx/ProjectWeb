using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.DataModels
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Giá")]
        public double Price { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        [DisplayName("Ảnh")]
        public string Image { get; set; }

        [DisplayName("Số lượng")]
        public int Amount { get; set; }

        [DisplayName("Color")]
        public string CodeColor { get; set; }

        [DisplayName("Trạng thái")]
        public bool Status { get; set; }

        [DisplayName("Hãng")]
        public int CategoryId { get; set; }

       
        [ForeignKey("CategoryId")]
        public virtual Category Categories { get; set; }


    }
}