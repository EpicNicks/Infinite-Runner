using UnityEngine;
using UnityEngine.UI;

public class TitleTextTheme : MonoBehaviour {

    private Text text;

    void Start () {
        text = GetComponent<Text>();
        text.color = PickAColor();
	}

    Color PickAColor()
    {
        switch (ColorSetter.selected)
        {
            case ColorSetter.NumOptions.COOL: return ColorRandomizer.RandomCold();
            case ColorSetter.NumOptions.WARM: return ColorRandomizer.RandomWarm();
            case ColorSetter.NumOptions.FABULOUS: return ColorRandomizer.RandomFabulous();
            case ColorSetter.NumOptions.LIGHT: return ColorRandomizer.RandomLight();
            case ColorSetter.NumOptions.DARK: return ColorRandomizer.RandomDark();
            case ColorSetter.NumOptions.RANDOM: return Random.ColorHSV();
            case ColorSetter.NumOptions.CLASSICBLACK: return Color.black;
            case ColorSetter.NumOptions.CLASSICWHITE: return Color.white;
            default: return Random.ColorHSV();
        }
    }
}
