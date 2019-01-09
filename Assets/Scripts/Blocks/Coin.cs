using UnityEngine;

public class Coin : MonoBehaviour {

    public int coinValue;
    bool isCollected = false;
    public AudioClip coinPickupAudio;

    private void Start()
    {
        //TODO ADD SUPERCOIN

        if (Random.Range(0, 20) > 18 && PlayerPrefsManager.IsUnlocked("Red Coin"))
        {
            coinValue = 20;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if(Random.Range(0, 10) == 0)
        {
            coinValue = 5;
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            coinValue = 1;
        }
    }

    private void OnTriggerEnter2D()
    {
        if (!isCollected)
        {
            ScoreManager.UpdateCoinCount(coinValue);
            AudioSource.PlayClipAtPoint(coinPickupAudio, Vector3.zero);
            Destroy(gameObject);
            isCollected = true;
        }
    }
}
