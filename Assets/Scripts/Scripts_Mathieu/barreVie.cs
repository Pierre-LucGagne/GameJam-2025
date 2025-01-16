using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barreVie : MonoBehaviour
{
    public float vie;
    public float vieMax;
    public Image barreDeVie;
    // Start is called before the first frame update
    void Start()
    {
        vieMax = vie;
    }

    // Update is called once per frame
    void Update()
    {
     barreDeVie.fillAmount = Mathf.Clamp(vie / vieMax, 0, 1);
    }
}
