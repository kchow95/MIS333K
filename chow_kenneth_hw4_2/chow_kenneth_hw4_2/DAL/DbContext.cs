using chow_kenneth_hw4_2.Models;
using System.Data.Entity;


namespace chow_kenneth_hw4_2.DAL
{
    public class AppDbContext : DbContext
    {
        //Constructor that invokes the base constructor
        public AppDbContext() : base("MyDBConnection") { }

        //Create the db set
        public DbSet<Member> Members { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Committee> Committees { get; set; }
    }
}