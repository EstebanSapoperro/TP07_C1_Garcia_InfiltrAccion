using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSliderSetting : MonoBehaviour
{
    [SerializeField] Slider generalAudioSlider;
    [SerializeField] Slider uIAudioSlider;
    [SerializeField] Slider sFXAudioSlider;
    [SerializeField] Slider musicAudioSlider;
    [SerializeField] AudioMixer mixerSelected;
    [SerializeField] AudioSource sliderSound;
    [SerializeField] AudioClip soundEffect;

    private void Awake()
    {
        generalAudioSlider.onValueChanged.AddListener(OnGeneralChangeValue);
        uIAudioSlider.onValueChanged.AddListener(OnuIChangeValue);
        sFXAudioSlider.onValueChanged.AddListener(OnsFXChangeValue);
        musicAudioSlider.onValueChanged.AddListener(OnMusicChangeValue);
    }
    private void OnDestroy()
    {
        generalAudioSlider.onValueChanged.RemoveAllListeners();
        uIAudioSlider.onValueChanged.RemoveAllListeners();
        sFXAudioSlider.onValueChanged.RemoveAllListeners();
        musicAudioSlider.onValueChanged.RemoveAllListeners();
    }

    private void OnGeneralChangeValue(float value)
    {
        ChangeSoundValue("GenerealAudio", value);
    }
    private void OnuIChangeValue(float value)
    {
        ChangeSoundValue("UIAudio", value);
    }
    private void OnsFXChangeValue(float value)
    {
        ChangeSoundValue("SFXAudio", value);
    }
    private void OnMusicChangeValue(float value) 
    {
        ChangeSoundValue("MusicAudio",value);

    }


    private void ChangeSoundValue(string sound, float value) 
    {
        float finalSound = Mathf.Clamp(Mathf.Log10(value) * 35, -80, 0);
        mixerSelected.SetFloat(sound, finalSound);

        sliderSound.PlayOneShot(soundEffect);
    }
}
