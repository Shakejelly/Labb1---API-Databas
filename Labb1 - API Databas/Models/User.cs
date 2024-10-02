using System.Reflection.Metadata.Ecma335;

namespace Labb1___API_Databas.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
