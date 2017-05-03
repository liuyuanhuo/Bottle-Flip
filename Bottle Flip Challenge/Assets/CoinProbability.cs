using UnityEngine;
using System.Collections;

public class CoinProbability : MonoBehaviour {

    public GameObject coin;

    void Start()
    {
   //     CheckAndDecide();
    }

    void OnEnable()
    {
        CheckAndDecide();
    }

    public void CheckAndDecide()
    {
        coin.SetActive(true);
      ///  coin.transform.localPosition = new Vector3(0.0f, 1.831425f, 0.0f);
    }
}
