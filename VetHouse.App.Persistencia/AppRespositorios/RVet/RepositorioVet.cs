using System.Collections.Generic;
using System.Linq;
using VetHouse.App.Dominio;

namespace VetHouse.App.Persistencia
{
    public class RepositorioVet : IRepositorioVet
    {
        /// <summary>
        /// Referencia al contexto del Vet
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo constructor utiliza
        /// Inyeccion de dependencia para indicar el contexto a utilizar 
        /// </summary>
        ///<param name= "appContext"></param>//
        public RepositorioVet (AppContext appContext)
        {
            _appContext=appContext;
        }
        Vet IRepositorioVet.AddVet(Vet vet)
        {
            var vetAdicionado = _appContext.Vet.Add(vet);
            _appContext.SaveChanges();
            return vetAdicionado.Entity;
        }
        void IRepositorioVet.DeleteVet(int idVet)
        {
            var vetEncontrado = _appContext.Vet.FirstOrDefault(v => v.Id == idVet);
            if (vetEncontrado == null)
                return;
            _appContext.Vet.Remove(vetEncontrado);
            _appContext.SaveChanges();
        }
        IEnumerable<Vet> IRepositorioVet.GetAllVet()
        {
            return _appContext.Vet;
        }
        Vet IRepositorioVet.GetVet(int idVet)
        {
            return _appContext.Vet.FirstOrDefault(v => v.Id == idVet);
        }
        Vet IRepositorioVet.UpdateVet(Vet vet)
        {
            var vetEncontrado = _appContext.Vet.FirstOrDefault(v => v.Id == vet.Id);
            if (vetEncontrado!=null)
            {
                vetEncontrado.Name=vet.Name;
                vetEncontrado.Surname=vet.Surname;
                vetEncontrado.PhoneNumber=vet.PhoneNumber;
                vetEncontrado.Gender=vet.Gender;
                vetEncontrado.Email=vet.Email;    
                vetEncontrado.DateBirth=vet.DateBirth;    
                vetEncontrado.RegisterRethus = vet.RegisterRethus;
                vetEncontrado.Specialty=vet.Specialty;

            }
            return vetEncontrado;
        }
    }
}