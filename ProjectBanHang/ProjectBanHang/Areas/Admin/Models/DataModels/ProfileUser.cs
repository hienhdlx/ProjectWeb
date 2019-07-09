using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.DataModels
{
    public class ProfileUser
    {
        private DateTime _date = DateTime.Now;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Tên")]
        public string Name { get; set; }
        [DisplayName("Ảnh")]
        [Required]
        public string Image { get; set; }
        [Required]
        [DisplayName("Tên đăng nhập")]
        [StringLength(225)]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Mật khẩu")]
        [StringLength(225)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Điện thoại")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DisplayName("Giới tính")]
        public int Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get { return _date; } set { _date = value; } }
        [DisplayName("Quyền")]
        public int Role { get; set; }
    }
}