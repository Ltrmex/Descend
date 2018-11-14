using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour {

    private bool collision = false;
    public GameObject gameOver;

    private void Start()
    {
        collision = false;
        Time.timeScale = 1;
        gameOver.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Dead Zone")
        {
            collision = true;
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

}