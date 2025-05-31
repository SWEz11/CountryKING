using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;
public class SaveSystem
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
        PlayerPrefs.Save();
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

    public void SaveMoney(int moneyAmount, string prefsKeyForMoney, float generatorTime, string prefsKeyForGenerator)
    {
        PlayerPrefs.SetInt(prefsKeyForMoney, moneyAmount);
        PlayerPrefs.SetFloat(prefsKeyForGenerator, generatorTime);
        //Debug.Log("Loaded Money " + moneyAmount + " " + generatorTime + " " + moneyPerTime);
    }

    public void LoadMoney(ref int moneyAmount, string prefsKeyForMoney, TMP_Text moneyText, ref float generatorTime, string prefsKeyForGenerator, ref int moneyPerTime, string prefsKeyForMoneyPerTime)
    {
        moneyAmount = PlayerPrefs.GetInt(prefsKeyForMoney, 0);
        moneyText.text = moneyAmount.ToString() + "$";
        generatorTime = PlayerPrefs.GetFloat(prefsKeyForGenerator, 6.0f);
        moneyPerTime = PlayerPrefs.GetInt(prefsKeyForMoneyPerTime, 1);
        //Debug.Log("Loaded Money" + moneyAmount + " " + generatorTime + " " + moneyPerTime);
    }

    //Storage


    public void SaveStorage(string prefsKey, int count)
    {
        PlayerPrefs.SetInt(prefsKey, count);
    }

    public void LoadStorage(string prefsKey, ref int count, TMP_Text countText, string text, int defaultValue)
    {
        count = PlayerPrefs.GetInt(prefsKey, defaultValue);
        countText.text = text + count.ToString();
    }

    //Market
    public void SaveMarket(string prefsKey, int value, bool canPress, Button button)
    {
        PlayerPrefs.SetInt(prefsKey, value);
        button.interactable = canPress;
    }

    public void LoadMarket(string prefsKey, int value, Button button)
    {
        value = PlayerPrefs.GetInt(prefsKey, 1);
        if (value == 1)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }

    //CountryInfo
    public void SaveInfo(string prefsKey, int isOcupied)
    {
        PlayerPrefs.SetInt(prefsKey, isOcupied);
    }

    public void LoadInfo(string prefsKey, int isOcupied, TMP_Text ocupiedText, Button button)
    {
        isOcupied = PlayerPrefs.GetInt(prefsKey, 0);
        if (isOcupied == 1)
        {
            ocupiedText.text = "Ocupied";
            button.interactable = false;
        }
        else
        {
            ocupiedText.text = "No Ocupied";
            button.interactable = true;
        }
    }

    //BattleInfo
}
