using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    //public float autoLoadNextLevel;   
    //NOT USED IN THIS IMPLEMENTATION
    /*
    void AutoLoad()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 && autoLoadNextLevel >= 0)
        {
            Invoke("LoadNextLevel", autoLoadNextLevel);
        }
    }
    */
    private void Start()
    {
        ScoreManager.coinCount = PlayerPrefsManager.GetCoinCount();
    }

    public void LoadLevel(string name)
    {
        Debug.Log("Level Load Requested For: " + name);
        SceneManager.LoadScene(name);
        //Resets the timescale from pause menu
        Time.timeScale = 1;
        Pause.isPaused = false;

        ScoreManager.score = 0;
    }

	public void QuitRequest()
    {
		Debug.Log ("Bye:");
		Application.Quit ();
	}
	//Load Next Level using Build Settings
	public void LoadNextLevel()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
	}

    private void OnApplicationQuit()
    {
        PlayerPrefsManager.SetCoinCount(ScoreManager.coinCount);
    }
}