using System.Collections.Generic;
using System.Linq;
using VetHouse.App.Dominio;

namespace VetHouse.App.Persistencia
{
    public class RepositorioHistory : IRepositorioHistory
    {
        /// <summary>
        /// Referencia al contexto del History
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo constructor utiliza
        /// Inyeccion de dependencia para indicar el contexto a utilizar 
        /// </summary>
        ///<param name= "appContext"></param>//
        public RepositorioHistory (AppContext appContext)
        {
            _appContext=appContext;
        }
        History IRepositorioHistory.AddHistory(History history)
        {
            var historyAdicionado = _appContext.History.Add(history);
            _appContext.SaveChanges();
            return historyAdicionado.Entity;
        }
        void IRepositorioHistory.DeleteHistory(int idHistory)
        {
            var historyEncontrado = _appContext.History.FirstOrDefault(h => h.Id == idHistory);
            if (historyEncontrado == null)
                return;
            _appContext.History.Remove(historyEncontrado);
            _appContext.SaveChanges();
        }
        IEnumerable<History> IRepositorioHistory.GetAllHistory()
        {
            return _appContext.History;
        }
        History IRepositorioHistory.GetHistory(int idHistory)
        {
            return _appContext.History.FirstOrDefault(h => h.Id == idHistory);
        }
        History IRepositorioHistory.UpdateHistory(History history)
        {
            var historyEncontrado = _appContext.History.FirstOrDefault(h => h.Id == history.Id);
            if (historyEncontrado!=null)
            {
                historyEncontrado.CreatedAt=history.CreatedAt;
                historyEncontrado.Diagnose=history.Diagnose;
                historyEncontrado.VitalSign=history.VitalSign;
            }
            return historyEncontrado;
        }
    }
}
