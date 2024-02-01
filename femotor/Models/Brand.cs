using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace femotor.Models
{
    public class Brand
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte BrandID { get; set; }


        [Required(ErrorMessage = "{0} girilmesi gerekli.")]
        [Display(Name = "Marka")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string BrandName { get; set; }


    }
}