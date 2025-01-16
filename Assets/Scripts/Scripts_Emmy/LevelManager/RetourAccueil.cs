using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetourAccueil : MonoBehaviour
{
    [SerializeField] private Button _retourAccueil;    // Bouton pour retourner à l'accueil

    private LevelManager _levelManager; // Référence au LevelManager (singleton)

    void Start()
    {
        // Initialisation du LevelManager
        _levelManager = LevelManager.Instance;

        // Vérification que le LevelManager est bien initialisé
        if (_levelManager == null)
        {
            Debug.LogError("LevelManager.Instance est introuvable. Assurez-vous qu'un LevelManager est présent dans la scène.");
            return;
        }

        // Ajout du listener au bouton
        if (_retourAccueil != null)
        {
            _retourAccueil.onClick.AddListener(RetournerAccueil); // Méthode pour retourner à l'accueil
        }
        else
        {
            Debug.LogError("Le bouton RetourAccueil n'est pas assigné dans l'Inspector.");
        }
    }

    // Retourne à la scène d'accueil
    private void RetournerAccueil()
    {
        if (_levelManager != null)
        {
            Debug.Log("Retour à l'écran d'accueil.");
            //_levelManager.RetourAccueil(); // Appelle la méthode RetourAccueil dans le LevelManager
        }
    }
}
