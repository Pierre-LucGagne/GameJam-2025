using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class PvEtPowerUp : MonoBehaviour
{
     [SerializeField] private InfosJoueurs _infosJoueurs;
     [SerializeField] private InfosJeu _infosDuJeu;
     //image des pv 
     public Image[] sectionPv;
  private int _nbPVPresentement;
    void Start()
    {
        _nbPVPresentement = _infosJoueurs._nbPvDepart;
    }

     private void PerdrePV(){
     
    //Enleve un pv au nombre de pv présentement
    _nbPVPresentement--;
    
   
     // Vérifie si l'index pour le tableau de cœurs est dans les limites du tableau
        if (_nbPVPresentement >= 0 && _nbPVPresentement < sectionPv.Length)
        {
            // Désactive un cœur
            sectionPv[_nbPVPresentement].gameObject.SetActive(false);
           // On perd des points collectés
        //    _infosJoueurs._nbPoints -= _pointsPerdus;

        }
    
   if (_nbPVPresentement <= 0)
    {
     
  
        //Changement de scene
    //    _gestionScenes.SceneSuivante();
       //Change la valeur de la variable de l'infoNiveau qui permet de déterminer si la partie est gagné ou perdu ce qui determine quel canvas entre le canvas de défaite et victoire est affiché
       _infosDuJeu._victoirePartie = false;
      _infosDuJeu._defaitePartie = true;
    }

}
}
