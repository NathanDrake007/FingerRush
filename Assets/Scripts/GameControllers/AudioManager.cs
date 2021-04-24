using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    private float musicVolume = 1f;
    private void Update()
    {
        audioSource.volume = musicVolume; 
    }
    public void VolumeControl(float volume)
    {
        Debug.Log(volume);
        musicVolume = volume;
    }
}
