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
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = ColorEnumToColorScript.instance.ColorEnumToColor(colorToGive);
    }

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
        if (playerColor == ColorEnum.Blue && colorToGive == ColorEnum.Yellow || playerColor == ColorEnum.Yellow && colorToGive == ColorEnum.Blue)
            return ColorEnum.Green;
        else if (playerColor == ColorEnum.Blue && colorToGive == ColorEnum.Red || playerColor == ColorEnum.Red && colorToGive == ColorEnum.Blue)
            return ColorEnum.Purple;
        else if (playerColor == ColorEnum.Red && colorToGive == ColorEnum.Yellow || playerColor == ColorEnum.Yellow && colorToGive == ColorEnum.Red)
            return ColorEnum.Orange;
        else
            return colorToGive;
    }
}
