using UnityEngine;
using UnityEngine.UI;

public class BGColorSet : MonoBehaviour {

    private static Color chosenColor;

    void Start () {
        Image image = GetComponent<Image>();
        Color invisible = new Color(0, 0, 0, 0);

        switch (ColorSetter.selected)
        {
            case ColorSetter.NumOptions.COOL: chosenColor = Color.cyan; break;
            case ColorSetter.NumOptions.WARM: chosenColor = Color.red; break;
            case ColorSetter.NumOptions.DARK: chosenColor = Color.grey; break;
            case ColorSetter.NumOptions.LIGHT: chosenColor = Color.white; break;
            case ColorSetter.NumOptions.FABULOUS: chosenColor = Color.magenta; break;
            case ColorSetter.NumOptions.RANDOM: chosenColor = ColorRandomizer.RandomLight(); break;
            case ColorSetter.NumOptions.CLASSICBLACK: chosenColor = invisible; break;
            case ColorSetter.NumOptions.CLASSICWHITE: chosenColor = Color.black; break;
            default: chosenColor = Color.white; break;
        }
        image.color = chosenColor;
    }
}
