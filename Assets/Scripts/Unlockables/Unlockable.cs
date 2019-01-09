using UnityEngine;
using UnityEngine.UI;

public class Unlockable : MonoBehaviour {

    public string itemName;
    public int price;
    public bool isUnlocked;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        if (PlayerPrefsManager.IsUnlocked(itemName))
        {
            GetComponentInChildren<Text>().color = Color.gray;
            button.enabled = false;
        }
        else if(PlayerPrefsManager.GetCoinCount() < price)
        {
            GetComponentInChildren<Text>().color = Color.red;
            button.enabled = false;
        }

        else
            GetComponentInChildren<Text>().color = Color.white;
    }

    public void Unlock()
    {
            GetComponentInChildren<Text>().color = Color.gray;
        if (!PlayerPrefsManager.IsUnlocked(itemName))
            if(PlayerPrefsManager.UnlockItem(itemName, price))
            {
                GetComponentInChildren<Text>().color = Color.gray;
            }
        if (PlayerPrefsManager.IsUnlocked(itemName))
            button.enabled = false;
    }
}
