using System.Collections.Generic;
using System.Linq;
using VetHouse.App.Dominio;

namespace VetHouse.App.Persistencia
{
    public class RepositorioCareSuggestion : IRepositorioCareSuggestion
    {
        private readonly AppContext _appContext;

        public RepositorioCareSuggestion(AppContext appContext)
        {
            _appContext = appContext;
        }

        CareSuggestion IRepositorioCareSuggestion.AddCareSuggestion(CareSuggestion careSuggestion)
        {
            var addCareSuggestion = _appContext.CareSuggestion.Add(careSuggestion);

            _appContext.SaveChanges();
            return addCareSuggestion.Entity;
        }

        void IRepositorioCareSuggestion.DeleteCareSuggestion(int idCareSuggestion)
        {
            var careSuggestionFound = _appContext.CareSuggestion.FirstOrDefault(cs => cs.Id == idCareSuggestion);

            if (careSuggestionFound == null)
            {
                return;
            }

            _appContext.CareSuggestion.Remove(careSuggestionFound);
            _appContext.SaveChanges();
        }

        IEnumerable<CareSuggestion> IRepositorioCareSuggestion.GetAllCareSuggestions()
        {
            return _appContext.CareSuggestion;
        }

        CareSuggestion IRepositorioCareSuggestion.UpdateCareSuggestion(CareSuggestion careSuggestion)
        {
            var careSuggestionFound = _appContext.CareSuggestion.FirstOrDefault(cs => cs.Id == careSuggestion.Id);

            if (careSuggestionFound != null)
            {
                careSuggestionFound.Description = careSuggestion.Description;
                careSuggestionFound.CreatedAt = careSuggestion.CreatedAt;

                _appContext.SaveChanges();
            }

            return careSuggestionFound;
        }

        CareSuggestion IRepositorioCareSuggestion.GetCareSuggestion(int idCareSuggestion)
        {
            return _appContext.CareSuggestion.FirstOrDefault(cs => cs.Id == idCareSuggestion);
        }
    }
}