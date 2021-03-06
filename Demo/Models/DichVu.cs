//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            this.ChiTietSuDungDVs = new HashSet<ChiTietSuDungDV>();
            this.HinhAnhDVs = new HashSet<HinhAnhDV>();
            ImageDV = "~/Upload/images/s1.png";
        }

        public int IdDV { get; set; }

        [StringLength(20)]
        [Display(Name = "Tên dịch vụ")]
        [Required(ErrorMessage = "Không được bỏ trống {0}")]
        public string TenDichVu { get; set; }

        [Display(Name = "Giá dịch vụ")]
        [Required(ErrorMessage = "Không được bỏ trống {0}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,##0 vnd}")]
        public decimal? GiaDV { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Display(Name = "Nhà cung cấp")]
        public Nullable<int> IdNCC { get; set; }

        [Display(Name = "Hình ảnh DV")]
        public string ImageDV { get; set; }
        public Nullable<bool> Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSuDungDV> ChiTietSuDungDVs { get; set; }
        public virtual CoSoDichVu CoSoDichVu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HinhAnhDV> HinhAnhDVs { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
