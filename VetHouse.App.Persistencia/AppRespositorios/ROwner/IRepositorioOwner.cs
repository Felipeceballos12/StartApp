using System.Collections.Generic;
using VetHouse.App.Dominio;

namespace VetHouse.App.Persistencia
{
    public interface IRepositorioOwner
    {
        IEnumerable<Owner> GetAllOwner();
        Owner AddOwner(Owner owner);
        Owner UpdateOwner(Owner owner);
        void DeleteOwner(int idOwner);
        Owner GetOwner(int idOwner);
    }
}
