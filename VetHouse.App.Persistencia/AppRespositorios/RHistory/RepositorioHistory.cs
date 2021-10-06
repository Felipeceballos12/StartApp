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

        History IRepositorioHistory.GetDiagnose(int IdHistory)
        {
            var historyFound = _appContext.History.FirstOrDefault(h => h.Id == IdHistory);
            return historyFound;
        }
    }
}