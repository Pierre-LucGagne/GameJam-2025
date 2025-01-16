using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class VictoireOuDefaite : MonoBehaviour
{
    // Référence aux scriptables objects
    [SerializeField] private InfosJoueurs _infosJoueurs;
    [SerializeField] private InfosJeu _infosDuJeu;


    [SerializeField] private GameObject _canvasVictoire;

   
    void Start()
    {
        // Cache l'écran de victoire au départ
          _infosDuJeu._victoirePartie = false;
    _infosDuJeu._defaitePartie = false;
        _canvasVictoire.gameObject.SetActive(false);
    }
    
    void Update()
    {
        // Debug.Log(_infosJoueurs._nbPv);
         if (_infosJoueurs._nbPv > 0 && _infosDuJeu._tempsEcoule == 0f)  // si temps fini et barre de vie a encore des points 
        {
    
            //Pour appler le void victoire 
            Victoire();
        }
        
    }
       

    private void Victoire(){
    //Pour appeler le changement de scene 
   AfficherCanvasVictoire();
    //Change la valeur de la variable de l'infoNiveau qui permet de déterminer si la partie est gagné ou perdu ce qui determine quel canvas entre le canvas de défaite et victoire est affiché   
    _infosDuJeu._victoirePartie = true;
    _infosDuJeu._defaitePartie = false;

    }

    //Pour changer de scene
    private void AfficherCanvasVictoire(){
    _canvasVictoire.gameObject.SetActive(true);



     
     
    }
   public void ReinitialiserVictoire()
    {
        // Réinitialise les variables de victoire/défaite et autres valeurs de jeu
        _infosDuJeu._victoirePartie = false;
        _infosDuJeu._defaitePartie = false;

    
    }

    public void RelancerJeu()
    {
        // Réinitialise les valeurs avant de recharger la scène
        ReinitialiserVictoire();

        // Recharge la scène actuelle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}  


