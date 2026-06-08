using System.ComponentModel.DataAnnotations;
using HAK_BlazorPicoTemplate.Models;
using Microsoft.EntityFrameworkCore;

namespace HAK_BlazorPicoTemplate.Models
{
    public class User
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Bitte gegen Sie den Benutzername ein!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bitte gegen Sie das Passwort ein!")]
        public string Password { get; set; }
        


    }
}
