using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SaveSystem
{
    [SerializeField]

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

    public void LoadVolume(string prefsKey, Slider slider, AudioSource audioSource, int defaultValue)
    {
        slider.value = PlayerPrefs.GetFloat(prefsKey, defaultValue);
        audioSource.volume = slider.value;
    }

    public void LoadMixerVolume(string prefsKey, Slider slider, AudioMixer audioMixer, int defaultValue)
    {
        slider.value = PlayerPrefs.GetFloat("MainVolumeValue", defaultValue);
        float volume = slider.value;
        audioMixer.GetFloat(prefsKey, out volume);
    }

    //Money

    public void SaveMoney(int moneyAmount, string prefsKeyForMoney, float generatorTime, string prefsKeyForGenerator, int moneyPerTime, string prefsKeyForMoneyPerTime)
    {
        PlayerPrefs.SetInt(prefsKeyForMoney, moneyAmount);
        PlayerPrefs.SetFloat(prefsKeyForGenerator, generatorTime);
        PlayerPrefs.SetInt(prefsKeyForMoneyPerTime, moneyPerTime);
        Debug.Log("Saved " + moneyAmount + " " + generatorTime + " " + moneyPerTime);
    }

    public void LoadMoney(ref int moneyAmount, string prefsKeyForMoney, TMP_Text moneyText, ref float generatorTime, string prefsKeyForGenerator, ref int moneyPerTime, string prefsKeyForMoneyPerTime)
    {
        moneyAmount = PlayerPrefs.GetInt(prefsKeyForMoney, 0);
        moneyText.text = moneyAmount.ToString() + "$";
        generatorTime = PlayerPrefs.GetFloat(prefsKeyForGenerator, 6.0f);
        moneyPerTime = PlayerPrefs.GetInt(prefsKeyForMoneyPerTime, 1);
        Debug.Log("Loaded " + moneyAmount + " " + generatorTime + " " + moneyPerTime);
    }

    //Storage


    
}
