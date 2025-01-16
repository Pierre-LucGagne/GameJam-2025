using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireArme : MonoBehaviour
{
    [Header("Paramètres de l'arme")]
    [SerializeField] private GameObject projectilePrefab; // Le projectile à tirer
    [SerializeField] private Transform firePoint; // Le point de tir (où les projectiles apparaissent)
    [SerializeField] private Vector3 positionOffset; // Décalage de la position du point de tir
    [SerializeField] private float projectileSpeed = 10f; // Vitesse du projectile
    [SerializeField] private float maxDistance = 20f; // Distance maximale que le projectile peut parcourir
    [SerializeField] private float fireCooldown = 0.5f; // Temps de recharge entre chaque tir (en secondes)

    private float timeSinceLastShot = 0f; // Temps écoulé depuis le dernier tir

    void Update()
    {
        // Mise à jour du temps depuis le dernier tir
        timeSinceLastShot += Time.deltaTime;

        // Vérifie si le bouton gauche de la souris (clic) est enfoncé et si le délai de tir est écoulé
        if (Input.GetMouseButtonDown(0) && timeSinceLastShot >= fireCooldown)
        {
            Shoot();
            timeSinceLastShot = 0f; // Réinitialiser le temps après un tir
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null || firePoint == null)
        {
            Debug.LogError("ProjectilePrefab ou FirePoint non assigné dans l'inspecteur !");
            return;
        }

        // Calculer la position décalée du firePoint
        Vector3 shootPosition = firePoint.position + positionOffset;

        // Instancie le projectile à la position décalée et la rotation du point de tir
        GameObject projectile = Instantiate(projectilePrefab, shootPosition, firePoint.rotation);

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
