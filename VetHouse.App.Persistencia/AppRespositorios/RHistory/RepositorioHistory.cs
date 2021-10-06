using System.Collections.Generic;
using VetHouse.App.Dominio;
using System.Linq;

namespace VetHouse.App.Persistencia

{
    public class RepositorioHistory : IRepositorioHistory
    {
        private readonly AppContext _appContext;

        public RepositorioHistory(AppContext appContext)
        {
            _appContext = appContext;
        }

        string GetDiagnose(int IdHistory)
        {
            var HistoryFound = _appContext.History.FirstOrDefault(h => h.Id == IdHistory);
            return HistoryFound.Diagnose;
        }
    }
}