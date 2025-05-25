using UnityEngine;
using UnityEngine.UI;

public class OptionsHandler : MonoBehaviour
{
    [SerializeField] Player player;

    [Header("Options System")]
    public GameObject optionsPanel;

    [Header("Get Scripts / Objects")]
    [SerializeField] GameHandler gameHandler;
    [SerializeField] Slider backgroundMusicSlider;
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

    //BackgroundMusic
    private void SetVolume(float volume, AudioSource audioSource, Slider slider)
    {
        volume = slider.value;
        audioSource.volume = volume;
        Debug.Log(volume);
    }

    private void GetVolume(float volume, AudioSource audioSource, Slider slider)
    {
        slider.value = volume;
        audioSource.volume = slider.value;
        Debug.Log("Loaded " + volume);
    }

    //BackgroundMusic
    public void SetBackgroundMusicVolume()
    {
        SetVolume(player.backgroundMusicVolumeValue, gameHandler.backgroundMusic, backgroundMusicSlider);
    }

    public void GetBackgroundMusicVolume()
    {
        GetVolume(player.backgroundMusicVolumeValue, gameHandler.backgroundMusic, backgroundMusicSlider);
    }
}