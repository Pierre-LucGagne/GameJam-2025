using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="InfosArmes", menuName ="SO/Armes")]

public class Armes : ScriptableObject
{
    [SerializeField] public string _nomArme;
    [SerializeField] public float _prixArme;
    [SerializeField] public bool acheter;
}

