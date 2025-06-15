using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Kalesia : MonoBehaviour
{

    [Header("Kalesia")]

    [SerializeField] GameObject kalesiaPanel;
    SaveSystem saveSystem = new SaveSystem();
    public int isOccupied2;
    [SerializeField] TMP_Text ocupiedText;

    [Header("Get Scripts / Objects")]
    [SerializeField] GameHandler gameHandler;
    [SerializeField] StorageHandler storageHandler;

    [Header("Battle Info")]

    public int armyCount2;
    [SerializeField] TMP_Text armyCount2Text;

    public int pistolCount2;

    [SerializeField] TMP_Text pistolCount2Text;

    [SerializeField] Button battleButton;

    float timer = 0.0f;

    public void OpenPanel()
    {
        if (!gameHandler.panelOpened)
        {
            kalesiaPanel.SetActive(true);
            LoadKalesiaInfo();
            gameHandler.panelOpened = true;
        }
    }

    public void ClosePanel()
    {
        kalesiaPanel.SetActive(false);
        gameHandler.panelOpened = false;
    }

    void BattleInformation(int minValue, int maxValue)
    {
        armyCount2 = Random.Range(minValue, maxValue);
        armyCount2Text.text = armyCount2.ToString() + " Kalesia Army";

        pistolCount2 = Random.Range(minValue, maxValue);
        pistolCount2Text.text = pistolCount2.ToString() + " Kalesia Guns";
    }

    public void LoadKalesiaInfo()
    {
        saveSystem.LoadInfo("Kalesia", isOccupied2, ocupiedText, battleButton);
        if(isOccupied2 == 0)
        {
            BattleInformation(1, 4);
        }
    }

    public void Battle()
    {
        gameHandler.Battle(armyCount2, pistolCount2, isOccupied2, kalesiaPanel, "Kalesia");
    }

    public void EnableBattle()
    {
        if (storageHandler.armyCount >= armyCount2 && storageHandler.pistolCount >= pistolCount2 && !gameHandler.canBattle)
        {
            Battle();
            gameHandler.inWar = true;
            gameHandler.battlingTime = Random.Range(1, 10);
            gameHandler.canBattle = false;
        }
        else
        {
            print("No War");
        }
    }
}
