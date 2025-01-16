using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemeRamasseObjets : MonoBehaviour
{
    [SerializeField] private PvEtPowerUp _pvEtPowerUp;
    [SerializeField] private InfosJoueurs _infosJoueurs;
    [SerializeField] private GameObject _joueur; // Le joueur que l'objet va suivre
    [SerializeField] private int _nbPvBonus;
    [SerializeField] private float _cooldown = 5f; // Cooldown avant la destruction de l'objet

    private void Awake()
    {
        // Vérifie si le joueur est bien assigné
        if (!_joueur)
        {
            _joueur = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Assure-toi que c'est bien l'objet à ramasser qui entre en collision
        if (other.gameObject.CompareTag("StanleyCup"))
        {
            // On associe cet objet au joueur en tant que parent
            transform.SetParent(_joueur.transform);

            // Position relative par rapport au joueur
            float nouvelleHauteur = -0.1f;
            float distanceAvant = -0.2f; 
            float profondeur = 1.3f;
            
            // On définit la position locale pour que l'objet suive bien le joueur
            transform.localPosition = new Vector3(distanceAvant, nouvelleHauteur, profondeur);

            // Ajouter des PV bonus
            _infosJoueurs._bonusPv += _nbPvBonus;
            Debug.Log("PV ajoutés: " + _nbPvBonus);

            // Démarre la coroutine pour attendre avant de détruire l'objet
            StartCoroutine(AttendreEtDetruire(other.gameObject));
        }
    }

    // Coroutine pour attendre avant de détruire l'objet
    private IEnumerator AttendreEtDetruire(GameObject objet)
    {
        yield return new WaitForSeconds(_cooldown); // Attendre le cooldown
        Destroy(objet); // Détruire l'objet une fois le cooldown terminé
        Debug.Log("Objet détruit après le cooldown");
    }
}
