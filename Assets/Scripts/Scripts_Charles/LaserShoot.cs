using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserShoot : MonoBehaviour
{
     [Header("Paramètres de l'arme")]
    [SerializeField] private GameObject projectilePrefab; // Le projectile à tirer
    [SerializeField] private Transform firePoint; // Le point de tir (où les projectiles apparaissent)
    [SerializeField] private Vector3 positionOffset; // Décalage de la position du point de tir
    [SerializeField] private float projectileSpeed = 10f; // Vitesse du projectile
    [SerializeField] private float maxDistance = 20f; // Distance maximale que le projectile peut parcourir
    [SerializeField] private float fireCooldown = 0.5f; // Temps de recharge entre chaque tir (en secondes)

    public UnityEvent jouerSon; // Événement Unity pour jouer le son

    private bool isFiring = false; // Indique si le joueur maintient le clic enfoncé
    private Coroutine shootingCoroutine; // Référence à la coroutine de tir

    void Update()
    {
        // Vérifie si le clic gauche est enfoncé
        if (Input.GetMouseButtonDown(0) && !isFiring)
        {
            isFiring = true;
            shootingCoroutine = StartCoroutine(ShootingCoroutine());
        }

        // Vérifie si le clic gauche est relâché
        if (Input.GetMouseButtonUp(0) && isFiring)
        {
            isFiring = false;
            if (shootingCoroutine != null)
            {
                StopCoroutine(shootingCoroutine);
            }
        }
    }

    private IEnumerator ShootingCoroutine()
    {
        while (isFiring)
        {
            Shoot();
            yield return new WaitForSeconds(fireCooldown); // Attend le délai entre chaque tir
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

        // Créer le projectile
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

        // Joue le son
        jouerSon.Invoke();
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
