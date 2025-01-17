using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameReload : MonoBehaviour
{
    [SerializeField] private InfosJoueurs _infosJoueurs;
    private float _nbPoints;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       _infosJoueurs._nbPoints = 0;

        
    }
}
