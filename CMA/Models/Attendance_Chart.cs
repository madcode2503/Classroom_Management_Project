using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CMA.Models
{
    public class Attendance_Chart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public float Math_Attendance { get; set; }
        public float Physics_Attendance { get; set; }
        public float Chemitry_Attendance { get; set; }
        public float Biology_Attendance { get; set; }
        public float History_Attendance { get; set; }
        public float Literature_Attendance { get; set; }
        public string? Remarks { get; set; }
    }
}
