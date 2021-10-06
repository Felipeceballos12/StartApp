using System.Collections.Generic;
using VetHouse.App.Dominio;

namespace VetHouse.App.Persistencia
{
    public interface IRepositorioHistory
    {
        History GetDiagnose(int IdHistory);
    }
}