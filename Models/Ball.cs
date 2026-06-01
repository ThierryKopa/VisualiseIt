using System.ComponentModel.DataAnnotations;


namespace HAK_BlazorPicoTemplate.Models
{
    public class Ball
    {
        
        [Required(ErrorMessageResourceType = typeof(HAK_BlazorPicoTemplate.Resources.Models.Ball), ErrorMessageResourceName = "Gewicht")]
        [Range(0.01, 90, ErrorMessageResourceType = typeof(HAK_BlazorPicoTemplate.Resources.Models.Ball), ErrorMessageResourceName = "GewichtRange")]
        public double gewicht { get; set; }
        [Required(ErrorMessage ="Bitte geben Sie Geschwindigkeit ein!")]
        [Range(1, 50, ErrorMessage = "Geschwindigkeit darf zwischen 1 und 50 m/s sein!")]
        public double geschwindigkeit { get; set; }
        [Required(ErrorMessage = "Bitte geben Sie Winkel des Wurfes ein!")]
        [Range(-360, 360, ErrorMessage = "Winkel darf zwischen -360° und 360° sein!")]
        public double winkel {  get; set; }
        [Required(ErrorMessage ="Bitte geben Sie g-Wert ein!")]
        public string g {  get; set; }
        
        public double tempoX { get; set; }
        public double tempoY {  get; set; }
    }
}
