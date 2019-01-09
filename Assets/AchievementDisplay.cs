using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class AchievementDisplay : MonoBehaviour {

    public GameObject achievementBlock;
    public Transform parent;
    public List<GameObject> achievementBlocks;
    public Sprite lockedImage;

    void Start ()
    {
        parent = transform;
        for(int i = 0; i < Enum.GetValues(typeof(AchievementManager.Achievements)).Length; i++)
        {
            GameObject g = Instantiate(achievementBlock, parent) as GameObject;
            achievementBlocks.Add(g);
        }
        SetAllAchievementBlocks();
        SetBlockPos();
    }

    private void SetAllAchievementBlocks()
    {
        for(int i = 0; i < Enum.GetValues(typeof(AchievementManager.Achievements)).Length; i++)
        {
            ComponentHolder componentHolder = achievementBlocks[i].GetComponent<ComponentHolder>();

            if (!PlayerPrefsManager.IsAchievementUnlocked(AchievementManager.achievements[i]))
            {
                componentHolder.achievementName.GetComponent<Text>().text = "???";
                componentHolder.description.GetComponent<Text>().text = "???";
                componentHolder.image.GetComponent<Image>().sprite = lockedImage;
            }
            else
            {
                componentHolder.achievementName.GetComponent<Text>().text = AchievementManager.achievements[i].name;
                componentHolder.description.GetComponent<Text>().text = AchievementManager.achievements[i].text;
                componentHolder.image.GetComponent<Image>().sprite = AchievementManager.achievements[i].icon;
            }
        }
    }
    void SetBlockPos()
    {
        Vector3 v = new Vector3(0, 162);
        for (int i = 0; i < achievementBlocks.Count; i++)
        {
            achievementBlocks[i].transform.position -=v;
            v -= v;
        }
    }
}
