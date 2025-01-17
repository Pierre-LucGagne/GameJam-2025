using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AffichageDesPoints : MonoBehaviour
{

      [SerializeField] private TMP_Text _texteNbPoints;
 
       [SerializeField] private InfosJoueurs _infosJoueurs;
    
    void Start()
    {
         _infosJoueurs._nbPoints = 0;
         _infosJoueurs._nbPvDepart = 100;
    }

    // Update is called once per frame
    void Update()
    {
           AfficherPoints();
    }
     public void AfficherPoints(){
      
       
       _texteNbPoints.text = _infosJoueurs._nbPoints.ToString();
         
    }
}
