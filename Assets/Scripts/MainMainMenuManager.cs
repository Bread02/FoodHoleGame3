using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMainMenuManager : MonoBehaviour
{
    public bool audioToggled;
    public AudioMixer audioMixer;

    public GameObject audioOn;
    public GameObject audioOff;

    [SerializeField] private AudioClip soundOnSFX;


    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60;
        audioToggled = true;
        audioOn.SetActive(true);
        audioOff.SetActive(false);
        audioMixer.SetFloat("Master", -10);

        if (!Application.isMobilePlatform)
        {
            Screen.fullScreen = false;
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void AudioToggleOn()
    {
        audioMixer.SetFloat("Master", -10);
        audioToggled = true;
        audioOff.SetActive(false);
        audioOn.SetActive(true);
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = soundOnSFX;
        audio.Play();
    }

    public void AudioToggleOff()
    {
        audioMixer.SetFloat("Master", -80);
        audioOff.SetActive(true);
        audioToggled = false;

        audioOn.SetActive(false);
    }
}
