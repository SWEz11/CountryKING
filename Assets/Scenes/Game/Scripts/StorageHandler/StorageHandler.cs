using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class StorageHandler : MonoBehaviour
{
    [Header("Storage System")]

    [Header("Get Scripts / Objects")]
    [SerializeField] GameObject storagePanel;
    [SerializeField] GameHandler gameHandler;
    [SerializeField] ShopHandler shopHandler;
    SaveSystem saveSystem = new SaveSystem();

    //Items
    [Header("Army")]
    public int armyCount;
    public int armyCost;
    [SerializeField] TMP_Text armyCountText;
    [Header("Pistol")]
    public int pistolCount;
    public int pistolCost;
    [SerializeField] TMP_Text pistolCountText;



    //Army

    void UpdateArmyCount()
    {
        armyCountText.text = "Army Count: " + armyCount.ToString();
        saveSystem.SaveStorage("ArmyCount", armyCount);
    }

    public void IncreaseArmyCount(int armyAmount)
    {
        armyCount += armyAmount;
        UpdateArmyCount();
    }

    public void DecreaseArmyCount(int armyAmount)
    {
        armyCount -= armyAmount;
        UpdateArmyCount();
    }
    
    public void ArmyCost()
    {
        armyCost = + armyCount * 6;
        shopHandler.armyCostText.text = "Cost: " + armyCost.ToString();
    }

    // Pistol


    void UpdatePistolCount()
    {
        pistolCountText.text = "Pistol Count: " + pistolCount.ToString();
        saveSystem.SaveStorage("PistolCount", pistolCount);
    }

    public void IncreasePistolCount(int pistolAmount)
    {
        pistolCount += pistolAmount;
        UpdatePistolCount();
    }

    public void DecreasePistolCount(int pistolAmount)
    {
        pistolCount -= pistolAmount;
        UpdatePistolCount();
    }

    public void PistolCost()
    {
        pistolCost = + pistolCount * 4;
        shopHandler.pistolCostText.text = "Cost: " + pistolCost.ToString();
    }




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
        saveSystem.LoadStorage("ArmyCount", ref armyCount, armyCountText, "Army Count: ", 1);
        saveSystem.LoadStorage("PistolCount", ref pistolCount, pistolCountText, "Pistol Count: ", 1);
    }


}
