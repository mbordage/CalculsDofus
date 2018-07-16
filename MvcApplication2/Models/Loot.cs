using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Loot
    {
        double leTaux, laPP, leChall, tauxVise;
        bool bonusPack; 
        public Loot(double t, double p, double c, double ta, bool b)
        {
            leTaux = t;
            laPP = p;
            leChall = c;
            tauxVise = ta;
            bonusPack = b;
        }
        private double GetTaux()
        {
            double leBonusPack = 1;
            if (bonusPack)
                leBonusPack = 2.5;
            return leTaux * leBonusPack * (laPP / 100) * (1 + leChall / 100);
        }
        private string GetEsperance()
        {
            if (GetTaux() < 100)
                return "Il faudra environ " + Math.Round(Math.Log(1-(tauxVise/100)) / Math.Log(1-(GetTaux() / 100)), 0) + " essais pour avoir " + tauxVise + "% de chances d'obtenir un exemplaire." ;
            else
                return "Vous obtiendrez en moyenne " + GetTaux() + " exemplaires sur 100 combats.";
        }
        public String GetAll()
        {
            return "Sur un essai, les chances de loot sont de : " + GetTaux() +"%\n" + GetEsperance();
        }
    }
}