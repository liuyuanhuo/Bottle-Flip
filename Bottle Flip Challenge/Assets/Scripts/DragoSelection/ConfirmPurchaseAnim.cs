using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConfirmPurchaseAnim : MonoBehaviour {
    public static int animCost;
    public Text costText;
    public AnimationUnloack animUnlocker;

    public AudioSource buttonClick;
    public GameObject dragoSelection;

    public CanvasGroup mainGroup;

    public AudioSource unlockItem;

    void OnEnable()
    {
        costText.text = animCost + " Coins?";
        mainGroup.interactable = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    public void onClickYes()
    {
        PrefsManager.setAnimUnloackStatus(AnimationUnloack.selectedAnim, 1);
        PrefsManager.SubtractFromTotalCoins(animCost);
        animUnlocker.updateValues();
        if (!buttonClick.isPlaying)
        {
            buttonClick.Play();
        }

        if (!unlockItem.isPlaying)
        {
            unlockItem.Play();
        }
        dragoSelection.SetActive(true);
        mainGroup.interactable = true;
        gameObject.SetActive(false);
    }

    public void onClickNo()
    {
        if (!buttonClick.isPlaying)
        {
            buttonClick.Play();
        }
        dragoSelection.SetActive(true);
        mainGroup.interactable = true;
        gameObject.SetActive(false);
    }
}
