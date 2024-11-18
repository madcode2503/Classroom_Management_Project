using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CMA.Models
{
    public class Lecture_Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Lectures_Absent { get; set; }
        public float Percentage { get; set; }
        public string? Remarks { get; set; }

    }
}
