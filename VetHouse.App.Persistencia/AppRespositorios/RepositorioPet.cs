using System.Collections.Generic;
namespace VetHouse.App.Persistencia
{
    public class RepositorioPet : IRepositorioPet
    {
        Pet IRepositorioPet.AddPet (Pet pet)
        {
            throw new System.NotImplementedException();
        }

        void IRepositorioPet.DeletePet(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Pet> IRepositorioPet.GetAllPets()
        {
            throw new System.NotImplementedException();
        }

        Pet IRepositorioPet.GetPet(Pet pet);
        {
            throw new System.NotImplementedException();
        }
    }
}