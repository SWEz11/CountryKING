using TMPro;
using UnityEngine;

public class ShopHandler : MonoBehaviour
{
    [Header("Store System")]

    [Header("Get Scripts / Objects")]
    [SerializeField] GameHandler gameHandler;
    [SerializeField] StorageHandler storageHandler;
    [SerializeField] GameObject shopPanel;

    //Items
    [Header("Army")]
    public TMP_Text armyCostText;

    [Header("Pistol")]
    public TMP_Text pistolCostText;

    public void OpenShopPanel()
    {
        if (!gameHandler.panelOpened)
        {
            shopPanel.SetActive(true);
            gameHandler.panelOpened = true;
            storageHandler.PistolCost();
            storageHandler.ArmyCost();
        }
    }

    public void CloseShopPanel()
    {
        shopPanel.SetActive(false);
        gameHandler.panelOpened = false;
    }

    public void BuyPistol()
    {
        if (storageHandler.pistolCost <= gameHandler.moneyInt)
        {
            gameHandler.RemoveMoney(storageHandler.pistolCost);
            storageHandler.IncreasePistolCount(1);
            storageHandler.PistolCost();
        }
    }

    public void BuyArmy()
    {
        if (storageHandler.armyCost <= gameHandler.moneyInt)
        {
            gameHandler.RemoveMoney(storageHandler.armyCost);
            storageHandler.IncreaseArmyCount(1);
            storageHandler.ArmyCost();
        }
    }
}
