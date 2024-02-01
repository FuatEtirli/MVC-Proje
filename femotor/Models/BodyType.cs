using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace femotor.Models
{
    public class BodyType
    {
        [Key]
        public int BodyTypeID { get; set; }

        [Required(ErrorMessage = "{0} girilmesi gerekli.")]
        [Display(Name = "Kasa tipi")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} {2}-{1} karakter olmalı")]

        public string BodyTypeName { get; set; }
    }
}