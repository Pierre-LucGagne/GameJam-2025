using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawn : MonoBehaviour
{

    [Header("Paramètres des Ennemis")]
    public GameObject ennemi1; // Type d'ennemi 1
    public GameObject ennemi2; // Type d'ennemi 2

    [Header("Paramètres des Vagues")]
    public float initialSpawnInterval = 5f; // Intervalle de la première vague
    public float reducedSpawnInterval = 3f; // Intervalle de la deuxième vague
    public float finalSpawnInterval = 1f; // Intervalle de la troisième vague
    public float intervalChangeTime1 = 40f; // Temps de transition à la deuxième vague
    public float intervalChangeTime2 = 80f; // Temps de transition à la troisième vague

    private float spawnInterval;
    private float timeSinceLastSpawn = 0f;
    private float elapsedTime = 0f;

    private Collider spawnZone;

    void Start()
    {
        spawnZone = GetComponent<Collider>(); 

        if (spawnZone == null)
        {
            Debug.LogError("Aucun collider trouvé sur cet objet.");
            enabled = false;
            return;
        }

        if (!spawnZone.isTrigger)
        {
            Debug.LogError("Le collider de cet objet doit être configuré comme un trigger.");
            enabled = false;
            return;
        }

        if (ennemi1 == null || ennemi2 == null)
        {
            Debug.LogError("Les GameObjects ennemi1 et ennemi2 doivent être assignés dans l'inspecteur.");
            enabled = false;
            return;
        }

        spawnInterval = initialSpawnInterval;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        timeSinceLastSpawn += Time.deltaTime;

        // Ajustement de l'intervalle en fonction du temps
        if (elapsedTime >= intervalChangeTime2)
        {
            spawnInterval = finalSpawnInterval; // Troisième vague
        }
        else if (elapsedTime >= intervalChangeTime1)
        {
            spawnInterval = reducedSpawnInterval; // Deuxième vague
        }

        // Vérifie si un ennemi doit être spawn
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Sélectionne un type d'ennemi aléatoire
        GameObject selectedEnemy = Random.Range(0, 2) == 0 ? ennemi1 : ennemi2;

        // Génère une position aléatoire dans la zone de spawn
        Vector3 spawnPosition = GetRandomPointInCollider(spawnZone);

        // Instancie l'ennemi
        Instantiate(selectedEnemy, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        // Obtenez les limites du collider
        Bounds bounds = collider.bounds;

        // Génère une position aléatoire à l'intérieur des limites
        Vector3 randomPosition = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );

        // Vérifie si la position est à l'intérieur du collider
        if (collider.ClosestPoint(randomPosition) == randomPosition)
        {
            return randomPosition;
        }

        // Si la position générée est à l'extérieur, recommence
        return GetRandomPointInCollider(collider);
    }

    // Dessine la zone de spawn dans la vue de l'éditeur
    private void OnDrawGizmosSelected()
    {
        if (spawnZone != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(spawnZone.bounds.center, spawnZone.bounds.size);
        }
    }
}
