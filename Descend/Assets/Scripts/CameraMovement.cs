using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    private float speed = .5f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("MoveCamera", 1, 0.5f);
    }

    void MoveCamera() {
        transform.position = new Vector3(0, transform.position.y - speed, -9);
    }
}
