using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemeRamasseObjets : MonoBehaviour
{
    [SerializeField] private PvEtPowerUp _pvEtPowerUp;
    [SerializeField] private InfosJoueurs _infosJoueurs;
    [SerializeField] private GameObject _falseCup;
    [SerializeField] private int _nbPvBonus;

    [SerializeField] private float _cooldown = 5f; // Cooldown avant la destruction de l'objet

   

    private void OnTriggerEnter(Collider other)
    {
        // Assure-toi que c'est bien l'objet à ramasser qui entre en collision
        if (other.gameObject.CompareTag("StanleyCup"))
        {
          
            
           
       _falseCup.SetActive(true);

            // Ajouter des PV bonus
            _infosJoueurs._bonusPv += _nbPvBonus;
            Debug.Log("PV ajoutés: " + _nbPvBonus);
             Destroy(other.gameObject);

            // Démarre la coroutine pour attendre avant de détruire l'objet
            StartCoroutine(AttendreEtDetruire(_falseCup));
        }
    }

    // Coroutine pour attendre avant de détruire l'objet
    private IEnumerator AttendreEtDetruire(GameObject _falseCup)
    {
        yield return new WaitForSeconds(_cooldown); // Attendre le cooldown
_falseCup.SetActive(false);
         // Détruire l'objet une fois le cooldown terminé
        Debug.Log("Objet détruit après le cooldown");
    }
}
