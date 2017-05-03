using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class ItemSelection : MonoBehaviour
{
    public int BottleNo;
    public Button thisButton;
    public GameObject buyPopUp;

    public int price;
    public Text priceText;
    public GameObject unLock, locked;
    public AudioSource clickSound;

    public Color unSelectedClr;
    public Color selectedClr;
    void Awake()
    {
        showBottleINFO();

        if (BottleNo==0)
        {
            PlayerPrefs.SetInt("isBottle" + BottleNo + "Purchased",1);
            PlayerPrefs.Save();
        }
    }

    void Start()
    {
        thisButton.onClick.AddListener(() =>
        {
            OnClickBuy(BottleNo);
        });
    }

    public void showBottleINFO()
    {

        priceText.text = "100";
        if (PlayerPrefs.GetInt("isBottle" + BottleNo + "Purchased") == 1 || PrefsManager.getUnlockAll() == 1)
        {
            unLock.SetActive(true);
            locked.SetActive(false);
            if (PlayerPrefs.GetInt("BottleSelected") == BottleNo)
            {
                //this.GetComponent<Image>().color = selectedClr;
                unLock.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                //this.GetComponent<Image>().color = unSelectedClr;
                unLock.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else
        {
            unLock.SetActive(false);
            locked.SetActive(true);
            if (PrefsManager.GetTotalCoins() < 100)
            {
                priceText.color = Color.red;
                this.GetComponent<Button>().interactable = false;
            }
            else
            {
                priceText.color = Color.white;
                this.GetComponent<Button>().interactable = true;
            }
        }

    }

    public void OnClickBuy(int index)
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }

        if (PlayerPrefs.GetInt("isBottle" + index + "Purchased") == 1 || PrefsManager.getUnlockAll() == 1)
        {
            PlayerPrefs.SetInt("BottleSelected",index);
            PlayerPrefs.Save();

            transform.root.BroadcastMessage("showBottleINFO");
        }
        else
        {
            if (PrefsManager.GetTotalCoins() >= 100)
            {
                ConfirmPurchase.bottleCost = 100;
                ConfirmPurchase.bottleIndex = this.GetComponent<ItemSelection>();
                buyPopUp.SetActive(true);
            }
            else
            {
                //InAPPMenu.SetActive(true);
                //gameObject.SetActive(false);
            }
        }
    }
}
