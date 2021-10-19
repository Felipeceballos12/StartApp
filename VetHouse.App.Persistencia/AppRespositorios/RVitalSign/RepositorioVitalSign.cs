using System.Collections.Generic;
using System.Linq;
using VetHouse.App.Dominio;


namespace VetHouse.App.Persistencia
{
    public class RepositorioVitalSign : IRepositorioVitalSign
    {
        private readonly AppContext _appContext = new AppContext();

        VitalSign IRepositorioVitalSign.AddVitalSign(VitalSign vitalSign)
        {
            var addVitalSign = _appContext.VitalSign.Add(vitalSign);

            _appContext.SaveChanges();
            return addVitalSign.Entity;
        }

        void IRepositorioVitalSign.DeleteVitalSign(int idVitalSign)
        {
            var vitalSignFound = _appContext.VitalSign.Find(idVitalSign);

            if (vitalSignFound == null)
            {
                return;
            }

            _appContext.VitalSign.Remove(vitalSignFound);
            _appContext.SaveChanges();
        }

        IEnumerable<VitalSign> IRepositorioVitalSign.GetAllVitalSigns()
        {
            return _appContext.VitalSign;
        }

        VitalSign IRepositorioVitalSign.UpdateVitalSign(VitalSign vitalSign)
        {
            var vitalSignFound = _appContext.VitalSign.Find(vitalSign.Id);

            if (vitalSignFound != null)
            {
                vitalSignFound.HeartRate = vitalSign.HeartRate;
                vitalSignFound.BreathingFreq = vitalSign.BreathingFreq;
                vitalSignFound.Temperature = vitalSign.Temperature;
                vitalSignFound.CreatedAt = vitalSign.CreatedAt;
                vitalSignFound.StatusHealth = vitalSign.StatusHealth;

                _appContext.SaveChanges();
            }

            return vitalSignFound;
        }

        VitalSign IRepositorioVitalSign.GetVitalSign(int idVitalSign)
        {
            return _appContext.VitalSign.Find(idVitalSign);
        }
    }
}