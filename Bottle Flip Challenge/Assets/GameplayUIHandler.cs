using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameplayUIHandler : MonoBehaviour {

    public GameManager Manager;
    public GameObject PausePanel;
    public GameObject GameOverPanel;

    public string packageName;
    public AudioSource clickSound;

    public bool isBottleFlip = false;

    public Text TotalCoinsText;

    public GameObject MainMenu;
    public GameObject GameplayUI;

    public GameManager gameManager;
    // Use this for initialization
    void Awake () 
    {
        this.gameManager = GameManager.GetInstance();
        this.TotalCoinsText.text = PrefsManager.GetTotalCoins().ToString();
        this.Manager = GameManager.GetInstance();
	}

    public void StartGame()
    {
        this.MainMenu.SetActive(false);
        this.StartG();
        //Invoke("StartG", 0.01f);
    }

    void StartG()
    {
        this.GameplayUI.SetActive(true);
        GameManager.CanSpawnHurdle = true;
        this.gameManager.PlayerController.enabled = true;
    }

	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            this.HomeButton();
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    this.StartGame();
        //}
	}

    public void OnShareButton()
    {
        Application.OpenURL("https://www.facebook.com/");
    }

    public void OnLikeButton()
    {
        Application.OpenURL("https://www.facebook.com/hadid.ali");
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("1-MainMenu");
    }

    public void RestartButtonLevel()
    {
        this.Manager.RestartGame();
    }

    public void PauseButton()
    {
        this.Manager.PauseGame();
    }

    public void UnPauseButton()
    {
        this.Manager.UnPauseGame();
    }

    public void OnClickBottleFlip()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene("4-BottleFlip");
    }

    public void OnClickDumpTheBall()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene("5-DumpTheBall");
    }

    public void OnClickBack()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene("1-MainMenu");
    }


    public void OnStore()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        if (isBottleFlip)
        {
            Store.backScene = "4-BottleFlip";
        }
        else
        {
            Store.backScene = "5-DumpTheBall";
        }
        SceneManager.LoadScene("2-Store");

        //if (Chartboost.hasInterstitial(CBLocation.Static))
        //{
        //    Chartboost.showInterstitial(CBLocation.Static);
        //}
        //else
        //{
        //    Debug.Log("cb Pangay no MainMenu");
        //    GameObject.Find("AdMob").GetComponent<GoogleMobileAdsDemoScript>().ShowInterstitial();
        //    Chartboost.cacheInterstitial(CBLocation.Static);
        //}
        //Store.SetActive(true);
    }

    public void OnClickStats()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene("3-Stats");

        //if (Chartboost.hasInterstitial(CBLocation.Static))
        //{
        //    Chartboost.showInterstitial(CBLocation.Static);
        //}
        //else
        //{
        //    Debug.Log("cb Pangay no MainMenu");
        //    GameObject.Find("AdMob").GetComponent<GoogleMobileAdsDemoScript>().ShowInterstitial();
        //    Chartboost.cacheInterstitial(CBLocation.Static);
        //}
        //Store.SetActive(true);
    }

    public void PlayClickSound()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
    }

    public void OnRateUs()
    {
        Application.OpenURL("play.google.com");
    }
}
