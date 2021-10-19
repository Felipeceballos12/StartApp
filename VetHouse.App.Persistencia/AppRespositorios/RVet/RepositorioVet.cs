using System.Collections.Generic;
using System.Linq;
using VetHouse.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VetHouse.App.Persistencia
{
    public class RepositorioVet : IRepositorioVet
    {
        /// <summary>
        /// Referencia al contexto del Vet
        /// </summary>
        private readonly AppContext _appContext = new AppContext()
        ;
        /// <summary>
        /// Metodo constructor utiliza
        /// Inyeccion de dependencia para indicar el contexto a utilizar 
        /// </summary>
        ///<param name= "appContext"></param>//
      
        Vet IRepositorioVet.AddVet(Vet vet)
        {
            var vetAdicionado = _appContext.Vet.Add(vet);
            _appContext.SaveChanges();
            return vetAdicionado.Entity;
        }
        void IRepositorioVet.DeleteVet(int idVet)
        {
            var vetEncontrado = _appContext.Vet.Find(idVet);
            if (vetEncontrado == null)
                return;
            _appContext.Vet.Remove(vetEncontrado);
            _appContext.SaveChanges();
        }
        IEnumerable<Vet> IRepositorioVet.GetAllVet()
        {
            return _appContext.Vet
            .Include (v => v.Pets)
            .ToList();        
        }
        Vet IRepositorioVet.GetVet(int idVet)
        {
            return _appContext.Vet.Find(idVet);
        }
        Vet IRepositorioVet.UpdateVet(Vet vet)
        {
            var vetEncontrado = _appContext.Vet.Find(vet.Id);
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

        Pet IRepositorioVet.AssignPet(int idVet, int idPet)
        {
            var vetFound = _appContext.Vet.Find(idVet);
            var petFound = _appContext.Pet.Find(idPet);

            if (vetFound != null)
            {
                if (vetFound.Pets != null)
                {
                    vetFound.Pets.Add(petFound);
                    _appContext.SaveChanges();
                }
                else
                {
              
                    vetFound.Pets = new List<Pet>();
                    vetFound.Pets.Add(petFound);
                    _appContext.SaveChanges();
                }

                var vetFound2 = _appContext.Vet.Find(vetFound.Id);

                if (vetFound2 != null)
                {
                    vetFound2.Name = vetFound.Name;
                    vetFound2.Surname = vetFound.Surname;
                    vetFound2.PhoneNumber = vetFound.PhoneNumber;
                    vetFound2.Gender = vetFound.Gender;
                    vetFound2.Email = vetFound.Email;
                    vetFound2.DateBirth = vetFound.DateBirth;
                    vetFound2.RegisterRethus = vetFound.RegisterRethus;
                    vetFound2.Specialty = vetFound.Specialty;

                    _appContext.SaveChanges();

                    return petFound;
                }
            }

            return null;
        }



    }
}