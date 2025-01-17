using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueJoueur : MonoBehaviour
{

    [SerializeField] private InfosProjectile projectile;
    [SerializeField] private InfoEnnemis infoEnnemi1;
    [SerializeField] private InfoEnnemis infoEnnemi2;
    [SerializeField] private InfoEnnemis infoEnnemi3;
    

    


    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant a le tag "Player"
        if (other.CompareTag("ennemy"))
        {
            infoEnnemi1.pointDeVie -= projectile.degat;
            infoEnnemi2.pointDeVie -= projectile.degat;
            infoEnnemi3.pointDeVie -= projectile.degat;
        }
    }
    
}
