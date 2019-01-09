using UnityEngine;

public class ComponentHolder : MonoBehaviour
{
    public GameObject achievementName, description, image;

    private void Start()
    {
        achievementName = GameObject.Find("Achievement Name");
        description = GameObject.Find("Achievement Description");
        image = GameObject.Find("Achievement Image");
    }
}
