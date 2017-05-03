using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimationUnloack : MonoBehaviour {
    public int[] priceAnim;
    public Text[] priceText;
    public GameObject confirmDilog;
    public GameObject[] priceObj;
    public GameObject store;
    public GameObject[] dragons;
    public string[] triggers;

    public static int selectedAnim=0;

    public AudioSource[] animSound;

    void OnEnable()
    {
        for (int i = 0; i < priceAnim.Length; i++)
        {
            priceText[i].text = priceAnim[i].ToString();
            if (PrefsManager.getAnimUnloackStatus(i) == 0 && PrefsManager.getUnlockAll() == 0)
            {
                priceObj[i].SetActive(true);
            }
            else
            {
                priceObj[i].SetActive(false);
            }
        }
    }
    void Start()
    {
        priceObj[0].SetActive(false);
        priceObj[1].SetActive(false);
    }
    public void onCLickAnimBtn(int index)
    {
        if(PrefsManager.getAnimUnloackStatus(index) ==1||PrefsManager.getUnlockAll()==1)
        {
            dragons[AppController.dragoIndex].GetComponent<PlayAnimation>().playAnim(triggers[index]);
            if (!animSound[index].isPlaying)
            {
                animSound[index].Play();
            }
            else
            {
                for (int i = 0; i < animSound.Length; i++)
                {
                    animSound[index].Stop();
                    animSound[index].Play();
                }
            }
        }
        else
        {
            unlockAnim(index, priceAnim[index]);
        }
    }

    void unlockAnim(int index,int price)
    {
        if (PrefsManager.GetTotalCoins()>=price)
        {
            selectedAnim = index;
            ConfirmPurchaseAnim.animCost = price;
            confirmDilog.SetActive(true);
            //PrefsManager.SubtractFromTotalCoins(price);
            //PrefsManager.setAnimUnloackStatus(index, 1);
            //updateValues();
        }
        else
        {
            store.SetActive(true);
        }
    }

    public void updateValues()
    {
        for (int i = 0; i < priceAnim.Length; i++)
        {
            priceText[i].text = priceAnim[i].ToString();
            if (PrefsManager.getAnimUnloackStatus(i) == 0 && PrefsManager.getUnlockAll() == 0)
            {
                priceObj[i].SetActive(true);
            }
            else
            {
                priceObj[i].SetActive(false);
            }
        }
    }
}
