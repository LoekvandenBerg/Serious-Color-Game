using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public ColorEnum colorToPass; 
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = ColorEnumToColorScript.instance.ColorEnumToColor(colorToPass);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player.colorEnum == colorToPass)
                gameObject.SetActive(false);
        }
    }
}
