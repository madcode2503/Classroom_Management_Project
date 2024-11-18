using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CMA.Migrations;

namespace CMA.Models
{
    public class Grade_Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Mathematics { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Biology { get; set; }
        public int History { get; set; }
        public int Literature { get; set; }
        public float Avg_grade;
        public string? Letter_grade;
        public string? Remarks { get; set; }
       
    }
}
