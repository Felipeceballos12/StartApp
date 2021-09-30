using System;

namespace VetHouse.App.Dominio
{
    public class VitalSign
    {
        public int Id {get;set;}
        public DateTime CreatedAt {get;set;}
        public float HeartRate {get;set;}
        public float Temperature {get;set;}
        public float BreathingFreq {get;set;}
    }
}