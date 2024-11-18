using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CMA.Models
{
    public class Teacher:UserActivities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public  string? FirstName { get; set; }
        public  string? LastName { get; set; }
        public  string? Email { get; set; }
        public  string? PhoneNumber { get; set; }
        public  string? Department { get; set; }
        public  string? Subject { get; set; }

    }
}
