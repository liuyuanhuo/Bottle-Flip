using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

    public GameManager manager;
    public static bool GameOver;
    public BottleTest bottle;
    public Text text;

    public int StartingMinutes;
    public int StartingSeconds;

    public int Minutes;
    public int Seconds;

    void Start()
    {
        this.manager = GameManager.GetInstance();
        this.Minutes = this.StartingMinutes;
        this.Seconds = this.StartingSeconds;
        InvokeRepeating("ReduceTime", 1.0f, 1.0f);
    }

    void ReduceTime()
    {
        if (this.Seconds > 0)
        {
            this.Seconds--;
        }
        else if (this.Minutes > 0)
        {
            this.Minutes--;
            this.Seconds = 59;
        }
        else if (this.Seconds <= 0 && this.Minutes <= 0)
        {
            Debug.Log("GameOver");
            CancelInvoke();
            this.manager.GameOver();
            this.bottle.GameOver();
            GameOver = true;
        }
        this.text.text = this.Minutes + ":" + this.Seconds;
    }

    void InitTime()
    {
        this.Minutes = this.StartingMinutes;
        this.Seconds = this.StartingSeconds;
    }
}
