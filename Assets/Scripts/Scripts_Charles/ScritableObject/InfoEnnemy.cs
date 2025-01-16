using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="SO/InfoEnnemis")]
public class InfoEnnemis : ScriptableObject
{
    public int pointDeVie;
    public int degat;
    public int TypeAttaque;
    public AudioClip prendDesDegatsSon;
    public AudioClip mortSon;
}
