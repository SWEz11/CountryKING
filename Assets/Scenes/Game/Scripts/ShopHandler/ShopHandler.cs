using UnityEngine;

public class ShopHandler : MonoBehaviour
{
    [Header("Store System")]

    [Header("Get Scripts / Objects")]
    [SerializeField] GameHandler gameHandler;
    [SerializeField] StorageHandler storageHandler;
    [SerializeField] GameObject shopPanel;

    public void OpenShopPanel()
    {
        if (!gameHandler.panelOpened)
        {
            shopPanel.SetActive(true);
            gameHandler.panelOpened = true;
        }
    }

    public void CloseShopPanel()
    {
        shopPanel.SetActive(false);
        gameHandler.panelOpened = false;
    }

    // public void BuyPistol()
    // {
    //     storageHandler.IncreaseArmyCount(1);
    // }
}
