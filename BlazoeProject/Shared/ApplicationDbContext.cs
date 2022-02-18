using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazoeProject.Shared
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var departments = new List<Department>
            {
                new Department { Id=1,Name="IT"},
                new Department { Id=2,Name="HR"},
                new Department { Id=3,Name="Finace"},
                new Department { Id=4,Name="Security"},
                new Department { Id=5,Name="Devops"},
                new Department { Id=6,Name="Vas IOT"},
                new Department { Id=7,Name="Busines"},
                new Department { Id=8,Name="Medical"},

            };

            modelBuilder.Entity<Department>().HasData(departments);

            var employees = new List<Employee>
            {
                    new Employee
                    {
                        Id=1,
                        FirstName="ombasa",
                        LastName="mukhwami",
                        DateOfBirth=new DateTime(2000,2,3),
                        Gender=Gender.Male,
                        DepartmentId=1,
                        PhotoPath="images/john.png",
                        Email="mukhwami@gmail.com"
                    },
                    new Employee
                    {
                        Id=2,
                        FirstName="martin",
                        LastName="simiyu",
                        DateOfBirth=new DateTime(1999,2,3),
                        Gender=Gender.Male,
                        DepartmentId=2,
                        Email="martin.simiyu@test.com",
                        PhotoPath="images/john.png"
                    },
                    new Employee
                    {
                        Id=3,
                        FirstName="joel",
                        LastName="orangi",
                        DateOfBirth=new DateTime(2002,12,7),
                        Gender=Gender.Male,
                        DepartmentId=3,
                        Email="joel.orandi@tes.com",
                        PhotoPath="images/john.png"
                    },
                    new Employee
                    {
                        Id=4,
                        FirstName="ososi",
                        LastName="vincent",
                        DateOfBirth=new DateTime(2001,4,13),
                        Gender=Gender.Male,
                        DepartmentId=1,
                        Email="ososi.vincent@tes.com",
                        PhotoPath="images/john.png"
                    },
                    new Employee
                    {
                        Id=5,
                        FirstName="phelisters",
                        LastName="Bogongo",
                        DateOfBirth=new DateTime(2010,8,20),
                        Gender=Gender.Female,
                        DepartmentId=4,
                        Email="phelisters.bogonko@test.com",
                        PhotoPath="images/john.png"
                    },
                    new Employee
                    {
                        Id=6,
                        FirstName="silas",
                        LastName="mogare",
                        DateOfBirth=new DateTime(1998,2,3),
                        Gender=Gender.Male,
                        DepartmentId=5,
                        Email="silas.mogare@test.com",
                        PhotoPath="images/john.png"
                    },
                    new Employee
                    {
                        Id=7,
                        FirstName="scholastica",
                        LastName="memusi",
                        DateOfBirth=new DateTime(2009,7,23),
                        Gender=Gender.Female,
                        DepartmentId=6,
                        Email="scholastica.memusi@test.com",
                        PhotoPath="images/john.png"
                    },
                    new Employee
                    {
                        Id=8,
                        FirstName="branambo",
                        LastName="midecha",
                        DateOfBirth=new DateTime(2002,7,23),
                        Gender=Gender.Female,
                        DepartmentId=7,
                        Email="breana62@gmail.com",
                        PhotoPath="images/john.png"
                    },
                    new Employee
                    {
                        Id=9,
                        FirstName="sarah",
                        LastName="moraa",
                        Email="sarah.moraa@test.com",
                        DateOfBirth=new DateTime(2006,7,23),
                        Gender=Gender.Female,
                        DepartmentId=8,
                        PhotoPath="images/john.png"
                    },
                    new Employee
                    {
                        Id=10,
                        FirstName="Aquirinah",
                        LastName="mukhwami",
                        Email="aquirinah.mukhwami@test.com",
                        DateOfBirth=new DateTime(2004,7,23),
                        Gender=Gender.Female,
                        DepartmentId=8,
                        PhotoPath="images/john.png"
                    }
            };


            modelBuilder.Entity<Employee>().HasData(employees);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
