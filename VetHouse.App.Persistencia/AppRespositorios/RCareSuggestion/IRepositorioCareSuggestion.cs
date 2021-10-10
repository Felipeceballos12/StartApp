using System.Collections.Generic;
using VetHouse.App.Dominio;


namespace VetHouse.App.Persistencia
{
    public interface IRepositorioCareSuggestion
    {
        IEnumerable<CareSuggestion> GetAllCareSuggestions();
        CareSuggestion AddCareSuggestion(CareSuggestion careSuggestion);
        CareSuggestion UpdateCareSuggestion(CareSuggestion careSuggestion);
        void DeleteCareSuggestion(int idCareSuggestion);
        CareSuggestion GetCareSuggestion(int idCareSuggestion);
    }
}