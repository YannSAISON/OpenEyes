using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderSoundPanel : MonoBehaviour {
    public AudioMixer audioMixer;
    public Text legendText;
    public Slider slider;
    public AudioMixerSliderEnum volumeToChange;
    private float m_Volume;


    public void Awake() {
        legendText.name = "Label_" + volumeToChange.ToString();
        legendText.text = volumeToChange.ToString(); 
        slider.name = "Slider_" + volumeToChange.ToString();
        audioMixer.GetFloat(volumeToChange.ToString(), out m_Volume);
        slider.value = (float) Math.Pow(10, m_Volume / 20);
    }

    public void SetVolume() {
        m_Volume = (float) Math.Log10(slider.value) * 20.0f;
        audioMixer.SetFloat(volumeToChange.ToString(), m_Volume);
    }
}
