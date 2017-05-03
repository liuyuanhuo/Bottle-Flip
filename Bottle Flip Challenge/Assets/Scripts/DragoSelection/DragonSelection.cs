using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class DragonSelection : MonoBehaviour {

    public GameObject playButton, buyButton, buyPopUp, InAPPMenu;
    public Text totelCoins ,weight;
    public CanvasGroup mainCanvesGroup;

    public int[] price;
    public int[] fires;
    public GameObject confirmDialogFire;
    public AudioSource clickSound;

    public static DragonSelection instance;


    void Awake()
    {

        Time.timeScale = 1;
        showDragoINFO();

        instance = GetComponent<DragonSelection>();
      //  PlayerPrefs.DeleteAll();

        AppController.chartBoostMainMenu = true;

        if (PlayerPrefs.GetInt("defaultSetup") == 0)
        {
            defaultSetup();
        }

        for (int i = 0; i < dragoObj.Length; i++)
        {
            dragoObj[i].SetActive(false);
        }
        dragoObj[AppController.dragoIndex].SetActive(true);
    }

    // Use this for initialization
    void Start () {
        if (Social.localUser.authenticated)
        {
            // best Distance
			Social.ReportScore((int)(PlayerPrefs.GetFloat("HighestDistance")), "CgkIlrKTotoDEAIQAA", (bool success) =>
            {
            });

            ////// Max Time
            ////Social.ReportScore(PlayerPrefs.GetInt("BestTotalSec"), "CgkIl8SYkoQHEAIQAA", (bool success) =>
            ////{
            ////});
        }
    }

    void OnEnable()
    {
        //if (PlayerPrefs.GetInt("isDrago" + AppController.dragoIndex + "Purchased") == 1 || PrefsManager.getUnlockAll() == 1)
        //{
        //    playButton.SetActive(true);
        //    buyButton.SetActive(false);
        //}
        //else
        //{
        //    buyButton.SetActive(true);
        //    playButton.SetActive(false);
        //}
    }

    void Update()
    {
        totelCoins.text = "" + PrefsManager.GetTotalCoins();
        //totelFires.text = "" + PrefsManager.GetTotalFires();

        if (Input.GetKey(KeyCode.Escape) && mainCanvesGroup.interactable)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void defaultSetup()
    {
        PrefsManager.SetUnLoackAllStatus(0);
        PlayerPrefs.SetInt("isDrago" + 0 + "Purchased", 1);
        PrefsManager.setAnimUnloackStatus(0, 1);
        PrefsManager.setAnimUnloackStatus(1, 1);
        PlayerPrefs.SetInt("TotalCoins", 1800);
        PlayerPrefs.SetInt("TotelFires", 10);

        PlayerPrefs.SetInt("defaultSetup", 1);
    }

    public void OnClickPLay()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene("GamePlay");
    }

    public void OnClickBack()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickStore()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        InAPPMenu.SetActive(true);
    }

    public void OnClickFires()
    {
        clickSound.Play();
        if (PrefsManager.GetTotalCoins() >= price[PrefsManager.getfireDeal()])
        {
            ConfirmPurchaseFire.FireCost = price[PrefsManager.getfireDeal()];
            ConfirmPurchaseFire.Fires = fires[PrefsManager.getfireDeal()];
            confirmDialogFire.SetActive(true);
        }
        else
        {
            InAPPMenu.SetActive(true);
        }
    }
    
    public GameObject[] dragoObj;
    public Text dragoPriceDisplayText;
    public GameObject switchParticles;
	public Transform particlePos;
    public void showNextDrago()
    {
        if (AppController.dragoIndex < dragoObj.Length )
        {
            if (!clickSound.isPlaying)
            {
                clickSound.Play();
            }
            AppController.dragoIndex++;
            if (AppController.dragoIndex > dragoObj.Length - 1) AppController.dragoIndex = 0;
            for (int i = 0; i < dragoObj.Length; i++)
            {
                dragoObj[i].SetActive(false);
            }

//            switchParticles.SetActive(true);
			GameObject pObj=Instantiate(switchParticles,particlePos.position,particlePos.rotation)as GameObject;
            Invoke("activeDragon", 0.4f);

            //dragoObj[AppController.dragoIndex].SetActive(true);
            showDragoINFO();
        }
    }
    public void showPreviousDrago()
    {
        if (AppController.dragoIndex >= 0 )
        {
            if (!clickSound.isPlaying)
            {
                clickSound.Play();
            }
            AppController.dragoIndex--;
            if (AppController.dragoIndex < 0) AppController.dragoIndex = dragoObj.Length - 1;
            for (int i = 0; i < dragoObj.Length; i++)
            {
                dragoObj[i].SetActive(false);
            }

//            switchParticles.SetActive(true);
			GameObject pObj=Instantiate(switchParticles,particlePos.position,particlePos.rotation)as GameObject;
            Invoke("activeDragon", 0.4f);

            //dragoObj[AppController.dragoIndex].SetActive(true);
            showDragoINFO();
        }
    }


    void activeDragon()
    {
        dragoObj[AppController.dragoIndex].SetActive(true);
    }

   public void showDragoINFO()
    {

        switch (AppController.dragoIndex)
        {
            case 0:
                dragoPriceDisplayText.text = "FREE";
                weight.text = "500gm";
                playButton.SetActive(true);
                buyButton.SetActive(false);
                break;
            case 1:
                dragoPriceDisplayText.text = "100";
                weight.text = "600gm";
                if (PlayerPrefs.GetInt("isDrago"+1+"Purchased") == 1||PrefsManager.getUnlockAll()==1)
                {
                    playButton.SetActive(true);
                    buyButton.SetActive(false);
                }
                else {
                    buyButton.SetActive(true);
                    playButton.SetActive(false);
                    if (PrefsManager.GetTotalCoins() < 100)
                    {
                        buyButton.GetComponent<Button>().interactable = false;
                    }
                    else
                    {
                        buyButton.GetComponent<Button>().interactable = true;
                    }
                }
                break;
            case 2:
                dragoPriceDisplayText.text = "100";
                weight.text = "700gm";
                if (PlayerPrefs.GetInt("isDrago" + 2 + "Purchased") == 1 || PrefsManager.getUnlockAll() == 1)
                {
                    playButton.SetActive(true);
                    buyButton.SetActive(false);
                }
                else {
                    buyButton.SetActive(true);
                    playButton.SetActive(false);
                    if (PrefsManager.GetTotalCoins() < 100)
                    {
                        buyButton.GetComponent<Button>().interactable = false;
                    }
                    else
                    {
                        buyButton.GetComponent<Button>().interactable = true;
                    }
                }
                break;
            case 3:
                dragoPriceDisplayText.text = "100";
                weight.text = "800gm";
                if (PlayerPrefs.GetInt("isDrago" + 3 + "Purchased") == 1 || PrefsManager.getUnlockAll() == 1)
                {
                    playButton.SetActive(true);
                    buyButton.SetActive(false);
                }
                else {
                    buyButton.SetActive(true);
                    playButton.SetActive(false);
                    if (PrefsManager.GetTotalCoins() < 100)
                    {
                        buyButton.GetComponent<Button>().interactable = false;
                    }
                    else
                    {
                        buyButton.GetComponent<Button>().interactable = true;
                    }
                }
                break;
            case 4:
                dragoPriceDisplayText.text = "100";
                weight.text = "900gm";
                if (PlayerPrefs.GetInt("isDrago" + 4 + "Purchased") == 1 || PrefsManager.getUnlockAll() == 1)
                {
                    playButton.SetActive(true);
                    buyButton.SetActive(false);
                }
                else {
                    buyButton.SetActive(true);
                    playButton.SetActive(false);
                    if (PrefsManager.GetTotalCoins() < 100)
                    {
                        buyButton.GetComponent<Button>().interactable = false;
                    }
                    else
                    {
                        buyButton.GetComponent<Button>().interactable = true;
                    }
                }
                break;
            case 5:
                dragoPriceDisplayText.text = "100";
                weight.text = "100gm";
                if (PlayerPrefs.GetInt("isDrago" + 5 + "Purchased") == 1 || PrefsManager.getUnlockAll() == 1)
                {
                    playButton.SetActive(true);
                    buyButton.SetActive(false);
                }
                else {
                    buyButton.SetActive(true);
                    playButton.SetActive(false);
                    if (PrefsManager.GetTotalCoins() < 100)
                    {
                        buyButton.GetComponent<Button>().interactable = false;
                    }
                    else
                    {
                        buyButton.GetComponent<Button>().interactable = true;
                    }
                }
                break;
            case 6:
                dragoPriceDisplayText.text = "100";
                weight.text = "100gm";
                if (PlayerPrefs.GetInt("isDrago" + 6 + "Purchased") == 1 || PrefsManager.getUnlockAll() == 1)
                {
                    playButton.SetActive(true);
                    buyButton.SetActive(false);
                }
                else {
                    buyButton.SetActive(true);
                    playButton.SetActive(false);
                    if (PrefsManager.GetTotalCoins() < 100)
                    {
                        buyButton.GetComponent<Button>().interactable = false;
                    }
                    else
                    {
                        buyButton.GetComponent<Button>().interactable = true;
                    }
                }
                break;
            case 7:
                dragoPriceDisplayText.text = "640000";
                weight.text = "100gm";
                if (PlayerPrefs.GetInt("isDrago" + 7 + "Purchased") == 1 || PrefsManager.getUnlockAll() == 1)
                {
                    playButton.SetActive(true);
                    buyButton.SetActive(false);
                }
                else {
                    buyButton.SetActive(true);
                    playButton.SetActive(false);
                }
                break;
            case 8:
                dragoPriceDisplayText.text = "1280000";
                weight.text = "100gm";
                if (PlayerPrefs.GetInt("isDrago" + 8 + "Purchased") == 1 || PrefsManager.getUnlockAll() == 1)
                {
                    playButton.SetActive(true);
                    buyButton.SetActive(false);
                }
                else {
                    buyButton.SetActive(true);
                    playButton.SetActive(false);
                }
                break;
            case 9:
                dragoPriceDisplayText.text = "2560000";
                weight.text = "100gm";
                if (PlayerPrefs.GetInt("isDrago" + 9 + "Purchased") == 1 || PrefsManager.getUnlockAll() == 1)
                {
                    playButton.SetActive(true);
                    buyButton.SetActive(false);
                }
                else {
                    buyButton.SetActive(true);
                    playButton.SetActive(false);
                }
                break;
        }

    }

    public void OnClickBuy()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        switch (AppController.dragoIndex)
        {
            case 1:

                if (PrefsManager.GetTotalCoins() >= 100)
                {
                    ConfirmPurchase.dragoCost = 100;//to set the cost in buyPopUpScript
                    buyPopUp.SetActive(true);
                    //gameObject.SetActive(false);
                }
                else {
                    //InAPPMenu.SetActive(true);
                    //gameObject.SetActive(false);
                }

                break;
            case 2:
                if (PrefsManager.GetTotalCoins() >= 100)
                {
                    ConfirmPurchase.dragoCost = 100;
                    buyPopUp.SetActive(true);
                    //gameObject.SetActive(false);
                }
                else {
                    //InAPPMenu.SetActive(true);
                    //gameObject.SetActive(false);
                }

                break;
            case 3:
                if (PrefsManager.GetTotalCoins() >= 100)
                {
                    ConfirmPurchase.dragoCost = 100;
                    buyPopUp.SetActive(true);
                    //gameObject.SetActive(false);
                }
                else {
                    //InAPPMenu.SetActive(true);
                    //gameObject.SetActive(false);
                }

                break;
            case 4:
                if (PrefsManager.GetTotalCoins() >= 100)
                {
                    ConfirmPurchase.dragoCost = 100;
                    buyPopUp.SetActive(true);
                    //gameObject.SetActive(false);
                }
                else {
                    //InAPPMenu.SetActive(true);
                    //gameObject.SetActive(false);
                }

                break;
            case 5:
                if (PrefsManager.GetTotalCoins() >= 100)
                {
                    ConfirmPurchase.dragoCost = 100;
                    //buyPopUp.SetActive(true);
                    //gameObject.SetActive(false);
                }
                else {
                    InAPPMenu.SetActive(true);
                    //gameObject.SetActive(false);
                }
                break;
            case 6:
                if (PrefsManager.GetTotalCoins() >= 100)
                {
                    ConfirmPurchase.dragoCost = 100;
                    buyPopUp.SetActive(true);
                    gameObject.SetActive(false);
                }
                else {
                    InAPPMenu.SetActive(true);
                    gameObject.SetActive(false);
                }
                break;
            case 7:
                if (PrefsManager.GetTotalCoins() >= 640000)
                {
                    ConfirmPurchase.dragoCost = 640000;
                    buyPopUp.SetActive(true);
                    gameObject.SetActive(false);
                }
                else {
                    InAPPMenu.SetActive(true);
                    gameObject.SetActive(false);
                }
                break;
            case 8:
                if (PrefsManager.GetTotalCoins() >= 1280000)
                {
                    ConfirmPurchase.dragoCost = 1280000;
                    buyPopUp.SetActive(true);
                    gameObject.SetActive(false);
                }
                else {
                    InAPPMenu.SetActive(true);
                    gameObject.SetActive(false);
                }
                break;
            case 9:
                if (PrefsManager.GetTotalCoins() >= 2560000)
                {
                    ConfirmPurchase.dragoCost = 2560000;
                    buyPopUp.SetActive(true);
                    gameObject.SetActive(false);
                }
                else {
                    InAPPMenu.SetActive(true);
                    gameObject.SetActive(false);
                }
                break;
        }
    }
}
