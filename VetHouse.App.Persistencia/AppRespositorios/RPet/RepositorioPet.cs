using System.Collections.Generic;
using VetHouse.App.Dominio;
using System.Linq;

namespace VetHouse.App.Persistencia
{
    public class RepositorioPet : IRepositorioPet
    {
        private readonly AppContext _appContext;

        public RepositorioPet(AppContext appContext)
        {
            _appContext = appContext;
        }
        Pet IRepositorioPet.AddPet (Pet pet)
        {
            var PetAdded = _appContext.Pet.Add(pet);
            _appContext.SaveChanges();
            return PetAdded.Entity;
        }

        void IRepositorioPet.DeletePet(int IdPet)
        {
            var PetFound = _appContext.Pet.FirstOrDefault(p => p.Id == IdPet);
            if(PetFound==null)
                return;
            _appContext.Pet.Remove(PetFound);
            _appContext.SaveChanges();
        }

        IEnumerable<Pet> IRepositorioPet.GetAllPets()
        {
            return _appContext.Pet;
        }

        Pet IRepositorioPet.GetPet(int IdPet)
        {
            return _appContext.Pet.FirstOrDefault(p => p.Id == IdPet);
        }

        Pet IRepositorioPet.UpdatePet(Pet pet)
        {
            var PetFound = _appContext.Pet.FirstOrDefault(p => p.Id == pet.Id);
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