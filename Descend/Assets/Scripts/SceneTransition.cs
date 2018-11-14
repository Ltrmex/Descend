using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }   //  StartGame()

    public void StartGame()
    {
        SceneManager.LoadScene("Level Pick");
    }   //  StartGame()

    public void Quit()
    {
        Application.Quit();
    }   //  Quit()

    public void PickLevel(int levelNum) {
        string sceneName;

        switch (levelNum) {
            case 1:
                sceneName = "Green Zone";
                break;
            case 2:
                sceneName = "Yellow Zone";
                break;
            case 3:
                sceneName = "Blue Zone";
                break;
            case 4:
                sceneName = "Red Zone";
                break;
            default:
                sceneName = "Green Zone";
                break;
        }   //  switch

        SwitchLevel(sceneName);
    }   //  PickLevel()

    private void SwitchLevel(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }   //  SwitchLevel()
}
