using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Détruire le projectile lorsqu'il entre en collision avec un autre objet
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si vous utilisez un trigger au lieu d'un collider physique
        Destroy(gameObject);
    }
}
