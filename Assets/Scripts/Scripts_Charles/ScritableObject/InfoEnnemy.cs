using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="SO/InfoEnnemis")]
public class InfoEnnemis : ScriptableObject
{
    public float pointDeVie;

    public float pointDeVieMax;
    public int degat;
    public int TypeAttaque;
    public AudioClip prendDesDegatsSon;
    public AudioClip mortSon;
}
