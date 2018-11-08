using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level Pick");
    }   //  StartGame()

    public void Quit()
    {
        Application.Quit();
    }   //  Quit()

} //  Menu