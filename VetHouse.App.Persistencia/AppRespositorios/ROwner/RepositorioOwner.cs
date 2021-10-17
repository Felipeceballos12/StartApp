using System.Collections.Generic;
using System.Linq;
using VetHouse.App.Dominio;

namespace VetHouse.App.Persistencia
{
    public class RepositorioOwner : IRepositorioOwner
    {
        /// <summary>
        /// Referencia al contexto del Owner
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo constructor utiliza
        /// Inyeccion de dependencia para indicar el contexto a utilizar 
        /// </summary>
        ///<param name= "appContext"></param>//
        public RepositorioOwner (AppContext appContext)
        {
            _appContext=appContext;
        }
        Owner IRepositorioOwner.AddOwner(Owner owner)
        {
            var ownerAdicionado = _appContext.Owner.Add(owner);
            _appContext.SaveChanges();
            return ownerAdicionado.Entity;
        }
        void IRepositorioOwner.DeleteOwner(int idOwner)
        {
            var ownerEncontrado = _appContext.Owner.FirstOrDefault(o => o.Id == idOwner);
            if (ownerEncontrado == null)
                return;
            _appContext.Owner.Remove(ownerEncontrado);
            _appContext.SaveChanges();
        }
        IEnumerable<Owner> IRepositorioOwner.GetAllOwner()
        {
            return _appContext.Owner;
        }
        Owner IRepositorioOwner.GetOwner(int idOwner)
        {
            return _appContext.Owner.FirstOrDefault(o => o.Id == idOwner);
        }
        Owner IRepositorioOwner.UpdateOwner(Owner owner)
        {
            var ownerEncontrado = _appContext.Owner.FirstOrDefault(o => o.Id == owner.Id);
            if (ownerEncontrado!=null)
            {
                ownerEncontrado.Name=owner.Name;
                ownerEncontrado.Surname=owner.Surname;
                ownerEncontrado.PhoneNumber=owner.PhoneNumber;
                ownerEncontrado.Gender=owner.Gender;
                ownerEncontrado.Email=owner.Email;               
                ownerEncontrado.DateBirth=owner.DateBirth;               
            }
            return ownerEncontrado;
        }
    }
}