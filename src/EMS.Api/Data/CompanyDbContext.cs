namespace EMS.Api.Data;

public class CompanyDbContext : DbContext
{
    public DbSet<eEmployee> Employees { get; set; }
    public DbSet<eDepartment> Departments { get; set; }

    public CompanyDbContext(DbContextOptions options)
    : base(options)
    {

    }

    protected override void OnModelCreating(Modelbuilder modelBuilder)
    {
        modelBuilder.Entity<eEmployee>(etb =>
        {
            etb.HasOne(e => e.Department)
               .WithMany(d => d.Employees)
               .HasForeignKey(e => e.DepartmentId);
        })

        modelBuilder.Entity<eEmployee>().HasData(
            new eEmployee {
                Id = 1,
                FirstName = "Harry",
                LastName = "Smith",
                Email = "johnsmith@gmail.com",
                JoinDate = new DateTime(2020, 12, 24),
                Gender = rGender.Male,
                DepartmentId = 1,
                PhotoPath = "images/harry.png" 
            }, new eEmployee {
                Id = 2,
                FirstName = "Mary",
                LastName = "Sutherland",
                Email = "marysutherland@gmail.com",
                JoinDate = new DateTime(2022, 4, 21),
                Gender = rGender.Female,
                DepartmentId = 2,
                PhotoPath = "images/mary.png"
            }, new eEmployee {
                Id = 3,
                FirstName = "Sam",
                LastName = "Fallon",
                Email = "samfallon@gmail.com",
                JoinDate = new DateTime(2023, 8, 14),
                Gender = rGender.Other,
                DepartmentId = 3,
                PhotoPath = "images/sam.png"
            }, new eEmployee {
                Id = 4,
                FirstName = "Fin",
                LastName = "Harrington",
                Email = "finharrington@gmail.com",
                JoinDate = new DateTime(2019, 5, 2),
                DepartmentId = 3,
                Gender = rGender.Male,
                PhotoPath = "images/harry.png"
            }, new eEmployee {
                Id = 5,
                FirstName = "Max",
                LastName = "Snipe",
                Email = "maxsnipe@gmail.com",
                JoinDate = new DateTime(2017, 9, 2),
                DepartmentId = 2,
                Gender = rGender.Male,
                PhotoPath = "images/max.png"
            }, new eEmployee {
                Id = 4,
                FirstName = "Wesley",
                LastName = "Kemp",
                Email = "wesleykemp@gmail.com",
                JoinDate = new DateTime(2015, 1, 2),
                DepartmentId = 1,
                Gender = rGender.Male,
                PhotoPath = "images/wesley.png"
            }
        );

        modelBuilder.Entity<eDepartment>().HasData(
            new eDepartment { Id = 1, DepartmentName = "HR" },
            new eDepartment { Id = 2, DepartmentName = "IT" },
            new eDepartment { Id = 3, DepartmentName = "Admin" }
        );
    }
}