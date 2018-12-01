using UnityEngine;

public class Scores : MonoBehaviour
{
    public User[] user;
    private int i = 0;
    private DataController dataController;
    private Data[] data;

    // Use this for initialization
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        data = dataController.Get();

        while (i < user.Length)
        {
            user[i].Name = data[i].name;
            user[i].Difficulty = data[i].difficulty;
            user[i].Score = data[i].score;
            user[i].SetValues();

            ++i;
        }   //  for

    }   //  Start()

}   //  Highscores
