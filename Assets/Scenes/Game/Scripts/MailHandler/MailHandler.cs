using UnityEngine;

public class MailHandler : MonoBehaviour
{
    [SerializeField] Player player;

    [Header("Mail System")]
    public GameObject mailPanel;

    [Header("Get Scripts / Objects")]
    [SerializeField] GameHandler gameHandler;

    public void OpenMailPanel()
    {
        if (!gameHandler.panelOpened)
        {
            mailPanel.SetActive(true);
            gameHandler.panelOpened = true;
        }
    }

    public void CloseMailPanel()
    {
        mailPanel.SetActive(false);
        gameHandler.panelOpened = false;
    }
}
