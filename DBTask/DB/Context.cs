using DBTask.DB.Entities;
using Microsoft.EntityFrameworkCore;


public class Context : DbContext
{
    /*public Context()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();

    }*/
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Data Source=DESKTOP-7F4LQ55\SQLEXPRESS;Initial Catalog=MyasnichenkoDB;Integrated Security=True");
    }

    public DbSet<MessageRegistration> MessageRegistrations { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<CriminalCase> CriminalCases { get; set; }
    public DbSet<PersonInCriminalCase> PersonInCriminalCase { get; set; }

    public DbSet<CriminalDecision> CriminalDecisions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CriminalDecision>()
            .HasOne(cd => cd.MessageRegistration)
            .WithOne(mr => mr.CriminalDecision);

        modelBuilder.Entity<CriminalDecision>()
            .HasOne(cd => cd.CriminalCase)
            .WithOne(cc => cc.CriminalDecision);


        modelBuilder.Entity<PersonInCriminalCase>()
            .HasOne(pic => pic.CriminalCase)
            .WithMany(cc => cc.PersonInCriminalCases)
            .HasForeignKey(pic => pic.CriminalCaseId);

        modelBuilder.Entity<PersonInCriminalCase>()
            .HasOne(pic => pic.Person)
            .WithMany(p => p.PersonInCriminalCases)
            .HasForeignKey(pic => pic.PersonId);
    }
}