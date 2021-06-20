namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Required]
        [StringLength(6)]
        [Display(Name = "Mã sản phẩm")]
        public string ProductID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Display(Name = "Đơn giá")]
        public decimal UnitCost { get; set; }

        [Required]
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Required]
        [StringLength(6)]

        public string CategoryID { get; set; }

        [Display(Name = "Trạng thái")]
        public int? Status { get; set; }

        public virtual Category Category { get; set; }
    }
}
