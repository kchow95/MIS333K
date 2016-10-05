using Chow_Kenneth_hw3.Models;
using System.Data.Entity;

namespace Chow_Kenneth_hw3.DAL
{
    public class AppDbContext : DbContext
    {
        //Constructor that invokes the base constructor
        public AppDbContext() : base("MyDBConnection") { }

        //Create the db set
        public DbSet<Member> Members { get; set; }
    }
}