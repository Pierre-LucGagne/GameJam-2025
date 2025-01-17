using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationShootScript : MonoBehaviour
{
    [Header("Paramètres du joueur")]
    public Transform player; // Référence au Transform du joueur

    [Header("Paramètres de l'ennemi")]
    public float shootingRange = 20f; // Distance maximale pour tirer

    [Header("Composant Arme")]
    public TireArme arme; // Référence au script TireArme attaché à l'ennemi

    void Start()
    {
        // Vérification des assignations
        if (player == null)
        {
            Debug.LogError("Le Transform du joueur n'est pas assigné !");
            enabled = false;
            return;
        }

        if (arme == null)
        {
            Debug.LogError("Le script TireArme n'est pas assigné !");
            enabled = false;
            return;
        }
    }

    void Update()
    {
        if (player == null || arme == null) return;

        // Calcul de la distance entre l'ennemi et le joueur
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si le joueur est à portée
        if (distanceToPlayer <= shootingRange)
        {
            // Vérifie si l'arme peut tirer
            arme.Tirer();
        }
    }
}
