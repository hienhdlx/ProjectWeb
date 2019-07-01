using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.DataModels
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
        [Required]
        public int ModelsID { get; set; }
        public int CategoryId { get; set; }

        //thuộc tính liên kết
        [ForeignKey("ModelsID")]
        public Model Modeles { get; set; }
        [ForeignKey("CategoryId")]
        public Category Categories { get; set; }


    }
}