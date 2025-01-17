using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    [SerializeField] private InfosJeu _infosDuJeu;

    // Start is called before the first frame update
    void Start()
    {
        _infosDuJeu.init();
    }

   
}
