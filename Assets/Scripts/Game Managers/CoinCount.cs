using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour {


    Text coinText;

	void Start () {
        coinText = GetComponent<Text>();
    }
	
	void Update () {
        coinText.text = "x " + ScoreManager.coinCount;
    }
}
