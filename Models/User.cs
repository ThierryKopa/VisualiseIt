using System.ComponentModel.DataAnnotations;
using HAK_BlazorPicoTemplate.Models;
using Microsoft.EntityFrameworkCore;

namespace HAK_BlazorPicoTemplate.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        


    }
}
