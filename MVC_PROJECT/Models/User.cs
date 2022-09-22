using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVC_PROJECT.Models
{
    [Index(nameof(Login), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }

        [BindProperty]
        [Required]
        public string? Login { get; set; }
        [Required]
        public string? Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
