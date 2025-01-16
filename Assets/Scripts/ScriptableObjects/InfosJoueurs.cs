using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Pour créer le scriptable object joueur
[CreateAssetMenu(fileName="InfosJoueurs", menuName ="SO/NouveauJoueur")]



public class InfosJoueurs : ScriptableObject
{
    
//     public string _prenomJoueurs;
//nombre de pv
  public int _nbPvDepart; 

  //au cours de la partie
 public float _nbPv;

 public int _bonusPv;
      public float _nbPoints;
 
//     public string _causeMort;

//     [SerializeField] public string _tempsDuJoueur;
}
