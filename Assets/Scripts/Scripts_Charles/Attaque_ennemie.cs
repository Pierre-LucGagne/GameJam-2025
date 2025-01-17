using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaque_ennemie : MonoBehaviour
{
    [Header("Données de l'ennemi")]
    [SerializeField] private InfoEnnemis infoEnnemi; // Référence au ScriptableObject contenant les données de l'ennemi
     [SerializeField] private InfosJoueurs _infosJoueurs;

    

    
    //private bool hasDealtDamage = false; // Vérifie si l'ennemi a déjà infligé des dégâts au joueur

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant a le tag "Player"
        if (other.CompareTag("Player"))
        {
            _infosJoueurs._nbPv -= infoEnnemi.degat;
        }
    }

}
