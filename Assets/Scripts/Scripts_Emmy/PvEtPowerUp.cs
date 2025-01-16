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
        _infosJoueurs._nbPv = _nbPVPresentement;

          if (sectionPv.Length != _infosJoueurs._nbPvDepart)
        {
            Debug.LogWarning("Le nombre de sections PV ne correspond pas au nombre de PV de départ !");
        }
            MettreAJourBarrePv();
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
           _infosJoueurs._nbPv = _nbPVPresentement;
    
   if (_nbPVPresentement <= 0)
    {
     
  FinDePartie();
    }

}
private void MettreAJourBarrePv()
    {
        for (int i = 0; i < sectionPv.Length; i++)
        {
            sectionPv[i].gameObject.SetActive(i < _nbPVPresentement);
        }
}
 private void FinDePartie()
    {
        _infosDuJeu._victoirePartie = false;
        _infosDuJeu._defaitePartie = true;

        // Exemple : charger une scène ou afficher un écran
        SceneManager.LoadScene("SceneDefaite");
    }
}
