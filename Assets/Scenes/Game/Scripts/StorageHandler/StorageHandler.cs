using TMPro;
using UnityEngine;

public class StorageHandler : MonoBehaviour
{
    [Header("Storage System")]
    int armyCount;

    [Header("Get Scripts / Objects")]
    [SerializeField] TMP_Text armyCountText;
    [SerializeField] GameObject storagePanel;
    [SerializeField] GameHandler gameHandler;
    SaveSystem saveSystem = new SaveSystem();

    void UpdateArmyCount()
    {
        armyCountText.text = "Army Count " + armyCount.ToString();
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

    public void LoadStorage() {
        saveSystem.LoadStorage("ArmyCount", ref armyCount, armyCountText, 0);
    }

}
