using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    private static GameManager instance;
    private int count = 0;
    public Text text;
    public Text Distance;
    public GameObject Player;
    public BottleTest PlayerController;
    public GameplayUIHandler uiHandler;
    public ObjectPool HurdlesPool;
    public TargetTest targetIndicator;
    public Vector2 HorrizontalRange = new Vector2(11.21f, 7.83f);
    public float YPosition = 6.96f;
    public Vector2 FrontRange = new Vector2(1.116f, 7.26f);
    public Text CoveredDistance;
    public Text FinalDistance;
    public BottleTest controller;
    public float TotalDistance;
    public GameObject Tutorial;
    public static int CoinPerk;
    public Vector2 YStartPositions;

    public Vector3 DumpScenePosition;

    public TimerManager Timer;

    public GameObject Basket;

    public Vector2 BasketPositionRange = new Vector2(0.0f, 0.0f);

    public GameObject coins;

    public GameObject LerpTarget;

    public int Counter;

    public int CoinCount;
    public bool Dump;

    public static bool CanSpawnHurdle;


    public static bool CanPlay;

    void Start()
    {
        Debug.Log(PrefsManager.GetTotalCoins().ToString());
        PrefsManager.ResetGameplayCoins();
        PrefsManager.ResetCurrentGamePlayCoins();
        this.Counter = 0;
    }

    void Awake()
    {
        CanSpawnHurdle = false;
        PrefsManager.ResetCurrentStats();
        this.Tutorial.SetActive(false);
        this.Player = GameObject.FindGameObjectWithTag("Player");
        this.PlayerController = this.Player.GetComponent<BottleTest>();
        this.DumpScenePosition = this.Player.transform.position;
        this.controller = this.Player.GetComponent<BottleTest>();
        this.targetIndicator = this.Player.GetComponentInChildren<TargetTest>();
        instance = this;
        this.uiHandler = GameObject.FindObjectOfType(typeof(GameplayUIHandler)) as GameplayUIHandler;
        this.uiHandler.GameOverPanel.SetActive(false);

        if (PrefsManager.TimesPlayed() < 1)
        {
            this.Tutorial.SetActive(true);
            PrefsManager.IncreaseTimesPlayed();
        }

    }

    public void CloseTutorial()
    {
        this.Tutorial.SetActive(false);
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void SpawnNextHurdle(Vector3 V,Quaternion Q)
    {
        if ( CanSpawnHurdle)
        {
            //float X = Random.Range(this.HorrizontalRange.x, this.HorrizontalRange.y);
            float Z = Random.Range(this.FrontRange.x, this.FrontRange.y);
            Vector3 nextPos = new Vector3(0, 7.85f, V.z + Z);
            GameObject G = (GameObject)this.HurdlesPool.InstantiateObject(nextPos, Q);
        }
    }

    public void RestoreToLastPosition()
    {
        this.Player.transform.rotation = Quaternion.Euler(0, 180, 0);
        this.Player.transform.position = this.DumpScenePosition;
    }

    void Update()
    {
        this.TotalDistance = this.controller.CoveredDistance;
      //  this.Distance.text = this.targetIndicator.Distance.ToString("###0.00")+"m";
        this.CoveredDistance.text = ((int)this.TotalDistance).ToString() + "m";
   //     this.FinalDistance.text = this.TotalDistance.ToString("###0.00") + "m";
    }

    public void AddCoins()
    {
        int x = Random.Range(1, 6);
        this.CoinCount = x;
        PrefsManager.AddToTotalCoins(x);
        PrefsManager.AddToCurrentCoins(x);
        CoinPerk = x;
        this.count+=x;
        this.text.text = this.count.ToString();

        InvokeRepeating("spawnCoin", 0.1f, 0.1f);

        //for (int i = 0; i < x; i++)
        //{
        //    Invoke("spawnCoin",0.01f);
        //}
    }

    void spawnCoin()
    {
        this.Counter++;
        GameObject h = this.Player.GetComponent<BottleTest>().PlatForm.transform.root.gameObject;
        GameObject obj = GameObject.Instantiate(coins, h.transform.position, coins.transform.rotation)as GameObject;
        obj.GetComponent<LerpCoins>().finelPos = this.LerpTarget.transform.position;
        if (Dump)
        {
            obj.GetComponent<LerpCoins>().startPos = this.Player.transform.position;
        }
        else
        {
            obj.GetComponent<LerpCoins>().startPos = h.transform.position + new Vector3(0, 1.0f, 0.0f);
        }
        if (this.Counter >= this.CoinCount)
        {
            CancelInvoke("spawnCoin");
            this.Counter = 0;
            this.CoinCount = 0;
        }
    }

    public void AssignDistance(float Distance)
    {
        this.Distance.text = Distance.ToString() + "m";
    }

    public void RandomizeBaskePosition()
    {
        float Z = Random.Range(this.BasketPositionRange.x, this.BasketPositionRange.y);
        Vector3 v = this.Basket.transform.position;
        this.Basket.transform.GetChild(1).gameObject.GetComponent<SphereCollider>().enabled = true;
        this.Player.GetComponent<BottleTest>().PlatForm.GetComponent<SpawnPoint>().Randomize();
        this.Basket.transform.position = new Vector3(v.x, v.y, Z);
        this.Basket.transform.GetChild(0).gameObject.SetActive(true);
        this.Basket.transform.GetChild(0).localPosition = new Vector3(0, 0, 0.7f);
    }

    public void GameOver()
    {

        if (PrefsManager.GetCurrentGamePlayCoins() > PrefsManager.GetBestCoins())
        {
            PrefsManager.SetBestCoins(PrefsManager.GetCurrentGamePlayCoins());
        }

        Debug.Log("Game Over");
       // PrefsManager.AddToTotalCoins();
        int HD = PrefsManager.GetHighestDistance();
        //if (this.TotalDistance > HD)
        //{
        //    PrefsManager.SetHighestDistance((int)this.TotalDistance);
        //    ///Debug.Log("Highest Distance: " + PrefsManager.GetHighestDistance().ToString());
        //    /// Put leaderboard client ID in place of CLIent ID here

        //    Social.ReportScore((int)(PlayerPrefs.GetInt("HighestDistance")), "Client ID here", (bool success) => {
        //    });
        //}
        this.uiHandler.GameOverPanel.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1.0f;
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void GoToHome()
    {
        Application.LoadLevel(Application.loadedLevel - 1);
    }

}
