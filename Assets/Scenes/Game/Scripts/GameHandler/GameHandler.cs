using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{

    [Header("Game Handler")]

    [Header("Money Generator")]
    public float moneyGeneratorTime;
    public int moneyPerTime;
    public float timer = 0.0f;

    [Header("Money")]
    [SerializeField] TMP_Text moneyText;
    public int moneyInt;

    [Header("Panels")]
    public bool panelOpened;

    [Header("SoundsEffects")]
    public AudioSource backgroundMusic;
    public AudioMixer mainVolumeMixer;

    [Header("Get Scripts / Objects")]
    [SerializeField] OptionsHandler optionsHandler;
    [SerializeField] StorageHandler storageHandler;
    SaveSystem saveSystem = new SaveSystem();

    [Header("ResetGame")]
    [SerializeField] GameObject warningPanel;

    void Awake()
    {
        //Volumes
        optionsHandler.GetBackgroundMusic();
        optionsHandler.GetMasterVolume();

        //Money
        saveSystem.LoadMoney(ref moneyInt, "MoneyAmount", moneyText, ref moneyGeneratorTime, "MoneyGeneratorTime", ref moneyPerTime, "MoneyPerTime");

        //Storage
        storageHandler.LoadStorage();
    }

    void Update()
    {
        MoneyGenerator(moneyGeneratorTime, moneyPerTime);
    }

    //Money

    public void UpdateMoney()
    {
        moneyText.text = moneyInt.ToString() + "$";
        saveSystem.SaveMoney(moneyInt, "MoneyAmount", moneyGeneratorTime, "MoneyGeneratorTime");
    }

    public void AddMoney(int moneyAmount)
    {
        moneyInt += moneyAmount;
        UpdateMoney();
    }

    public void RemoveMoney(int moneyAmount)
    {
        moneyInt -= moneyAmount;
        UpdateMoney();
    }

    //Money Generator
    void MoneyGenerator(float generatorTime, int moneyAmount)
    {
        timer += Time.deltaTime;
        if (timer > generatorTime)
        {
            AddMoney(moneyAmount);
            timer = 0;
            Debug.Log("Passed");
        }
    }

    //Quit

    void OnApplicationQuit()
    {
        saveSystem.SaveMoney(moneyInt, "MoneyAmount", moneyGeneratorTime, "MoneyGeneratorTime");
        storageHandler.LoadStorage();
    }

    //Reset game

    //Warning
    public void Warning()
    {
        warningPanel.SetActive(true);
        optionsHandler.closeButton.interactable = false;
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Game");
    }

    public void CancelGameReseting()
    {
        warningPanel.SetActive(false);
        optionsHandler.closeButton.interactable = true;
    }
}