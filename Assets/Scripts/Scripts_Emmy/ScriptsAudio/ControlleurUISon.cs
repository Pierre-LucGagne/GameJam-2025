using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class ControlleurUISon : MonoBehaviour
{
    [SerializeField] private GameObject _panneauSon;




    // Cette méthode est appelée lors d'un événement d'entrée
    public void OnMenu(InputValue value)
    {
     
       
        // Si le panneau est déjà actif, on le désactive
        if (_panneauSon.activeSelf)
        {
       
            _panneauSon.SetActive(false);
        }
        else
        {
            // Sinon on l'active
           
            _panneauSon.SetActive(true);
        }
      

    }

    // // Pour fermer le menu
  private void FermerMenu()
    {
           if(_panneauSon.gameObject.activeInHierarchy ==true){
            _panneauSon.SetActive(false);
        }
        Debug.Log("test fermer");
        
        // if (_panneauSon.activeSelf)
        // {
        //     _panneauSon.SetActive(false);
        // }
    }
}
