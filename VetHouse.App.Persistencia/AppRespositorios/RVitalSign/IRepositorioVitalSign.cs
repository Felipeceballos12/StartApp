using System.Collections.Generic;
using VetHouse.App.Dominio;

namespace VetHouse.App.Persistencia
{
    public interface IRepositorioVitalSign
    {
        IEnumerable<VitalSign> GetAllVitalSigns();
        VitalSign AddVitalSign(VitalSign vitalSign);
        VitalSign UpdateVitalSign(VitalSign vitalSign);
        void DeleteVitalSign(int idVitalSign);
        VitalSign GetVitalSign(int idVitalSign);
    }
}