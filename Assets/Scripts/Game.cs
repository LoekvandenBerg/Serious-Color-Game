using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Game : MonoBehaviour 
{
    [SerializeField]
    private int lives;
    [SerializeField]
    private TMPro.TextMeshProUGUI[] keyCountTexts;
    [SerializeField]
    private TMPro.TextMeshProUGUI livesText;

    [UnityEditor.MenuItem("Dev Tools/Data/Delete Save")]
    public static void DeleteSaves()
    {
        PlayerPrefs.DeleteAll();
    }

    public void RemoveLife()
    {
        lives--;
        if (lives < 0)
        {
            Debug.Log("game over");
            PlayerPrefs.DeleteAll();
            //reset colors
        }
    }

    public void MixColor(string colorGet)
    {

    }

    public bool HasColor(string neccesaryColor)
    {
        return true;
    }
}
