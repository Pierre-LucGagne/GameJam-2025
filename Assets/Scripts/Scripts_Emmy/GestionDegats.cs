using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionDegats : MonoBehaviour
{
    [SerializeField] private PvEtPowerUp _pvEtPowerUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemi"))
        {
            _pvEtPowerUp.PerdrePV();
        }
    }
}
