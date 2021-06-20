namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Product = new HashSet<Product>();
        }

        [StringLength(6)]
        [Display(Name = "Mã danh mục")]
        public string CategoryID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Tên danh mục")]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
