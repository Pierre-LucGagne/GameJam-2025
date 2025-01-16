using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemeRamasseObjets : MonoBehaviour
{
    [SerializeField] private PvEtPowerUp _pvEtPowerUp;
       [SerializeField] private InfosJoueurs _infosJoueurs;
       [SerializeField]private int _nbPvBonus;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "StanleyCup")
        {
            // _pvEtPowerUp.BonusPV(25); // Gagner 25 PV
            _infosJoueurs._nbPv += _nbPvBonus;
            Debug.Log("ajoutpv");
            Destroy(other.gameObject); // Détruire l'objet ramassé
        }
    }
}
