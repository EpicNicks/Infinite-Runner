using UnityEngine;
using UnityEngine.UI;
public class Pause : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject pauseMenu;
    public Sprite[] pausedSprites;
    private Image myImage;

    private void Start()
    {
        pauseMenu.SetActive(isPaused);
        myImage = GetComponent<Image>();
    }

    public void PauseGame()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            myImage.sprite = pausedSprites[1];
        }
        else
        {
            Time.timeScale = 1;
            myImage.sprite = pausedSprites[0];
        }

        pauseMenu.SetActive(isPaused);
    }
}
