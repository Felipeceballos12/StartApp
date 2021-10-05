using System.Collections.Generic;
using VetHouse.App.Dominio;

namespace VetHouse.App.Persistencia
{
    public interface IRepositorioPet
    {
        IEnumerable<Pet> GetAllPets();

        Pet AddPet(Pet pet);

        void DeletePet(int IdPet);

        Pet GetPet(int IdPet);

        Pet UpdatePet(Pet pet);
    }
}