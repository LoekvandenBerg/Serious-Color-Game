using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public ColorEnum colorToPass; 
    private SpriteRenderer sr;
    public Sprite openSprite;
    public BoxCollider2D collider1, collider2;

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
            {
                sr.sprite = openSprite;
                collider1.enabled = false;
                collider2.enabled = false;
            }
        }
    }
}
