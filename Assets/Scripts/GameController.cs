using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject headPrefab;
    public GameObject panelStartGame;
    private bool startGame;

    void Start()
    {
        startGame = false;
        panelStartGame.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && startGame == false)
        {
            StartGame();
            panelStartGame.SetActive(false);
        }
    }

    void StartGame()
    {
        startGame = true;
        Instantiate(headPrefab, new Vector2(0f, 0f), Quaternion.identity);
    }
}
