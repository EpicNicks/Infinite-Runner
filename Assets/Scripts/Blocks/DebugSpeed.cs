using UnityEngine.UI;
using UnityEngine;

public class DebugSpeed : MonoBehaviour {

    private Text text;

	void Start () {
        text = GetComponent<Text>();
	}
	
	void Update () {
        text.text = "Speed: " + BlockMovementManager.speed.ToString();
    }
}
