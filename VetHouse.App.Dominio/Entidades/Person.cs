using System;

namespace VetHouse.App.Dominio
{
    public class Person
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Surname {get;set;}
        public string PhoneNumber {get;set;}
        public GenderPerson Gender {get;set;}
        public DateTime DateBirth {get;set;}
        public string Email {get;set;}
    }
}