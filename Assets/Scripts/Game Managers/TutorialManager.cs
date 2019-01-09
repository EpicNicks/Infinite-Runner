using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

    public string[] tutorials;
    private Text tutText;
    private Button NextButton, BackButton;
    private int index = 0;

	void Start ()
    {
        //TODO: Make actual tutorial blocks
        tutorials = new string[12];

        NextButton = GameObject.Find("Next Button").GetComponent<Button>();
        BackButton = GameObject.Find("Back Button").GetComponent<Button>();

        BackButton.interactable = false;

        tutText = GetComponent<Text>();

        tutorials[0] = "Welcome to <b>Infinity Run</b>";//Insert final game name here
        tutorials[1] = "Your objective:";
        tutorials[2] = "Survive as long as you can by jumping from block to block";
        tutorials[3] = "You jump by pressing and holding the screen to charge up and release to jump";
        tutorials[4] = "<b>Try it here!</b>";
        tutorials[5] = "You can vary the size of your jump depending on whether you tap or hold";
        tutorials[6] = "You may collect <color=yellow><b>Coins</b></color> in order to purchase upgrades";
        tutorials[7] = "Upgrades can be purchased in the shop";
        tutorials[8] = "You accumulate <color=green><b>Score</b></color> by making it past blocks";
        tutorials[9] = "Both stats are visible at the top right of the screen";
        tutorials[10] = "If you miss a block and fall, you <color=red>lose</color> and your score will be reset";
        //tutorials[10] = "";
        //tutorials[11] = "";
        //tutorials[12] = "";
        tutorials[11] = "Good Luck!";
	}
	
	void Update ()
    {
        tutText.text = tutorials[index];
	}

    public void Next()
    {
        if(index < tutorials.Length - 1)
        {
            index++;
            BackButton.interactable = true;
            if (index == tutorials.Length - 1)
            {
                NextButton.interactable = false;
            }
        }
    }
    
    public void Back()
    {
        if(index > 0)
        {
            index--;
            NextButton.interactable = true;
            if(index == 0)
            {
                BackButton.interactable = false;
            }
        }
    }
}
