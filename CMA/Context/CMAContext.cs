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
        var admin = new IdentityRole("Admin");
        admin.NormalizedName = "Admin";
        var math_teacher = new IdentityRole("Math Teacher");
        math_teacher.NormalizedName = "Math Teacher";
        var phy_teacher = new IdentityRole("Physics Teacher");
        phy_teacher.NormalizedName = "Physics Teacher";
        var chm_teacher = new IdentityRole("Chemistry Teacher");
        chm_teacher.NormalizedName = "Chemistry Teacher";
        var bio_teacher = new IdentityRole("Biology Teacher");
        bio_teacher.NormalizedName = "Biology Teacher";
        var hist_teacher = new IdentityRole("History Teacher");
        hist_teacher.NormalizedName = "History Teacher";
        var lit_teacher = new IdentityRole("Literature Teacher");
        lit_teacher.NormalizedName = "Literature Teacher";
        var user = new IdentityRole("User");
        user.NormalizedName = "User";

        builder.Entity<IdentityRole>().HasData(admin,math_teacher,phy_teacher,chm_teacher,bio_teacher,hist_teacher,lit_teacher,user);
    }
}
