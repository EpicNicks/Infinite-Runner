using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicArray;
    private AudioSource audioSource;
    static MusicManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this; // In first scene, make us the singleton.
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.
        Debug.Log("Audio Playing From: "+ name);
    }

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
        SceneManager.sceneLoaded += OnLevelLoad;
    }

    void OnLevelLoad (Scene scene, LoadSceneMode mode)
    {
        int musicIndex = scene.buildIndex;
        AudioClip thisLevelMusic = (levelMusicArray.Length > musicIndex) ? levelMusicArray[musicIndex] : null;
        Debug.Log("Playing clip: " + thisLevelMusic);

        if (thisLevelMusic) //If there is music playing
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
