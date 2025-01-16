using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ShootSextan : MonoBehaviour
{
    [Header("Paramètres de l'arme")]
    [SerializeField] private GameObject sextantPrefab; // Le prefab du sextant
    [SerializeField] private Transform handPosition; // Position où le sextant est dans la main

    private GameObject sextantInHand; // Le sextant actuellement dans la main du joueur

    void Start()
    {
        //SpawnSextantInHand();
    }

    void Update()
    {
        // Vérifie si le joueur appuie sur le clic gauche
        if (Input.GetMouseButtonDown(0) && sextantInHand != null)
        {
            DestroySextant();
        }
    }

    // Fonction pour détruire l'objet sextant dans la main du joueur
    void DestroySextant()
    {
        // Détruire l'objet actuellement dans la main du joueur
        sextantPrefab.SetActive(false);

        // Optionnel : Afficher un message dans la console pour signaler que l'objet est détruit
        Debug.Log("Sextant détruit !");
    }

    // Fonction pour instancier un sextant dans la main du joueur
    private void SpawnSextantInHand()
    {
        if (sextantPrefab != null && handPosition != null)
        {
            // Instancie un sextant dans la main du joueur
            sextantInHand = Instantiate(sextantPrefab, handPosition.position, handPosition.rotation);
            sextantInHand.transform.SetParent(handPosition); // Attache le sextant à la main
        }
        else
        {
            Debug.LogError("SextantPrefab ou HandPosition non assigné dans l'inspecteur !");
        }
    }
}
