using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EauBenitedamage : MonoBehaviour
{
    [SerializeField] private InfosJoueurs _infosJoueurs;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant a le tag "Player"
        if (other.CompareTag("Player"))
        {
            _infosJoueurs._nbPv -= 5f;
        }
    }
}
