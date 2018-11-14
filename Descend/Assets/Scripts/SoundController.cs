using UnityEngine;

//  CODE ADAPTED FROM: https://www.youtube.com/watch?v=82Mn8v55nr0

public class SoundController : MonoBehaviour
{
    private static SoundController instance = null;
    private int count;
    public AudioSource backgroundMusicSource;

    public static SoundController Instance
    {
        get { return instance; }
    }

    void Start()
    {
        count = 0;
        backgroundMusicSource.volume = 0.5f;
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }   //  Awake()

    public void Mute()
    {
        if (count == 0)
        {
            count = 1;
            backgroundMusicSource.volume = 0;
        }
        else
        {
            count = 0;
            backgroundMusicSource.volume = 0.5f;
        }
    }
} //  SoundController