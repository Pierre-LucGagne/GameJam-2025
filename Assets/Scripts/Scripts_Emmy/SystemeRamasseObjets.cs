using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SystemeRamasseObjets : MonoBehaviour
{
    // [SerializeField] private PvEtPowerUp _pvEtPowerUp;
    [SerializeField] private InfosJoueurs _infosJoueurs;
    [SerializeField] private GameObject _falseCup;
    [SerializeField] private int _nbPvBonus;
    [SerializeField] private TextMeshProUGUI _texteBonus;

    [SerializeField] private float _cooldown = 5f; // Cooldown avant de cacher les effets
    [SerializeField] private float _spawnInterval = 3f; // Intervalle entre chaque spawn d'une StanleyCup
    [SerializeField] private GameObject _stanleyCupPrefab; // Préfabriqué de la StanleyCup
    [SerializeField] private Transform[] _spawnPoints; // Points où les StanleyCups apparaîtront (peut être vide ou configuré dans l'inspecteur)

    private void Start()
    {
        // Cache l'écran de bonus et les objets au départ
        _texteBonus.gameObject.SetActive(false); // Active ou désactive l'objet parent contenant le TextMeshProUGUI
        _falseCup.SetActive(false);

        // Lance le spawn des StanleyCups après un certain délai
        StartCoroutine(SpawnStanleyCups());
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet en collision est bien une StanleyCup
        if (other.gameObject.CompareTag("StanleyCup"))
        {
          
            
           _texteBonus.gameObject.SetActive(true);
       _falseCup.SetActive(true);

            // Ajoute les points de vie bonus au joueur
            _infosJoueurs._bonusPv += _nbPvBonus;

            // Détruit l'objet StanleyCup collecté
            Destroy(other.gameObject);

            // Lance la coroutine pour cacher les effets après un délai
            StartCoroutine(AttendreEtDetruireEffets());
        }
    }

    private IEnumerator AttendreEtDetruireEffets()
    {
        // Attendre la durée du cooldown avant de masquer les objets visuels
        yield return new WaitForSeconds(_cooldown);

        // Cache les effets visuels et le texte
        _falseCup.SetActive(false);
        _texteBonus.gameObject.SetActive(false); // Désactive l'objet contenant le TextMeshProUGUI
    }

    // Coroutine pour spawn des StanleyCups à intervalles réguliers
    private IEnumerator SpawnStanleyCups()
    {
        while (true)
        {
            // Si des points de spawn sont définis, choisis un point au hasard
            if (_spawnPoints.Length > 0)
            {
                Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
                Instantiate(_stanleyCupPrefab, spawnPoint.position, Quaternion.identity);
            }
            else
            {
                // Si aucun point de spawn n'est défini, spawn l'objet à une position aléatoire dans la scène
                Vector3 randomPosition = new Vector3(
                    Random.Range(-10f, 10f), // Coordonnée X aléatoire
                    1f, // Hauteur fixe de spawn
                    Random.Range(-10f, 10f) // Coordonnée Z aléatoire
                );
                Instantiate(_stanleyCupPrefab, randomPosition, Quaternion.identity);
            }

            // Attendre avant de spawn un autre objet
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}
