using Microsoft.EntityFrameworkCore;
using VetHouse.App.Dominio;

namespace VetHouse.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<AuxVet> AuxVet {get;set;}
        public DbSet<CareSuggestions> CareSuggestion {get;set;}
        public DbSet<History> History {get;set;}
        public DbSet<Owner> Owner {get;set;}
        public DbSet<Persons> Person {get;set;}
        public DbSet<Pet> Pet {get;set;}
        public DbSet<Vet> Vet {get;set;}
        public DbSet<VitalSign> VitalSign {get;set;}
    }
}