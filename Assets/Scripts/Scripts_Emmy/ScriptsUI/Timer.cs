using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //Référence au texte du timer
    [SerializeField] private TMP_Text _tempsTexte; //gameobject txt
    //Variable qui affichera le temps 
  private bool _tempsJeuFini = false;

    // Référence aux scriptables objects
    [SerializeField] private InfosJeu _infosDuJeu;
  
 // [SerializeField]private ZoneSceneFin _zoneFinScene; //pour changer de scène
   


 void Awake()
 {
    
 if (_infosDuJeu != null)
    {
        _infosDuJeu.init();
    }
 }


    
    void Update()
    {
      
            CalculTemps(); 

           

    
        
    }
   
   void CalculTemps(){

    _infosDuJeu._tempsEcoule -= Time.deltaTime; 
    if(_tempsTexte != null){
        AfficherTemps(_infosDuJeu._tempsEcoule);
    }
     if (_infosDuJeu._tempsEcoule<= 0f){
        Debug.Log($"h");
        _tempsJeuFini = true;
        _infosDuJeu._tempsEcoule =0f; //défaite
        //  _zoneFinScene.AllerSceneCredits(); //pour changer de scène

       
    }
 


   }
   
    //Pour afficher le temps du timer qui avance 
    void AfficherTemps(float temps){

    temps +=1;

    float minutes = Mathf.FloorToInt(temps/60);
    float secondes = Mathf.FloorToInt(temps % 60);

    _tempsTexte.text = string.Format("{0:00}:{1:00}",minutes,secondes);
    
 
 
   }

}


