using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireArme : MonoBehaviour
{
    [Header("Paramètres de l'arme")]
    [SerializeField] private GameObject projectilePrefab; // Le projectile à tirer
    [SerializeField] private Transform firePoint; // Le point de tir (où les projectiles apparaissent)
    [SerializeField] private float fireRate = 1f; // Temps entre chaque tir (en secondes)
    [SerializeField] private float projectileSpeed = 10f; // Vitesse du projectile
    [SerializeField] private float maxDistance = 20f; // Distance maximale que le projectile peut parcourir

    private float timeSinceLastShot = 0f;

    void Update()
    {
        // Mise à jour du temps depuis le dernier tir
        timeSinceLastShot += Time.deltaTime;

        // Si l'intervalle de tir est écoulé, tire un projectile
        if (timeSinceLastShot >= fireRate)
        {
            Shoot();
            timeSinceLastShot = 0f; // Réinitialise le temps
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null || firePoint == null)
        {
            Debug.LogError("ProjectilePrefab ou FirePoint non assigné dans l'inspecteur !");
            return;
        }

        // Instancie le projectile à la position et la rotation du point de tir
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Ajoute une force au projectile pour le faire bouger
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Désactive la gravité
            rb.useGravity = false;

            // Vérifie que le Rigidbody n'est pas en mode Kinematic
            if (rb.isKinematic)
            {
                rb.isKinematic = false;
            }

            // Applique une vitesse au projectile
            rb.velocity = firePoint.forward * projectileSpeed;

            // Lance une coroutine pour gérer la distance parcourue par le projectile
            StartCoroutine(DestroyProjectileAfterDistance(projectile, rb, maxDistance));
        }
        else
        {
            Debug.LogWarning("Le projectile doit avoir un Rigidbody pour appliquer une vitesse.");
        }
    }

    // Coroutine qui détruira le projectile après avoir parcouru la distance spécifiée
    private IEnumerator DestroyProjectileAfterDistance(GameObject projectile, Rigidbody rb, float distance)
    {
        float traveledDistance = 0f;
        Vector3 initialPosition = projectile.transform.position;

        // Calculer la distance parcourue
        while (traveledDistance < distance)
        {
            traveledDistance = Vector3.Distance(initialPosition, projectile.transform.position);
            yield return null; // Attendre jusqu'au prochain frame
        }

        // Détruire le projectile une fois la distance atteinte
        Destroy(projectile);
    }
}
