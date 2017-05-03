using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainManu : MonoBehaviour {

    public GameObject StoreObj;
    public string packageName;
    public GameObject quitDialog;
    public CanvasGroup mainCanves;
    public AudioSource clickSound;
	// Use this for initialization
	void Start () {

        //PlayerPrefs.DeleteAll();

        if (PlayerPrefs.GetInt("defaultSetup") == 0)
        {
            defaultSetup();
        }
    }


    void defaultSetup()
    {
        PrefsManager.SetUnLoackAllStatus(0);
        PlayerPrefs.SetInt("isBottle" + 0 + "Purchased", 1);
        PrefsManager.setAnimUnloackStatus(0, 1);
        PrefsManager.setAnimUnloackStatus(1, 1);
        PlayerPrefs.SetInt("TotalCoins", 300);
        //PlayerPrefs.SetInt("TotelFires", 10);

        PlayerPrefs.SetInt("defaultSetup", 1);
    }
    

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mainCanves.interactable)
            {
                quitDialog.SetActive(true);
                mainCanves.interactable = false;
            }
            else
            {
                quitDialog.SetActive(false);
                mainCanves.interactable = true;
            }
        }

    }

    public void OnCLickBottleFlip()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene("4-BottleFlip");

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

    }

    public void OnCLickDumpTheBall()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene("5-DumpTheBall");

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

    }

    public void OnStore()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        Store.backScene = "1-MainMenu";
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

    public void OnRateUs()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        Application.OpenURL("market://details?id="+ packageName);
    }

    public void OnMoreGames()
    {

    }

    public void OnClickLeaderBoard()
    {
        //		if (!Social.localUser.authenticated) 
        //		{
        //			Social.localUser.Authenticate ((bool success) => {
        //				Debug.Log ("Authenticated " + success);
        //				//Social.ShowLeaderboardUI();
        //				if (success)
        //					Social.ShowLeaderboardUI ();
        //			});
        //		}
        //        else
        //        {
        //            Social.ShowLeaderboardUI();
        //        }      

		if (!clickSound.isPlaying)
		{
			clickSound.Play();
		}
    }
}
