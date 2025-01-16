using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchatArme : MonoBehaviour
{
    [Header("Armes équipées dans les mains du joueur")]
    [SerializeField] private GameObject astrofuseurActif; // Arme Astrofuseur équipée
    [SerializeField] private GameObject sextantActif;    // Arme Sextant équipée

    [Header("Données du joueur")]
    [SerializeField] private ListeArmes listeArmes;      // Gestion des armes achetées
    [SerializeField] private InfosJoueurs infosJoueurs;  // Points et autres informations du joueur

    [Header("UI - Gestion des achats")]
    [SerializeField] private Button boutonAstrofuseur;   // Bouton pour acheter/équiper l'Astrofuseur
    [SerializeField] private Button boutonSextant;       // Bouton pour acheter/équiper le Sextant
    [SerializeField] private RawImage rawImageArmeCanvas; // RawImage représentant l'arme actuelle dans le canvas
    [SerializeField] private RawImage astrofuseurImage;   // RawImage pour afficher l'Astrofuseur dans le Canvas
    [SerializeField] private RawImage sextantImage;       // RawImage pour afficher le Sextant dans le Canvas

    [Header("Messages et prix")]
    [SerializeField] private TextMeshProUGUI messagePoints; // Message pour notifier le joueur
    [SerializeField] private int prixSextant = 500;         // Prix du Sextant en points

    private bool isAstrofuseurAchete = false;
    private bool isSextantAchete = false;

    private void Start()
    {
        // Initialisation des boutons et des messages
        messagePoints.gameObject.SetActive(false);
        boutonSextant.interactable = false; // Désactiver l'achat du Sextant au départ

        // Désactiver les armes au début
        astrofuseurActif.SetActive(false);
        sextantActif.SetActive(false);

        // Ajouter des listeners aux boutons
        if (boutonAstrofuseur != null)
            boutonAstrofuseur.onClick.AddListener(AcheterAstrofuseur);
           
        if (boutonSextant != null)
            boutonSextant.onClick.AddListener(AcheterSextant);
             
    }

    private void Update()
    {
        // Afficher un message et activer le bouton du Sextant si le joueur a assez de points
        if (infosJoueurs._nbPoints >= prixSextant && !boutonSextant.interactable)
        {
            messagePoints.text = "Vous avez atteint 500 points ! Débloquez de nouvelles armes dans le shop.";
            messagePoints.gameObject.SetActive(true);
            boutonSextant.interactable = true;
        }
    }

    private void AcheterAstrofuseur()
    {
        if (!isAstrofuseurAchete)
        {
            isAstrofuseurAchete = true;

            // Mettre à jour le RawImage pour afficher l'Astrofuseur dans le canvas
            Debug.Log("Astrofuseur acheté, changement de texture dans le Canvas");
            rawImageArmeCanvas.texture = astrofuseurImage.texture;

            // Activer l'Astrofuseur dans les mains du joueur et désactiver le Sextant
            astrofuseurActif.SetActive(true);
            sextantActif.SetActive(false);

            // Marquer l'arme comme achetée
            if (listeArmes != null)
                listeArmes.ArmeAcheter("Astrofuseur");
        }
    }

    public void AcheterSextant()
    {
        if (!isSextantAchete && infosJoueurs._nbPoints >= prixSextant)
        {
            isSextantAchete = true;

            // Réduire les points du joueur
            infosJoueurs._nbPoints -= prixSextant;
            Debug.Log("prix soustrait");

            // Mettre à jour le RawImage pour afficher le Sextant dans le canvas
            Debug.Log("Sextant acheté, changement de texture dans le Canvas");
            rawImageArmeCanvas.texture = sextantImage.texture;

            // Activer le Sextant dans les mains du joueur et désactiver l'Astrofuseur
            sextantActif.SetActive(true);
            astrofuseurActif.SetActive(false);

            // Marquer l'arme comme achetée
            if (listeArmes != null)
                listeArmes.ArmeAcheter("Sextant");
        }
        else if (infosJoueurs._nbPoints < prixSextant)
        {
            Debug.LogWarning("Points insuffisants pour acheter le Sextant !");
        }
    }
}
