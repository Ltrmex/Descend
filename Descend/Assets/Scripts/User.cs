using UnityEngine.UI;

[System.Serializable]
public class User
{
    public Text nameDisplay;
    public Text difficultyDisplay;
    public Text scoreDisplay;

    private string name;
    private string difficulty;
    private int score;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }   //  Name

    public string Difficulty
    {
        get { return difficulty; }
        set { difficulty = value; }
    }   //  Difficulty

    public int Score
    {
        get { return score; }
        set { score = value; }
    }   //  Wave

    public void SetValues()
    {
        nameDisplay.text = Name;
        difficultyDisplay.text = Difficulty;
        scoreDisplay.text = Score.ToString();
    }   //  SetValues()
}   //  User
