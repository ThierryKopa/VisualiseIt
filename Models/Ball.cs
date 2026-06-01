using System.ComponentModel.DataAnnotations;


namespace HAK_BlazorPicoTemplate.Models
{
    public class Ball
    {
        
        [Required(ErrorMessageResourceType = typeof(HAK_BlazorPicoTemplate.Resources.Models.Ball), ErrorMessageResourceName = "Gewicht")]
        [Range(0.01, 90, ErrorMessageResourceType = typeof(HAK_BlazorPicoTemplate.Resources.Models.Ball), ErrorMessageResourceName = "GewichtRange")]
        public double gewicht { get; set; }

        [Required(ErrorMessageResourceType = typeof(HAK_BlazorPicoTemplate.Resources.Models.Ball), ErrorMessageResourceName = "Geschwindigkeit")]
        [Range(1, 80, ErrorMessageResourceType = typeof(HAK_BlazorPicoTemplate.Resources.Models.Ball), ErrorMessageResourceName = "GeschwindigkeitRange")]
        public double geschwindigkeit { get; set; }

        [Required(ErrorMessageResourceType = typeof(HAK_BlazorPicoTemplate.Resources.Models.Ball), ErrorMessageResourceName = "Wurfwinkel")]
        [Range(-360, 360, ErrorMessageResourceType = typeof(HAK_BlazorPicoTemplate.Resources.Models.Ball), ErrorMessageResourceName = "WurfwinkelRange")]
        public double winkel {  get; set; }

        public string g {  get; set; }
        
        public double tempoX { get; set; }
        public double tempoY {  get; set; }
    }
}
