using UnityEngine;
using UnityEngine.UI;

public class OptionsHandler : MonoBehaviour
{
    [Header("Options System")]
    public GameObject optionsPanel;

    [Header("Get Scripts / Objects")]
    [SerializeField] GameHandler gameHandler;
    [SerializeField] Slider backgroundMusicSlider;
    [SerializeField] Slider mainVolumeSlider;
    SaveSystem saveSystem = new SaveSystem();
    public void OpenOptionsPanel()
    {
        if (!gameHandler.panelOpened)
        {
            optionsPanel.SetActive(true);
            gameHandler.panelOpened = true;
        }
    }

    public void CloseOptionsPane()
    {
        optionsPanel.SetActive(false);
        gameHandler.panelOpened = false;
    }

    //Volumes

    //BackgroundSound

    public void SetBackgroundMusic()
    {
        saveSystem.SaveVolume(backgroundMusicSlider, gameHandler.backgroundMusic, "BackgroundMusic");
    }

    public void GetBackgroundMusic()
    {
        saveSystem.LoadVolume("BackgroundMusic", backgroundMusicSlider, gameHandler.backgroundMusic, 1);
    }


    //MainVolume

    public void SetMasterVolume()
    {
        saveSystem.SaveMixerVolume(mainVolumeSlider, gameHandler.mainVolumeMixer, "MainVolume");
    }

    public void GetMasterVolume()
    {
        saveSystem.LoadMixerVolume("MainVolume", mainVolumeSlider, gameHandler.mainVolumeMixer, 1);
    }

}