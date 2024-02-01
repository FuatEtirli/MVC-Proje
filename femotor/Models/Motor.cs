using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace femotor.Models
{
    public class Motor
    {

        [Key]
        public int MotorID { get; set; }

        
        [Required(ErrorMessage ="{0} girilmesi gerekli.")]
        [Display(Name ="Renk")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string Color { get; set; }

        [Required(ErrorMessage = "{0} girilmesi gerekli.")]
        [Display(Name = "Marka")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "{0} girilmesi gerekli.")]
        [Display(Name = "Model")]
        [StringLength(30,MinimumLength =3,ErrorMessage ="{0} {2}-{1} karakter olmalı")]
        public string MotorModel { get; set; }

        [Required(ErrorMessage = "{0} girilmesi gerekli.")]
        [Display(Name = "Model Yılı")]
        [Range(1990, 2030, ErrorMessage = "{0} {1}-{2} arasında bir değer olmalıdır.")]
        public short ModelYear { get; set; }

        [Required(ErrorMessage = "{0} girilmesi gerekli.")]
        [Display(Name = "Kasa Tipi")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string BodyType { get; set; }   

        public int  BodyTypeID { get; set; }
        public string  BodyTypeName { get; set; }

        [Required(ErrorMessage = "{0} girilmesi gerekli.")]
        [Display(Name = "Vites Tipi")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string GearType { get; set; }

        [Required(ErrorMessage = "{0} girilmesi gerekli.")]
        [Display(Name = "Motor Hacmi")]
        [Range(50, 5000, ErrorMessage = "{0} {1}-{2} arasında bir değer olmalıdır.")]
        public short EngineVolume { get; set; }

       
        public decimal Price { get; set; }
       
        
        public decimal KDVPrice
        {
            get

            {
                return Convert.ToDecimal(0.18) * Price;
            }

        }

        
        public decimal ÖTVPrice
        {
            get

            {
                decimal result = 0;
                if (EngineVolume < 1000)
                {
                    result = Convert.ToDecimal(0.10) * Price;
                }
                else if (EngineVolume < 1300)
                {
                    result = Convert.ToDecimal(0.20) * Price;
                }
                else if (EngineVolume < 1600)
                {
                    result = Convert.ToDecimal(0.30) * Price;
                }
                else if (EngineVolume < 2000)
                {
                    result = Convert.ToDecimal(0.40) * Price;
                }
                else if (EngineVolume < 3000)
                {
                    result = Convert.ToDecimal(0.50) * Price;
                }
                else
                {
                    result = Convert.ToDecimal(0.100) * Price;
                }
                return result;
            }
        }

        public decimal FinalPrice
        {
            get
            {
                return (Price + KDVPrice + ÖTVPrice);
            }
        }

       
    
        
        
    }
}
