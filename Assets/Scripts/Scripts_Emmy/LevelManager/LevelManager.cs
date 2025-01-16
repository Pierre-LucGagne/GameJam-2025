using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private void Awake()
    {
        // Initialisation du singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Charge une scène de manière synchrone
    public void LoadScene(Scene sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }

    // Charge une scène de manière asynchrone sans loader canvas
    public async void LoadAsyncScene(string sceneName)
    {
        var sceneLoad = SceneManager.LoadSceneAsync(sceneName);
        sceneLoad.allowSceneActivation = false;

        // Attente de la fin du chargement avant d'activer la scène
        do
        {
            await Task.Delay(1000);
        } while (sceneLoad.progress < 0.9f);

        // Active la scène une fois prête
        sceneLoad.allowSceneActivation = true;
    }

    // Enumération des scènes disponibles
    public enum Scene
    {
        Accueil,         // Nom de la scène d'accueil
        JeuSceneTestBuild // Nom de la scène de jeu
    }

    // Méthode pour revenir à l'écran d'accueil
    public void RetourAccueil()
    {
        Debug.Log("Retour à la scène d'accueil.");
        LoadScene(Scene.Accueil);
    }

    // Méthode pour quitter l'application
    public void QuiteGame()
    {
        Debug.Log("Application quittée.");
        Application.Quit();
    }
}
