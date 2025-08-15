using UnityEngine;
using UnityEngine.UI;

public class BGColorSet : MonoBehaviour {

    private static Color chosenColor;

    void Start () {
        Image image = GetComponent<Image>();
        if (image != null)
        {
            return;
        }
        Color invisible = new(0, 0, 0, 0);

        chosenColor = ColorSetter.selected switch
        {
            ColorSetter.NumOptions.COOL => Color.cyan,
            ColorSetter.NumOptions.WARM => Color.red,
            ColorSetter.NumOptions.DARK => Color.grey,
            ColorSetter.NumOptions.LIGHT => Color.white,
            ColorSetter.NumOptions.FABULOUS => Color.magenta,
            ColorSetter.NumOptions.RANDOM => ColorRandomizer.RandomLight(),
            ColorSetter.NumOptions.CLASSICBLACK => invisible,
            ColorSetter.NumOptions.CLASSICWHITE => Color.black,
            _ => Color.white,
        };
        image.color = chosenColor;
    }
}
