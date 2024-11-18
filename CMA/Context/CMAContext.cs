using CMA.Areas.Identity.Data;
using CMA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMA.Context;

public class CMAContext : IdentityDbContext<CMAUsers>
{
    public CMAContext(DbContextOptions<CMAContext> options)
        : base(options)
    {
    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Student_Backup> Student_Backup { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Teacher_Backup> Teacher_Backup { get; set; }
    public DbSet<Grade_Book> GradeBook { get; set; }
    public DbSet<Math_Attendance> math_Attendance { get; set; }
    public DbSet<Physics_Attendance> physics_Attendance { get; set; }
    public DbSet<Chemistry_Attendance> chemistry_Attendance { get; set; }
    public DbSet<Biology_Attendance> biology_Attendance { get; set; }
    public DbSet<History_Attendance> history_Attendance { get; set; }
    public DbSet<Literature_Attendance> lit_Attendance { get; set; }
    public DbSet<Attendance_Chart> attendance_Chart { get; set; }
    public DbSet<Schedule> schedule { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
