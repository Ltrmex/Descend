using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Coin" || col.tag == "Enemy")
            Destroy(col.gameObject);
    }
}
