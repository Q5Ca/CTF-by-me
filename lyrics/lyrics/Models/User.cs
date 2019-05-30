using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace lyrics.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password does not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public int LyricID { get; set; }
    }
    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}