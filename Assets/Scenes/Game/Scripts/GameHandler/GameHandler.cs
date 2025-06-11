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
    [SerializeField] AudioSource warInProgressSoundsEffect;

    [Header("Get Scripts / Objects")]
    [SerializeField] OptionsHandler optionsHandler;
    [SerializeField] StorageHandler storageHandler;
    [SerializeField] MarketHandler marketSellingHandler;
    [SerializeField] Vostrelia vostreliaInfo;
    [SerializeField] Kalesia kalesiaInfo;
    SaveSystem saveSystem = new SaveSystem();

    [Header("ResetGame")]
    [SerializeField] GameObject warningPanel;

    [Header("Battle InProgress")]
    [SerializeField] GameObject battleInProgressPanel;
    public bool inWar;

    public bool canBattle;

    public float battlingTime;
    float battleTimer = 0.0f;

    [Header("Battle WIN")]
    [SerializeField] GameObject countryWinPanel;
    [SerializeField] TMP_Text countryWinIncreaseArmy;
    [SerializeField] TMP_Text countryWinIncreasePistol;

    [Header("Battle LOST")]
    [SerializeField] GameObject countryLostPanel;
    [SerializeField] TMP_Text countryLostDecreaseArmy;
    [SerializeField] TMP_Text countryLostDecreasePistol;

    void Awake()
    {
        //Volumes
        optionsHandler.GetBackgroundMusic();
        optionsHandler.GetMasterVolume();

        //Money
        saveSystem.LoadMoney(ref moneyInt, "MoneyAmount", moneyText, ref moneyGeneratorTime, "MoneyGeneratorTime", ref moneyPerTime, "MoneyPerTime");

        //Storage
        storageHandler.LoadStorage();

        //Market
        marketSellingHandler.LoadGasButton();
        marketSellingHandler.GasCost(5, 15);
    }

    void Update()
    {
        MoneyGenerator(moneyGeneratorTime, moneyPerTime);

        //Battle Vostrelia
        vostreliaInfo.Battle();

        //Battle Kalesia
        kalesiaInfo.Battle();
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


    //Battle

    public void Battle(int armyCount, int pistolCount, int isOcupied, GameObject panel, string prefsKeyForOcupied)
    {
        if (inWar)
        {
            panel.SetActive(false);
            battleInProgressPanel.SetActive(true);
            backgroundMusic.Stop();
            warInProgressSoundsEffect.Play();
            battleTimer += Time.deltaTime;
            //Debug.Log(timer + " " + battlingTime);
            if (Mathf.RoundToInt(battleTimer) >= battlingTime)
            {
                //Debug.Log("Timer end");
                int playerWin = Random.Range(0, 2);
                //Debug.Log("Win? " + playerWin);
                if (playerWin == 1)
                {
                    battleInProgressPanel.SetActive(false);
                    isOcupied = 1;
                    int increasedArmyCount = Random.Range(1, 10);
                    countryWinPanel.SetActive(true);
                    storageHandler.IncreaseArmyCount(increasedArmyCount);
                    countryWinIncreaseArmy.text = "You increased your army count by: " + increasedArmyCount.ToString();
                    int increasedPistolCount = Random.Range(1, 8);
                    storageHandler.IncreaseArmyCount(increasedPistolCount);
                    countryWinIncreasePistol.text = "You increased your pistol count by: " + increasedPistolCount.ToString();
                    saveSystem.SaveInfo(prefsKeyForOcupied, isOcupied);
                    battleTimer = 0;
                    //panelOpened = false;
                    inWar = false;
                    warInProgressSoundsEffect.Stop();
                    backgroundMusic.Play();
                }
                else
                {
                    battleInProgressPanel.SetActive(false);
                    countryLostPanel.SetActive(true);
                    countryLostDecreaseArmy.text = "You decreased your army count by: " + armyCount.ToString();
                    countryLostDecreasePistol.text = "You decreased your pistol count by: " + pistolCount.ToString();
                    isOcupied = 0;
                    storageHandler.DecreaseArmyCount(armyCount);
                    storageHandler.DecreasePistolCount(pistolCount);
                    if (storageHandler.armyCount <= 0)
                    {
                        storageHandler.armyCount = 1;
                    }
                    if (storageHandler.pistolCount <= 0)
                    {
                        storageHandler.pistolCount = 1;
                    }
                    saveSystem.SaveInfo(prefsKeyForOcupied, isOcupied);
                    battleTimer = 0.0f;
                    panelOpened = false;
                    inWar = false;
                    warInProgressSoundsEffect.Stop();
                    backgroundMusic.Play();
                }
            }
        }
    }

    public void CloseCountryWinPanel()
    {
        countryWinPanel.SetActive(false);
        panelOpened = false;
    }
    public void CloseCountryLostPanel()
    {
        countryLostPanel.SetActive(false);
        panelOpened = false;
    }
}