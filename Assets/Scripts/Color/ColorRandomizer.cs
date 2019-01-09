using UnityEngine;

public class ColorRandomizer {

    /// Warm colors use R = 1, G = 0-1, B = 0
    /// Cool colors use R = 0, G = 0-1, B = 1
    /// Dark shades must have all values below 60
    /// Light shades must have all values above 100
    /// GreyScale values must have matching r g b values

    public static Color RandomWarm()
    {
        return new Color(1, Random.Range(0, 1.0f), 0);
    }

    public static Color RandomCold()
    {
        return new Color(0, Random.Range(0, 1.0f), 1);
    }

    public static Color RandomFabulous()
    {
        if (Random.Range(0, 15) >= 5)
            return new Color(1, Random.Range(0, 1.0f), 1);
        else if (Random.Range(0, 15) >= 10)
            return new Color(1, 0, Random.Range(1 / 2.0f, 1));
        else
            return new Color(Random.Range(1.0f / 2, 1), 0, 1);
    }

    public static Color RandomDark()
    {
        return new Color(Random.Range(0, 60.0f / 255), Random.Range(0, 60.0f / 255), Random.Range(0, 60.0f / 255));
    }

    public static Color RandomLight()
    {
        return new Color(Random.Range(100.0f / 255, 1), Random.Range(100.0f / 255, 1), Random.Range(100.0f / 255, 1));
    }

    public static Color RandomGreyScale()
    {
        float rgb = Random.Range(0, 255) / 255.0f;
        return new Color(rgb, rgb, rgb);
    }
}
