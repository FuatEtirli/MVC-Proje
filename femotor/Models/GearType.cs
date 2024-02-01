using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace femotor.Models
{
    public class GearType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte GearTypeID { get; set; }

        [Required(ErrorMessage = "{0} girilmesi gerekli.")]
        [Display(Name = "Vites tipi")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string GearTypeName { get; set; }
    }
}