using System.Collections.Generic;
using VetHouse.App.Dominio;


namespace VetHouse.App.Persistencia
{
    public interface IRepositorioCareSuggestion
    {
        IEnumerable<CareSuggestions> GetAllCareSuggestions();
        CareSuggestions AddCareSuggestion(CareSuggestions careSuggestion);
        CareSuggestions UpdateCareSuggestion(CareSuggestions careSuggestion);
        void DeleteCareSuggestion(int idCareSuggestion);
        CareSuggestions GetCareSuggestion(int idCareSuggestion);
    }
}