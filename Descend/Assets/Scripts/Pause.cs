using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Pause the game on up key
            if (Time.timeScale == 1)
            {
                //When timeScale is set to zero the game is basically paused
                Time.timeScale = 0;
            }//End of if
            else
            {
                Time.timeScale = 1;
            }
        }//End of if

    }//End of update 
}