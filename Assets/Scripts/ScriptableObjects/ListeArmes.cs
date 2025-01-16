using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ListeObjectifs", menuName = "ScriptableObject/NouveauxObjectifs", order = 1)]

public class ListeArmes : ScriptableObject
{
    [System.Serializable] 

    public class Arme
    {
        public string _nomArme;
        public bool _estAcheter;
       
    }
   public List<Arme> armes = new List<Arme>();


       public void ArmeAcheter(string _nomArme)
    {
       Arme arme = armes.Find(o => o._nomArme == _nomArme);
        if (arme != null)
        {
            arme._estAcheter = true;
        }
    }

       public bool ToutesLesArmesSontAcheter()
    {
   
        // Vérifie si tous les objectifs sont accomplis
        return armes.All(o => o._estAcheter);
        
    }
    public void ReinitialiserObjectifs()
    {
        // Réinitialise tous les objectifs à non accomplis
        foreach (Arme arme in armes)
        {
            arme._estAcheter = false;
        }
    }
}

