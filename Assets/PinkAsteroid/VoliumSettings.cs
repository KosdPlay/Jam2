using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VoliumSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider Slider;



    private void Start()
    {
        SetMusicVolum();
    }
    public void SetMusicVolum()
    {
        float volum = Slider.value;
        myMixer.SetFloat("Volume", Mathf.Log10(volum)*20);

    }
}
