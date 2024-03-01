using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject headPrefab;
    public GameObject panelStartGame;
    public GameObject panelGameOver;
    public SpawnFood spawnFood;
    private bool startGame;

    void Start()
    {
        startGame = false;
        panelStartGame.SetActive(true);
        panelGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && startGame == false)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        panelStartGame.SetActive(false);
        startGame = true;
        spawnFood.StartSpawnFood();
        Instantiate(headPrefab, new Vector2(0f, 0f), Quaternion.identity);
        headPrefab.SetActive(true);
    }
    public void GameOver()
    {
        headPrefab.SetActive(false);
        panelGameOver.SetActive(true);
    }
    public void RestartGame()
    {

    }
}
