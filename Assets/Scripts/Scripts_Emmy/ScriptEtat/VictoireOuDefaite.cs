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

    

   

    
    void Update()
    {
         if (_infosJoueurs._nbPv > 0 && _infosDuJeu._tempsEcoule == 0f)  // si temps fini et barre de vie a encore des points 
        {
            //Pour appler le void victoire 
            Victoire();
        }
        
    }
       

    private void Victoire(){
    //Pour appeler le changement de scene 
    ChangementDeScene();
    //Change la valeur de la variable de l'infoNiveau qui permet de déterminer si la partie est gagné ou perdu ce qui determine quel canvas entre le canvas de défaite et victoire est affiché   
    _infosDuJeu._victoirePartie = true;
    _infosDuJeu._defaitePartie = false;

    }

    //Pour changer de scene
    private void ChangementDeScene(){

     int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
     SceneManager.LoadScene(nextSceneIndex); 

     
     
    }

    

}  


