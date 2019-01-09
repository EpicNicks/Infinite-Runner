using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorLerp : MonoBehaviour {

    public float time;
    public float r, g, b;
    private bool isDoneLerping = true;
    private Text text;

	void Start () {
        text = GetComponent<Text>();

        if (name.Equals("CoinCount"))
            text.text = PlayerPrefsManager.GetCoinCount().ToString();
        else if (name.Equals("HighScore"))
            text.text = PlayerPrefsManager.GetHighScore().ToString();
	}
	
	void Update () {
        if(isDoneLerping)
            StartCoroutine(Lerp(time));
	}

    IEnumerator Lerp(float time)
    {
        isDoneLerping = false;
        text.color = new Color(r, g, b);
        yield return new WaitForSeconds(time);
        text.color = Color.white;
        yield return new WaitForSeconds(time);
        isDoneLerping = true;
    }


}
