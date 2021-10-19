using System.Collections.Generic;
using VetHouse.App.Dominio;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VetHouse.App.Persistencia
{
    public class RepositorioPet : IRepositorioPet
    {
        private readonly AppContext _appContext = new AppContext();

        Pet IRepositorioPet.AddPet (Pet pet)
        {
            var PetAdded = _appContext.Pet.Add(pet);
            _appContext.SaveChanges();
            return PetAdded.Entity;
        }

        void IRepositorioPet.DeletePet(int IdPet)
        {
            var PetFound = _appContext.Pet.Find(IdPet);
            if(PetFound==null)
                return;
            _appContext.Pet.Remove(PetFound);
            _appContext.SaveChanges();
        }

        IEnumerable<Pet> IRepositorioPet.GetAllPets()
        {
            return _appContext.Pet
            .Include (p => p.AuxVet)
            .Include (p => p.Owner)
            .Include (p => p.History)
            .ToList();            
        }

        Pet IRepositorioPet.GetPet(int IdPet)
        {
            return _appContext.Pet.Find(IdPet);
        }

        Pet IRepositorioPet.UpdatePet(Pet pet)
        {
            var PetFound = _appContext.Pet.Find(pet.Id);
            if (PetFound!=null)
            {
                PetFound.Name = pet.Name;
                PetFound.Type = pet.Type;
                PetFound.Breed = pet.Breed;
                PetFound.Address = pet.Address;
                PetFound.Latitude = pet.Latitude;
                PetFound.Longitude = pet.Longitude;
                PetFound.Weight = pet.Weight;
                PetFound.DateBirth = pet.DateBirth;
                _appContext.SaveChanges();
            }
            return PetFound;
        }
    }
}