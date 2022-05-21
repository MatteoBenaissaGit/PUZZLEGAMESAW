using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChoice : MonoBehaviour
{
    public enum HueColorNames
    {
        Lime,
        Green,
        Aqua,
        Blue,
        Navy,
        Purple,
        Pink,
        Red,
        Orange,
        Yellow
    }

    private static Hashtable hueColourValues = new Hashtable{
         { HueColorNames.Lime,     new Color( 166 , 254 , 0, 1 ) },
         { HueColorNames.Green,     new Color( 0 , 254 , 111, 1 ) },
         { HueColorNames.Aqua,     new Color( 0 , 201 , 254, 1 ) },
         { HueColorNames.Blue,     new Color( 0 , 122 , 254, 1 ) },
         { HueColorNames.Navy,     new Color( 60 , 0 , 254, 1 ) },
         { HueColorNames.Purple,    new Color( 143 , 0 , 254, 1 ) },
         { HueColorNames.Pink,     new Color( 232 , 0 , 254, 1 ) },
         { HueColorNames.Red,     new Color( 254 , 9 , 0, 1 ) },
         { HueColorNames.Orange, new Color( 254 , 161 , 0, 1 ) },
         { HueColorNames.Yellow, new Color( 254 , 224 , 0, 1 ) },
     };

    public static Color HueColourValue(HueColorNames color)
    {
        return (Color)hueColourValues[color];
    }
}