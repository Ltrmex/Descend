using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool collision = false;
    public GameObject gameOver;

    // Update is called once per frame
    void Update() {
        //check for player's collision with game object tagged Dock

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