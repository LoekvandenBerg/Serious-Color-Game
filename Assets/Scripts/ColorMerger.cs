using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ColorEnum
{
    White,
    Blue,
    Yellow,
    Green,
    Red,
    Orange,
    Purple
}

public class ColorMerger : MonoBehaviour
{
    public ColorEnum colorToGive;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Player player = collision.GetComponent<Player>();

            player.colorEnum = ColorMerge(player.colorEnum);
            player.color = ColorEnumToColorScript.instance.ColorEnumToColor(player.colorEnum);
        }
    }

    ColorEnum ColorMerge(ColorEnum playerColor)
    {
        if (playerColor == ColorEnum.Blue && colorToGive == ColorEnum.Yellow)
            return ColorEnum.Green;
        else if (playerColor == ColorEnum.Blue && colorToGive == ColorEnum.Red)
            return ColorEnum.Purple;
        else if (playerColor == ColorEnum.Red && colorToGive == ColorEnum.Yellow)
            return ColorEnum.Orange;
        else
            return colorToGive;
    }
}
