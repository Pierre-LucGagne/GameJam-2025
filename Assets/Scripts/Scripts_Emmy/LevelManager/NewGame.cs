using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    [SerializeField] private InfosJeu _infosDuJeu;

    // Start is called before the first frame update
    public void NewGameStart()
    {
        _infosDuJeu.init();
        Debug.Log("Jeu recommence");
    }

   
}
