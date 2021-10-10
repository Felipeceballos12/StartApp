using System;
using System.Collections.Generic;

namespace VetHouse.App.Dominio
{
    public class History
    {
        public int Id {get;set;}
        public DateTime CreatedAt {get;set;}
        public string Diagnose {get;set;}
        public List<VitalSign> VitalSign {get;set;}
        public List<CareSuggestion> CareSuggestion {get;set;}

    }
}