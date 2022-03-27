using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEnumToColorScript : MonoBehaviour
{
    public static ColorEnumToColorScript instance;

    public void Awake()
    {
        instance = this;
    }

    public Color ColorEnumToColor(ColorEnum color)
    {
        switch (color)
        {
            case ColorEnum.White:
                return Color.white;
            case ColorEnum.Blue:
                return Color.blue;
            case ColorEnum.Yellow:
                return Color.yellow;
            case ColorEnum.Green:
                return Color.green;
            case ColorEnum.Red:
                return Color.red;
            case ColorEnum.Orange:
                return new Color(0.93f, 0.57f, 0, 1);
            case ColorEnum.Purple:
                return new Color(1, 0, 1, 1);
            default:
                return Color.white;
        }
    }
}
