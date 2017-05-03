using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BottleFlipUIValueSetter : MonoBehaviour
{
    public Text CurrentSuccessfullFlips;
    public Text BestSuccessfullFlips;
    public Text CurrentDistance;
    public Text BestDistance;
    public Text CurrentCoins;
    public Text BestCoins;
    public Text TotalCoins;
    public Text BottleFlipCounts;
    public Text DumpBottleCounts;

    public GameManager manager;

    void Start()
    {
        this.manager = GameManager.GetInstance();
    }

    void OnEnable()
    {
        if (this.CurrentSuccessfullFlips)
            this.CurrentSuccessfullFlips.text = PrefsManager.GetCurrentBottleFlipsCount().ToString();

        if(BestSuccessfullFlips)
        this.BestSuccessfullFlips.text = PrefsManager.GetBestBottleFlipCount().ToString();

        if(CurrentCoins)
        this.CurrentCoins.text = PrefsManager.GetCurrentGamePlayCoins().ToString();

        if(BestCoins)
        this.BestCoins.text = PrefsManager.GetBestCoins().ToString();

        if(CurrentDistance)
        this.CurrentDistance.text = ((int)this.manager.TotalDistance).ToString()+"m";

        if(BestDistance)
        this.BestDistance.text = PrefsManager.GetHighestDistance().ToString() + "m";

        if (TotalCoins)
            this.TotalCoins.text = PrefsManager.GetTotalCoins().ToString();

        if (this.BottleFlipCounts)
        {
            this.BottleFlipCounts.text = PrefsManager.GetBottleFlipGameCount().ToString();
        }

        if (this.DumpBottleCounts)
        {
            this.DumpBottleCounts.text = PrefsManager.GetDumpBottleGameCount().ToString();
        }
    }
}
