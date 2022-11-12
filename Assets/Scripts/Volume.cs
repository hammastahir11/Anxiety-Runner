using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{

    //[SerializeField] private Slider volumeSlider=null;
    public AudioSource audioSource;
    public float musicVolume=1f;
    private void Start() {
        audioSource.Play();
    }

    private void Update() {
        audioSource.volume=musicVolume;
    }
    public void VolumeSlider(float volume){
        musicVolume=volume;
         
    }
}
