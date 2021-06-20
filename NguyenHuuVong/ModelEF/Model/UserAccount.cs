namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount
    {
        [Key]
        [StringLength(6)]

        public string UserID { get; set; }

        [Required]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Trạng thái")]
        public int? Status { get; set; }
    }
}
