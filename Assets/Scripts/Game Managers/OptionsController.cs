using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Dropdown theme;
    public LevelManager levelManager;
    private MusicManager musicManager;

	void Start ()
    {
        theme = FindObjectOfType<Dropdown>();
        musicManager = FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
    }
	
	void Update ()
    {
        musicManager.SetVolume(volumeSlider.value);
	}

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetTheme(theme.value);
        levelManager.LoadLevel("01A Start");
    }
    public void SetDefaults()
    {
        volumeSlider.value = 0.8f;
        theme.value = 0;
    }

    public void SetVolume()
    {
        musicManager.SetVolume(volumeSlider.value);
    }
}
