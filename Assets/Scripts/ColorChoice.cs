using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChoice : MonoBehaviour
{
    public enum HueColorNames
    {
        Red,
        Yellow,
        Green
    }

    private static Dictionary<HueColorNames, Color> hueColourValues = new Dictionary<HueColorNames, Color>() {
         {HueColorNames.Red, Color.red },
         {HueColorNames.Yellow, Color.yellow },
         {HueColorNames.Green, Color.green }
    };

    public static Color HueColourValue(HueColorNames color)
    {
        return hueColourValues[color];
    }
}
