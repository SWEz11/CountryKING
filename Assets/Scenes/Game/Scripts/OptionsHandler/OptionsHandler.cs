using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsHandler : MonoBehaviour
{
    [SerializeField] Player player;

    [Header("Options System")]
    public GameObject optionsPanel;

    [Header("Get Scripts / Objects")]
    [SerializeField] GameHandler gameHandler;
    [SerializeField] Slider backgroundMusicSlider;
    [SerializeField] Slider mainVolumeSlider;
    [SerializeField] SaveSystem saveSystem;
    [SerializeField] AudioMixer mainVolumeMixer;
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
        saveSystem.LoadVolume("BackgroundMusic", backgroundMusicSlider, gameHandler.backgroundMusic);
    }


    //MainVolume

    public void SetMasterVolume()
    {
        saveSystem.SaveMixerVolume(mainVolumeSlider, mainVolumeMixer, "MainVolume");
    }

    public void GetMasterVolume()
    {
        saveSystem.LoadMixerVolume("MainVolume", mainVolumeSlider, mainVolumeMixer);
    }

}