using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class GestionnaireMusique : MonoBehaviour
{

    // la musique
    [SerializeField] private AudioClip _musiqueJeu;

    // son objet qui la contient
    [SerializeField] private GameObject _contientMusique;

    // Audiosource qui permet à la musique de jouer dans la scène 
    private AudioSource _musique;


    // Start is called before the first frame update
    void Start()
    {
        _musique = _contientMusique.GetComponent<AudioSource>();
    }

   
}
