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
    [SerializeField] private GameObject _falseCoinCoin; 
    [SerializeField] private GameObject _falseTelescope; 


    [SerializeField] private GameObject _selectSextant; 
   [SerializeField] private GameObject _selectCoinCoin; 
   [SerializeField] private GameObject _selectTelescope; 


   [SerializeField] private GameObject _gun; 



    [SerializeField] private TextMeshProUGUI _texteNouvelArme;
    [SerializeField] private TextMeshProUGUI _texteAlerte;



    void Start()
    {
        _falseSextant.SetActive(false);
         _falseCoinCoin.SetActive(false);
           _falseTelescope.SetActive(false);
               
        _texteNouvelArme.gameObject.SetActive(false);
        _texteAlerte.gameObject.SetActive(false);
        
    }
    




 private void OnTriggerEnter(Collider other)
    {
         
         if (other.gameObject.CompareTag("coincoin"))
            {
            _gun.SetActive(false);
                
            _texteNouvelArme.gameObject.SetActive(true);
            _falseCoinCoin.SetActive(true);

       

                // Détruit l'objet StanleyCup collecté
                Destroy(other.gameObject);

            
            }
        if (_infosJoueurs._nbPoints >= _infosArme._prixArme){
            
      
            if (other.gameObject.CompareTag("sextant"))
            {
              _gun.SetActive(false);
                
            _texteNouvelArme.gameObject.SetActive(true);
            _falseSextant.SetActive(true);

            _infosJoueurs._nbPoints -= _infosArme._prixArme;

                // Détruit l'objet StanleyCup collecté
                Destroy(other.gameObject);

            
            }

             if (other.gameObject.CompareTag("telescope"))
            {
             _gun.SetActive(false);
                
            _texteNouvelArme.gameObject.SetActive(true);
            _falseTelescope.SetActive(true);

            _infosJoueurs._nbPoints -= _infosArme._prixArme;

                // Détruit l'objet StanleyCup collecté
                Destroy(other.gameObject);

            
            }
             
        }

        else{
         
            if (other.gameObject.CompareTag("sextant"))
            {
            _texteAlerte.gameObject.SetActive(true);
            StartCoroutine(HideTextAfterDelay(_texteAlerte, 2f));
            

            
            }

             if (other.gameObject.CompareTag("telescope"))
            {
            _texteAlerte.gameObject.SetActive(true);
            StartCoroutine(HideTextAfterDelay(_texteAlerte, 2f));
            

            
            }
             if (other.gameObject.CompareTag("coincoin"))
            {
            _texteAlerte.gameObject.SetActive(true);
            StartCoroutine(HideTextAfterDelay(_texteAlerte, 2f));
            

            
            }

        }
 
    }
     private IEnumerator HideTextAfterDelay(TextMeshProUGUI textObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        textObject.gameObject.SetActive(false);
    }
}