using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject panelPause;
    public Slider volumeSlider; 
    private AudioSource gameAudio; 
    public Button pauseOpen;

    void Start()
    {
        panelPause.SetActive(false);

        gameAudio = Object.FindFirstObjectByType<AudioSource>();

        if (gameAudio != null && volumeSlider != null)
        {
            volumeSlider.value = gameAudio.volume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        if (pauseOpen != null)
        {
            pauseOpen.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        
    }

    public void PauseFunction()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0;

        if (pauseOpen != null)
        {
            pauseOpen.gameObject.SetActive(false);
        }
    }

    public void BackFunction()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1;

        if (pauseOpen != null)
        {
            pauseOpen.gameObject.SetActive(true);
        }
    }

    private void SetVolume(float volume)
    {
        if (gameAudio != null)
        {
            gameAudio.volume = volume; 
        }
    }
}
