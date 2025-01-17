using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TilesArmes : MonoBehaviour
{
    [SerializeField] private InfosJoueurs _infosJoueurs;
    [SerializeField] private Armes _infosArme;
    [SerializeField] private GameObject _falseSextant; 
    [SerializeField] private GameObject _selectSextant; 

    [SerializeField] private TextMeshProUGUI _texteNouvelArme;



    void Start()
    {
        _falseSextant.SetActive(false);
               
        _texteNouvelArme.gameObject.SetActive(false);
        
    }
    




 private void OnTriggerEnter(Collider other)
    {
         
        
        if (_infosJoueurs._nbPoints >= _infosArme._prixArme){
            Debug.Log("checkPoints");
      
        if (other.gameObject.CompareTag("sextant"))
        {
          
            
           _texteNouvelArme.gameObject.SetActive(true);
       _falseSextant.SetActive(true);

           _infosJoueurs._nbPoints -= _infosArme._prixArme;

            // Détruit l'objet StanleyCup collecté
            Destroy(other.gameObject);

        
        }
        }
    }
}