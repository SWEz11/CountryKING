using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class StorageHandler : MonoBehaviour
{
    [Header("Storage System")]

    [Header("Get Scripts / Objects")]
    [SerializeField] TMP_Text armyCountText;
    [SerializeField] GameObject storagePanel;
    [SerializeField] GameHandler gameHandler;
    SaveSystem saveSystem = new SaveSystem();

    //Items
    int armyCount;
    int pistol;



    //Army

    void UpdateArmyCount()
    {
        armyCountText.text = "Army Count " + armyCount.ToString();
        saveSystem.SaveStorage("ArmyCount", armyCount);
    }

    public void IncreaseArmyCount(int armyAmount, int cost)
    {
        armyCount += armyAmount;
        UpdateArmyCount();
    }

    public void DecreaseArmyCount(int armyAmount)
    {
        armyCount -= armyAmount;
        UpdateArmyCount();
    }

    //ArmyCost
    // public void ArmyCost()
    // {
    //     switch (armyCount)
    //     {
    //         case 1:
    //     }

    // }


    //Panel
    public void OpenStoragePanel()
    {
        if (!gameHandler.panelOpened)
        {
            storagePanel.SetActive(true);
            gameHandler.panelOpened = true;
        }
    }

    public void CloseStoragePanel()
    {
        storagePanel.SetActive(false);
        gameHandler.panelOpened = false;
    }

    public void LoadStorage()
    {
        saveSystem.LoadStorage("ArmyCount", ref armyCount, armyCountText, 0);
    }


}
