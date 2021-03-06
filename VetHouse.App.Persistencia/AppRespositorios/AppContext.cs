using Microsoft.EntityFrameworkCore;
using VetHouse.App.Dominio;

namespace VetHouse.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<AuxVet> AuxVet {get;set;}
        public DbSet<CareSuggestion> CareSuggestion {get;set;}
        public DbSet<History> History {get;set;}
        public DbSet<Owner> Owner {get;set;}
        public DbSet<Person> Person {get;set;}
        public DbSet<Pet> Pet {get;set;}
        public DbSet<Vet> Vet {get;set;}
        public DbSet<VitalSign> VitalSign {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = VetHousetData");
            }
        }
    }
}