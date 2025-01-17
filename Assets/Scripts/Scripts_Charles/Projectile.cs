using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour



{
    [SerializeField] private InfosProjectile projectile;
    [SerializeField] private InfoEnnemis infoEnnemi;
    [SerializeField] private InfoEnnemis infoEnnemi2;
    [SerializeField] private InfoEnnemis infoEnnemi3;

    


    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant a le tag "Player"
        if (other.CompareTag("ennemy"))
        {
            infoEnnemi.pointDeVie -= projectile.degat;

            if (infoEnnemi.pointDeVie <= 0){
                Destroy(other.gameObject);
            }

             if (infoEnnemi2.pointDeVie <= 0){
                Destroy(other.gameObject);
            }

             if (infoEnnemi3.pointDeVie <= 0){
                Destroy(other.gameObject);
            }
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        // Détruire le projectile lorsqu'il entre en collision avec un autre objet
        Destroy(gameObject);
    }

    
}
