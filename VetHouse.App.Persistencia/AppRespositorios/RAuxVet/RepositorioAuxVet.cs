using System.Collections.Generic;
using System.Linq;
using VetHouse.App.Dominio;

namespace VetHouse.App.Persistencia
{
    public class RepositorioAuxVet : IRepositorioAuxVet
    {
        /// <summary>
        /// Referencia al contexto del AuxVet
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo constructor utiliza
        /// Inyeccion de dependencia para indicar el contexto a utilizar 
        /// </summary>
        ///<param name= "appContext"></param>//
        public RepositorioAuxVet (AppContext appContext)
        {
            _appContext=appContext;
        }
        AuxVet IRepositorioAuxVet.AddAuxVet(AuxVet auxVet)
        {
            var auxVetAdicionado = _appContext.AuxVet.Add(auxVet);
            _appContext.SaveChanges();
            return auxVetAdicionado.Entity;
        }
        void IRepositorioAuxVet.DeleteAuxVet(int idAuxVet)
        {
            var auxVetEncontrado = _appContext.AuxVet.FirstOrDefault(av => av.Id == idAuxVet);
            if (auxVetEncontrado == null)
                return;
            _appContext.AuxVet.Remove(auxVetEncontrado);
            _appContext.SaveChanges();
        }
        IEnumerable<AuxVet> IRepositorioAuxVet.GetAllAuxVet()
        {
            return _appContext.AuxVet;
        }
        AuxVet IRepositorioAuxVet.GetAuxVet(int idAuxVet)
        {
            return _appContext.AuxVet.FirstOrDefault(av => av.Id == idAuxVet);
        }
        AuxVet IRepositorioAuxVet.UpdateAuxVet(AuxVet auxVet)
        {
            var auxVetEncontrado = _appContext.AuxVet.FirstOrDefault(av => av.Id == auxVet.Id);
            if (auxVetEncontrado!=null)
            {
                auxVetEncontrado.Name=auxVet.Name;
                auxVetEncontrado.Surname=auxVet.Surname;
                auxVetEncontrado.PhoneNumber=auxVet.PhoneNumber;
                auxVetEncontrado.Gender=auxVet.Gender;
                auxVetEncontrado.Email=auxVet.Email;               
                auxVetEncontrado.DateBirth=auxVet.DateBirth;               
                auxVetEncontrado.ProfessionalCard=auxVet.ProfessionalCard;
                auxVetEncontrado.LaborHours=auxVet.LaborHours;
            }
            return auxVetEncontrado;
        }
    }
}