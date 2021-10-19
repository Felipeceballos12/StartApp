using System.Collections.Generic;
using System.Linq;
using VetHouse.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VetHouse.App.Persistencia
{
    public class RepositorioHistory : IRepositorioHistory
    {
        /// <summary>
        /// Referencia al contexto del History
        /// </summary>
        private readonly AppContext _appContext = new AppContext();
        /// <summary>
        /// Metodo constructor utiliza
        /// Inyeccion de dependencia para indicar el contexto a utilizar 
        /// </summary>
        ///<param name= "appContext"></param>//
       
        History IRepositorioHistory.AddHistory(History history)
        {
            var historyAdicionado = _appContext.History.Add(history);
            _appContext.SaveChanges();
            return historyAdicionado.Entity;
        }
        void IRepositorioHistory.DeleteHistory(int idHistory)
        {
            var historyEncontrado = _appContext.History.Find(idHistory);
            if (historyEncontrado == null)
                return;
            _appContext.History.Remove(historyEncontrado);
            _appContext.SaveChanges();
        }
        IEnumerable<History> IRepositorioHistory.GetAllHistory()
        {
            return _appContext.History
            .Include (h => h.VitalSign)
            .Include (h => h.CareSuggestion)
            .ToList();        
        }
        History IRepositorioHistory.GetHistory(int idHistory)
        {
            return _appContext.History.Find(idHistory);
        }
        History IRepositorioHistory.UpdateHistory(History history)
        {
            var historyEncontrado = _appContext.History.Find(history.Id);
            if (historyEncontrado!=null)
            {
                historyEncontrado.CreatedAt=history.CreatedAt;
                historyEncontrado.Diagnose=history.Diagnose;
            }
            return historyEncontrado;
        }

        VitalSign IRepositorioHistory.AssignVitalSign(int idVitalSign, int idHistory)
        {
            var vitalSignFound = _appContext.VitalSign.Find(idVitalSign);
            var historyFound = _appContext.History.Find(idHistory);

            if(historyFound != null)
            {
                if(historyFound.VitalSign != null)
                {
                    historyFound.VitalSign.Add(vitalSignFound);
                    _appContext.SaveChanges();
                }
                else
                {
                    historyFound.VitalSign = new List<VitalSign>();
                    historyFound.VitalSign.Add(vitalSignFound);
                    _appContext.SaveChanges();
                }
            
                var historyFound2 = _appContext.History.Find(historyFound.Id);
                if (historyFound2 != null)
                {
                    historyFound2.CreatedAt=historyFound.CreatedAt;
                    historyFound2.Diagnose=historyFound.Diagnose;
                    
                    _appContext.SaveChanges();
                
                    return vitalSignFound;
                }
            }
            return null;
        }

        CareSuggestion IRepositorioHistory.AssignCareSuggestion(int idCareSuggestion, int idHistory)
        {
            var careSuggestionFound = _appContext.CareSuggestion.Find(idCareSuggestion);
            var historyFound = _appContext.History.Find(idHistory); 

            if(historyFound != null)
            {
               if(historyFound.CareSuggestion != null)
                {
                historyFound.CareSuggestion.Add(careSuggestionFound);
                _appContext.SaveChanges();
                }
                else
                {
                    historyFound.CareSuggestion = new List<CareSuggestion>();
                    historyFound.CareSuggestion.Add(careSuggestionFound);
                    _appContext.SaveChanges();
                }
                
                var historyFound2 = _appContext.History.Find(historyFound.Id);
                if (historyFound2 != null)
                {
                    historyFound2.CreatedAt=historyFound.CreatedAt;
                    historyFound2.Diagnose=historyFound.Diagnose;
                    
                    _appContext.SaveChanges();
                
                    return careSuggestionFound;
                }
            }
            return null;
        }
    }
}


