using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    
    //Only use in case of debug testing where all prefs NEED to be deleted
    public void Purge()
    {
        PlayerPrefs.DeleteAll();
    }

    public static bool IsUnlocked(string itemName)
    {
        return PlayerPrefs.HasKey(itemName) || PlayerPrefs.GetInt(itemName) == 1;
    }

    public static bool LockItem(string itemName)
    {
        if (PlayerPrefs.HasKey(itemName))
        {
            PlayerPrefs.DeleteKey(itemName);
            return true;
        }
        return false;
    }

    public static bool UnlockItem(string itemName, int price)
    {
        if (PlayerPrefs.GetInt("Coins") > price && PlayerPrefs.GetInt(itemName) == 0)
        {
            var i = PlayerPrefs.GetInt("Coins") - price;
            PlayerPrefs.SetInt("Coins", i);
            PlayerPrefs.SetInt(itemName, 1);
            return true;
        }
        return false;
    }

    public static void UnlockAchievement(Achievement achievement)
    {
        PlayerPrefs.SetInt(achievement.name, 1);
    }

    public static bool IsAchievementUnlocked(Achievement achievement)
    {
        return (PlayerPrefs.GetInt(achievement.name) == 1);
    }

    //Volume Block
    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0.0f && volume <= 1.0f)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
            Debug.LogError("Master Volume out of Range");
    }
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    //Difficulty Block
    public static void SetDifficulty(float difficulty)
    {
        if(difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
            print("Is Set");
        }
        else
        {
            Debug.LogError("Difficulty out of Range");
        }
    }
    public static float GetDifficulty()
    {return PlayerPrefs.GetFloat(DIFFICULTY_KEY);}

    public static void SetTheme(int numOptions)
    {PlayerPrefs.SetInt("Theme", numOptions);}

    public static int GetTheme()
    {return PlayerPrefs.GetInt("Theme");}

    public static void SetCoinCount(int coinCount)
    {PlayerPrefs.SetInt("Coins", coinCount);}

    public static int GetCoinCount()
    {return PlayerPrefs.GetInt("Coins");}

    public static void SetHighScore(int score)
    { PlayerPrefs.SetInt("HighScore", score); }

    public static int GetHighScore()
    { return PlayerPrefs.GetInt("HighScore"); }

    public static void SetLifetimeCoins(int coins)
    { PlayerPrefs.SetInt("LifetimeCoins", coins); }

    public static int GetLifetimeCoins()
    { return PlayerPrefs.GetInt("LifetimeCoins"); }
}