using System;

namespace VetHouse.App.Dominio
{
    public class History
    {
        public int Id {get;set;}
        public DateTime CreatedAt {get;set;}
        public string Diagnose {get;set;}
        public System.Collections.Generic.List<VitalSign> VitalSign {get;set;}
    }
}