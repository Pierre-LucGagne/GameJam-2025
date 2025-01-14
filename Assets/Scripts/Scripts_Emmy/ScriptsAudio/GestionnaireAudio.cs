using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GestionnaireAudio : MonoBehaviour
{
   [SerializeField] private AudioMixer audioMixer;
   [SerializeField]   

// Pour lier les diffrents paramètres de l'audiomixer pour pouvoir ajuster les volumes des différents effets
public void AjusteVolumeMusique(float value){
        audioMixer.SetFloat("VolumeMusique" , value);
}

public void AjusteVolume3D(float value){
        audioMixer.SetFloat("Volume3D" , value);
}

public void AjusteVolume2D(float value){
        audioMixer.SetFloat("Volume2D" , value);
}

public void AjusteVolumeAmbiance(float value){
        audioMixer.SetFloat("VolumeAmbiance" , value);
}

}
