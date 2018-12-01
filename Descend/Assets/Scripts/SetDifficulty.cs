using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDifficulty : MonoBehaviour {
    public static string difficulty;

    // Use this for initialization
    void Start () {
        difficulty = "Easy";
	}

    public void Difficulty(string diff) {
        difficulty = diff;
    }
}
