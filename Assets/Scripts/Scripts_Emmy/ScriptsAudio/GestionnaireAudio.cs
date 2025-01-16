using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GestionnaireAudio : MonoBehaviour
{
   [SerializeField] private AudioMixer audioMixer;
  private LevelManager _levelManager;
 void Start()
    {
        _levelManager = LevelManager.Instance;
        
    }
//         public void DebutGame(){
         
//         _levelManager.LoadAsyncScene("SceneSallePrincipale");
      
//     }
// Pour lier les diffrents paramètres de l'audiomixer pour pouvoir ajuster les volumes des différents effets


    public void MasterVolumeChange(Slider slider)
    {
        float value = slider.value * 80;
        audioMixer.SetFloat("MasterVolume", value -80);
    }

    public void MusicVolumeChange(Slider slider)
    {
        float value = slider.value * 80;
        audioMixer.SetFloat("MusicVolume", value -80);
    }

    public void SFXVolumeChange(Slider slider)
    {
        float value = slider.value * 80;
        audioMixer.SetFloat("SFXVolume", value -80);
    }

// public void AjusteVolumeMusique(float value){
//         audioMixer.SetFloat("VolumeMusique" , value);
// }

// public void AjusteVolume3D(float value){
//         audioMixer.SetFloat("Volume3D" , value);
// }

// public void AjusteVolume2D(float value){
//         audioMixer.SetFloat("Volume2D" , value);
// }

// public void AjusteVolumeAmbiance(float value){
//         audioMixer.SetFloat("VolumeAmbiance" , value);
// }
 public void QuiteGame()
    {
        Debug.Log($"fonctionne");
        Application.Quit();
    }

}

