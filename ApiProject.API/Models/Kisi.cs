using System.ComponentModel.DataAnnotations;

namespace ApiProject.API.Models
{
    public class Kisi
    {
        [Key]
        public int kisiID {get; set;}
        [Required(ErrorMessage= "Bu alan boş bırakılamaz.")]
        [Display(Name = "Adınız")]
        public string kisiAdi {get; set;}
        [Required(ErrorMessage= "Bu alan boş bırakılamaz.")]
        [Display(Name = "Soyadınız")]
        public string kisiSoyadi {get; set;}
        [Required(ErrorMessage= "Bu alan boş bırakılamaz.")]
        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz.")]
        public string kisiTelefonNo {get; set;}
    }
}