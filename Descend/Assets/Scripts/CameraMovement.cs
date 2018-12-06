using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    private float speed = .3f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("MoveCamera", 1, 0.5f);
    }

    void MoveCamera() {
        if (SetDifficulty.difficulty == "Medium")
            speed = 0.5f;
        else if (SetDifficulty.difficulty == "Hard")
            speed = 0.7f;
        else speed = .3f;


        transform.position = new Vector3(0, transform.position.y - speed, -9);
    }
}
