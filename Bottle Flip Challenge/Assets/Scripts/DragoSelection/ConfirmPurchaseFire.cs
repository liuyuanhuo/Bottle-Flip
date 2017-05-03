using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConfirmPurchaseFire : MonoBehaviour
{
    public static int FireCost;
    public static int Fires;
    public Text costText;
    public Text fireText;
    public int limit;

    public AudioSource buttonClick;
    public GameObject dragoSelection;
    public CanvasGroup mainCanves;

    public AudioSource unlockItem;

    void OnEnable()
    {
        costText.text = FireCost + " Coins?";
        fireText.text = Fires + " fires";
        mainCanves.interactable = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    public void onClickYes()
    {
        PrefsManager.SubtractFromTotalCoins(FireCost);
        PrefsManager.setTotelFires(Fires);
        if (PrefsManager.getfireDeal() < limit)
        {
            PrefsManager.setFireDealIndex(PrefsManager.getfireDeal() + 1);
        }
        if (!buttonClick.isPlaying)
        {
            buttonClick.Play();
        }

        if (!unlockItem.isPlaying)
        {
            unlockItem.Play();
        }

        dragoSelection.SetActive(true);
        mainCanves.interactable = true;
        gameObject.SetActive(false);
    }

    public void onClickWatchVideo()
    {
        //PrefsManager.SubtractFromTotalCoins(FireCost);
        //PrefsManager.setTotelFires(10);
        //if (PrefsManager.getfireDeal() < limit)
        //{
        //    PrefsManager.setFireDealIndex(PrefsManager.getfireDeal() + 1);
        //}



        if (!buttonClick.isPlaying)
        {
            buttonClick.Play();
        }

        //if (!unlockItem.isPlaying)
        //{
        //    unlockItem.Play();
        //}

        dragoSelection.SetActive(true);
        mainCanves.interactable = true;
        gameObject.SetActive(false);
    }

    public void onClickNo()
    {
        if (!buttonClick.isPlaying)
        {
            buttonClick.Play();
        }
        dragoSelection.SetActive(true);
        mainCanves.interactable = true;
        gameObject.SetActive(false);
    }
}
