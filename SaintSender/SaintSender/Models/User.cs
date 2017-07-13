using System.ComponentModel.DataAnnotations;

namespace SaintSender.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
    
        public string Name { get; set; }
    }
}