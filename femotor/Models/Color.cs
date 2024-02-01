using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace femotor.Models
{
    public class Color
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte ColorID { get; set; }


        [Required(ErrorMessage = "{0} girilmesi gerekli.")]
        [Display(Name = "Renk")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string ColorName { get; set; }
    }
}