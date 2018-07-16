using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Exo
    {
        int prixRune, coutRemontee;
        double tauxIncertitude;
        public Exo(int r, int re, double m)
        {
            prixRune = r;
            coutRemontee = re;
            tauxIncertitude = m;
        }

        private double getCout()
        {
            return (prixRune + coutRemontee) * 100;
        }
        public string GetAll()
        {
            return "Le prix de l'exo sera probablement compris entre " + getCout() * (1 - (tauxIncertitude / 100)) + " et " + getCout() * (1 + (tauxIncertitude / 100)) + " kamas.";
        }
    }
}