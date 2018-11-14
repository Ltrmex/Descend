using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour {
    public AudioClip clickSound;
    public AudioSource clickSource;

    private static SoundEffects instance = null;

    // Use this for initialization
    void Start () {
        clickSource = GetComponent<AudioSource>();
    }

    public void ButtonClick() {
        clickSource.PlayOneShot(clickSound);
    }

}
