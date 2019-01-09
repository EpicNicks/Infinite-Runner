using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public struct Achievement
{
    public string text;
    public string name;
    public string type;
    public int num;
    public Sprite icon;

    public Achievement(string name, string text, string type, int num, Sprite icon)
    {
        this.name = name;
        this.text = text;
        this.type = type;
        this.num = num;
        this.icon = icon;
    }
}


public class AchievementManager : MonoBehaviour
{
    public enum Achievements
    {
        FIRST_STEPS, GOING_THE_DISTANCE, WOAH_HALFWAY_THERE, LIVING_LEGEND, PENNY_PINCHER, SMALL_FORTUNE, COIN_COLLECTOR, THE_ONE_PERCENT
    }

    public static Achievement[] achievements = new Achievement[10];
    public List<Achievement> curList = new List<Achievement>();
    public Sprite[] achievementIcons;
    public GameObject achievementPlayer;
    public GameObject spriteContainer;
    public Animator achievementPlayerAnim;

    private void Start()
    {       
        SetupAchievements();
        SetupLockedAchievements();

        foreach(Achievement achievement in achievements)
        {
            print(achievement.name + " Unlock Status " + PlayerPrefsManager.IsAchievementUnlocked(achievement).ToString());
        }
    }

    private void FixedUpdate()
    {
        CheckAchievement();
    }

    void SetupAchievements()
    {
        achievements = new Achievement[Enum.GetValues(typeof(Achievements)).Length];
        print(Enum.GetValues(typeof(Achievements)).Length);

        achievements[(int)Achievements.FIRST_STEPS] = new Achievement("First Steps", "Make it past <b>Five</b> blocks", "Score", 5, achievementIcons[0]);
        achievements[(int)Achievements.GOING_THE_DISTANCE] = new Achievement("Going the Distance", "Make it past <b>Twenty</b> blocks", "Score", 20, achievementIcons[1]);
        achievements[(int)Achievements.WOAH_HALFWAY_THERE] = new Achievement("Woah, Halfway There!", "Make it past <b>Fifty</b> blocks", "Score", 50, achievementIcons[2]);
        achievements[(int)Achievements.LIVING_LEGEND] = new Achievement("Living Legend", "Make it past <b>One Hundred</b> blocks", "Score", 100, achievementIcons[3]);
        achievements[(int)Achievements.PENNY_PINCHER] = new Achievement("Penny Pincher", "Collected your first <b>50</b> coins!", "Coin", 50, achievementIcons[4]);
        achievements[(int)Achievements.SMALL_FORTUNE] = new Achievement("Small Fortune", "Collected your first <b>500</b> coins!", "Coin", 500, achievementIcons[5]);
        achievements[(int)Achievements.COIN_COLLECTOR] = new Achievement("Coin Collector", "Collected your first <b>5000</b> coins!", "Coin", 5000, achievementIcons[6]);
    }
    void SetupLockedAchievements()
    {
        foreach(Achievement achievement in achievements)
        {
            if (!PlayerPrefsManager.IsAchievementUnlocked(achievement))
            {
                curList.Add(achievement);
                print(achievement + ": " + achievement.name + " added");
            }
        }
    }

    private int frames = 0;
    //Checks if an achievement has been unlocked every 10 frames
    private void CheckAchievement()
    {
        frames++;
        if(frames == 10)
        {
            foreach(Achievement achievement in curList)
            {
                if (!PlayerPrefsManager.IsAchievementUnlocked(achievement))
                {
                    if (achievement.type == "Score" && ScoreManager.score > achievement.num)
                    {
                        PlayerPrefsManager.UnlockAchievement(achievement);
                        SpawnAchievement(achievement);
                        //DOC: Causes buggy behaviour
                        //curList.Remove(achievement);
                    }
         ///Might need to separate into different frame denominations: ie Score = 10 frames, Coin = 20 frames, etc.
         ///to avoid hiccups where all calculations are done in one frame
                    else if (achievement.type == "Coin" && PlayerPrefsManager.GetLifetimeCoins() > achievement.num)
                    {
                        PlayerPrefsManager.UnlockAchievement(achievement);
                        SpawnAchievement(achievement);
                    }
                }
            }
            frames = 0;
        }
    }

    private void SpawnAchievement(Achievement achievement)
    {
        //DontDestroyOnLoad(achievementPlayer);
        achievementPlayer.GetComponentInChildren<Text>().text = achievement.name;
        spriteContainer.GetComponent<Image>().sprite = achievement.icon;
        achievementPlayerAnim.SetTrigger("Achievement Get");
    }
}
