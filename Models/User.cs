using System.ComponentModel.DataAnnotations;
using HAK_BlazorPicoTemplate.Models;
using Microsoft.EntityFrameworkCore;
using HAK_BlazorPicoTemplate.Models;

namespace HAK_BlazorPicoTemplate.Models
{
    public class User
    {
        
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(HAK_BlazorPicoTemplate.Resources.Models.User), ErrorMessageResourceName = "BN")]
        public string Username { get; set; }
        [Required(ErrorMessageResourceType = typeof(HAK_BlazorPicoTemplate.Resources.Models.User), ErrorMessageResourceName = "PS")]
        public string Password { get; set; }
        


    }
}
