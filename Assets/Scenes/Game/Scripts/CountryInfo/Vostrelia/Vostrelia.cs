using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Vostrelia : MonoBehaviour
{

    [Header("Vostrelia")]

    [SerializeField] GameObject vostreliaPanel;
    SaveSystem saveSystem = new SaveSystem();
    public int isOcupied;
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
            gameHandler.panelOpened = true;
        }
    }

    public void ClosePanel()
    {
        vostreliaPanel.SetActive(false);
        gameHandler.panelOpened = false;
    }

    public void BattleInformation(int minValue, int maxValue)
    {
        armyCount = Random.Range(minValue, maxValue);
        armyCountText.text = armyCount.ToString() + " Vostrelia Army";

        pistolCount = Random.Range(minValue, maxValue);
        pistolCountText.text = pistolCount.ToString() + " Vostrelia Guns";
    }

    public void LoadVostreliaInfo()
    {
        saveSystem.LoadInfo("Vostrelia", isOcupied, ocupiedText);
        if (isOcupied == 1)
        {
            battleButton.interactable = false;
        }
        else
        {
            BattleInformation(15, 45);
            battleButton.interactable = true;
        }
    }
}
