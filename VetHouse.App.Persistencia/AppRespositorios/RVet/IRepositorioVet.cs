using System.Collections.Generic;
using VetHouse.App.Dominio;

namespace VetHouse.App.Persistencia
{
    public interface IRepositorioVet
    {
        IEnumerable<Vet> GetAllVet();
        Vet AddVet(Vet vet);
        Vet UpdateVet(Vet vet);
        void DeleteVet(int idVet);
        Vet GetVet(int idVet);
    }
}
