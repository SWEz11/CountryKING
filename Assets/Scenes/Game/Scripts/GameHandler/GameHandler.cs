using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour
{
    [SerializeField] Player player;

    [Header("Money")]
    public TMP_Text moneyText;

    [Header("Panels")]
    public bool panelOpened;

    [Header("SoundsEffects")]
    public AudioSource backgroundMusic;

    [Header("Get Scripts / Objects")]
    [SerializeField] OptionsHandler optionsHandler;

    void Awake()
    {
        optionsHandler.GetBackgroundMusic();
        optionsHandler.GetMasterVolume();
    }

    void Update()
    {
        MoneyGenerator(player.generatorTime, player.moneyPerTime);
    }

    //Money

    public void UpdateMoney()
    {
        moneyText.text = player.moneyInt.ToString() + "$";
    }

    public void AddMoney(int moneyAmount)
    {
        player.moneyInt += moneyAmount;
        UpdateMoney();
    }

    public void RemoveMoney(int moneyAmount)
    {
        player.moneyInt -= moneyAmount;
        UpdateMoney();
    }

    //Money Generator
    void MoneyGenerator(float generatorTime, int moneyAmount)
    {
        player.timer += Time.deltaTime;
        if (player.timer > generatorTime)
        {
            AddMoney(moneyAmount);
            player.timer = 0;
        }
    }
    
}