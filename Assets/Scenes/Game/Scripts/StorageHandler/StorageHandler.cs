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

    void UpdateArmyCount()
    {
        armyCountText.text = "Army Count " + armyCount.ToString();
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

}
