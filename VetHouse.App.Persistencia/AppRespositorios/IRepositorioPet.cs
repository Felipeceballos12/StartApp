using System.Collections.Generic;
using VetHouse.App.Dominio;

namespace VetHouse.App.Persistencia
{
    public interface IRepositorioPet
    {
        IEnumerable<Pet> GetAllPets();

        Pet AddPet(Pet pet);

        Pet UpdatePet(Pet pet);

        void DeletePet(Pet pet);

        Pet GetPet(Pet pet);
    }
}