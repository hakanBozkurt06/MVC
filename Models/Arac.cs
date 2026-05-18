using System.ComponentModel.DataAnnotations;

namespace VehicleGallery.Models
{
    public class Arac : Object
    {
        public int AracId { get; set; }

        [Required(ErrorMessage = "Marka zorunludur.")]
        [StringLength(30, ErrorMessage = "Marka en fazla 30 karakter olabilir.")]
        [Display(Name = "Marka")]
        public string Marka { get; set; }

        [Required(ErrorMessage = "Model zorunludur.")]
        [StringLength(40, ErrorMessage = "Model en fazla 40 karakter olabilir.")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Range(1900, 2100, ErrorMessage = "Yıl 1900 ile 2100 arasında olmalıdır.")]
        [Display(Name = "Yılı")]
        public int Yil { get; set; }

        public override string ToString()
        {
            return $"Marka:{this.Marka} Model:{this.Model}";
        }
    }
}
