using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pour créer le scriptable object du jeu
[CreateAssetMenu(fileName="InfosJeu", menuName ="SO/NouveauJeu")]

public class InfosJeu : ScriptableObject
{
    //  //Variable du scriptable object jeu
    // [SerializeField] public string leNomDuJeu;

    // [SerializeField] public int _nbDePointsRequis;
  [SerializeField] public float _tempsDeJeu;
    [SerializeField] public float _tempsEcoule;
    [SerializeField] public bool firstTime;
    // [SerializeField] public float _nbPvDepart;
    // //Variable qui dit si on gagne la partie
 public bool _defaitePartie;
 public bool _victoirePartie;



     public void init()
    {   
   
       // if(firstTime == false)
        //{
        _tempsEcoule = _tempsDeJeu;
        firstTime = true;
     
        //}
        
    }

}
