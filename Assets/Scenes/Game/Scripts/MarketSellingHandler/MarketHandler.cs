using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketHandler : MonoBehaviour
{

    [Header("Market / Selling System")]

    [Header("Get Scripts / Objects")]
    [SerializeField] StorageHandler storageHandler;
    [SerializeField] GameHandler gameHandler;

    [SerializeField] GameObject marketPanel;

    [Header("Gas Marketing")]

    [SerializeField] Button buyGasButton;
    [SerializeField] TMP_Text gasCostText;
    int gasCostToBuy;
    [SerializeField] int gasValue; //How much to give gas

    int interactableButtonValue;

    //SaveSystem
    SaveSystem saveSystem = new SaveSystem();


    public void OpenMarketPanel()
    {
        if (!gameHandler.panelOpened)
        {
            marketPanel.SetActive(true);
            gameHandler.panelOpened = true;
        }
    }

    public void CloseMarketPanel()
    {
        marketPanel.SetActive(false);
        gameHandler.panelOpened = false;
    }

    //Gas 

    public void GasCost(int minValue, int maxValue)
    {
        gasCostToBuy = Random.Range(minValue, maxValue);
        gasCostText.text = "Cost: " + gasCostToBuy.ToString();
        gasValue = gasCostToBuy - Random.Range(minValue, maxValue);
    }

    public void BuyGas()
    {
        if (gasCostToBuy <= gameHandler.moneyInt)
        {
            gameHandler.RemoveMoney(gasCostToBuy);
            gameHandler.moneyGeneratorTime = Random.Range(1, 5);
            gameHandler.moneyPerTime = Random.Range(1, 4);
            interactableButtonValue = 0;
            saveSystem.SaveMarket("GasButton", interactableButtonValue, false, buyGasButton);
        }
    }

    public void LoadGasButton()
    {
        saveSystem.LoadMarket("GasButton", interactableButtonValue, buyGasButton);
    }
}
