using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SaveSystem", menuName = "Scriptable Objects/SaveSystemSO")]
public class SaveSystem : ScriptableObject
{

    //Volume

    public void SaveVolume(Slider slider, AudioSource audioSource, string prefsKey)
    {
        audioSource.volume = slider.value;
        PlayerPrefs.SetFloat(prefsKey, slider.value);
    }

    public void SaveMixerVolume(Slider slider, AudioMixer audioMixer, string prefsKey)
    {
        PlayerPrefs.SetFloat("MainVolumeValue", slider.value);
        audioMixer.SetFloat(prefsKey, slider.value);
    }

    public void LoadVolume(string prefsKey, Slider slider, AudioSource audioSource)
    {
        if (PlayerPrefs.HasKey(prefsKey))
        {
            slider.value = PlayerPrefs.GetFloat(prefsKey);
            audioSource.volume = slider.value;
        }
    }

    public void LoadMixerVolume(string prefsKey, Slider slider, AudioMixer audioMixer)
    {
        if (PlayerPrefs.HasKey(prefsKey))
        {
            slider.value = PlayerPrefs.GetFloat("MainVolumeValue");
            float volume = slider.value;
            audioMixer.GetFloat(prefsKey, out volume);
        }
        else
        {
            float value = slider.value = 1;
            float volume = value;
            audioMixer.GetFloat(prefsKey, out volume);
        }
    }
}
