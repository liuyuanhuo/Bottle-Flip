using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConfirmPurchase : MonoBehaviour
{
    public static int dragoCost;
    public static int bottleCost;
    public static ItemSelection bottleIndex;
    public Text costText;

    public AudioSource buttonClick;
    public GameObject dragoSelection;
    public CanvasGroup mainCanves;

    public AudioSource unlockItem;

    public DragonSelection bottleSelection;
    public GameObject store;
    void OnEnable()
    {
        costText.text = bottleCost + " Coins?";
        mainCanves.interactable = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    public void onClickYes()
    {
        //PrefsManager.unLoackDragon(AppController.dragoIndex);

        PrefsManager.SubtractFromTotalCoins(bottleCost);

        PlayerPrefs.SetInt("isBottle" + bottleIndex.BottleNo + "Purchased", 1);
        PlayerPrefs.SetInt("BottleSelected", bottleIndex.BottleNo);
        PlayerPrefs.Save();

        if (!buttonClick.isPlaying)
        {
            buttonClick.Play();

        }
        if (!unlockItem.isPlaying)
        {
            unlockItem.Play();

        }

        //bottleIndex.showBottleINFO(bottleIndex.BottleNo);

        //SendMessage("showBottleINFO");
        store.BroadcastMessage("showBottleINFO");
        //dragoSelection.SetActive(true);
        mainCanves.interactable = true;
        gameObject.SetActive(false);
    }

    public void onClickNo()
    {
        if (!buttonClick.isPlaying)
        {
            buttonClick.Play();
        }
        //dragoSelection.SetActive(true);
        mainCanves.interactable = true;
        gameObject.SetActive(false);
    }
}
