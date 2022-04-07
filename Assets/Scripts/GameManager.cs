using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    Player player;

    public GameObject gameOverMenu;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        Events.OnGameOver += GameOver;
    }

    void GameOver()
    {
        Events.OnGameOver -= GameOver;
        gameOverMenu.SetActive(true);

    }

    public void OnRetry()
    {
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
