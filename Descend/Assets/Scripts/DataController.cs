using System;
using UnityEngine;

//  CODE ADAPTED FROM: https://unity3d.com/learn/tutorials/topics/scripting/high-score-playerprefs

public class DataController : MonoBehaviour
{
    private Data[] data = new Data[5];
    private bool isSaved = false;

    private void Start()
    {
        isSaved = false;
        Load();
    }   //  Start()

    public void Submit(string newName, string newDifficulty, int newScore)
    {
        for (int i = 0; i < 5; i++)
        {
            if (newScore > data[i].score)
            {
                data[i].score = newScore;
                data[i].name = newName;
                data[i].difficulty = newDifficulty;

                Array.Sort(data, delegate (Data x, Data y) { return x.score.CompareTo(y.score); });

                if (!isSaved)
                    Save();
                else
                    return;
            }   //  if
        }   //  for
    }   //  Submit()

    public Data[] Get()
    {
        return data;
    }   //  Get()

    private void Load()
    {
        for (int i = 0; i < 5; i++)
            data[i] = new Data();

        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("Score" + (i + 1)))
            {
                data[i].score = PlayerPrefs.GetInt("Score" + (i + 1));
                data[i].name = PlayerPrefs.GetString("Name" + (i + 1));
                data[i].difficulty = PlayerPrefs.GetString("Difficulty" + (i + 1));
            }   //  if
        }   //  for
    }   //  Load()

    private void Save()
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt("Score" + (i + 1), data[i].score);
            PlayerPrefs.SetString("Name" + (i + 1), data[i].name);
            PlayerPrefs.SetString("Difficulty" + (i + 1), data[i].difficulty);
            isSaved = true;
        }   //  for
    }   //  Save()
}   //  DataController
