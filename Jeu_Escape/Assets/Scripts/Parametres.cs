using UnityEngine;
using UnityEngine.Audio;

public class Parametres : MonoBehaviour
{
    public static Parametres instance;
    public AudioMixer audioMixer;
    public static float volume;
    public static float son; 

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("VolumeJoueur",volume);
        AudioListener.volume = PlayerPrefs.GetFloat("volumeJoueur");
    }

    public void SetSon(float son)
    {
        PlayerPrefs.SetFloat("VolumeSonJoueur",son);
        //AudioListener."son" = PlayerPrefs.GetFloat("VolumeSonJoueur");
    }
}
