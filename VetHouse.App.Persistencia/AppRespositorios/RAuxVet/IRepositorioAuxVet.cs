using System.Collections.Generic;
using VetHouse.App.Dominio;

namespace VetHouse.App.Persistencia
{
    public interface IRepositorioAuxVet
    {
        IEnumerable<AuxVet> GetAllAuxVet();
        AuxVet AddAuxVet(AuxVet auxVet);
        AuxVet UpdateAuxVet(AuxVet auxVet);
        void DeleteAuxVet(int idAuxVet);
        AuxVet GetAuxVet(int idAuxVet);
    }
}
