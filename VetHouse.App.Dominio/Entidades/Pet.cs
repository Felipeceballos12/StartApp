namespace VetHouse.App.Dominio
{
    public class Pet
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public TypePet Type {get;set;}
        public string Breed {get;set;}
        public string Address {get;set;}
        public float Latitude {get;set;}
        public float Longitude {get;set;}
        public float Weight {get;set;}
        public System.DateTime DateBirth {get;set;}
        public GenderPet Gender {get;set;}
        public AuxVet AuxVet {get;set;}
        public Owner Owner {get;set;}
        public History History {get;set;}

    }
}