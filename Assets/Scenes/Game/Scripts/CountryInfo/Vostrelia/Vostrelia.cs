using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Vostrelia : MonoBehaviour
{

    [Header("Vostrelia")]

    [SerializeField] GameObject vostreliaPanel;
    SaveSystem saveSystem = new SaveSystem();
    public int isOccupied;
    [SerializeField] TMP_Text ocupiedText;

    [Header("Get Scripts / Objects")]
    [SerializeField] GameHandler gameHandler;
    [SerializeField] StorageHandler storageHandler;

    [Header("Battle Info")]

    public int armyCount;
    [SerializeField] TMP_Text armyCountText;

    public int pistolCount;

    [SerializeField] TMP_Text pistolCountText;

    [SerializeField] Button battleButton;

    float timer = 0.0f;

    public void OpenPanel()
    {
        if (!gameHandler.panelOpened)
        {
            vostreliaPanel.SetActive(true);
            LoadVostreliaInfo();
            gameHandler.panelOpened = true;
        }
    }

    public void ClosePanel()
    {
        vostreliaPanel.SetActive(false);
        gameHandler.panelOpened = false;
    }

    void BattleInformation(int minValue, int maxValue)
    {
        armyCount = Random.Range(minValue, maxValue);
        armyCountText.text = armyCount.ToString() + " Vostrelia Army";

        pistolCount = Random.Range(minValue, maxValue);
        pistolCountText.text = pistolCount.ToString() + " Vostrelia Guns";
    }

    public void LoadVostreliaInfo()
    {
        saveSystem.LoadInfo("Vostrelia", isOccupied, ocupiedText, battleButton);
        if(isOccupied == 0)
        {
            BattleInformation(1, 4);
        }
    }

    public void Battle()
    {
        gameHandler.Battle(armyCount, pistolCount, isOccupied, vostreliaPanel, "Vostrelia");
    }

    public void EnableBattle()
    {
        if (storageHandler.armyCount >= armyCount && storageHandler.pistolCount >= pistolCount && !gameHandler.canBattle)
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
