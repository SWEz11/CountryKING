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
    [Header("Pistol")]
    public TMP_Text pistolCostText;

    public void OpenShopPanel()
    {
        if (!gameHandler.panelOpened)
        {
            shopPanel.SetActive(true);
            gameHandler.panelOpened = true;
            storageHandler.PistolCost();
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
            storageHandler.pistolCount++;
            storageHandler.PistolCost();
            storageHandler.IncreasePistolCount(1);
        }
    }
}
